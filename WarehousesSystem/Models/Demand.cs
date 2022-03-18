using System;

namespace WarehousesSystem.Models
{
    public class Demand:Operation
    {
        public string CustomerEmail { get; set; }

        public Customer Customer { get; set; }
    }
}
