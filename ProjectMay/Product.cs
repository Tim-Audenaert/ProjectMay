using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMay
{
    class Product
    {
        public Product(string name, double price, Supplier supplier)
        {
            Name = name;
            Price = price;
            Supplier = supplier;
        }

        public Product()
        { 
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Sale> Orders { get; set; }
    }
}
