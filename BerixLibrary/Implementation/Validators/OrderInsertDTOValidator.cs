using Application.DTOs.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class OrderInsertDTOValidator: AbstractValidator<OrderInsertDTO>
    {
        public OrderInsertDTOValidator()
        {
            
        }
    }
}
