using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using JS.BILL;

namespace JS.DAL
{
    class InvoiceDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region SELECT Invoice
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Invoice";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        #endregion
        #region Insert Invoice
        public bool Insert(InvoiceBLL t, out int invoiceID)
        {
            bool isSuccess = false;
            invoiceID = -1;

            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO Invoice (cashierId, dealer_customerId, grandTotal, transaction_date, vat, discount, payment, change, type) VALUES (@cashierId, @dealer_customerId, @grandTotal, @transaction_date, @vat, @discount, @payment, @change, @type); SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cashierId", t.cashierId);
                cmd.Parameters.AddWithValue("@dealer_customerId", t.dealer_customerId);
                cmd.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", t.trasaction_date);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@payment", t.payment);  
                cmd.Parameters.AddWithValue("@change", t.change);
                cmd.Parameters.AddWithValue("@type", t.type);

              
                   
                con.Open();

                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    invoiceID= int.Parse(o.ToString());
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }
        #endregion
        #region Delete Invoice
        public bool Delete(InvoiceBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Invoice WHERE invoiceNo = @invoiceNo";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@invoiceNo", c.invoiceNo);

                con.Open();

                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }
        #endregion
        #region Method to Display all Invoice transaction
        public DataTable DisplayAllInvoiceTransaction()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Invoice";
                SqlCommand cmd = new SqlCommand(sql,con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        #endregion
        #region Method to Display Invoice based on transactionType
        public DataTable DisplayTransactionType(string type)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Invoice WHERE type ='" + type +"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion


    }
}
