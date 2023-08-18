using Application.DTOs.Orders;
using Application.DTOs.Users;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, UserDTO>();
            CreateMap<OrderInsertDTO, Order>();
            CreateMap<Order, OrderInsertDTO>();
        }
    }
}
