using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SM.Repository
{
    public class SubmissionRepository
    {

        private readonly string _filePath;

        public SubmissionRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Submission> GetAllSubmissions()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<Submission>();
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Submission>>(json)
                       ?? new List<Submission>();
            }
            catch (FileNotFoundException)
            {
                return new List<Submission>();
            }
            catch (JsonException)
            {
                return new List<Submission>();
            }
        }

        public async Task AddSubmissionAsync(Submission submission)
        {
            var submissions = GetAllSubmissions();
            submissions.Add(submission);
            await SaveSubmissionsAsync(submissions);
        }


        public async Task UpdateSubmissionsAsync (Submission updatedSubmission)
        {
            try
            {
                var submissions = GetAllSubmissions();
                var index = submissions.FindIndex(s => s.AssignmentId == updatedSubmission.AssignmentId
                                                     && s.StudentUsername.Equals(updatedSubmission.StudentUsername, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    submissions[index] = updatedSubmission;
                    await SaveSubmissionsAsync(submissions);
                }
                else
                {
                    Console.WriteLine("Submission not found for update.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating submission: {ex.Message}");
            }
        }
        public async Task SaveSubmissionsAsync (List<Submission> submissions)
        {
            try
            {
                var json = JsonSerializer.Serialize(submissions, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving submissions: {ex.Message}");
            }
        }
    }
}
