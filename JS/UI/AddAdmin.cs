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
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        AdminBLL abll = new AdminBLL();
        AdminDAL aDal = new AdminDAL();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textUserName.Text == string.Empty && textPassword.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the data first", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                abll.username = textUserName.Text;
                abll.password = textPassword.Text;

                bool success = aDal.InsertAdmin(abll);
                if (success == true)
                {
                    MessageBox.Show("Data inserted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminClear();
                    DataTable dt = aDal.SelectAdmin();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AdminClear()
        {
            textUserName.Text = "";
            textPassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textUserName.Text == string.Empty && textPassword.Text == string.Empty)
            {
                MessageBox.Show("Please choose the data to update", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                abll.username = textUserName.Text;
                abll.password = textPassword.Text;

                bool success = aDal.UpdateAdmin(abll);
                if (success == true)
                {
                    MessageBox.Show("Data updated successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminClear();
                    DataTable dt = aDal.SelectAdmin();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to update data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {
            DataTable dt = aDal.SelectAdmin();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                abll.adminId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                textUserName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textPassword.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please click the cell!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textUserName.Text == string.Empty && textPassword.Text == string.Empty)
            {
                MessageBox.Show("Please choose the data to delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = aDal.DeleteAdmin(abll);
                if (success == true)
                {
                    MessageBox.Show("Data deleted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminClear();
                    DataTable dt = aDal.SelectAdmin();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to delete data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textSearchAdmin_TextChanged(object sender, EventArgs e)
        {
            string keywords = textSearchAdmin.Text;
            if (keywords != null)
            {
                DataTable dt = aDal.SearchAdmin(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = aDal.SelectAdmin();
                dataGridView1.DataSource = dt;

            }

        }
    }
}
