using Application.DTOs.Orders;
using Application.Queries.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Orders
{
    public class EfGetOrders : IGetOrdersQuery
    {
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IEnumerable<OrderDTO> Execute(string execute)
        {
            throw new NotImplementedException();
        }
    }
}
