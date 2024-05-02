using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAdminPanel
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region ADMIN METHOD

        public Admin AdminLogin(string surname, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Admin WHERE Surname = @sname AND Password = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sname", surname);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID, Name, Surname, Password FROM Admin  WHERE Surname = @surname AND Password = @password";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@password", password);
                    //con.Open();//SAKIN YAPMA
                    SqlDataReader reader = cmd.ExecuteReader();
                    Admin a = new Admin();
                    while (reader.Read())
                    {
                        a.ID = reader.GetInt32(0);
                        a.Name = reader.GetString(1);
                        a.Surname = reader.GetString(2);
                        a.Password = reader.GetString(3);
                    }
                    return a;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        #endregion

        #region PRODUCT METHOD

        public bool CreateProduct(Product pro)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Products(Name, Description, Image, Price, CategoryID) VALUES(@name, @desc, @image, @price, @catid)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@desc", pro.Description);
                cmd.Parameters.AddWithValue("@image", pro.Image);
                cmd.Parameters.AddWithValue("@price", pro.Price);
                cmd.Parameters.AddWithValue("@catid", pro.CategoryID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }

        public List<Product> ProductList(int id)
        {
            List<Product> products = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, p.Image, p.Price, c.Name FROM Products AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID WHERE p.CategoryID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Image = reader.GetString(3);
                    p.Price = reader.GetInt32(4);
                    p.Category = reader.GetString(5);
                    products.Add(p);
                }
                return products;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public bool UpdateProduct(Product pro)
        {
            try
            {
                cmd.CommandText = "UPDATE Products SET Name = @name, Description=@desc, Image=@image, Price=@price, CategoryID = CategoryID WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", pro.ID);
                cmd.Parameters.AddWithValue("@baslik", pro.Name);
                cmd.Parameters.AddWithValue("@kategori_ID", pro.Description);
                cmd.Parameters.AddWithValue("@ozet", pro.Image);
                cmd.Parameters.AddWithValue("@icerik", pro.Price);

                con.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
