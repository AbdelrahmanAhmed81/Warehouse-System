
using WarehousesSystem.Models.Helper;

namespace WarehousesSystem.Models
{
    public class ItemMeasureUnit
    {
        public int ItemCode { get; set; }
        public MeasureUnit MeasureUnit { get; set; }

        //navigation property
        public Item Item { get; set; }
    }
}
