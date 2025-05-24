require_relative 'models/book'
require_relative 'services/catalog'
require_relative 'services/book_catalog_ui'
require_relative 'ui/book_catalog_window'

catalog = Catalog.new
ui_controller = BookCatalogUI.new(catalog)
launch_book_catalog_window(ui_controller)
