namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(@"Choose From This two (or 'E' to quit):");

                Console.WriteLine("1: Enter random number range by yourself (e.g., 1-100):");
                Console.WriteLine("2: Or choose from predefined ranges:");
                var rangeInput = Console.ReadLine().ToLower();

                if (rangeInput == "e")
                {
                    isRunning = false;
                    continue;
                }

                if (rangeInput == "1")
                {
                    int customMin = GetValidNumber("Enter the minimum number:");

                    int customMax = GetValidNumber("Enter the maximum number:");

                    if (customMin >= customMax)
                    {
                        Console.WriteLine("Invalid range! Minimum should be less than maximum.");
                        continue;
                    }
                    else
                    {
                        PlayGame(customMin, customMax);
                    }
                }
                else if (rangeInput == "2")
                {
                    Console.WriteLine("Choose a predefined range:");
                    Console.WriteLine("1: 1-10");
                    Console.WriteLine("2: 1-100");
                    Console.WriteLine("3: 1-1000");
                    var predefinedRangeInput = Console.ReadLine().ToLower();
                    switch (predefinedRangeInput)
                    {
                        case "1":
                            PlayGame(1, 10);
                            break;
                        case "2":
                            PlayGame(1, 100);
                            break;
                        case "3":
                            PlayGame(1, 1000);
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please select a valid option.");
                            break;
                    }
                }


            }
        }

        public static void PlayGame(int min, int max)
        {
            Random random = new Random();
            int numberToGuess = random.Next(min, max + 1);
            int attempts = 0;
            bool guessedCorrectly = false;
            Console.WriteLine($"I have selected a number between {min} and {max}. Can you guess it?");
            while (!guessedCorrectly)
            {
                Console.Write("Enter your guess: ");
                int userGuess;
                if (int.TryParse(Console.ReadLine(), out userGuess))
                {
                    attempts++;
                    if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        guessedCorrectly = true;
                        Console.WriteLine($"Congratulations! You've guessed the number {numberToGuess} in {attempts} attempts.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }
        }



        static int GetValidNumber(string message)
        {
            int number;
            Console.WriteLine(message);

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input! Please enter a valid number:");
            }

            return number;
        }
    }
}
