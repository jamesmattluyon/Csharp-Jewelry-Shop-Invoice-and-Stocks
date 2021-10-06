using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JS.DAL;
using JS.BILL;

namespace JS.UI
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        ItemDAL itmDal = new ItemDAL();
        ItemBLL itmBll = new ItemBLL();
        private void Stock_Load(object sender, EventArgs e)
        {
            DataTable dt = itmDal.Select();
            dataGridView1.DataSource = dt;
        }

        private void comboBoxCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemCategory = comboBoxCategoryType.Text;
            DataTable dt = itmDal.DisplayItemCategory(itemCategory);
            dataGridView1.DataSource = dt;
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            DataTable dt = itmDal.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                itmBll.itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                textStock.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            }

            catch (Exception)
            {
                MessageBox.Show("Please click the cell", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textStock.Text == string.Empty)
            {
                MessageBox.Show("Please choose the data to update", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                itmBll.itemQuantity = decimal.Parse(textStock.Text);
                itmBll.added_Date = DateTime.Now;
            

                bool success = itmDal.UpdateStock(itmBll);
                if (success == true)
                {
                    MessageBox.Show("Data updated successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dt = itmDal.Select();
                    dataGridView1.DataSource = dt;
                    textStock.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void textStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && textStock.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
