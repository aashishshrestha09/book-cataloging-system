using System;
using System.Linq;
using Xunit;
using csharp.Models;
using csharp.Services;

namespace csharp.Tests
{
    public class CatalogServiceTests
    {
        [Fact]
        public void AddBook_AddsBookSuccessfully()
        {
            var service = new CatalogService();
            var book = new Book("Test Title", "Test Author", "Test Genre", 2020, 20.0);

            service.AddBook(book);

            // The service will contain the default book plus the added one
            var books = service.GetBooks();
            Assert.Contains(book, books);
            Assert.Contains(books, b => b.Title == "It Ends with Us"); // default book present
        }

        [Fact]
        public void DeleteBook_RemovesBookSuccessfully()
        {
            var service = new CatalogService();
            var book = new Book("ToDelete", "Author", "Genre", 2020, 10.0);
            service.AddBook(book);

            service.DeleteBook(book);

            var books = service.GetBooks();
            Assert.DoesNotContain(book, books);

            // Default book should still be there
            Assert.Contains(books, b => b.Title == "It Ends with Us");
        }

        [Fact]
        public void SearchBooks_FindsMatchingBooks()
        {
            var service = new CatalogService();
            var book1 = new Book("C# Guide", "Author1", "Programming", 2021, 30.0);
            var book2 = new Book("Ruby Guide", "Author2", "Programming", 2022, 25.0);
            service.AddBook(book1);
            service.AddBook(book2);

            var results = service.SearchBooks("c#");

            Assert.Single(results);
            Assert.Contains(book1, results);
        }

        [Fact]
        public void GetBooksByGenre_ReturnsGroupedBooks()
        {
            var service = new CatalogService();
            var book1 = new Book("Book1", "AuthorA", "Sci-Fi", 2020, 15.0);
            var book2 = new Book("Book2", "AuthorB", "Sci-Fi", 2021, 20.0);
            var book3 = new Book("Book3", "AuthorC", "Romance", 2022, 10.0);
            service.AddBook(book1);
            service.AddBook(book2);
            service.AddBook(book3);

            var grouped = service.GetBooksByGenre();

            Assert.True(grouped.ContainsKey("Sci-Fi"));

            // Romance genre will have default + Book3 now
            Assert.True(grouped.ContainsKey("Romance"));

            Assert.Equal(2, grouped["Sci-Fi"].Count);
            Assert.Equal(2, grouped["Romance"].Count); // default + Book3
        }

        [Fact]
        public void AddBook_ThrowsArgumentNullException_WhenBookIsNull()
        {
            var service = new CatalogService();
            Assert.Throws<ArgumentNullException>(() => service.AddBook(null!));
        }

        [Fact]
        public void DeleteBook_ThrowsArgumentNullException_WhenBookIsNull()
        {
            var service = new CatalogService();
            Assert.Throws<ArgumentNullException>(() => service.DeleteBook(null!));
        }

        [Fact]
        public void DeleteBook_DoesNothing_WhenBookDoesNotExist()
        {
            var service = new CatalogService();
            var nonExistentBook = new Book("NonExistent", "Nobody", "Fiction", 2000, 5.0);

            // Should not throw, no exception expected
            service.DeleteBook(nonExistentBook);

            // Default book still exists
            Assert.Contains(service.GetBooks(), b => b.Title == "It Ends with Us");
        }

        [Fact]
        public void SearchBooks_ReturnsAllBooks_WhenSearchTermIsEmptyOrWhitespace()
        {
            var service = new CatalogService();
            var books = service.GetBooks().ToList();

            var results1 = service.SearchBooks("");
            var results2 = service.SearchBooks(" ");
            var results3 = service.SearchBooks(string.Empty);

            Assert.Equal(books.Count, results1.Count());
            Assert.Equal(books.Count, results2.Count());
            Assert.Equal(books.Count, results3.Count());
        }

        [Fact]
        public void SearchBooks_IsCaseInsensitive()
        {
            var service = new CatalogService();
            var book = new Book("Unique Title", "Unique Author", "Unique Genre", 2023, 99.99);
            service.AddBook(book);

            var results = service.SearchBooks("unique title");
            Assert.Contains(book, results);

            results = service.SearchBooks("UNIQUE AUTHOR");
            Assert.Contains(book, results);

            results = service.SearchBooks("unique GENRE");
            Assert.Contains(book, results);
        }

        [Fact]
        public void GetBooksByAuthor_ReturnsCorrectGrouping()
        {
            var service = new CatalogService();
            var book1 = new Book("Title1", "AuthorX", "GenreA", 2019, 12.5);
            var book2 = new Book("Title2", "AuthorX", "GenreB", 2020, 15.0);
            var book3 = new Book("Title3", "AuthorY", "GenreA", 2021, 10.0);
            service.AddBook(book1);
            service.AddBook(book2);
            service.AddBook(book3);

            var grouped = service.GetBooksByAuthor();

            Assert.True(grouped.ContainsKey("AuthorX"));
            Assert.True(grouped.ContainsKey("AuthorY"));
            Assert.Equal(2, grouped["AuthorX"].Count);
            Assert.Single(grouped["AuthorY"]);
        }

        [Fact]
        public void GetBooksByGenre_HandlesGenresWithMultipleBooksIncludingDefault()
        {
            var service = new CatalogService();
            var book = new Book("Another Romance", "AuthorZ", "Romance", 2018, 9.99);
            service.AddBook(book);

            var grouped = service.GetBooksByGenre();

            Assert.True(grouped.ContainsKey("Romance"));
            Assert.Equal(2, grouped["Romance"].Count); // Default + added
        }

    }
}
