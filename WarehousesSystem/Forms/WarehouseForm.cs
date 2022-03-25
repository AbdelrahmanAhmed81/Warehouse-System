﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehousesSystem.Forms
{
    public partial class WarehouseForm : Form
    {
        WarehouseSystem.WarehouseDBContext context;
        public WarehouseForm()
        {
            InitializeComponent();
            context = new WarehouseSystem.WarehouseDBContext();
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
            using (context)
            {
                dgvWarehouseData.DataSource = context.Warehouses;
            }
        }
    }
}
