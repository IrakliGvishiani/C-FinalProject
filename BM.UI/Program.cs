using BM.Repository;
using BM.Repository.Models;
using System.Threading.Tasks;

namespace BM.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var path = @"../../../../Book.json";

            var bookRepo = new BookRepository(path);
            Console.WriteLine("Welcome to the Book Manager!");
            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Search Book by Name");
                Console.WriteLine("3. Add New Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    var books = bookRepo.GetAllBooks();
                    foreach (var book in books)
                    {
                        Console.WriteLine($"ID: {book.Id},Name: {book.Name}, Author: {book.Author}, Year: {book.PublishedDate.ToString("yyyy-MM-dd")}");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter book name: ");
                    var name = Console.ReadLine();
                    var book = bookRepo.GetBookByName(name);
                    if (book != null)
                    {
                        Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Author: {book.Author}, Year: {book.PublishedDate.ToString("yyyy-MM-dd")}");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter book name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter author name: ");
                    var author = Console.ReadLine();
                    Console.Write("Enter publication year: ");
                    var yearInput = Console.ReadLine();
                    if (DateTime.TryParse(yearInput, out DateTime year))
                    {
                        var newBook = new Book
                        {
                            Name = name,
                            Author = author,
                            PublishedDate = year
                        };
                        var newBookId = await bookRepo.AddBookAsync(newBook);
                        if (newBookId > 0)
                        {
                            Console.WriteLine($"Book added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add book.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid year input.");
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Enter book ID to delete: ");
                    var idInput = Console.ReadLine();
                    if (idInput != null)
                    {
                        await bookRepo.DeleteBookAsync(int.Parse(idInput));
                        Console.WriteLine("Book deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID input.");
                    }
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }

        }
    }
}
