using SM.Repository;
using SM.Repository.Interfaces;
using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace SM.Service
{
    public class AssignmentService
    {


        private readonly IAssignmentRepository _assignmentRepo;

        public AssignmentService(IAssignmentRepository assignmentRepo)
        {
            _assignmentRepo = assignmentRepo;
        }

        public async Task CreateAssignment(string title, string description, string lecturer)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Title and description cannot be empty.");
                return;
            }

            var assignments = _assignmentRepo.GetAllAssignments();

            int newId = assignments.Any() ? assignments.Max(a => a.Id) + 1 : 1;

            var assignment = new Assignment
            {
                Id = newId,
                Title = title,
                Description = description,
                CreatedBy = lecturer
            };

            await _assignmentRepo.AddAssignmentAsync(assignment);
        }


 
    }

}