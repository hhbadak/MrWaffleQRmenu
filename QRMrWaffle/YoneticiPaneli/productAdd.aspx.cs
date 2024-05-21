using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMrWaffle.YoneticiPaneli
{
    public partial class productAdd : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_category.DataTextField = "Name";
                ddl_category.DataValueField = "ID";
                ddl_category.DataSource = dm.ListCategory();
                ddl_category.DataBind();
            }
        }

        protected void lbtn_create_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_category.SelectedItem.Value) != 0)
            {
                Product pro = new Product();
                pro.CategoryID = Convert.ToInt32(ddl_category.SelectedItem.Value);
                pro.Name = tb_name.Text;
                pro.Description = tb_description.Text;
                pro.Price = tb_price.Text;
                pro.BestSeller = cb_best.Checked;
                if (fu_picture.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_picture.FileName);
                    if (fi.Extension == ".jpg" || fi.Extension == ".png")
                    {
                        string uzanti = fi.Extension;
                        string isim = Guid.NewGuid().ToString();
                        pro.Image = isim + uzanti;
                        fu_picture.SaveAs(Server.MapPath("~/assets/images/product/" + isim + uzanti));
                        if (dm.CreateProduct(pro))
                        {
                            pnl_basarisiz.Visible = false;
                            pnl_basarili.Visible = true;
                            tb_description.Text = tb_name.Text = tb_price.Text = "";
                            ddl_category.SelectedValue = "0";
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            pnl_basarili.Visible = false;
                            lbl_mesaj.Text = "Ürün Ekleme Başarısız";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                    }
                }
                else
                {
                    pro.Image = "none.png";
                    if (dm.CreateProduct(pro))
                    {
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                        tb_price.Text = tb_name.Text = tb_description.Text = "";
                        ddl_category.SelectedValue = "0";
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        lbl_mesaj.Text = "Ürün Ekleme Başarısız";
                    }
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Kategori seçimi yapmalısınız";
            }
        }
    }
}