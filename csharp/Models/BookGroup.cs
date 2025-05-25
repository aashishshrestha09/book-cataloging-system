using System.Collections.ObjectModel;
using csharp.Models;

namespace csharp.Models
{
    public class BookGroup
    {
        public string? GroupName { get; set; }
        public ObservableCollection<Book>? Books { get; set; }
    }
}
