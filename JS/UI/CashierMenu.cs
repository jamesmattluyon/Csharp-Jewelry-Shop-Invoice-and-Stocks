using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JS.UI
{
    public partial class CashierMenu : Form
    {
        public CashierMenu()
        {
            InitializeComponent();
        }
        public static string transaction_type;
        private void CashierMenu_Load(object sender, EventArgs e)
        {
            UI.LogIn LogIn = new UI.LogIn();
            labelLoginUser.Text = "Welcome! \" " + LogIn.recby2 + " \"";
            timer1.Interval = 2;
            timer1.Start();

            timer2.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
        }

        private void cashierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transaction_type = "Sales";
            UI.Transaction sales = new UI.Transaction();
            sales.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transaction_type = "Purchase";
            UI.Transaction purchase = new UI.Transaction();
            purchase.ShowDialog();
        }

        private void dealerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Dealer_Customer dc = new UI.Dealer_Customer();
            dc.ShowDialog();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Stock stc = new UI.Stock();
            stc.ShowDialog();
        }

        private void CashierMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            UI.LogIn LogIn = new UI.LogIn();
            LogIn.Show();
            this.Hide();
        }

        int x = 255, y = 350;
        int z = 255, w = 390;

        private void transactionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.TransactionDetailsForCashier tdfc = new UI.TransactionDetailsForCashier();
            tdfc.ShowDialog();
        }

        private void invoiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.InvoiceDetailForCashier idfc = new UI.InvoiceDetailForCashier();
            idfc.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelBig.SetBounds(x, y, 1, 1);
            labelSmall.SetBounds(z, w, 1, 1);
            x++;
            z++;
            if(x > 1000)
            {
                x = 2;
            }
            if (z > 1000)
            {
                z = 2;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
