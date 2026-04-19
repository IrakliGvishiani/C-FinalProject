using SM.Repository.Interfaces;
using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SM.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath;

        public UserRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<User> GetAllUsers()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<User>();
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<User>>(json)
                       ?? new List<User>();
            }
            catch (FileNotFoundException)
            {
                return new List<User>();
            }
            catch (JsonException)
            {
                return new List<User>();
            }
        }


        public User GetUserByUsername(string username)
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Task AddUserAsync(User user)
        {
            var users = GetAllUsers();
            users.Add(user);
            return SaveUsersAsync(users);
        }

        private async Task SaveUsersAsync(List<User> users)
        {
            try
            {
                var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
               await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving users: {ex.Message}");
            }
        }
    }
}
