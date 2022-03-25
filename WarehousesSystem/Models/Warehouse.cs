using System.Collections.Generic;

namespace WarehousesSystem.Models
{
    public class Warehouse
    {
        public string WarehouseName { get; set; }
        public string Address { get; set; }
        public string ManagerName { get; set; }
        //navigation property
        public ICollection<Operation> Operations { get; set; }

    }
}
