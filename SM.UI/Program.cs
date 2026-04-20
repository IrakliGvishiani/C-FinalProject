using SM.Repository;
using SM.Service;
using System.Threading.Tasks;

namespace SM.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AssignmentRepository assignmentRepository = new AssignmentRepository("C:\\Users\\user\\source\\repos\\C#FinalProject\\SM.Data\\Assignments.json");
            SubmissionRepository submissionRepository = new SubmissionRepository("C:\\Users\\user\\source\\repos\\C#FinalProject\\SM.Data\\Submissions.json");

            SubmissionService submissionService = new SubmissionService(submissionRepository, assignmentRepository);
            AssignmentService assignmentService = new AssignmentService(assignmentRepository);



            while (true)
            {
                Console.WriteLine("\n1. Create Assignment");
                Console.WriteLine("2. Submit Assignment");
                Console.WriteLine("3. Grade Submission");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Title: ");
                        var title = Console.ReadLine();

                        Console.Write("Description: ");
                        var desc = Console.ReadLine();

                        await assignmentService.CreateAssignment(title, desc, "lecturer1");
                        break;

                    case "2":
                        Console.Write("Assignment Id: ");
                        int aId = int.Parse(Console.ReadLine());

                        Console.Write("Student Username: ");
                        var username = Console.ReadLine();

                        Console.Write("Answer: ");
                        var answer = Console.ReadLine();

                        await submissionService.Submit(aId, username, answer);
                        break;

                    case "3":
                        Console.Write("Assignment Id: ");
                        int gId = int.Parse(Console.ReadLine());

                        Console.Write("Student Username: ");
                        var stu = Console.ReadLine();

                        Console.Write("Grade (A-F): ");
                        char grade = Console.ReadLine().ToUpper()[0];


                        await submissionService.Grade(gId, stu, grade);
                        break;

                    case "4":
                        return;
                }
            }

        }
    }
}
