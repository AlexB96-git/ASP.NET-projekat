using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        virtual public ICollection<Book> Books { get; set; } = new List<Book>();
        virtual public ICollection<Genre> s { get; set; } = new List<Genre>();
    }
}
