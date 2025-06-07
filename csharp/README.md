# 📚 Book Cataloging System (C# + AvaloniaUI)

[![C#](https://img.shields.io/badge/C%23-9.0-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![AvaloniaUI](https://img.shields.io/badge/AvaloniaUI-11.0.0-blue.svg)](https://avaloniaui.net/)
[![Tested with xUnit](https://img.shields.io/badge/tested%20with-xUnit-brightgreen)](https://xunit.net/)

A simple desktop book cataloging system built with **C#**, **.NET**, and **[AvaloniaUI](https://avaloniaui.net/)**. It allows users to add, delete, search, and group books by genre or author with a reactive, modern desktop interface.

## 📖 Table of Contents

- [Project Structure](#-project-structure)
- [Setup Instructions](#️-setup-instructions)
- [Run the Application](#-run-the-application)
- [Testing](#testing)
- [Features](#features)
- [Acknowledgements](#-acknowledgements)
- [Simple Demo](#-simple-demo)

## 📦 Project Structure

```text
.
├── App.axaml
├── App.axaml.cs
├── app.manifest
├── csharp.csproj
├── MainWindow.axaml
├── MainWindow.axaml.cs
├── Models
│   ├── Book.cs
│   └── BookGroup.cs
├── Program.cs
├── README.md
├── Services
│   └── CatalogService.cs
└── ViewModels
    └── MainWindowViewModel.cs
```

## 🛠️ Setup Instructions

### 📌 Requirements

- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### 📥 Restore Dependencies

1️⃣ Navigate to the `csharp` project directory, run:

```bash
dotnet restore
```

## 🚀 Run the Application

From the `csharp/` directory:

```bash
dotnet run
```

## Testing

Unit tests are located in a separate project directory named `csharp.Tests` within this repository.

To run the tests:

1️⃣ From the `csharp` project directory, navigate to the `csharp.Tests/` directory:

```bash
cd ../csharp.Tests
```

2️⃣ Restore dependencies:

```bash
dotnet restore
```

3️⃣ Run the tests:

```bash
dotnet test --logger "console;verbosity=detailed
```

For more details, see the [csharp.Tests/README.md](csharp.Tests/README.md).

## 📚 Features

- Add new books to the catalog (title, author, genre, publication year, price)
- Remove existing books
- Search for books by title, author, genre or price
- View simple reports of books grouped by genre or author

## 🎉 Acknowledgements

This project wouldn’t have been possible without the fantastic [AvaloniaUI](https://avaloniaui.net/). Huge thanks to the maintainers and community for their brilliant work, examples, and documentation!

## 📺 Simple Demo

### 📖 Add a Book

1️⃣ Enter book details like **Title**, **Author**, **Genre**, **Publication Year**, and **Price**.

![Enter book details](./img/enter-book-details.png)

2️⃣ Click the **"Add Book"** button.

3️⃣ The new book will appear in the catalog list.

![Added Book](./img/book-added.png)

---

### 🗑️ Delete a Book

1️⃣ Locate the book you want to delete in the catalog table. Each entry has an `Action` column with a `Delete` button.

![Book to Delete](./img/book-to-delete.png)

2️⃣ Click the **"Delete"** button corresponding to that book.  
3️⃣ The book will be removed from the catalog immediately.

![Delete a Book](./img/book-deleted.png)

---

### 🔍 Search for Books

1️⃣ Enter a search term in the `Search` box. You can search by `Title`, `Author`, `Genre`, `Publication Year`, or `Price`.

2️⃣ Click the Search button to filter the catalog.

3️⃣ The catalog will instantly update to show only the matching books.

![Filter By title](./img/filter-by-title.png)

---

### 📊 View Reports (Optional)

1️⃣ Use the dropdown menu to switch the report type from `All Books` to `Group by Author`, then click `View Report`.

![Report By Author](./img/report-by-author.png)

2️⃣ Similarly, you can select `Group by Genre` from the dropdown and click `View Report` to see the catalog grouped by genre.

![Report By Genre](./img/report-by-genre.png)
