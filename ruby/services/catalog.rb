# services/catalog.rb
require_relative '../models/book'

class Catalog
  attr_accessor :books

  def initialize
    @books = [
      Book.new('It Ends with Us', 'Colleen Hoover', 'Romance', 2016, 10.0)
    ]
  end

  def add_book(book)
    @books << book
  end


  def delete_book(index)
    @books.delete_at(index)
  end

  def filter_books(keyword)
    return books if keyword.nil? || keyword.strip.empty?

    keyword_down = keyword.downcase
    books.select do |book|
      book.members.any? { |attr| book[attr].to_s.downcase.include?(keyword_down) }
    end
  end

  def books_by_genre_report
    genre_counts = books.group_by(&:genre).transform_values(&:count)
    genre_counts.map { |genre, count| "#{genre}: #{count} book(s)" }.join("\n")
  end

  def books_by_author_report
    author_books = books.group_by(&:author)
    author_books.map do |author, books|
      "#{author}:\n" + books.map { |b| "  - #{b.title} (#{b.genre}, #{b.publication_year})" }.join("\n")
    end.join("\n\n")
  end
end
