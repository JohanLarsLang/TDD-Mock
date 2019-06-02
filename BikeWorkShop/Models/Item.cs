using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeWorkShop.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RepairCost { get; set; }
    }
}
