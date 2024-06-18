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
    public partial class updatePopUp : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopUp p = dm.GetPopUp();
                tb_name.Text = p.Name;
                tb_url.Text = p.Url;
                img_picture.ImageUrl = "~/assets/images/popUp/" + p.Image;
            }
        }

        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            PopUp pop = dm.GetPopUp();
            pop.Name = tb_name.Text;
            pop.Url = tb_url.Text;
            if (fu_picture.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    pop.Image = isim + uzanti;
                    fu_picture.SaveAs(Server.MapPath("~/assets/images/popUp/" + isim + uzanti));
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                }
            }
            if (dm.UpdatePopUp(pop))
            {
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
                lbl_mesaj.Text = "Ürün Ekleme Başarılı";
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