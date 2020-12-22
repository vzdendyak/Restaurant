using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Data.DTOs
{
    public class DishOrdersDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int PortionNumber { get; set; }
    }
}