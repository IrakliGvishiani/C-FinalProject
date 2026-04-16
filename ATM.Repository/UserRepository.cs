using ATM.Repository.Models;
using System.Text.Json;

namespace ATM.Repository
{
    public class UserRepository
    {
        private readonly string _filePath;

        public UserRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<User>();

                var json = await File.ReadAllTextAsync(_filePath);

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



        public async Task SaveUsersAsync(List<User> users)
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
        public async Task AddUserAsync(User user)
        {
            try
            {
                var users = await GetAllUsersAsync();

                users.Add(user);

                await SaveUsersAsync(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
            }
        }


        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            try
            {
                var users = await GetAllUsersAsync();

                return users.FirstOrDefault(u => u.Username == username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                return null;
            }
        }
    }
}
