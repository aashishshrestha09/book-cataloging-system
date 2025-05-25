using System;
using System.Collections.Generic;
using System.Linq;
using csharp.Models;

namespace csharp.Services
{
    public class CatalogService
    {
        private readonly List<Book> _books;

        public CatalogService()
        {
            _books = new List<Book>
            {
                new Book("It Ends with Us", "Colleen Hoover", "Romance", 2016, 10.0)
            };
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _books.Remove(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public IEnumerable<Book> SearchBooks(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return _books;

            term = term.ToLower();

            return _books.FindAll(book =>
                book.Title.ToLower().Contains(term) ||
                book.Author.ToLower().Contains(term) ||
                book.Genre.ToLower().Contains(term) ||
                book.PublicationYear.ToString().Contains(term) ||
                book.Price.ToString("F2").Contains(term)
            );
        }

        public Dictionary<string, List<Book>> GetBooksByGenre()
        {
            return _books
                .GroupBy(b => b.Genre)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public Dictionary<string, List<Book>> GetBooksByAuthor()
        {
            return _books
                .GroupBy(b => b.Author)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
