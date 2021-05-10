﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMay
{
    class Order
    {
        public Order(ICollection<Product> products, DateTime dateOrdered, Customer customer, OrderStatus orderStatus)
        {
            Products = products;
            DateOrdered = dateOrdered;
            Customer = customer;
            OrderStatus = orderStatus;
        }

        public Order()
        {
        }

        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public DateTime DateOrdered { get; set; }
        public Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
