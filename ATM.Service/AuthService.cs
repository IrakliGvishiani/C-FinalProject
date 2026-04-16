using ATM.Repository;
using ATM.Repository.Models;
using System.Threading.Tasks;

namespace ATM.Service
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;


        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> Register(string username, string password)
        {

            var existingUser = await _userRepository.GetUserByUsernameAsync(username);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty.");
                return null;
            }


            if (existingUser != null)
            {
                Console.WriteLine("User already exists.");
            }

            var user = new User
            {
                Username = username,
                Password = password,
                Balance = 0.00m
            };
          await _userRepository.AddUserAsync(user);
            return user;
        }

        public async Task<User?> Login(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty.");
                return null;
            }


            if (user == null || user.Password != password)
            {
                Console.WriteLine("Invalid username or password.");
                return null;
            }

            return user;
        }

    }
}
