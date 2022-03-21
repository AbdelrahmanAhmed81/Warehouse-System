using System;

namespace WarehousesSystem.Models
{
    public class Supply:Operation
    {
        public string SupplierEmail { get; set; }
        public DateTime ProductionDate { get; set; }
        public int ExpireDays { get; set; }
        public Supplier Supplier { get; set; }

    }
}
