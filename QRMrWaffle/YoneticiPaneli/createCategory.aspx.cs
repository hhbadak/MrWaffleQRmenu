using DataAccessLayer;
using System;
using System.Collections.Generic;
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
            cat.Active = cb_best.Checked;
            if (dm.CreateCategory(cat))
            {
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
                tb_name.Text = "";
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