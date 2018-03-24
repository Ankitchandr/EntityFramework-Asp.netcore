using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurdOperation
{
    public partial class Form1 : Form
    {
        Customer model = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            textFirstName.Text = textLastName.Text = textCity.Text = textAddress.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            model.CustomerId = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            populateDataGridView();
        }

        private void False(object sender, EventArgs e)
        {

        }

        private void True(object sender, EventArgs e)
        {

        }

        private void green(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCustomer.CurrentRow.Index != -1)
            {
                model.CustomerId = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CustomerId"].Value);
                using (DBEntities db = new DBEntities())
                {
                    model = db.Customers.Where(x => x.CustomerId == model.CustomerId).FirstOrDefault();
                    textFirstName.Text = model.First_Name;
                    textLastName.Text = model.Last_Name;
                    textCity.Text = model.City;
                    textAddress.Text = model.Address;
                }
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to Delete this records ?","EF curd Operation",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                using (DBEntities db = new DBEntities())
                {
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Detached)
                        db.Customers.Attach(model);
                    db.Customers.Remove(model);
                    db.SaveChanges();
                    populateDataGridView();
                    MessageBox.Show("Deleted Successfully");
                }
            }
        }
    }
}
