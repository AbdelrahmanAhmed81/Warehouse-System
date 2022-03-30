using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace WarehousesSystem
{
    static class Helper
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data,DbContext context) where T : class
        {
            Type type = typeof(T);
            var instance = (T)Activator.CreateInstance(type);

            var properties = type.GetProperties();
            DataTable table = new DataTable();
            foreach (var prop in properties)
            {
                var reference = context.Entry(instance).Member(prop.Name) ;

                if (reference as DbCollectionEntry == null && reference as DbReferenceEntry == null)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    row[properties[i].Name] = properties[i].GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
