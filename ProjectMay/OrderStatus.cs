using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMay
{
    class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public OrderStatus(string status)
        {
            Status = status;
        }
    }
}
