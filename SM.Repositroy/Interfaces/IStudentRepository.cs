using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Repository.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

         Student GetStudentByRollNumber(int rollNumber);

         Task AddStudent(Student student);

        Task UpdateGrade(int rollNumber, char newGrade);

    }
}
