using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMrWaffle.YoneticiPaneli
{
    public partial class sign : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_login_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tb_surname.Text) && !string.IsNullOrEmpty(tb_password.Text))
            {
                Admin y = dm.AdminLogin(tb_surname.Text, tb_password.Text);
                if (y != null)
                {
                    Session["yonetici"] = y;
                    Response.Redirect("../YoneticiPaneli/index.aspx");

                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hata.Text = "Kullanıcı Bulunamadı";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hata.Text = "Kullanıcı Adı ve Şifre Boş olamaz";
            }
        }
    }
}