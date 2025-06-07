require_relative '../services/catalog'
require_relative '../models/book'

RSpec.describe Catalog do
  let(:catalog) { Catalog.new }

  describe '#add_book' do
    it 'adds a book to the catalog' do
      book = Book.new('Title', 'Author', 'Genre', 2020, 10.0)
      expect { catalog.add_book(book) }.to change { catalog.books.size }.by(1)
      expect(catalog.books.last.title).to eq('Title')
    end
  end

  describe '#delete_book' do
    it 'deletes a book by index' do
      initial_size = catalog.books.size
      catalog.delete_book(0)
      expect(catalog.books.size).to eq(initial_size - 1)
    end

    it 'does nothing if index is invalid' do
      initial_books = catalog.books.dup
      catalog.delete_book(1000) # out of range
      expect(catalog.books).to eq(initial_books)
    end
  end

  describe '#filter_books' do
    it 'returns all books if keyword is nil or empty' do
      expect(catalog.filter_books(nil)).to eq(catalog.books)
      expect(catalog.filter_books('')).to eq(catalog.books)
    end

    it 'returns filtered books matching keyword (case insensitive)' do
      result = catalog.filter_books('ends')
      expect(result).not_to be_empty
      expect(result.all? { |book| book.title.downcase.include?('ends') || book.author.downcase.include?('ends') }).to be true
    end
  end

  describe '#books_by_genre_report' do
    it 'returns correctly formatted genre report string' do
      catalog.add_book(Book.new('Book2', 'Author2', 'Romance', 2018, 12.0))
      report = catalog.books_by_genre_report
      expect(report).to include('Romance: 2 book(s)')
    end
  end

  describe '#books_by_author_report' do
    it 'returns correctly formatted author report string' do
      catalog.add_book(Book.new('Book2', 'Colleen Hoover', 'Romance', 2018, 12.0))
      report = catalog.books_by_author_report
      expect(report).to include('Colleen Hoover:')
      expect(report).to include('Book2')
    end
  end
end
