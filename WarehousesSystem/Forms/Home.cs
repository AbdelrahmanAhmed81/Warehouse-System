using System;
using System.Windows.Forms;
using WarehousesSystem.Forms;
namespace WarehousesSystem
{
    public partial class Home : Form
    {
        public static string form;
        void nextForm(string formName)
        {
            switch (formName)
            {
                case "Warehouse":
                    {
                        var warehouseForm = new WarehouseForm();
                        Hide();
                        warehouseForm.ShowDialog();
                        nextForm(form);
                        break;
                    }
                case "Item":
                    {
                        var ItemForm = new ItemForm();
                        Hide();
                        ItemForm.ShowDialog();
                        nextForm(form);
                        break;
                    }
                case "Customer":
                    {
                        var CustomerForm = new CustomerForm();
                        Hide();
                        CustomerForm.ShowDialog();
                        nextForm(form);
                        break;
                    }
                case "Supplier":
                    {
                        var SupplierForm = new SupplierForm();
                        Hide();
                        SupplierForm.ShowDialog();
                        nextForm(form);
                        break;
                    }
                case "Demand":
                    {
                        var DemandForm = new DemandForm();
                        Hide();
                        DemandForm.ShowDialog();
                        nextForm(form);
                        break;
                    }
                case "Supply":
                    {
                        var SupplyForm = new SupplyForm();
                        Hide();
                        SupplyForm.ShowDialog();
                        nextForm(form);
                        break;
                    }
                default:
                    {
                        Visible = true;
                        break;
                    }
            }
        }
        public Home()
        {
            InitializeComponent();
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            nextForm("Warehouse");   
        }


        private void btnItem_Click(object sender, EventArgs e)
        {
            nextForm("Item");
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            nextForm("Customer");
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            nextForm("Supplier");
        }

        private void btnDemand_Click(object sender, EventArgs e)
        {
            nextForm("Demand");
        }

        private void btnSupply_Click(object sender, EventArgs e)
        {
            nextForm("Supply");
        }
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
