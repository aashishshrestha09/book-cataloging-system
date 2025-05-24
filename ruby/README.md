# 📚 Book Cataloging System (Ruby + Glimmer DSL for LibUI)

A simple GUI-based desktop application for managing a catalog of books built with Ruby and the excellent [Glimmer DSL for LibUI](https://github.com/AndyObtiva/glimmer-dsl-libui).

## 📦 Project Structure

```text
.
├── Gemfile
├── Gemfile.lock
├── main.rb
├── models
│   └── book.rb               # Book Struct (data model)
├── services
│   ├── book_catalog_ui.rb    # Catalog UI controller logic
│   └── catalog.rb            # Catalog service logic
├── ui
│   └── book_catalog_window.rb # GUI window definition
└── README.md
```

## 🛠️ Setup Instructions

### 📌 Requirements

- Ruby (3.0+ recommended)
- Bundler (for managing dependencies — typically comes with modern Ruby)

### 📥 Install Dependencies

1️⃣ Install Bundler if you haven't yet:

```bash
gem install bundler
```

2️⃣ 2️⃣ Install the required gems:

```bash
bundle install
```

## 🚀 Run the Application

From the `ruby/` directory:

```bash
ruby main.rb
```

## 📚 Features

- Add new books to the catalog (title, author, genre, publication year, price)
- Remove existing books
- Search for books by title, author, genre or price
- View simple reports of books grouped by genre or author

## 🎉 Acknowledgements

This project wouldn’t have been possible without the fantastic [Glimmer DSL for LibUI (v0.12.8)](https://github.com/AndyObtiva/glimmer-dsl-libui). Huge thanks to the maintainers and community for their brilliant work, examples, and documentation!

## 📺 Simple Demo

### 📖 Add a Book

1️⃣ Enter book details like **Title**, **Author**, **Genre**, **Publication Year**, and **Price**.

![Enter book details](./img/enter-book-details.png)

2️⃣ Click the **"Add Book"** button.

3️⃣ The new book will appear in the catalog list.

![Added Book](./img/book-added.png)

### 🗑️ Delete a Book

1️⃣ Select a book from the catalog list.

![Select a Book](./img/select-book.png)

2️⃣ Click **"Delete Selected Book"**.  
3️⃣ The book will be removed from the catalog.

![Delete a Book](./img/book-deleted.png)

---

### 🔍 Search for Books

1️⃣ Enter a search term in the **Search** box (by Title, Author, Genre, Publication Year or Price).

2️⃣ Matching books will instantly be filtered in the catalog list.

![Filter By title](./img/filter-by-title.png)

---

### 📊 View Reports (Optional)

1️⃣ Click Show Books by Author to see a summary grouped by author.

![Report By Author](./img/report-by-author.png)

2️⃣ Click Show Books by Genre to see a summary grouped by genre.

![Report By Genre](./img/report-by-genre.png)
