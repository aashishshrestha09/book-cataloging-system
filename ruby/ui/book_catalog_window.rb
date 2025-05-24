require 'glimmer-dsl-libui'

def launch_book_catalog_window(ui_controller)
  include Glimmer

  window('Book Catalog', 700, 600) {
    margined true

    vertical_box {
    
      form {
        stretchy false
        entry {
          label 'Title'
          text <=> [ui_controller, :title]
        }
        entry {
          label 'Author'
          text <=> [ui_controller, :author]
        }
        entry {
          label 'Genre'
          text <=> [ui_controller, :genre]
        }
        entry {
          label 'Publication Year'
          text <=> [ui_controller, :publication_year]
        }
        entry {
          label 'Price'
          text <=> [ui_controller, :price]
        }
      }

      button('Add Book') {
        stretchy false
        on_clicked do
          result = ui_controller.add_book
          case result
          when :validation_error
            msg_box_error('Validation Error', 'Please fill in all fields!')
          when :invalid_year
            msg_box_error('Validation Error', 'Publication Year must be positive.')
          when :invalid_price
            msg_box_error('Validation Error', 'Price must be positive.')
          end
        end
      }

      button('Delete Selected Book') {
        stretchy false
        on_clicked do
          result = ui_controller.delete_selected_book
          case result
          when :deleted
            msg_box('Success', 'Book deleted.')
          when :no_selection
            msg_box_error('Error', 'No book selected.')
          end
        end
      }

      search_entry {
        stretchy false
        text <=> [ui_controller, :filter_value,
          after_write: ->(_) { ui_controller.refresh_table_data }
        ]
      }

      table {
        text_column('Title')
        text_column('Author')
        text_column('Genre')
        text_column('Year')
        text_column('Price')

        editable false
        cell_rows <=> [ui_controller, :table_data]

        on_row_clicked do |t, row|
          ui_controller.selected_row = row
        end
      }

      button('Show Books by Genre') {
        stretchy false
        on_clicked do
          report = ui_controller.show_books_by_genre
          msg_box('Books by Genre', report.empty? ? 'No books.' : report)
        end
      }

      button('Show Books by Author') {
        stretchy false
        on_clicked do
          report = ui_controller.show_books_by_author
          msg_box('Books by Author', report.empty? ? 'No books.' : report)
        end
      }
    }
  }.show
end
