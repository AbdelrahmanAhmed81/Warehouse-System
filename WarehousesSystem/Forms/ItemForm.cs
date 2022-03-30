using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehousesSystem.Models;
using WarehousesSystem.Models.Helper;

namespace WarehousesSystem.Forms
{
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();
        }
        private void dataLoad()
        {
            using (var context = new WarehouseSystem.WarehouseDBContext())
            {
                dgvItemData.DataSource = context.Items.ToDataTable(context);
            }
            dgvItemData.ClearSelection();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            Home.form = "Home";
            Close();
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            Home.form = "Warehouse";
            Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Home.form = "Customer";
            Close();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Home.form = "Supplier";
            Close();
        }

        private void btnDemand_Click(object sender, EventArgs e)
        {
            Home.form = "Demand";
            Close();
        }

        private void btnSupply_Click(object sender, EventArgs e)
        {
            Home.form = "Supply";
            Close();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            dataLoad();
            clbMeasureUnits.Items.AddRange(Enum.GetNames(typeof(MeasureUnit)));
            clbMeasureUnitsUpdate.Items.AddRange(Enum.GetNames(typeof(MeasureUnit)));
        }

        private void dgvItemData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                var rowData = dgvItemData.Rows[row];
                txtItemCodeUpdate.Text = rowData.Cells[0].Value.ToString();
                txtItemNameUpdate.Text = rowData.Cells[1].Value.ToString();

                using (var context = new WarehouseSystem.WarehouseDBContext())
                {
                    int itemCode = int.Parse(txtItemCodeUpdate.Text);
                    dgvItemMeasureUnits.DataSource = context.ItemMeasureUnits
                        .Where(i => i.ItemCode == itemCode)
                        .ToDataTable(context);
                }

                foreach (var index in clbMeasureUnitsUpdate.CheckedIndices)
                {
                    clbMeasureUnitsUpdate.SetItemCheckState((int)index, CheckState.Unchecked);
                };
                foreach (var item in dgvItemMeasureUnits.Rows)
                {
                    var unit = (int)(item as DataGridViewRow).Cells[1].Value;
                    clbMeasureUnitsUpdate.SetItemCheckState(unit, CheckState.Checked);
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var itemName = txtItemName.Text.Trim();

            //validation
            if (!Validation.charsOnlyStringRegex.IsMatch(itemName))
            {
                MessageBox.Show("Item name is required and must contain only characters and spaces");
                return;
            }

            try
            {
                using (var context = new WarehouseSystem.WarehouseDBContext())
                {
                    var measureItems = new List<ItemMeasureUnit>();
                    var item = new Item()
                    {
                        Name = itemName
                    };
                    foreach (var unit in clbMeasureUnits.CheckedItems)
                    {
                        measureItems.Add(new ItemMeasureUnit()
                        {
                            Item = item,
                            MeasureUnit = (MeasureUnit)Enum.Parse(typeof(MeasureUnit), unit.ToString())
                        });
                    }
                    item.MeasureUnits = measureItems;
                    context.Items.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Item Added Successfuly");
                    txtItemName.Text = string.Empty;
                    dataLoad();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("there is another Item with this name");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var itemName = txtItemNameUpdate.Text.Trim();

            //validation
            if (!Validation.charsOnlyStringRegex.IsMatch(itemName))
            {
                MessageBox.Show("Item name is required and must contain only characters and spaces");
                return;
            }

            try
            {
                using (var context = new WarehouseSystem.WarehouseDBContext())
                {
                    var code = int.Parse(txtItemCodeUpdate.Text);
                    var item = context.Items.SingleOrDefault(i => i.ItemCode == code);
                    context.Entry(item).Collection(i => i.MeasureUnits).Load();

                    item.Name =itemName;

                    var measureItems = new List<ItemMeasureUnit>();
                    foreach (var unit in clbMeasureUnitsUpdate.CheckedItems)
                    {
                        measureItems.Add(new ItemMeasureUnit()
                        {
                            ItemCode = item.ItemCode,
                            MeasureUnit = (MeasureUnit)Enum.Parse(typeof(MeasureUnit), unit.ToString())
                        });
                    }
                    item.MeasureUnits = measureItems;
                    context.SaveChanges();

                    MessageBox.Show("Item Updated Successfuly");
                    txtItemCodeUpdate.Text = txtItemNameUpdate.Text = string.Empty;
                    dataLoad();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("there is another Item with this name");
            }
        }
    }
}
