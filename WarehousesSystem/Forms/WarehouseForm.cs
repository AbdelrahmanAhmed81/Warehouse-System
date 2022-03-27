using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;
using WarehousesSystem.Models;

namespace WarehousesSystem.Forms
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
        }
        private void dataLoad()
        {
            using (var context = new WarehouseSystem.WarehouseDBContext())
            {
                dgvWarehouseData.DataSource = context.Warehouses.ToDataTable(context);
            }
            dgvWarehouseData.ClearSelection();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            Home.form = "Home";
            Close();
        }
        private void btnItem_Click(object sender, EventArgs e)
        {
            Home.form = "Item";
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

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            dataLoad();
        }

        private void btnAddWarehouse_Click(object sender, EventArgs e)
        {
            var warehouseName = txtWarehouseName.Text.Trim();
            var address = txtAddress.Text.Trim();
            var managerName = (txtManager.Text.Trim() == "") ? null : txtManager.Text.Trim();

            //validation
            if (!Validation.charsOnlyStringRegex.IsMatch(warehouseName))
            {
                MessageBox.Show("Warehouse name is required and must contain only characters and spaces");
                return;
            }
            if (!Validation.addressRegex.IsMatch(address))
            {
                MessageBox.Show("Warehouse address is required and must contain only characters, digits, spaces and underscores");
                return;
            }
            if (managerName != null)
            {
                if (!Validation.charsOnlyStringRegex.IsMatch(managerName))
                {
                    MessageBox.Show("Manager name must contain only characters and spaces");
                    return;
                }
            }

            try
            {
                using (var context = new WarehouseSystem.WarehouseDBContext())
                {
                    context.Warehouses.Add(new Warehouse()
                    {
                        WarehouseName = warehouseName,
                        Address = address,
                        ManagerName = managerName
                    });
                    context.SaveChanges();
                    MessageBox.Show("Warehouse Added Successfuly");
                    txtWarehouseName.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    txtManager.Text = string.Empty;
                    dataLoad();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("there is another warehouse with this name");
            }
        }

        private void dgvWarehouseData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                var rowData = dgvWarehouseData.Rows[row];
                txtWarehouseNameUpdate.Text = rowData.Cells[0].Value.ToString();
                txtAddressUpdate.Text = rowData.Cells[1].Value.ToString();
                txtManagerUpdate.Text = rowData.Cells[2].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var address = txtAddressUpdate.Text.Trim();
            var managerName = (txtManagerUpdate.Text.Trim() == "") ? null : txtManagerUpdate.Text.Trim();
            if (!Validation.addressRegex.IsMatch(address))
            {
                MessageBox.Show("Warehouse address is required and must contain only characters, digits, spaces and underscores");
                return;
            }
            if (managerName != null)
            {
                if (!Validation.charsOnlyStringRegex.IsMatch(managerName))
                {
                    MessageBox.Show("Manager name must contain only characters and spaces");
                    return;
                }
            }

            try
            {
                using (var context = new WarehouseSystem.WarehouseDBContext())
                {
                    var newWarehouse = new Warehouse()
                    {
                        WarehouseName = txtWarehouseNameUpdate.Text,
                        Address = address,
                        ManagerName = managerName
                    };
                    context.Warehouses.Attach(newWarehouse);
                    context.Entry(newWarehouse).State = EntityState.Modified;
                    context.SaveChanges();
                    MessageBox.Show("Warehouse Updated Successfuly");
                    txtWarehouseNameUpdate.Text = string.Empty;
                    txtAddressUpdate.Text = string.Empty;
                    txtManagerUpdate.Text = string.Empty;
                    dataLoad();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("updated failed");
            }
        }
    }
}
