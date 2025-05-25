# 📚 Book Cataloging System (C# + AvaloniaUI)

A simple desktop book cataloging system built with **C#**, **.NET**, and **[AvaloniaUI](https://avaloniaui.net/)**. It allows users to add, delete, search, and group books by genre or author with a reactive, modern desktop interface.

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

## 📚 Features

- Add new books to the catalog (title, author, genre, publication year, price)
- Remove existing books
- Search for books by title, author, genre or price
- View simple reports of books grouped by genre or author

## 🎉 Acknowledgements

This project wouldn’t have been possible without the fantastic [AvaloniaUI](https://avaloniaui.net/). Huge thanks to the maintainers and community for their brilliant work, examples, and documentation!
