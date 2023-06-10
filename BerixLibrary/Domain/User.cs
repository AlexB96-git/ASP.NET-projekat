﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        virtual public ICollection<Log> Logs { get; set; } = new List<Log>();
        virtual public ICollection<Order> Orders { get; set; } = new List<Order>();
        virtual public Role Role { get; set; }
    }
}
