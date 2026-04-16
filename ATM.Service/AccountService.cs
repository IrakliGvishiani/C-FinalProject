using ATM.Repository;
using ATM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Service
{
    public class AccountService
    {
        private readonly UserRepository _repo;


        public AccountService(UserRepository userRepo)
        {
            _repo = userRepo;
        }

        public async Task Deposit(User user, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            user.Balance += amount;
            var users = await _repo.GetAllUsersAsync();
            var dbUser = users.First(u => u.Username == user.Username);
            dbUser.Balance = user.Balance;

            await _repo.SaveUsersAsync(users);

            Console.WriteLine($"Deposited {amount:C}. New balance: {user.Balance:C}");
        }

        public async Task Withdraw(User user, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }
            if (user.Balance < amount)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            user.Balance -= amount;
            var users = await _repo.GetAllUsersAsync();
            var dbUser = users.First(u => u.Username == user.Username);
            dbUser.Balance = user.Balance;
            await _repo.SaveUsersAsync(users);
            Console.WriteLine($"Withdrew {amount:C}. New balance: {user.Balance:C}");
        }

        public  decimal CheckBalance(User user)
        {
            var users =  _repo.GetAllUsersAsync().Result;
            var dbUser = users.First(u => u.Username == user.Username);
            Console.WriteLine($"Your current balance is: {dbUser.Balance:C}");

            return dbUser.Balance;
        }
    }
}
