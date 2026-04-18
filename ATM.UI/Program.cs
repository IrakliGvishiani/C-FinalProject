using ATM.Repository;
using ATM.Repository.Models;
using ATM.Service;
using System.Threading.Tasks;

namespace ATM.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var path = @"../../../../User.json";
            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "User.json");
            var userRepo = new UserRepository(path);
            var authService = new AuthService(userRepo);
            var accountService = new AccountService(userRepo);
            Console.WriteLine("Welcome to the ATM!");
            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("Enter username: ");
                    var username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var password = Console.ReadLine();
                    var user = await authService.Register(username, password);
                    if (user != null)
                    {
                        Console.WriteLine($"User {username} registered successfully!");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter username: ");
                    var username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var password = Console.ReadLine();
                    var user = await authService.Login(username, password);
                    if (user != null)
                    {
                        Console.WriteLine($"Welcome back, {username}!");
                       var loginedUser = await userRepo.GetUserByUsernameAsync(username);

                        while (true)
                        {
                            Console.WriteLine("\nPlease select an option:");
                            Console.WriteLine("1. Check Balance");
                            Console.WriteLine("2. Deposit");
                            Console.WriteLine("3. Withdraw");
                            Console.WriteLine("4. Logout");
                            var accountChoice = Console.ReadLine();
                            if (accountChoice == "1")
                            {
                                var balance = accountService.CheckBalance(loginedUser);
                            }
                            else if (accountChoice == "2")
                            {
                                decimal Amount;

                                Console.Write("Enter amount to deposit: ");
                                var amount = IsDecimal(Console.ReadLine(), out Amount);
                                await accountService.Deposit(loginedUser, amount);
                   

                            }
                            else if (accountChoice == "3")
                            {
                                decimal Amount;

                                Console.Write("Enter amount to withdraw: ");
                                var amount = IsDecimal(Console.ReadLine(), out Amount);
                                var success = accountService.Withdraw(loginedUser, amount);
                            }
                            else if (accountChoice == "4")
                            {
                                Console.WriteLine("Logging out...");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid option. Please try again.");
                            }
                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Thank you for using the ATM. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        public static decimal IsDecimal(string input, out decimal result)
        {
            if (!decimal.TryParse(input, out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return result;
        }
    }
}
