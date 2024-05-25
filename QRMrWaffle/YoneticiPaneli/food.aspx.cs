using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMrWaffle.YoneticiPaneli
{
    public partial class food : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            VeriDoldur();
        }

        protected void lv_listProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.DeleteProduct(id);
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
                lbl_mesaj.Text = "Silme İşlemi Başarılı";
            }
        }
        public void VeriDoldur()
        {
            Product p = new Product();
            lv_listProduct.DataSource = dm.ProductListFood();
            lv_listProduct.DataBind();
        }
    }
}