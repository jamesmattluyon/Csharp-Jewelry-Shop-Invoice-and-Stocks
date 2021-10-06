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
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
        }

        ItemBLL c = new ItemBLL();
        ItemDAL dal = new ItemDAL();
        private void button1_Click(object sender, EventArgs e)
        {
            if(textItemName.Text == string.Empty && comboBoxItemType.Text == string.Empty && comboBoxItemCategory.Text == string.Empty && comboBoxItemCondition.Text == string.Empty && textItemPrice.Text == string.Empty)
            {
              MessageBox.Show("Please fill all the data first", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                c.itemName = textItemName.Text;
                c.itemType = comboBoxItemType.Text;
                c.itemCategory = comboBoxItemCategory.Text;
                c.itemCondition = comboBoxItemCondition.Text;
                c.itemPrice = decimal.Parse(textItemPrice.Text);
                c.itemQuantity = 0;
                c.added_Date = DateTime.Now;

                bool success = dal.Insert(c);
                if (success == true)
                {
                    MessageBox.Show("Data inserted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ItemClear();
                    DataTable dt = dal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void ItemClear()
        {
            textItemName.Text = "";
            comboBoxItemType.Text = "";
            comboBoxItemCategory.Text = "";
            comboBoxItemCondition.Text = "";
            textItemPrice.Text = "";
        }

        private void Item_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void textItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && textItemPrice.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                c.itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                textItemName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBoxItemType.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBoxItemCategory.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBoxItemCondition.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textItemPrice.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please click the cell!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textItemName.Text == string.Empty && comboBoxItemType.Text == string.Empty && comboBoxItemCategory.Text == string.Empty && comboBoxItemCondition.Text == string.Empty && textItemPrice.Text == string.Empty)
            {
                MessageBox.Show("Please choose data to update", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                c.itemName = textItemName.Text;
                c.itemType = comboBoxItemType.Text;
                c.itemCategory = comboBoxItemCategory.Text;
                c.itemCondition = comboBoxItemCondition.Text;
                c.itemPrice = decimal.Parse(textItemPrice.Text);
                c.added_Date = DateTime.Now;

                bool success = dal.Update(c);
                if (success == true)
                {
                    MessageBox.Show("Data updated successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ItemClear();
                    DataTable dt = dal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textItemName.Text == string.Empty && comboBoxItemType.Text == string.Empty && comboBoxItemCategory.Text == string.Empty && comboBoxItemCondition.Text == string.Empty && textItemPrice.Text == string.Empty)
            {
                MessageBox.Show("Please choose data to delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = dal.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("Data deleted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ItemClear();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }
    }
}
