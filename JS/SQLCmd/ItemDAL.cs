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
    class ItemDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Item
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Item";
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
        #region Insert Item
        public bool Insert(ItemBLL c)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO Item (itemName, itemType, itemCategory, itemCondition, itemPrice, itemQuantity, added_Date) VALUES (@itemName, @itemType, @itemCategory, @itemCondition, @itemPrice, @itemQuantity, @added_Date)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@itemName", c.itemName);
                cmd.Parameters.AddWithValue("@itemType", c.itemType);
                cmd.Parameters.AddWithValue("@itemCategory", c.itemCategory);
                cmd.Parameters.AddWithValue("@itemCondition", c.itemCondition);
                cmd.Parameters.AddWithValue("@itemPrice", c.itemPrice);
                cmd.Parameters.AddWithValue("@itemQuantity", c.itemQuantity);
                cmd.Parameters.AddWithValue("@added_Date", c.added_Date);

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
        #region Update Item
        public bool Update(ItemBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Item SET itemName = @itemName, itemType = @itemType, itemCategory = @itemCategory, itemCondition = @itemCondition, itemPrice = @itemPrice, added_Date = @added_Date WHERE itemId = @itemId";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@itemName", c.itemName);
                cmd.Parameters.AddWithValue("@itemType", c.itemType);
                cmd.Parameters.AddWithValue("@itemCategory", c.itemCategory);
                cmd.Parameters.AddWithValue("@itemCondition", c.itemCondition);
                cmd.Parameters.AddWithValue("@itemPrice", c.itemPrice);
                cmd.Parameters.AddWithValue("@added_Date", c.added_Date);

                cmd.Parameters.AddWithValue("@itemId", c.itemId);

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
        #region Update Stock 
        public bool UpdateStock(ItemBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Item SET itemQuantity = @itemQuantity, added_Date = @added_Date WHERE itemId = @itemId";
                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@itemQuantity", c.itemQuantity);
                cmd.Parameters.AddWithValue("@added_Date", c.added_Date);
                cmd.Parameters.AddWithValue("@itemId", c.itemId);

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
        #region Delete Item 
        public bool Delete(ItemBLL c)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Item WHERE itemId = @itemId";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@itemId", c.itemId);

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
        #region Search Item
        public DataTable Search(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Item WHERE itemId LIKE '%" + keywords + "%' OR itemName LIKE'%" + keywords + "%' OR itemType LIKE'%" + keywords + "%' OR itemCategory LIKE'%" + keywords + "%' OR itemCondition LIKE'%" + keywords + "%' OR itemPrice LIKE'%" + keywords + "%' OR itemQuantity LIKE'%" + keywords + "%' OR added_Date LIKE'%" + keywords + "%'";
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
        #region Method to search Item in Transaction 
        public ItemBLL GetItemForTransaction(string keyword)
        {
            ItemBLL p = new ItemBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            
            try
            {
                string sql = "SELECT itemName, itemType, itemCategory, itemPrice, itemQuantity FROM Item WHERE itemId LIKE '%" + keyword + "%' OR itemName LIKE '%" + keyword + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    p.itemName = dt.Rows[0]["itemName"].ToString();
                    p.itemType = dt.Rows[0]["itemType"].ToString();
                    p.itemCategory = dt.Rows[0]["itemCategory"].ToString();
                    p.itemPrice = decimal.Parse(dt.Rows[0]["itemPrice"].ToString());
                    p.itemQuantity = decimal.Parse(dt.Rows[0]["itemQuantity"].ToString());
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

            return p;
        }
        #endregion
        #region Method to get itemId based on itemName
        public ItemBLL GetitemIdFromitemName(string itemName)
        {
            ItemBLL itmb = new ItemBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT itemId FROM Item WHERE itemName = '" + itemName + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    itmb.itemId = int.Parse(dt.Rows[0]["itemId"].ToString());

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

            return itmb;
        }

        #endregion
        #region Method to get current itemQuantity from the Database based on itemId
        public decimal GetItemQuantity(int itemId)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            decimal itemQuantity = 0;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT itemQuantity FROM Item WHERE itemId = " + itemId;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    itemQuantity = decimal.Parse(dt.Rows[0]["itemQuantity"].ToString());
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
            return itemQuantity;
        }
        #endregion
        #region Method to update itemQuantity
        public bool UpdateItemQuantity(int itemId, decimal itemQuantity)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Item SET itemQuantity = @itemQuantity WHERE itemId = @itemId";
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@itemQuantity", itemQuantity);
                cmd.Parameters.AddWithValue("@itemId", itemId);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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
            return success;
        }
        #endregion
        #region Method to increase Item
        public bool IncreaseItem(int itemId, decimal IncreaseQty)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                decimal currentQuantity = GetItemQuantity(itemId);
                decimal NewQty = currentQuantity + IncreaseQty;
                success = UpdateItemQuantity(itemId, NewQty);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Open();
            }
            return success;
        }
        #endregion
        #region Method to decrease Item
        public bool DecreaseItem(int itemId, decimal itemQuantity)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                decimal currentQty = GetItemQuantity(itemId);
                decimal NewQty = currentQty - itemQuantity;
                success = UpdateItemQuantity(itemId, NewQty);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return success;
        }
        #endregion
        #region Method to Display Item based on itemCategory
        public DataTable DisplayItemCategory(string itemCategory)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Item WHERE itemCategory ='" + itemCategory + "'";
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
