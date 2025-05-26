# Book Cataloging System: Design Document

## Application Design

### Overview

The Book Cataloging System is a desktop application implemented in two languages: Ruby and C#. Both implementations provide a user-friendly GUI to manage a catalog of books with features to add, remove, search, and view reports grouped by genre or author.

### Architecture and Features

#### Ruby Version (Glimmer DSL for LibUI)

- **GUI Framework:** [Glimmer DSL for LibUI](https://github.com/AndyObtiva/glimmer-dsl-libui), providing a lightweight and native GUI experience.
- **Project Structure:**

  - `models/book.rb`: Defines the `Book` data structure using a Ruby Struct.
  - `services/catalog.rb`: Manages the core catalog logic, including add, remove, and search functionality.
  - `services/book_catalog_ui.rb`: Bridges the UI and catalog services.
  - `ui/book_catalog_window.rb`: Defines the main application window and GUI elements.
  - `main.rb`: Entry point to launch the app.

- **Key Features:**
  - Add new books with attributes: title, author, genre, publication year, and price.
  - Remove books from the catalog.
  - Instant filtering/search on multiple fields.
  - Simple reports grouped by author or genre.
  - Clean and minimalistic UI with responsive interactions.

#### C# Version (AvaloniaUI)

- **GUI Framework:** [AvaloniaUI](https://avaloniaui.net/), a modern, cross-platform UI framework for .NET.
- **Project Structure:**

  - `Models/Book.cs` and `Models/BookGroup.cs`: Book entity and grouping models.
  - `Services/CatalogService.cs`: Business logic for managing the catalog.
  - `ViewModels/MainWindowViewModel.cs`: MVVM pattern to bind UI to logic.
  - `MainWindow.axaml` and `MainWindow.axaml.cs`: Define the UI layout and code-behind.
  - `Program.cs` and `App.axaml`: Application bootstrap and configuration.

- **Key Features:**
  - Book addition, deletion, and searching similar to the Ruby version.
  - Grouped reports by genre and author via dropdown selection.
  - Reactive UI using MVVM, enhancing maintainability and extensibility.
  - User-friendly interface with buttons and tables for book management.

## Task Assignment

| Task                              | Assigned To           | Project Role                 | Strengths and Contributions                         |
| --------------------------------- | --------------------- | ---------------------------- | --------------------------------------------------- |
| Ruby Application Development      | Aashish Shrestha      | Developer                    | Experienced in coding; learned Ruby and Glimmer DSL |
| C# Application Development        | Aashish Shrestha      | Developer                    | Experienced in coding; learned C# and Avalonia UI   |
| Code Snippet Contribution         | Richin Swaroop Dasari | Contributor                  | Delivered Ruby code snippets                        |
| Code Snippet Contribution         | Hasaan Ali            | Contributor                  | Delivered C# code snippets                          |
| Code Review and Quality Assurance | Sandip K C            | Reviewer / Quality Assurance | Conducted thorough code reviews and quality checks  |

_Note:_ Prashant Khanal has not responded yet regarding task assignment.

## Timeline Creation

| Day   | Milestone                                    | Deliverable                                                      |
| ----- | -------------------------------------------- | ---------------------------------------------------------------- |
| Day 1 | Project Setup and Initial Design             | Repository initialization and design documentation               |
| Day 2 | Implementation of Core Models and Services   | Development of `Book` model and catalog management logic         |
| Day 3 | User Interface Development for Both Versions | Construction of main windows and fundamental UI components       |
| Day 4 | Implementation of Advanced Features          | Integration of search functionality and report grouping features |
| Day 5 | Testing and Bug Fixing                       | Verification of features and resolution of identified issues     |
| Day 6 | Documentation Preparation                    | Completion of comprehensive README and project documentation     |

## Documentation of Design

### Design Explanation

- Both versions maintain modularity with separation of concerns: data models, business logic, and UI layers.
- Ruby leverages the declarative Glimmer DSL to simplify UI building, whereas C# uses MVVM with AvaloniaUI for scalable UI.
- Services handle the core catalog logic, enabling reuse and easier maintenance.
- The search function is implemented with live filtering, improving UX.
- Grouping reports are provided for quick insights by author or genre, enhancing usability.

### Language-Specific Features and Comparison

| Feature          | Ruby (Glimmer DSL)                                 | C# (AvaloniaUI)                                 |
| ---------------- | -------------------------------------------------- | ----------------------------------------------- |
| Typing           | Dynamically typed, flexible and concise            | Statically typed, enhancing compile-time safety |
| UI Construction  | Declarative DSL with Ruby blocks, simpler syntax   | MVVM pattern with XAML and data bindings        |
| State Management | Uses Ruby observers and bindings                   | Reactive properties with INotifyPropertyChanged |
| Performance      | Interpreted, may have slower UI responsiveness     | Compiled, generally faster UI and data binding  |
| Error Handling   | Runtime errors, flexible but prone to runtime bugs | Compile-time errors, better tooling support     |

### Impact on Design, Performance, and Readability

- Ruby’s dynamic nature and DSL lead to very concise and readable UI code but may cause runtime errors if not carefully tested
- C#’s static typing and MVVM pattern add boilerplate but improve maintainability, tooling support, and runtime performance
- Avalonia’s reactive data binding enhances responsiveness and scalability, especially for larger applications.
- Ruby’s simpler UI code enables faster prototyping, while C# suits long-term maintainable and extensible applications.

### Future Enhancements

- Persistence layer (database integration) for saving catalog between sessions.
- Export and import functionality (CSV/JSON).
- Enhanced reports with charts.

## Conclusion

This Book Cataloging System project demonstrates a robust and consistent design implemented in both Ruby and C#, utilizing best practices in desktop UI frameworks and software architecture. Task assignments and timeline planning ensured efficient progress, while thorough documentation provides a solid foundation for future improvements.
