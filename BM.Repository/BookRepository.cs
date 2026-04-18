using BM.Repository.Interfaces;
using BM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BM.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly string _filePath;


        public BookRepository(string filePath)
        {
            _filePath = filePath;
            LoadBooks();
        }



        public IEnumerable<Book> GetAllBooks() => LoadBooks();






        public Book GetBookByName(string name)
        {
            try
            {
                var books = LoadBooks();
                return books.Find(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving book: {ex.Message}");
                return null;
            }
        }

        public async Task<int> AddBookAsync(Book book)
        {
            try
            {
                var books = LoadBooks();
                book.Id = books.Count > 0 ? books[^1].Id + 1 : 1;
                books.Add(book);
                await SaveBooksAsync(books);
                return book.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
                return -1;
            }
        }


        public async Task DeleteBookAsync(int id)
        {
           try
            {
                var books = LoadBooks();
                var bookToRemove = books.Find(b => b.Id == id);
                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                    await SaveBooksAsync(books);
                }
                else
                {
                  Console.WriteLine($"Book with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
            }
        }
        #region helper methods

        private List<Book> LoadBooks()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<Book>();
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Book>>(json)
                       ?? new List<Book>();
            }
            catch (FileNotFoundException)
            {
                return new List<Book>();
            }
            catch (JsonException)
            {
                return new List<Book>();
            }
        }


        private async Task SaveBooksAsync(List<Book> books)
        {
            try
            {
                var json = JsonSerializer.Serialize(books, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving books: {ex.Message}");
            }
        }
        #endregion

    }
}
