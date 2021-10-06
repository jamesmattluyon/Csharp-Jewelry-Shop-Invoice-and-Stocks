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
    public partial class TransactionDetailsForCashier : Form
    {
        public TransactionDetailsForCashier()
        {
            InitializeComponent();
        }

        TransactionBLL tb = new TransactionBLL();
        TransactionDAL tdal = new TransactionDAL();
        private void TransactionDetails_Load(object sender, EventArgs e)
        {
            DataTable dt = tdal.DisplayAllTransactionDeal();
            dataGridView1.DataSource = dt;
        }

        private void textSearchTransaction_TextChanged(object sender, EventArgs e)
        {
            string keywords = textSearchTransaction.Text;
            if (keywords != null)
            {
                DataTable dt = tdal.SearchTransaction(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = tdal.SelectTransaction();
                dataGridView1.DataSource = dt;

            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            DataTable dt = tdal.DisplayAllTransactionDeal();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tb.transactionNo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                textSearchTransaction.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please click the cell!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textSearchTransaction.Text == string.Empty)
            {
                MessageBox.Show("Please choose the data to delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = tdal.Delete(tb);
                if (success == true) 
                {
                    MessageBox.Show("Data deleted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textSearchTransaction.Text = "";
                    DataTable dt = tdal.SelectTransaction();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to delete data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
