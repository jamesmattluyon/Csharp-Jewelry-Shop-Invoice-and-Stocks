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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
        }

        CashierBLL c = new CashierBLL();
        CashierDAL dal = new CashierDAL();
        AdminDAL admDal = new AdminDAL();
        private void button1_Click(object sender, EventArgs e)
        {
            if(textCashierName.Text == string.Empty && textContactNo.Text == string.Empty)
            {
              MessageBox.Show("Please fill all the data first", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                c.cashierName = textCashierName.Text;
                c.contactNo = textContactNo.Text;
                c.username = textUsername.Text;
                c.password = textPassword.Text;
                c.added_date = DateTime.Now;

                string LogUser = UI.LogIn.recby1;
                AdminBLL ab = admDal.GetAdminIdFromUsername(LogUser);
                c.added_by = ab.adminId;

                bool success = dal.Insert(c);
                if (success == true)
                {
                    MessageBox.Show("Data inserted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CashierClear();
                    DataTable dt = dal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        public void CashierClear()
        {
            textCashierName.Text = "";
            textContactNo.Text = "";
            textUsername.Text = "";
            textPassword.Text = "";
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                c.cashierId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                textCashierName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textContactNo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textUsername.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textPassword.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please click the cell!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textCashierName.Text == string.Empty && textContactNo.Text == string.Empty)
            {
                MessageBox.Show("Please choose the data to update", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                c.cashierName = textCashierName.Text;
                c.contactNo = textContactNo.Text;
                c.username = textUsername.Text;
                c.password = textPassword.Text;
                c.added_date = DateTime.Now;

                bool success = dal.Update(c);
                if (success == true)
                {
                    MessageBox.Show("Data updated successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CashierClear();
                    DataTable dt = dal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to update data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textCashierName.Text == string.Empty && textContactNo.Text == string.Empty)
            {
                MessageBox.Show("Please choose the data to delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {  
                bool success = dal.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("Data deleted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CashierClear();
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
            if(keywords != null)
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
    }
}
