using SM.Repository;
using SM.Repository.Interfaces;
using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Service
{
    public class SubmissionService
    {

        private readonly ISubmissionRepository _submissionRepo;
        private readonly IAssignmentRepository _assignmentRepo;


        public SubmissionService(ISubmissionRepository submissionRepo, IAssignmentRepository assignmentRepo)
        {
            _submissionRepo = submissionRepo;
            _assignmentRepo = assignmentRepo;
        }

        public async Task Submit(int assignmentId, string studentUsername, string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("Answer cannot be empty.");
                return;
            }

            if (string.IsNullOrWhiteSpace(studentUsername))
            {
                Console.WriteLine("Invalid student.");
                return;
            }

            var assignment =  _assignmentRepo.GetAssignmentById(assignmentId);

            if (assignment == null)
            {
                Console.WriteLine("Assignment not found.");
                return;
            }

            var submissions = _submissionRepo.GetAllSubmissions();

            bool alreadySubmitted = submissions.Any(s =>
                s.AssignmentId == assignmentId &&
                s.StudentUsername == studentUsername);

            if (alreadySubmitted)
            {
                Console.WriteLine("You have already submitted this assignment.");
                return;
            }

            var submission = new Submission
            {
                AssignmentId = assignmentId,
                StudentUsername = studentUsername,
                Answer = answer,
                Grade = null
            };

            await _submissionRepo.AddSubmissionAsync(submission);
        }


        public async Task Grade(int assignmentId, string studentUsername, char grade)
        {
            if (!"ABCDF".Contains(grade))
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            var submissions = _submissionRepo.GetAllSubmissions();

            var submission = submissions.FirstOrDefault(s =>
                s.AssignmentId == assignmentId &&
                s.StudentUsername == studentUsername);

            if (submission == null)
            {
                Console.WriteLine("Submission not found.");
                return;
            }

            submission.Grade = grade;

            await _submissionRepo.SaveSubmissionsAsync(submissions);
        }


    }
}
