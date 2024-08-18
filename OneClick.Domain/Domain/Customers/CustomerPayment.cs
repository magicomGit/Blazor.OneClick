using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Domain.Customers
{
    public class CustomerPayment
    {
        public long Id { get; set; }
        public DateTime LastPayment { get; set; }       
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}
