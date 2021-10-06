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
    class CashierDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Cashier";
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
        #region Insert Cashier 
        public bool Insert(CashierBLL c)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO Cashier (cashierName, contactNo, username, password, added_date, added_by) VALUES (@cashierName, @contactNo, @username, @password, @added_date, @added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cashierName", c.cashierName);
                cmd.Parameters.AddWithValue("@contactNo", c.contactNo);
                cmd.Parameters.AddWithValue("@username", c.username);
                cmd.Parameters.AddWithValue("@password", c.password);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

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
        #region Update Cashier
        public bool Update(CashierBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Cashier SET cashierName = @cashierName, contactNo = @contactNo, username = @username, password = @password, added_date = @added_date, added_by = @added_by WHERE cashierId = @cashierId";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cashierName", c.cashierName);
                cmd.Parameters.AddWithValue("@contactNo", c.contactNo);
                cmd.Parameters.AddWithValue("@username", c.username);
                cmd.Parameters.AddWithValue("@password", c.password);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

                cmd.Parameters.AddWithValue("@cashierId", c.cashierId);

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
        #region Delete Cashier 
        public bool Delete(CashierBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Cashier WHERE cashierId = @cashierId";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cashierId", c.cashierId);

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
        #region Search Cashier
        public DataTable Search(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Cashier WHERE cashierId LIKE '%" + keywords + "%' OR cashierName LIKE'%" + keywords + "%' OR contactNo LIKE'%" + keywords + "%'";
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
        #region Method to Search Cashier in Transaction Module
        public CashierBLL SearchCashierforTransaction(string keyword)
        {
            CashierBLL dc = new CashierBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT cashierName FROM Cashier WHERE cashierId LIKE '%" + keyword + "%' OR cashierName LIKE '%" + keyword + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dc.cashierName = dt.Rows[0]["cashierName"].ToString();

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

            return dc;
        }
        #endregion
        #region Method to get cashierId based on Name
        public CashierBLL GetcashierIdFromName(string Name)
        {
            CashierBLL dc = new CashierBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT cashierId FROM Cashier WHERE cashierName = '" + Name + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dc.cashierId = int.Parse(dt.Rows[0]["cashierId"].ToString());

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

            return dc;
        }
        #endregion
        #region Getting CashierId from Username
        public CashierBLL GetCashierIdFromUsername(string username)
        {
            CashierBLL cb = new CashierBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT cashierId FROM Cashier WHERE username = '" + username +"'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    cb.cashierId = int.Parse(dt.Rows[0]["cashierId"].ToString());
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

            return cb;
        }

        #endregion
        #region Getting CashierName from Username
        public CashierBLL GetCashierNameFromUsername(string username)
        {
            CashierBLL cb = new CashierBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT cashierName FROM Cashier WHERE username = '" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cb.cashierName = dt.Rows[0]["cashierName"].ToString();
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

            return cb;
        }

        #endregion


    }
}
