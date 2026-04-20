using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SM.Repository
{
    public class AssignmentRepository
    {
        private readonly string _filePath;

        public AssignmentRepository(string filePath)
        {
            _filePath = filePath;
        }


        public List<Assignment> GetAllAssignments()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<Assignment>();
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Assignment>>(json)
                       ?? new List<Assignment>();
            }
            catch (FileNotFoundException)
            {
                return new List<Assignment>();
            }
            catch (JsonException)
            {
                return new List<Assignment>();
            }
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            var assignments = GetAllAssignments();
            assignments.Add(assignment);
            await SaveAssignmentsAsync(assignments);
        }
        private async Task SaveAssignmentsAsync(List<Assignment> assignments)
        {
            try
            {
                var json = JsonSerializer.Serialize(assignments, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving assignments: {ex.Message}");
            }
        }


        public Assignment GetAssignmentById(int id)
        {
            try
            {
                var assignments = GetAllAssignments();
                return assignments.Find(a => a.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving assignment: {ex.Message}");
                return null;

            }
        }
    }
}
