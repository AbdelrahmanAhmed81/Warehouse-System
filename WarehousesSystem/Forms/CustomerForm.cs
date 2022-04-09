using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using WarehousesSystem.Models;

namespace WarehousesSystem.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
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

        private void btnItem_Click(object sender, EventArgs e)
        {
            Home.form = "Item";
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
        private void dataLoad()
        {
            using (var context = new WarehouseSystem.WarehouseDBContext())
            {
                dgvCustomerData.DataSource = context.Persons.Where(p=>p is Customer).Select(p => p as Customer).ToDataTable(context);
            }
            dgvCustomerData.ClearSelection();
        }
        private void CustomerForm_Load(object sender , EventArgs e)
        {
            dataLoad();
        }
    }
}
