
using System.Collections.Generic;

namespace WarehousesSystem.Models
{
    public class Item
    {
        public int ItemCode { get; set; }
        public string Name { get; set; }

        //navigation property
        public ICollection<ItemMeasureUnit> MeasureUnits { get; set; }
        public ICollection<Operation> Operations { get; set; }
    }
}
