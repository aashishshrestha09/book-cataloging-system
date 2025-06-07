# 📚 Book Cataloging System — Tests (csharp.Tests)

This directory contains the **unit tests** for the Book Cataloging System built with **C#** and **AvaloniaUI**.

## 🧪 Testing Frameworks & Tools Used

- **xUnit** — test framework for writing and running unit tests
- **Moq** — mocking framework to create test doubles
- **coverlet.collector** — for code coverage collection
- **Microsoft.NET.Test.Sdk** — .NET test SDK for running tests

## 📦 Project Structure

```text
.
├── CatalogServiceTests.cs
├── csharp.Tests.csproj
└── README.md
```

## 🚀 Running Tests

1️⃣ Navigate to the csharp.Tests directory:

```bash
cd csharp.Tests
```

2️⃣ Restore dependencies (if not already done):

```bash
dotnet restore
```

3️⃣ Run all tests with detailed output:

```bash
dotnet test --logger "console;verbosity=detailed"
```
