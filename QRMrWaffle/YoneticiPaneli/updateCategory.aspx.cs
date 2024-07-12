using DataAccessLayer;
using System;
using System.Collections.Generic;
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
                cb_active.Checked = c.Active;
            }
        }

        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);

            Category cat = dm.GetCategory(id);
            cat.Name = tb_name.Text;
            cat.Active = cb_active.Checked;

            if (dm.UpdateCategory(cat))
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