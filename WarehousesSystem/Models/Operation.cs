using System;

namespace WarehousesSystem.Models
{
    internal abstract class Operation
    {
        public string PersonEmail { get; set; }
        public int TypeCode { get; set; }
        public string WarehouseName { get; set; }
        public int DemandCode { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
    }
}
