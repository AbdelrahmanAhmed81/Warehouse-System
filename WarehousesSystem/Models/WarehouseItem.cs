namespace WarehousesSystem.Models
{
    public class WarehouseItem
    {
        public string WarehouseName { get; set; }
        public int ItemCode { get; set; }
        public int Quantity { get; set; }

        //navigation Property
        public Warehouse Warehouse { get; set; }
        public Item Item { get; set; }
    }
}
