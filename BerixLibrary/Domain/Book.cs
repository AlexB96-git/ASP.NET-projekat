using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book
    {
        public int  Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        virtual public ICollection<OrderInvoice> OrderInvoices { get; set; } = new List<OrderInvoice>();
        virtual public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        virtual public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}