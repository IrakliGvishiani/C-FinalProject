using SM.Repository;
using SM.Repository.Models;
using SM.Service;
using System.Threading.Tasks;

namespace SM.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var userRepo = new UserRepository(@"C:\\Users\\user\\source\\repos\\C#FinalProject\\SM.Data\\User.json");
            var studentRepo = new StudentRepository(@"C:\Users\user\source\repos\C#FinalProject\SM.Data\Student.json");
            var assignmentRepo = new AssignmentRepository(@"C:\Users\user\source\repos\C#FinalProject\SM.Data\Assignments.json");
            var submissionRepo = new SubmissionRepository(@"C:\Users\user\source\repos\C#FinalProject\SM.Data\Submissions.json");

            var authService = new AuthService(userRepo);           

            var assignmentService = new AssignmentService(assignmentRepo);
            var submissionService = new SubmissionService(submissionRepo, assignmentRepo);

            User currentUser = null;


            while (currentUser == null)
            {
                Console.WriteLine("\n1. Login");
                Console.WriteLine("2. Register");
                var choice = Console.ReadLine();

                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                }
                else
                {
                    Console.Write("Username: ");
                    var username = Console.ReadLine();

                    Console.Write("Password: ");

                    var password = Console.ReadLine();

                    if (choice == "1")
                    {
                        currentUser = await authService.Login(username, password);
                    }
                    else if (choice == "2")
                    {
                        //Console.Write("Role (Student/Lecturer): ");
                        var role = "student";

                        currentUser = await authService.Register(username, password, role);

                        if (role == "student")
                        {
                            //Console.Write("Name: ");
                            var name = ReadString("Name: ");

                            //Console.Write("Roll Number: ");
                            int roll = ReadInt("Roll Number");

                            await studentRepo.AddStudent(new Student
                            {
                                UserName = username,
                                Name = name,
                                RollNumber = roll,
                                Grade = 'F'
                            });
                        }
                    }
                }
             
            }

 
            while (true)
            {
                Console.WriteLine($"\nLogged in as: {currentUser.Username} ({currentUser.Role})");

                if (currentUser.Role == "Lecturer")
                {
                    Console.WriteLine("\n1. Create Assignment");
                    Console.WriteLine("2. View Assignments");
                    Console.WriteLine("3. View Submissions");
                    Console.WriteLine("4. Grade Submission");
                    Console.WriteLine("5. Grade Student's main grade");
                    Console.WriteLine("6. Add Student");
                    Console.WriteLine("7. Add Lecturer");
                    Console.WriteLine("8. Exit");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Title: ");
                            var title = Console.ReadLine();

                            Console.Write("Description: ");
                            var desc = Console.ReadLine();

                            await assignmentService.CreateAssignment(title, desc, currentUser.Username);
                            break;

                        case "2":
                            var assignments = assignmentRepo.GetAllAssignments();
                            foreach (var a in assignments)
                                Console.WriteLine($"{a.Id}. {a.Title} (by {a.CreatedBy})");
                            break;

                        case "3":
                            var submissions = submissionRepo.GetAllSubmissions();
                            foreach (var s in submissions)
                                Console.WriteLine($"Assignment Id:{s.AssignmentId} | Student:{s.StudentUsername} | Grade:{s.Grade}\n" +
                                    $"Answer: {s.Answer}");
                            break;

                        case "4":
                            //Console.Write("Assignment Id: ");
                            int aid = ReadInt("Assignment Id: ");

                            //Console.Write("Student Username: ");
                            var stu = ReadString("Student Username: ");

                            //Console.Write("Grade (A-F): ");
                            char grade = ReadGrade("Grade (A-F): ");

                            await submissionService.Grade(aid, stu, grade);
                            break;

                            case "5":
                            var students = studentRepo.GetAllStudents();
                            Console.WriteLine("Students:");
                            foreach (var s in students)
                                Console.WriteLine($"{s.UserName} | {s.Name} | Roll: {s.RollNumber} | Grade: {s.Grade}");

                         //Console.Write("Enter Student Roll Number: ");
                            var studentRollNumber = ReadInt("Enter Student Roll Number: ");

                            //Console.Write("New Grade (A-F): ");
                            var newGrade = ReadGrade("New Grade (A-F): ");

                            await studentRepo.UpdateGrade(studentRollNumber, newGrade);
                            break;

                        case "6":
                            //Console.Write("Username: ");
                            var newUser = ReadString("Username: ");

                            //Console.Write("Password: ");
                            var pass = ReadString("Password: ");

                            await authService.Register(newUser, pass, "Student");

                            //Console.Write("Name: ");
                            var name = ReadString("Name: ");

                            //Console.Write("Roll Number: ");
                            int roll = ReadInt("Roll Number");

                            await studentRepo.AddStudent(new Student
                            {
                                UserName = newUser,
                                Name = name,
                                RollNumber = roll,
                                Grade = 'F'
                            });

                            break;

                            case "7":
                            var newLecturer = ReadString("Username: ");

                            var lecturerPass = ReadString("Password: ");

                            await authService.Register(newLecturer, lecturerPass, "Lecturer");

                            break;

                        case "8":
                            return;
                    }
                }
                else 
                {
                    Console.WriteLine("\n1. View Assignments");
                    Console.WriteLine("2. Submit Assignment");
                    Console.WriteLine("3. View My Grades");
                    Console.WriteLine("4. Exit");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            var assignments = assignmentRepo.GetAllAssignments();
                            foreach (var a in assignments)
                                Console.WriteLine($"{a.Id}. {a.Title}");
                            break;

                        case "2":
                            var allAssignments = assignmentRepo.GetAllAssignments();

                            Console.WriteLine("Available Assignments:");
                            foreach (var a in allAssignments)
                                Console.WriteLine($"{a.Id}. {a.Title} \n" +
                                    $" {a.Description}");

                            //Console.Write("Assignment Id: ");
                            int id = ReadInt("Assignment ID: ");

                            //Console.Write("Answer: ");
                            var answer = ReadString("Answer: ");

                            await submissionService.Submit(id, currentUser.Username, answer);
                            break;

                        case "3":
                            var submissions = submissionRepo.GetAllSubmissions();
                            var mySubs = submissions
                                .Where(s => s.StudentUsername == currentUser.Username);

                            foreach (var s in mySubs)
                                Console.WriteLine($"Assignment {s.AssignmentId} → Grade: {s.Grade}");

                            break;

                        case "4":
                            return;
                    }
                }
            }
        }


        #region

       public static int ReadInt(string message)
        {
            int value;
            Console.WriteLine(message);

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid number. Try again:");
            }

            return value;
        }



       public static char ReadGrade(string message)
        {
            Console.WriteLine(message);

            while (true)
            {
                var input = Console.ReadLine()?.Trim().ToUpper();

                if (!string.IsNullOrEmpty(input) && "ABCDF".Contains(input[0]))
                    return input[0];

                Console.WriteLine("Invalid grade. Use A, B, C, D, F:");
            }
        }


      public static string ReadString(string message)
        {
            Console.WriteLine(message);

            while (true)
            {
                var input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty.");
            }
        }


        #endregion


    }

}
