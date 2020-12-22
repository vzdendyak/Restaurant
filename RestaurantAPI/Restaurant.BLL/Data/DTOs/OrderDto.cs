using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Data.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string OwnerName { get; set; }
        public int TotalPrice { get; set; }
    }
}