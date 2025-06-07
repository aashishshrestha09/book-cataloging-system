# 📚 Book Cataloging System — Cross-Language Application Development

## 📖 Project Overview

This is a group project for **MSCS-632: Advanced Programming Languages** at University of the Cumberlands, Summer 2025 First Bi-term.

We have implemented a **Book Cataloging System** in **C#** and **Ruby** to compare how both languages handle similar functionalities, focusing on data storage, querying, and iteration.

## 👥 Group 5 Members

- Aashish Shrestha
- Hasaan Ali
- Prashant Khanal
- Richin Swaroop Dasari
- Sandip K C

## 📝 Features

- Add, remove, and search for books by title, author, or genre.
- Simple reporting by genre or author.
- Demonstration of language-specific features:
  - **C#**: Classes, LINQ, and strong typing.
  - **Ruby**: Dynamic typing, blocks, and iterators.

## 📂 Project Structure

```
.
├── csharp                                # 📌 C# implementation
│   ├── App.axaml
│   ├── App.axaml.cs
│   ├── app.manifest
│   ├── csharp.csproj
│   ├── img
│   │   ├── book-added.png
│   │   ├── book-deleted.png
│   │   ├── book-to-delete.png
│   │   ├── enter-book-details.png
│   │   ├── filter-by-title.png
│   │   ├── report-by-author.png
│   │   └── report-by-genre.png
│   ├── MainWindow.axaml
│   ├── MainWindow.axaml.cs
│   ├── Models
│   │   ├── Book.cs
│   │   └── BookGroup.cs
│   ├── Program.cs
│   ├── README.md                         # C# info and instructions
│   ├── Services
│   │   └── CatalogService.cs
│   └── ViewModels
│       └── MainWindowViewModel.cs
├── csharp.Tests                          # 📌 C# Unit Tests
│   ├── CatalogServiceTests.cs
│   └── csharp.Tests.csproj
|   └── README
├── design_document.md
├── README.md                             # Project overview and details
└── ruby                                  # 📌 Ruby implementation
    ├── Gemfile
    ├── Gemfile.lock
    ├── img
    │   ├── book-added.png
    │   ├── book-deleted.png
    │   ├── book-list.png
    │   ├── enter-book-details.png
    │   ├── filter-by-title.png
    │   ├── report-by-author.png
    │   ├── report-by-genre.png
    │   └── select-book.png
    ├── main.rb
    ├── models
    │   └── book.rb
    ├── README.md                         # Ruby-specific info and instructions
    ├── services
    │   ├── book_catalog_ui.rb
    │   └── catalog.rb
    ├── tests                             # 📌 C# Unit Tests
    │   ├── catalog_spec.rb
    │   └── test_book_catalog_ui_spec.rb
    └── ui
        └── book_catalog_window.rb
```
