using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
    }
}
