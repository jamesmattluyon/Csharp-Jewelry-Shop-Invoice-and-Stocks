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
    class TransactionDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region SELECT Transaction
        public DataTable SelectTransaction()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM BusinessTransaction";
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
        #region Insert Transaction
        public bool Insert(TransactionBLL td)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO BusinessTransaction (invoiceNo, itemId, price, qty, total, added_date, dealer_customerId) VALUES (@invoiceNo, @itemId, @price, @qty, @total, @added_date, @dealer_customerId)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@invoiceNo", td.invoiceNo);
                cmd.Parameters.AddWithValue("@itemId", td.itemId);
                cmd.Parameters.AddWithValue("@price", td.price);
                cmd.Parameters.AddWithValue("@qty", td.qty);
                cmd.Parameters.AddWithValue("@total", td.total);
                cmd.Parameters.AddWithValue("@added_Date", td.added_date);
                cmd.Parameters.AddWithValue("@dealer_customerId", td.dealer_customerId);

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
        #region Delete Transaction
        public bool Delete(TransactionBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM BusinessTransaction WHERE transactionNo = @transactionNo";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@transactionNo", c.transactionNo);

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
        #region Method to Display all Transaction deal
        public DataTable DisplayAllTransactionDeal()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM BusinessTransaction";
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
        #region Search Transaction
        public DataTable SearchTransaction(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM BusinessTransaction WHERE transactionNo LIKE '%" + keywords + "%' OR invoiceNo LIKE '%" + keywords + "%' OR itemId LIKE '%" + keywords + "%' OR price LIKE '%" + keywords + "%' OR qty LIKE '%" + keywords + "%' OR total LIKE '%" + keywords + "%' OR added_date LIKE '%" + keywords + "%' OR dealer_customerId LIKE '%" + keywords + "%'";
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




    }
}
