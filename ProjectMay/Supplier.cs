using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMay
{
    class Supplier
    {
        public Supplier(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public Supplier()
        { 
        
        }

        public override string ToString()
        {
            return Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
   
}
