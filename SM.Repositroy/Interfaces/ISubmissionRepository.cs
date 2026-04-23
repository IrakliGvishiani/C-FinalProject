using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Repository.Interfaces
{
    public interface ISubmissionRepository
    {

        List<Submission> GetAllSubmissions();

        Task AddSubmissionAsync(Submission submission);

        Task UpdateSubmissionsAsync(Submission updatedSubmission);

        Task SaveSubmissionsAsync(List<Submission> submissions);
    }
}
