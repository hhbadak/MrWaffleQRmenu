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
    public partial class updateProduct : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                ddl_category.DataTextField = "Name";
                ddl_category.DataValueField = "ID";
                ddl_category.DataSource = dm.ListCategory();
                ddl_category.DataBind();

                Product p = dm.GetProduct(id);

                ddl_category.SelectedValue = p.CategoryID.ToString();
                tb_description.Text = p.Description;
                tb_price.Text = p.Price;
                tb_name.Text = p.Name;
                cb_best.Checked = p.BestSeller;
                img_picture.ImageUrl = "~/assets/images/product/" + p.Image;
            }
        }

        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);

            Product pro = dm.GetProduct(id);
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
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                }
            }
            if (dm.UpdateProduct(pro))
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
}