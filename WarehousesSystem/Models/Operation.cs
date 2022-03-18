using System;

namespace WarehousesSystem.Models
{
    public abstract class Operation
    {
        public Guid Code { get; set; }
        public int ItemCode { get; set; }
        public string WarehouseName { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }

        //navigation property
        public Item Item { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
