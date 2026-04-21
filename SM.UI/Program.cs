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

                Console.Write("Username: ");
                var username = Console.ReadLine();

                Console.Write("Password: ");
                var password = Console.ReadLine();

                if (choice == "1")
                {
                    currentUser = await authService.Login(username, password);
                    if (currentUser == null)
                        Console.WriteLine("Invalid credentials.");
                }
                else if (choice == "2")
                {
                    Console.Write("Role (Student/Lecturer): ");
                    var role = Console.ReadLine();

                    currentUser = await authService.Register(username, password, role);

                    if (role == "Student")
                    {
                        Console.Write("Name: ");
                        var name = Console.ReadLine();

                        Console.Write("Roll Number: ");
                        int roll = int.Parse(Console.ReadLine());

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
                    Console.WriteLine("7. Exit");

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
                            Console.Write("Assignment Id: ");
                            int aid = int.Parse(Console.ReadLine());

                            Console.Write("Student Username: ");
                            var stu = Console.ReadLine();

                            Console.Write("Grade (A-F): ");
                            char grade = Console.ReadLine().ToUpper()[0];

                            await submissionService.Grade(aid, stu, grade);
                            break;

                            case "5":
                            var students = studentRepo.GetAllStudents();
                            Console.WriteLine("Students:");
                            foreach (var s in students)
                                Console.WriteLine($"{s.UserName} | {s.Name} | Roll: {s.RollNumber} | Grade: {s.Grade}");

                         Console.Write("Enter Student Roll Number: ");
                            var studentRollNumber = int.Parse(Console.ReadLine());

                            Console.Write("New Grade (A-F): ");
                            var newGrade = char.Parse(Console.ReadLine().ToUpper());

                            await studentRepo.UpdateGrade(studentRollNumber, newGrade);
                            break;

                        case "6":
                            Console.Write("Username: ");
                            var newUser = Console.ReadLine();

                            Console.Write("Password: ");
                            var pass = Console.ReadLine();

                            await authService.Register(newUser, pass, "Student");

                            Console.Write("Name: ");
                            var name = Console.ReadLine();

                            Console.Write("Roll Number: ");
                            int roll = int.Parse(Console.ReadLine());

                            await studentRepo.AddStudent(new Student
                            {
                                UserName = newUser,
                                Name = name,
                                RollNumber = roll,
                                Grade = 'F'
                            });

                            break;

                        case "7":
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

                            Console.Write("Assignment Id: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Answer: ");
                            var answer = Console.ReadLine();

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


    

    }
    
}
