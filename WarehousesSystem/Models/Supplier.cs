
using System.Collections.Generic;

namespace WarehousesSystem.Models
{
    public class Supplier:Person
    {
        public ICollection<Supply> Supplies { get; set; }

    }
}
