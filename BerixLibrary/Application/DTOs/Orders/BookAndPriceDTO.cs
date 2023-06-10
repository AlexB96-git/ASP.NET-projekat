using Application.DTOs.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Orders
{
    public class BookAndPriceDTO
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }
    }
}
