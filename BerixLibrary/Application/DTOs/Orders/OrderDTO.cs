using Application.DTOs.ShippingMethods;
using Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public UserDTO Customer { get; set; }
        public ShippingMethodDTO ShippingMethod { get; set; }
        public ICollection<BookAndPriceDTO> BooksAndPrices { get; set; } = new List<BookAndPriceDTO>();
    }
}
