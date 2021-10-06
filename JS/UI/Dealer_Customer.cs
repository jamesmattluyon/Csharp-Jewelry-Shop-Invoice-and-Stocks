using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JS.BILL;
using JS.DAL;

namespace JS.UI
{
    public partial class Dealer_Customer : Form
    {
        public Dealer_Customer()
        {
            InitializeComponent();
        }

        Dealer_CustomerBLL c = new Dealer_CustomerBLL();
        Dealer_CustomerDAL dal = new Dealer_CustomerDAL();
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBoxType.Text == string.Empty && textCustomerName.Text == string.Empty && textContactNo.Text == string.Empty && textAge.Text == string.Empty && textAddress.Text == string.Empty && textEmail.Text == string.Empty )
            {
                MessageBox.Show("Please fill all the data first", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                c.name = textCustomerName.Text;
                c.contactNo = textContactNo.Text;
                c.age = textAge.Text;
                c.address = textAddress.Text;
                c.email = textEmail.Text;
                c.type = comboBoxType.Text;

                bool success = dal.Insert(c);
                if (success == true)
                {
                    MessageBox.Show("Data inserted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerClear();
                    DataTable dt = dal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }

        public void CustomerClear()
        {
            textCustomerName.Text = "";
            textContactNo.Text = "";
            textAge.Text = "";
            textAddress.Text = "";
            textEmail.Text = "";
            comboBoxType.Text = "";
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBoxType.Text == string.Empty && textCustomerName.Text == string.Empty && textContactNo.Text == string.Empty && textAge.Text == string.Empty && textAddress.Text == string.Empty && textEmail.Text == string.Empty)
            {
                MessageBox.Show("Please choose data to update", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                c.name = textCustomerName.Text;
                c.contactNo = textContactNo.Text;
                c.age = textAge.Text;
                c.address = textAddress.Text;
                c.email = textEmail.Text;
                c.type = comboBoxType.Text;

                bool success = dal.Update(c);
                if (success == true)
                {
                    MessageBox.Show("Data updated successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerClear();
                    DataTable dt = dal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
    

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxType.Text == string.Empty && textCustomerName.Text == string.Empty && textContactNo.Text == string.Empty && textAge.Text == string.Empty && textAddress.Text == string.Empty && textEmail.Text == string.Empty)
            {
                MessageBox.Show("Please choose data to delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = dal.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("Data deleted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerClear();
                    DataTable dt = dal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to delete data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void textSeach_TextChanged(object sender, EventArgs e)
        {
            string keywords = textSeach.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dataGridView1.DataSource = dt;

            }
        }

        private void textContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                c.dealer_customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                textCustomerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textContactNo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textAge.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textAddress.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textEmail.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                comboBoxType.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please click the cell", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
