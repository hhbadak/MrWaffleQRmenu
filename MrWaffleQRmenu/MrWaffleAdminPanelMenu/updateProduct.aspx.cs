using MenuAdminPanel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MrWaffleQRmenu.MrWaffleAdminPanelMenu
{
    public partial class updateProduct : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
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
                    tb_name.Text = p.Name;
                    tb_description.Text = p.Description;
                    tb_price.Text = p.Price;
                    img_image.ImageUrl = "../MrWaffleAdminPanelMenu/img/product/" + p.Image;
                }
            }
            else
            {
                Response.Redirect("../MrWaffleAdminPanelMenu/admin.aspx");
            }
        }

        protected void lbtn_create_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Product p = dm.GetProduct(id);
            p.Name = tb_name.Text;
            p.Description = tb_description.Text;
            p.Price = tb_price.Text;
            p.CategoryID = Convert.ToInt32(ddl_category.SelectedItem.Value);
            if (fu_picture.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    p.Image = isim + uzanti;
                    fu_picture.SaveAs(Server.MapPath("~/MrWaffleAdminPanelMenu/img/product" + isim + uzanti));
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                }
            }
            if (dm.UpdateProduct(p))
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
                lbl_mesaj.Text = "Ürün Düzenleme Başarısız";
            }
        }
    }
}