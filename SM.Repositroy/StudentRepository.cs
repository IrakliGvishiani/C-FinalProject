using SM.Repository.Interfaces;
using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace SM.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _filePath;

        public StudentRepository(string filePath)
        {
            _filePath = filePath;
        }


        public List<Student> GetAllStudents()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<Student>();
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Student>>(json)
                       ?? new List<Student>();
            }
            catch (FileNotFoundException)
            {
                return new List<Student>();
            }
            catch (JsonException)
            {
                return new List<Student>();
            }
        }

        public Student GetStudentByRollNumber (int rollNumber)
        {
            try
            {
                var students = GetAllStudents();
                return students.Find(s => s.RollNumber == rollNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving student: {ex.Message}");
                return null;
            }
        }

        public async Task AddStudent(Student student)
        {
            try
            {
                var students = GetAllStudents();
                students.Add(student);
                await SaveStudentsAsync(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }


        public async Task UpdateGrade(int rollNumber, char newGrade)
        {
            try
            {
                var students = GetAllStudents();
                var student = students.Find(s => s.RollNumber == rollNumber);

                if (!"ABCDF".Contains(newGrade))
                {
                    Console.WriteLine("Invalid grade.");
                    return;
                }

                if (student != null)
                {
                    student.Grade = newGrade;
                    await SaveStudentsAsync(students);
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating grade: {ex.Message}");
            }
        }
        private async Task SaveStudentsAsync(List<Student> students)
        {
            try
            {
                var json = JsonSerializer.Serialize(students, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving students: {ex.Message}");
            }
        }
    }
}
