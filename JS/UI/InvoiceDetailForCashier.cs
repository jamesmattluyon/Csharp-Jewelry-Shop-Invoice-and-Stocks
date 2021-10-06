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
    public partial class InvoiceDetailForCashier : Form
    {
        public InvoiceDetailForCashier()
        {
            InitializeComponent();
        }
        InvoiceDAL invDal = new InvoiceDAL();
        InvoiceBLL invBll = new InvoiceBLL();
        private void TransactionDetail_Load(object sender, EventArgs e)
        {
            DataTable dt = invDal.DisplayAllInvoiceTransaction();
            dataGridView1.DataSource = dt;
        }

        private void comboBoxTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = comboBoxTransactionType.Text;
            DataTable dt = invDal.DisplayTransactionType(type);
            dataGridView1.DataSource = dt;
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            DataTable dt = invDal.DisplayAllInvoiceTransaction();
            dataGridView1.DataSource = dt;
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                invBll.invoiceNo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                comboBoxTransactionType.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please click the cell!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxTransactionType.Text == string.Empty)
            {
                MessageBox.Show("Please choose the data to delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = invDal.Delete(invBll);
                if (success == true)
                {
                    MessageBox.Show("Data deleted successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxTransactionType.Text = "";
                    DataTable dt = invDal.Select();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Failed to delete data", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
