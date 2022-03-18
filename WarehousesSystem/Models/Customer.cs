
using System.Collections.Generic;

namespace WarehousesSystem.Models
{
    public class Customer:Person
    {
        public ICollection<Demand> Demands { get; set; }

    }
}
