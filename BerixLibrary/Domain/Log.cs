﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Log : Entity
    { 
        public string Data { get; set; }
        virtual public UseCase UseCase { get; set; }
        virtual public User Actor { get; set; }
    }
}