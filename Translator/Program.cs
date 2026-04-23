using System.Text;

namespace Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(@"Choose a number to select language (or 'E' to quit):
--------------------------------
English to Georgian  1
Georgian to English  2");



                var response = Console.ReadLine().ToLower();
                if (response == "e")
                {
                    isRunning = false;
                }

                else if (response == "1")
                {

                    //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EN-KA.txt");
                    var path = @"../../../EN-KA.txt";

                    Translate(path,"English","Georgian");




                }
                else if (response == "2")
                {

                    //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KA-EN.txt");
                     var path = @"../../../KA-EN.txt";

                    Translate(path,"Georgian","English");


                }
            }
        }

        static Dictionary<string, string> LoadTranslations(string filePath)
        {
            Dictionary<string, string> translations = new Dictionary<string, string>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        string englishWord = parts[0].Trim();
                        string georgianWord = parts[1].Trim();
                        translations[englishWord] = georgianWord;
                    }
                }
            }
            return translations;
        }

        public static void Translate(string path,string translateFrom, string translateTo)
        {
            try
            {
                var translation = LoadTranslations(path);

                Console.WriteLine($"Enter a {translateFrom} word to translate:");
                var input = Console.ReadLine().ToLower();
                if (translation.ContainsKey(input))
                {
                    Console.WriteLine($"The {translateTo} translation of '{input}' is: {translation[input]}");
                }
                else
                {
                    Console.WriteLine($"'{input}' word doesn't exist in dictionary! would you like it to add? (Y/N)");
                    var addResponse = Console.ReadLine().ToLower();
                    if (addResponse == "y")
                    {
                        Console.WriteLine($"Enter the {translateTo} translation:");
                        var translationInput = Console.ReadLine().ToLower();
                        File.AppendAllText(path,$"{input}={translationInput}", Encoding.UTF8);
                    }
                    else
                    {
                        Console.WriteLine("Word not added to the dictionary.");
                    }
                }
                }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading file: " + ex.Message);
            }
        }
    }
}
