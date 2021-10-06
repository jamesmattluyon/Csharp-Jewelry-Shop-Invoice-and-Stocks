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
    class Dealer_CustomerDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Dealer_Customer
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Dealer_Customer";
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
        #region Insert Dealer_Customer 
        public bool Insert(Dealer_CustomerBLL c)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO Dealer_Customer (name, contactNo, age, address, email, type) VALUES (@name, @contactNo, @age, @address, @email, @type)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@contactNo", c.contactNo);
                cmd.Parameters.AddWithValue("@age", c.age);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@type", c.type);

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
        #region Update Dealer_Customer
        public bool Update(Dealer_CustomerBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Dealer_Customer SET name = @name, contactNo = @contactNo, age = @age, address = @address, email = @email, type = @type WHERE dealer_customerId = @dealer_customerId";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@contactNo", c.contactNo);
                cmd.Parameters.AddWithValue("@age", c.age);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@type", c.type);

                cmd.Parameters.AddWithValue("@dealer_customerId", c.dealer_customerId);

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
        #region Delete Dealer_Customer 
        public bool Delete(Dealer_CustomerBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Dealer_Customer WHERE dealer_customerId = @dealer_customerId";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@dealer_customerId", c.dealer_customerId);

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
        #region Search Dealer_Customer
        public DataTable Search(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Dealer_Customer WHERE dealer_customerId LIKE '%" + keywords + "%' OR name LIKE'%" + keywords + "%' OR contactNo LIKE'%" + keywords + "%' OR age LIKE'%" + keywords + "%' OR address LIKE'%" + keywords + "%' OR email LIKE'%" + keywords + "%' OR type LIKE'%" + keywords + "%'";
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
        #region Search method to Dealer or Customer in transaction Module
        public Dealer_CustomerBLL SearchDealerCustomerforTransaction(string keyword)
        {
            Dealer_CustomerBLL dc = new Dealer_CustomerBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT name, contactNo, age, address, email FROM Dealer_Customer WHERE dealer_customerId LIKE '%"+ keyword + "%' OR name LIKE '%" + keyword + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.contactNo = dt.Rows[0]["contactNo"].ToString();
                    dc.age = dt.Rows[0]["age"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
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
        #region Method to get Dealer_CustomerID based on Name
        public Dealer_CustomerBLL GetDealer_CustomerIdFromName(string Name)
        {
            Dealer_CustomerBLL dc = new Dealer_CustomerBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();    
            try
            {
                string sql = "SELECT dealer_customerId FROM Dealer_Customer WHERE name = '" + Name + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);


                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dc.dealer_customerId = int.Parse(dt.Rows[0]["dealer_customerId"].ToString());

                }
            }
            catch(Exception ex)
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

    }
}
