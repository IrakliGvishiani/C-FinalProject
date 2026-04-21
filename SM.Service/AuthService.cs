using SM.Repository;
using SM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Service
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;


        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }



       public async Task<User> Register(string userName, string password, string role)
        {
            var existingUser =  _userRepository.GetUserByUsername(userName);


            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty.");
                return null;    
            }

            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }
            var user = new User
            {
                Username = userName,
                Password = password, // In production, hash the password!
                Role = role
            };
            await _userRepository.AddUserAsync(user);
            return user;
        }



        public async Task<User?> Login(string userName, string password)
        {
            var user =  _userRepository.GetUserByUsername(userName);
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty.");
                return null;
            }
            if (user == null)
            {
                Console.WriteLine("User not found");
                return null;
            }

            if (user.Password != password)
            {
                Console.WriteLine("Wrong password");
                return null;
            }

            return user;
        }
    }
}
