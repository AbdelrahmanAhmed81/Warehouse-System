using System;

namespace WarehousesSystem.Models
{
    public class Supply:Operation
    {
        public string SupplierEmail { get; set; }

        public Supplier Supplier { get; set; }

    }
}
