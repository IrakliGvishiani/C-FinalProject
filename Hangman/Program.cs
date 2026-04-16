namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../Words.txt";

            var words = File.ReadAllLines(path).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            //List<string> words = new List<string>
            //{
            //    "apple",
            //    "banana",
            //    "computer",
            //    "programming"
            //};

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Welcome to Hangman!");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StartGame(words);
                        break;
                    case "2":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select 1 or 2.");
                        break;
                }
            }



        }


        public static void StartGame(List<string> words)
        {
            try
            {
                var random = new Random();

                var wordToGuess = words[random.Next(words.Count)];

                char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();

                int attempts = 6;

                while (attempts > 0)
                {
                    Console.WriteLine("Word: " + string.Join(" ", guessedWord));
                    Console.Write("Enter a letter: ");

                    string input = Console.ReadLine().ToLower();

                    if (input.Length != 1)
                    {
                        Console.WriteLine("Enter only one letter!");
                        continue;
                    }

                    char letter = input[0];


                    bool found = false;

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == letter)
                        {
                            guessedWord[i] = letter;
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        attempts--;
                        Console.WriteLine($"Wrong! Attempts left: {attempts}");
                    }
                    else
                    {
                        Console.WriteLine("Correct!");
                    }

                    if (!guessedWord.Contains('_'))
                    {
                        Console.WriteLine($"You won! The word was: {wordToGuess}");
                        break;
                    }

                    if (attempts == 0)
                    {
                        Console.WriteLine($"Game over! The word was: {wordToGuess}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
