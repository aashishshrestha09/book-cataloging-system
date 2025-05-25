using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ReactiveUI;
using csharp.Models;
using csharp.Services;
using System.Reactive;
using System.Linq;

namespace csharp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly CatalogService _catalog;

        private string _title = "";
        private string _author = "";
        private string _genre = "";
        private int _publicationYear;
        private double _price;

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string Author
        {
            get => _author;
            set => this.RaiseAndSetIfChanged(ref _author, value);
        }

        public string Genre
        {
            get => _genre;
            set => this.RaiseAndSetIfChanged(ref _genre, value);
        }

        public int PublicationYear
        {
            get => _publicationYear;
            set => this.RaiseAndSetIfChanged(ref _publicationYear, value);
        }

        public double Price
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
        }

        private string _searchTerm = string.Empty;
        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }

        private string _selectedReportType = "All books";
        public string SelectedReportType
        {
            get => _selectedReportType;
            set => this.RaiseAndSetIfChanged(ref _selectedReportType, value);
        }

        private bool _isAllBooksViewVisible = true;
        public bool IsAllBooksViewVisible
        {
            get => _isAllBooksViewVisible;
            set => this.RaiseAndSetIfChanged(ref _isAllBooksViewVisible, value);
        }

        public ObservableCollection<Book> Books { get; }
        public ObservableCollection<string> ReportTypes { get; }
        public ObservableCollection<BookGroup> BookGroups { get; } = new();

        public ReactiveCommand<Unit, Unit> AddBookCommand { get; }
        public ReactiveCommand<Book, Unit> DeleteBookCommand { get; }
        public ReactiveCommand<Unit, Unit> SearchCommand { get; }
        public ReactiveCommand<Unit, Unit> ApplyReportGroupingCommand { get; }


        public MainWindowViewModel()
        {
            _catalog = new CatalogService();
            // Initialize Books from _catalog's existing books
            Books = new ObservableCollection<Book>(_catalog.GetBooks());
            ReportTypes = new ObservableCollection<string> {"All books", "Group by Genre", "Group by Author"};
            BookGroups = new ObservableCollection<BookGroup>();

            AddBookCommand = ReactiveCommand.Create(AddBook, this.WhenAnyValue(
                x => x.Title,
                x => x.Author,
                x => x.Genre,
                x => x.PublicationYear,
                x => x.Price,
                (title, author, genre, year, price) => !string.IsNullOrWhiteSpace(title)
                                                    && !string.IsNullOrWhiteSpace(author)
                                                    && !string.IsNullOrWhiteSpace(genre)
                                                    && year > 0
                                                    && price > 0));
            DeleteBookCommand = ReactiveCommand.Create<Book>(book =>
            {
                _catalog.DeleteBook(book);
                Books.Remove(book);
            });
            SearchCommand = ReactiveCommand.Create(() =>
            {
                var results = _catalog.SearchBooks(SearchTerm);
                Books.Clear();
                foreach (var book in results)
                {
                    Books.Add(book);
                }
            });                
            ApplyReportGroupingCommand = ReactiveCommand.Create(() =>
            {
                IsAllBooksViewVisible = SelectedReportType == "All books";
                ApplyReportGrouping();
            });

        }

        private void AddBook()
        {
            var newBook = new Book
            {
                Title = this.Title,
                Author = this.Author,
                Genre = this.Genre,
                PublicationYear = this.PublicationYear,
                Price = this.Price
            };

            _catalog.AddBook(newBook);
            Books.Add(newBook);

            // Reset fields after adding
            Title = "";
            Author = "";
            Genre = "";
            PublicationYear = 0;
            Price = 0.0;
        }

        private void ApplyReportGrouping()
        {
            BookGroups.Clear();
            Dictionary<string, List<Book>>? grouped = null;

            if (SelectedReportType == "Group by Genre")
                grouped = _catalog.GetBooksByGenre();
            else if (SelectedReportType == "Group by Author")
                grouped = _catalog.GetBooksByAuthor();

            if (grouped != null)
            {
                foreach (var kvp in grouped)
                {
                    BookGroups.Add(new BookGroup
                    {
                        GroupName = kvp.Key ?? "Unknown",
                        Books = new ObservableCollection<Book>(kvp.Value)
                    });
                }
            }
        }
    }
}
