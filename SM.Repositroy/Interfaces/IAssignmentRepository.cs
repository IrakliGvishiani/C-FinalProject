using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Repository.Interfaces
{
    public interface IAssignmentRepository
    {

        List<Assignment> GetAllAssignments();
         Assignment GetAssignmentById(int id);
         Task AddAssignmentAsync(Assignment assignment);
    }
}
