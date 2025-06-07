require_relative '../services/book_catalog_ui'
require_relative '../services/catalog'
require_relative '../models/book'

RSpec.describe BookCatalogUI do
  let(:catalog) { Catalog.new }
  let(:ui) { BookCatalogUI.new(catalog) }

  def fill_form_fields(title:, author:, genre:, year:, price:)
    ui.title = title
    ui.author = author
    ui.genre = genre
    ui.publication_year = year
    ui.price = price
  end

  describe '#add_book' do
    before(:each) { catalog.books.clear }

    context 'when any required field is empty' do
      it 'returns :validation_error' do
        fill_form_fields(title: '', author: 'Author', genre: 'Genre', year: '2020', price: '10.0')
        expect(ui.add_book).to eq(:validation_error)
      end
    end

    context 'when publication year is zero or less' do
      it 'returns :invalid_year' do
        fill_form_fields(title: 'Title', author: 'Author', genre: 'Genre', year: '0', price: '10.0')
        expect(ui.add_book).to eq(:invalid_year)
      end
    end

    context 'when price is zero or less' do
      it 'returns :invalid_price' do
        fill_form_fields(title: 'Title', author: 'Author', genre: 'Genre', year: '2020', price: '0')
        expect(ui.add_book).to eq(:invalid_price)
      end
    end

    context 'when all fields are valid' do
      it 'adds a new book, clears form fields, and returns :success' do
        fill_form_fields(title: 'New Book', author: 'New Author', genre: 'Fiction', year: '2022', price: '15.5')
        result = ui.add_book
        expect(result).to eq(:success)
        expect(catalog.books.map(&:title)).to include('New Book')
        expect(ui.title).to eq('')
        expect(ui.author).to eq('')
        expect(ui.genre).to eq('')
        expect(ui.publication_year).to eq('')
        expect(ui.price).to eq('')
      end
    end
  end

  describe '#delete_selected_book' do
    before(:each) { catalog.books.clear }

    context 'when no book is selected' do
      it 'returns :no_selection' do
        ui.selected_row = nil
        expect(ui.delete_selected_book).to eq(:no_selection)
      end
    end

    context 'when a book is selected' do
      before do
        fill_form_fields(title: 'Book to Delete', author: 'Author', genre: 'Genre', year: '2020', price: '20.0')
        ui.add_book
        ui.selected_row = catalog.books.find_index { |b| b.title == 'Book to Delete' }
      end

      it 'deletes the book and clears the selected row' do
        expect(ui.delete_selected_book).to eq(:deleted)
        expect(catalog.books.map(&:title)).not_to include('Book to Delete')
        expect(ui.selected_row).to be_nil
      end
    end
  end

  describe '#refresh_table_data' do
    before(:each) do
      catalog.books.clear
      catalog.add_book(Book.new('It Ends with Us', 'Colleen Hoover', 'Romance', 2016, 12.5))
    end

    it 'populates table_data with all books when no filter is applied' do
      ui.filter_value = ''
      ui.refresh_table_data
      expect(ui.table_data).not_to be_empty
    end

    it 'filters books based on filter_value' do
      ui.filter_value = 'It Ends with Us'
      ui.refresh_table_data
      expect(ui.table_data.size).to eq(1)
      expect(ui.table_data.first.first).to eq('It Ends with Us')
    end

    it 'filters books case-insensitively by partial matches' do
      ui.filter_value = 'ends'
      ui.refresh_table_data
      expect(ui.table_data.size).to be > 0
      expect(ui.table_data.flatten.any? { |cell| cell.downcase.include?('ends') }).to be true
    end
  end

  describe '#show_books_by_genre' do
    before(:each) do
      catalog.books.clear
      catalog.add_book(Book.new('Book1', 'Author1', 'Romance', 2020, 10.0))
    end

    it 'returns a genre report string containing the genre count' do
      report = ui.show_books_by_genre
      expect(report).to include('Romance: 1 book(s)')
    end
  end

  describe '#show_books_by_author' do
    before(:each) do
      catalog.books.clear
      catalog.add_book(Book.new('It Ends with Us', 'Colleen Hoover', 'Romance', 2016, 12.5))
    end

    it 'returns an author report string containing the author name' do
      report = ui.show_books_by_author
      expect(report).to include('Colleen Hoover:')
    end
  end
end
