using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using JS.BILL;
using JS.DAL;
using JS.Properties;

namespace JS.UI
{
  
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }
        private int numberOfItemsPerPage = 0;
        private int numberofPrinted = 0;


        Dealer_CustomerDAL dcDAL = new Dealer_CustomerDAL();
        ItemDAL itmDal = new ItemDAL();
        CashierDAL cDal = new CashierDAL();
        InvoiceDAL invDal = new InvoiceDAL();
        TransactionDAL trnDal = new TransactionDAL();

        DataTable transactionDT = new DataTable();
        
     
        private void Transaction_Load(object sender, EventArgs e)
        {
            string type = CashierMenu.transaction_type;
            labeltop.Text = type;
           
            transactionDT.Columns.Add("ID");
            transactionDT.Columns.Add("Item Name");
            transactionDT.Columns.Add("Price");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");

            TransactionBLL trnbll = new TransactionBLL();
            trnbll.invoiceNo = Idd;

            string username = UI.LogIn.recby2;
            CashierBLL cb = cDal.GetCashierNameFromUsername(username);
            cb.cashierName = cb.cashierName;

        }

        private void textSearchMforDelCus_TextChanged(object sender, EventArgs e)
        {
            string keyword = textSearchDC.Text;

            if(keyword=="")
            {
                textName.Text = "";
                textContactNo.Text = "";
                textAge.Text = "";
                textAddress.Text = "";
                textEmail.Text = "";

                return;
            }
            Dealer_CustomerBLL dc = dcDAL.SearchDealerCustomerforTransaction(keyword);
            textName.Text = dc.name;
            textContactNo.Text = dc.contactNo;
            textAge.Text = dc.age;
            textAddress.Text = dc.address;
            textEmail.Text = dc.email;

        }

        private void textSearchDetails_TextChanged(object sender, EventArgs e)
        {
            string keyword = textSearchDetails.Text;
            if(keyword == "")
            {
                textItemName.Text = "";
                textItemType.Text = "";
                textItemCategory.Text = "";
                textItemPrice.Text = "";
                textStock.Text = "";
                textQty.Text = "";

                return;
            }

            ItemBLL i = itmDal.GetItemForTransaction(keyword);
            textItemName.Text = i.itemName;
            textItemType.Text = i.itemType;
            textItemCategory.Text = i.itemCategory;
            textItemPrice.Text = i.itemPrice.ToString();
            textStock.Text = i.itemQuantity.ToString();

        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                string itemId = textSearchDetails.Text;
                string itemName = textItemName.Text;
                decimal price = decimal.Parse(textItemPrice.Text);
                decimal qty = decimal.Parse(textQty.Text);
                decimal total = price * qty;
                decimal subTotal = decimal.Parse(textSubtotal.Text);
                subTotal = subTotal + total;
                transactionDT.Rows.Add(itemId, itemName, price, qty, total);
                textSubtotal.Text = subTotal.ToString();
                dataGridView1.DataSource = transactionDT;

                textSearchDetails.Text = "";
                textItemName.Text = "";
                textItemType.Text = "";
                textItemCategory.Text = "";
                textItemPrice.Text = "0.00";
                textStock.Text = "0";
                textQty.Text = "0";
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill all the data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Please select data to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }   
        }

        private void textVat_TextChanged(object sender, EventArgs e)
        {
            string value = textVat.Text;
            if(value == "")
            {
                MessageBox.Show("Please Add Vat");
            }
            
            else
            {
                decimal vat = decimal.Parse(textVat.Text);
                decimal subTotal = decimal.Parse(textSubtotal.Text);
                decimal grandTotalWithVat = ((100 + vat) / 100) * subTotal;

                textGrandTotal.Text = grandTotalWithVat.ToString();
            }
            
        }

        private void textDiscount_TextChanged(object sender, EventArgs e)
        {
            string value = textDiscount.Text;
            if (value == "")
            {
                MessageBox.Show("Add Discount");
          
            }
            else
            {
                decimal subTotal = decimal.Parse(textSubtotal.Text);
                decimal discount = decimal.Parse(textDiscount.Text);
                decimal grandTotal = ((100 - discount) / 100) * subTotal;

                textGrandTotal.Text = grandTotal.ToString();
            }
            
        }

        private void textPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal grandTotal = decimal.Parse(textGrandTotal.Text);
                decimal payment = decimal.Parse(textPayment.Text);
                decimal change = payment - grandTotal;


                textChange.Text = change.ToString();
            }
            catch(FormatException)
            {
                MessageBox.Show("Please Add Payment");
            }
        }

        private int Idd;
        private int Idd2;
        private void button2_Click(object sender, EventArgs e)
        {

            //if(dataGridView1.CurrentCell != null || textSubtotal.Text != string.Empty || textDiscount.Text != string.Empty || textVat.Text != string.Empty || textGrandTotal.Text != string.Empty || textPayment.Text != string.Empty && textChange.Text != string.Empty)
            try
            {
                InvoiceBLL invoice = new InvoiceBLL();
                invoice.type = labeltop.Text;

                string name = textName.Text;
                Dealer_CustomerBLL dc = dcDAL.GetDealer_CustomerIdFromName(name);

                string username = UI.LogIn.recby2;
                CashierBLL cb = cDal.GetCashierIdFromUsername(username);

                
                invoice.cashierId = cb.cashierId;
                invoice.dealer_customerId = dc.dealer_customerId;
                invoice.grandTotal = Math.Round(decimal.Parse(textGrandTotal.Text), 2);
                invoice.trasaction_date = DateTime.Now;
                invoice.vat = Math.Round(decimal.Parse(textVat.Text), 2);
                invoice.discount = Math.Round(decimal.Parse(textDiscount.Text), 2);
                invoice.payment = Math.Round(decimal.Parse(textPayment.Text), 2);
                invoice.change = Math.Round(decimal.Parse(textChange.Text), 2);
                invoice.transaction = transactionDT;

               
                using (TransactionScope scope = new TransactionScope())
                {

                    bool success = false;
                    int invoiceID = -1;
                    bool w = invDal.Insert(invoice, out invoiceID);

                    for (int i = 0; i < transactionDT.Rows.Count; i++)
                    {
                        TransactionBLL trnbll = new TransactionBLL();
                        string itemName = transactionDT.Rows[i][1].ToString();
                        ItemBLL itmb = itmDal.GetitemIdFromitemName(itemName);

                        trnbll.invoiceNo = invoiceID;
                        trnbll.itemId = itmb.itemId;
                        trnbll.price = decimal.Parse(transactionDT.Rows[i][2].ToString());
                        trnbll.qty = decimal.Parse(transactionDT.Rows[i][3].ToString());
                        trnbll.total = Math.Round(decimal.Parse(transactionDT.Rows[i][4].ToString()), 2);
                        trnbll.added_date = DateTime.Now;
                        trnbll.dealer_customerId = dc.dealer_customerId;

                        Idd = trnbll.invoiceNo;
                        Idd2 = cb.cashierId;
                        bool x = false;
                        string transactionType = labeltop.Text;
                        if (transactionType == "Purchase")
                        {
                            if (invoice.payment < invoice.grandTotal)
                            {
                                MessageBox.Show("Payment should same or higher than GrandTotal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                x = itmDal.IncreaseItem(trnbll.itemId, trnbll.qty);
                            }
                            
                        }
                        else if (transactionType == "Sales")
                        {
                            if(trnbll.qty > itmDal.GetItemQuantity(trnbll.itemId) )
                            {
                                MessageBox.Show("The item ID no " + trnbll.itemId + " is under stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                transactionDT.Rows.Clear();
                            }
                            else if (itmDal.GetItemQuantity(trnbll.itemId) == 0)
                            {
                                MessageBox.Show("The item is out of stock please try again later", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if(invoice.payment < invoice.grandTotal)
                            {
                                MessageBox.Show("Payment should same or higher than GrandTotal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                x = itmDal.DecreaseItem(trnbll.itemId, trnbll.qty);
                            }

                        }
                     
                        bool y = trnDal.Insert(trnbll);
                        success = w && x && y;
                    }

                    
                    if (success == true)
                    {
                       
                        
                        scope.Complete();
                        MessageBox.Show("Transaction Completed Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        printDocument1.Print();
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        transactionDT.Rows.Clear();
                        textSearchDC.Text = "";
                        textName.Text = "";
                        textContactNo.Text = "";
                        textAge.Text = "";
                        textAddress.Text = "";
                        textEmail.Text = "";
                        textSearchDetails.Text = "";
                        textItemName.Text = "";
                        textItemType.Text = "";
                        textItemCategory.Text = "";
                        textItemPrice.Text = "";
                        textStock.Text = "";
                        textQty.Text = "";
                        textSubtotal.Text = "0";
                        textDiscount.Text = "0";
                        textVat.Text = "0";
                        textChange.Text = "";
                        textGrandTotal.Text = "";
                        textPayment.Text = "";


                      
                    }
                    else
                    {
                        MessageBox.Show("Transaction Failed", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

            }

            catch (Exception)
            {
                MessageBox.Show("Please fill all the data first", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool IsValidated()
        {
            if(dataGridView1.CurrentCell == null || textSubtotal.Text == string.Empty || textDiscount.Text == string.Empty || textVat.Text == string.Empty || textGrandTotal.Text == string.Empty || textPayment.Text == string.Empty && textChange.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the data first", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
      

        private void textQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textVat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textGrandTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textPayment_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textChange_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textSubtotal_KeyPress(object sender, KeyPressEventArgs e)
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

       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Image image = Resources.InvoiceHeader;
            // e.Graphics.DrawImage(image, 125, 0, image.Width, image.Height);
            e.Graphics.DrawString("JEWELRY SHOP ", new Font("Segoi UI", 26, FontStyle.Bold), Brushes.Black, new Point(250, 0));
            e.Graphics.DrawString("San marcelito St. Ermita Manila ", new Font("Segoi UI", 12, FontStyle.Bold), Brushes.Black, new Point(275, 35));
            e.Graphics.DrawString("Telephone No: 123 4567", new Font("Segoi UI", 12, FontStyle.Bold), Brushes.Black, new Point(300, 50));
            e.Graphics.DrawString("Website: jewelryshop.market.ph", new Font("Segoi UI", 12, FontStyle.Bold), Brushes.Black, new Point(275, 65));

       
            //string username1 = UI.LogIn.recby3;
           // CashierBLL cb = cDal.GetCashierNameFromUsername(username1);
            //cb.cashierName = cb.cashierName;


            e.Graphics.DrawString(" Cashier ID : " + Idd2, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 100));
            e.Graphics.DrawString(" Transaction Type : " + labeltop.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 130));
            e.Graphics.DrawString(" Transaction Date : " + DateTime.Now, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString(" Customer Name : " + textName.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString(" Contact Number : " + textContactNo.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 220));

            e.Graphics.DrawString("**************************************************************************************************************", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 240));
            e.Graphics.DrawString("ID", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, 255));
            e.Graphics.DrawString("Item Name", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(80, 255));
            e.Graphics.DrawString("Price", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(380, 255));
            e.Graphics.DrawString("Qty", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(510, 255));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(660, 255));

            int yPos = 300;
            for (int i = numberofPrinted; i < transactionDT.Rows.Count; i++)
            {
                numberOfItemsPerPage++;

                if(numberOfItemsPerPage <= 20)
                {
                    numberofPrinted++;
                    if(numberofPrinted <= transactionDT.Rows.Count)
                    {
                        e.Graphics.DrawString(transactionDT.Rows[i][0].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, yPos));
                        e.Graphics.DrawString(transactionDT.Rows[i][1].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(80, yPos));
                        e.Graphics.DrawString(transactionDT.Rows[i][2].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(380, yPos));
                        e.Graphics.DrawString(transactionDT.Rows[i][3].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(510, yPos));
                        e.Graphics.DrawString(transactionDT.Rows[i][4].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(660, yPos));

                        yPos += 30;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                   
                }
                else
                {
                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    return;
                }
              
            }
            e.Graphics.DrawString("**************************************************************************************************************", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, yPos));
            e.Graphics.DrawString("Sub Total  : " + textSubtotal.Text.Trim(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, yPos + 30));
            e.Graphics.DrawString("Discount  : " + textDiscount.Text.Trim() + "%", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, yPos + 60));
            e.Graphics.DrawString("Vat  : " + textVat.Text.Trim() + "%", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, yPos + 90));
            e.Graphics.DrawString("GrandTotal  : " + textGrandTotal.Text.Trim() , new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, yPos + 120));
            e.Graphics.DrawString("Payment  : " + textPayment.Text.Trim(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, yPos + 150));
            e.Graphics.DrawString("Change  : " + textChange.Text.Trim(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, yPos + 180));

            e.Graphics.DrawString("Invoice No  : " + Idd, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, yPos + 30));

            e.Graphics.DrawString("Thanks for supporting this program! ", new Font("Segoi 14", 12, FontStyle.Bold), Brushes.Black, new Point(275, yPos + 280));

            numberOfItemsPerPage = 0;
            numberofPrinted = 0;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void textSearchDC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textSearchDetails_KeyPress(object sender, KeyPressEventArgs e)
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
