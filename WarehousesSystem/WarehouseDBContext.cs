using System;
using System.Data.Entity;
using System.Linq;

namespace WarehouseSystem
{
    public class WarehouseDBContext : DbContext
    {

        public WarehouseDBContext()
            : base("name=WarehouseSystem")
        {
        }
    }

}