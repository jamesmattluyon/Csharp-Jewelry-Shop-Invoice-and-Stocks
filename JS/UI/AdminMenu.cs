using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JS.UI;


namespace JS.UI
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void cashierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.AddAdmin adm = new UI.AddAdmin();
            adm.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Cashier c = new UI.Cashier();
            c.ShowDialog();
        }

        private void AdminMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            UI.LogIn LogIn = new UI.LogIn();
            LogIn.Show();
            this.Hide();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            UI.LogIn LogIn = new UI.LogIn();

          
            labelLogin.Text = "Welcome! \" "  + LogIn.recby1 + " \"";
            timer1.Interval = 2;
            timer1.Start();

            labelTime.Text = DateTime.Now.ToLongTimeString(); 
            labelDate.Text = DateTime.Now.ToLongDateString();
            timer2.Start();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Item itm = new UI.Item();
            itm.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Stock stk = new UI.Stock();
            stk.Show();
        }

        private void invoiceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
         
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.TransactionDetails td = new UI.TransactionDetails();
            td.ShowDialog();
        }

        private void invoiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.InvoiceDetail invD = new UI.InvoiceDetail();
            invD.Show();
        }
        int x = 255, y = 350;
        int z = 255, w = 390;

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
            if (x > 1000)
            {
                x = 2;
            }
            if (z > 1000)
            {
                z = 2;
            }
        }
    }
}
