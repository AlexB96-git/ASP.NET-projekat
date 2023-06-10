using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Genre : Entity
    { 
        public string Name { get; set; }
        virtual public BookGenre Books { get; set; }
    }
}
