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
    public partial class updateCategory : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                Category c = dm.GetCategory(id);

                tb_name.Text = c.Name;
                img_picture.ImageUrl = "~/assets/images/product/" + c.Image;
            }
        }

        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);

            Category cat = dm.GetCategory(id);
            cat.Name = tb_name.Text;
            if (fu_picture.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    cat.Image = isim + uzanti;
                    fu_picture.SaveAs(Server.MapPath("~/assets/images/product/" + isim + uzanti));
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg ve .jpeg veya .png olmalıdır";
                }
            }
            else
            {
                // GetImage metodu bir Category nesnesi döndürdüğü için önce bu nesneyi alıyoruz
                Category category = dm.GetImage(id);

                if (category != null) // Null kontrolü
                {
                    cat.Image = category.Image; // Category nesnesinden Image özelliğini alıyoruz
                }
                else
                {
                    cat.Image = "none.png"; // Eğer GetImage null dönerse varsayılan bir değer atıyoruz
                }
            }

            if (dm.UpdateCategory(cat))
            {
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
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