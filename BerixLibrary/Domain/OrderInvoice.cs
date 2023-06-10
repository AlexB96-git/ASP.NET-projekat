using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderInvoice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        virtual public Book Book { get; set; }
        virtual public Order Order { get; set; }
    }
}
