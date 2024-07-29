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
    public partial class createCategory : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_create_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Name = tb_name.Text;
            cat.SpecialID = tb_specialID.Text;
            if (fu_picture.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    cat.Image = isim + uzanti;
                    fu_picture.SaveAs(Server.MapPath("~/assets/images/product/" + isim + uzanti));
                    if (dm.CreateCategory(cat))
                    {
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true; 
                        tb_specialID.Text = "";
                        tb_name.Text = "";
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        lbl_mesaj.Text = "Kategori Ekleme Başarısız";
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
                cat.Image = "none.png";
                if (dm.CreateCategory(cat))
                {
                    pnl_basarisiz.Visible = false;
                    pnl_basarili.Visible = true;
                    tb_name.Text  = "";
                    tb_specialID.Text = "";
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Kategori Ekleme Başarısız";
                }
            }
            
        }
    }
}