class BookCatalogUI
  attr_accessor :title, :author, :genre, :publication_year, :price, :filter_value, :table_data, :selected_row

  def initialize(catalog)
    @catalog = catalog
    refresh_table_data
  end

  def refresh_table_data
    filtered_books = @catalog.filter_books(filter_value)
    self.table_data = filtered_books.map do |book|
      [book.title, book.author, book.genre, book.publication_year.to_s, sprintf("$%.2f", book.price)]
    end
  end

  def clear_form_fields
    self.title = ''
    self.author = ''
    self.genre = ''
    self.publication_year = ''
    self.price = ''
  end

  def add_book
    if [title, author, genre, publication_year, price].any? { |f| f.to_s.strip.empty? }
      return :validation_error
    elsif publication_year.to_i <= 0
      return :invalid_year
    elsif price.to_f <= 0.0
      return :invalid_price
    else
      new_book = Book.new(title, author, genre, publication_year.to_i, price.to_f)
      @catalog.add_book(new_book)
      clear_form_fields
      refresh_table_data
      return :success
    end
  end

  def delete_selected_book
    if selected_row
      @catalog.delete_book(selected_row)
      refresh_table_data
      self.selected_row = nil
      return :deleted
    else
      return :no_selection
    end
  end

  def show_books_by_genre
    @catalog.books_by_genre_report
  end

  def show_books_by_author
    @catalog.books_by_author_report
  end
end
