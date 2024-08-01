using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
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
        public List<Category> ListActiveCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                cmd.CommandText = "SELECT * FROM Category WHERE Active = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Active = reader.GetBoolean(2)
                    });
                }
            }
            finally
            {
                con.Close();
            }
            return categories;
        }

        public List<Product> ListProductsByCategory(int categoryID)
        {
            List<Product> products = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT * FROM Products WHERE CategoryID = @CategoryID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Image = reader.GetString(3);
                    p.Price = reader.GetString(4);
                    p.CategoryID = reader.GetInt32(5);
                    p.BestSeller = reader.GetBoolean(6);
                    products.Add(p);
                }
            }
            finally
            {
                con.Close();
            }
            return products;
        }

        public bool CreateProduct(Product pro)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Products(Name, Description, Image, Price, CategoryID, BestSellers) VALUES(@name, @desc, @image, @price, @catid, @bsell)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@desc", pro.Description);
                cmd.Parameters.AddWithValue("@image", pro.Image);
                cmd.Parameters.AddWithValue("@price", pro.Price);
                cmd.Parameters.AddWithValue("@catid", pro.CategoryID);
                cmd.Parameters.AddWithValue("@bsell", pro.BestSeller);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }

        public List<Product> ProductListBestSellers()
        {
            List<Product> products = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, p.Image, p.Price, c.Name FROM Products AS p JOIN Category AS c ON c.ID = p.CategoryID WHERE p.BestSellers = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Image = reader.GetString(3);
                    p.Price = reader.GetString(4);
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

        public List<Product> ProductList()
        {
            List<Product> products = new List<Product>();
            try
            {
                // SQL sorgusunu oluştur
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, p.Image, p.Price, p.CategoryID " +
                                  "FROM Products p " +
                                  "JOIN Category c ON p.CategoryID = c.ID " +
                                  "WHERE c.Active = 1";

                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Image = reader.GetString(3);
                    p.Price = reader.GetString(4);
                    p.CategoryID = reader.GetInt32(5);
                    p.BestSeller = reader.GetBoolean(6);
                    products.Add(p);
                }
            }
            catch
            {
                // Hata durumunda boş liste döndür
                products = new List<Product>();
            }
            finally
            {
                con.Close();
            }

            return products;
        }

        public List<Category> GetCategoriesWithProducts()
        {
            List<Category> categories = new List<Category>();

            try
            {
                // Kategorileri alın
                cmd.CommandText = "SELECT c.ID, c.Name, c.SpecialID, c.Image " +
                                  "FROM Category c " +
                                  "WHERE c.Active = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        SpecialID = reader.GetString(2),
                        Image = reader.GetString(3),
                        Products = new List<Product>() // Boş ürün listesi
                    };

                    categories.Add(category);
                }
                reader.Close(); // Verileri okuma tamamlandıktan sonra kapat

                // Ürünleri alın ve uygun kategorilere ekleyin
                foreach (var category in categories)
                {
                    cmd.CommandText = "SELECT p.ID, p.Name, p.Description, p.Image, p.Price " +
                                      "FROM Products p " +
                                      "WHERE p.CategoryID = @CategoryID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryID", category.ID);
                    SqlDataReader productReader = cmd.ExecuteReader();

                    while (productReader.Read())
                    {
                        Product product = new Product
                        {
                            ID = productReader.GetInt32(0),
                            Name = productReader.GetString(1),
                            Description = productReader.GetString(2),
                            Image = productReader.GetString(3),
                            Price = productReader.GetString(4),
                            CategoryID = category.ID
                        };

                        category.Products.Add(product);
                    }
                    productReader.Close(); // Ürünleri okuma tamamlandıktan sonra kapat
                }
            }
            catch (Exception ex)
            {
                // Hata işleme
                // Log veya mesaj olarak hata bilgilerini kullanabilirsiniz
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close(); // Bağlantıyı kapat
            }

            return categories;
        }

        public bool UpdateProduct(Product pro)
        {
            try
            {
                cmd.CommandText = "UPDATE Products SET Name = @name, Description=@desc, Image=@image, Price=@price, CategoryID = @catid, BestSellers = @bsell WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", pro.ID);
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@desc", pro.Description);
                cmd.Parameters.AddWithValue("@image", pro.Image);
                cmd.Parameters.AddWithValue("@price", pro.Price);
                cmd.Parameters.AddWithValue("@catid", pro.CategoryID);
                cmd.Parameters.AddWithValue("@bsell", pro.BestSeller);

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

        public bool DeleteProduct(int id)
        {
            try
            {
                cmd.CommandText = "DELETE Products WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
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

        public Product GetProduct(int id)
        {
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, p.Image, p.Price, p.CategoryID, c.Name, p.BestSellers FROM Products AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID WHERE p.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Product p = new Product();
                while (reader.Read())
                {
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Image = reader.GetString(3);
                    p.Price = reader.GetString(4);
                    p.CategoryID = reader.GetInt32(5);
                    p.Category = reader.GetString(6);
                    p.BestSeller = reader.GetBoolean(7);
                }
                return p;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region CATEGORY METHOD

        public List<Category> ListCategory()
        {
            List<Category> category = new List<Category>();
            try
            {
                cmd.CommandText = "SELECT * FROM Category";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category();
                    c.ID = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                    c.Active = reader.GetBoolean(2);
                    category.Add(c);
                }
                return category;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public List<Category> ListCategoryMenu()
        {
            List<Category> category = new List<Category>();
            try
            {
                cmd.CommandText = "SELECT * FROM Category WHERE Active = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category();
                    c.ID = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                    c.Active = reader.GetBoolean(2);
                    c.SpecialID = reader.GetString(3);
                    c.Image = reader.GetString(4);
                    category.Add(c);
                }
                return category;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                cmd.CommandText = "DELETE Category WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
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

        public bool ActiveCategory(int id)
        {
            try
            {
                // Mevcut durumu al
                cmd.CommandText = "SELECT Active FROM Category WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                bool currentStatus = (bool)cmd.ExecuteScalar();
                bool newStatus = !currentStatus;

                // Yeni durumu güncelle
                cmd.CommandText = "UPDATE Category SET Active = @newStatus WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@newStatus", newStatus);
                cmd.Parameters.AddWithValue("@id", id);
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


        public Category GetCategory(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Name, Active FROM Category WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Category c = new Category();
                while (reader.Read())
                {
                    c.ID = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                    c.Active = reader.GetBoolean(2);
                }
                return c;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateCategory(Category cat)
        {
            try
            {
                cmd.CommandText = "UPDATE Category SET Name = @name, Image = @image WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", cat.ID);
                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.Parameters.AddWithValue("@image", cat.Image);

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

        public bool CreateCategory(Category cat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Category(Name, Active, SpecialID, Image) VALUES(@name, 1, @ID, @image)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.Parameters.AddWithValue("@ID", cat.SpecialID);
                cmd.Parameters.AddWithValue("@image", cat.Image);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }
        #endregion

        #region PopUp METHOD
        public List<PopUp> Pop_UpList()
        {
            List<PopUp> products = new List<PopUp>();
            try
            {
                cmd.CommandText = "SELECT ID, Name, Image, Url FROM PopUp";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PopUp p = new PopUp();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Image = reader.GetString(2);
                    p.Url = reader.GetString(3);
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

        public PopUp GetPopUp()
        {
            try
            {
                cmd.CommandText = "SELECT ID, Name, Image, Url FROM PopUp";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                PopUp p = new PopUp();
                while (reader.Read())
                {
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Image = reader.GetString(2);
                    p.Url = reader.GetString(3);
                }
                return p;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdatePopUp(PopUp pop)
        {
            try
            {
                cmd.CommandText = "UPDATE PopUp SET Name = @name, Image=@image, Url=@url WHERE ID = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", pop.Name);
                cmd.Parameters.AddWithValue("@image", pop.Image);
                cmd.Parameters.AddWithValue("@url", pop.Url);

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
