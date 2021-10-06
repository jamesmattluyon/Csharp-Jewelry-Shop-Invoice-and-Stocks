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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        LoginBLL l = new LoginBLL();
        LoginDAL dal = new LoginDAL();
        AdminDAL adminDal = new AdminDAL();

        public static string LoggedIn1;
        public static string LoggedIn2;

        public static string recby1
        {
            get { return LoggedIn1; }
            set { LoggedIn1 = value; }
        }

        public static string recby2
        {
            get { return LoggedIn2; }
            set { LoggedIn2 = value; }
        }

        public static string recby3
        {
            get { return LoggedIn2; }
            set { LoggedIn2 = value; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            l.username = textUsername.Text;
            l.password = textPassword.Text;
            l.user_type = comboUsertype.Text;

           // LoggedIn1 = l.username;
            
            if (comboUsertype.Text == "Admin")
            {
               
                bool success = dal.LoginCheck1(l);
                
                if (success == true)
                {
                    textUsername.ForeColor = Color.Green;
                    recby1 = textUsername.Text;
             

                    MessageBox.Show("Login successfully!","Success!", MessageBoxButtons.OK , MessageBoxIcon.Information);   
                    UI.AdminMenu adm = new UI.AdminMenu();
                    adm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed. Try Again!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else if(comboUsertype.Text == "Cashier")
            {
                bool success = dal.LoginCheck2(l);
                if (success == true)
                {
                    recby2 = textUsername.Text;
                    MessageBox.Show("Login successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UI.CashierMenu cm = new UI.CashierMenu();
                    cm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed. Try Again!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please choose type of User Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
