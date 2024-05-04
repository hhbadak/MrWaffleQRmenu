using MenuAdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MrWaffleQRmenu.MrWaffleAdminPanelMenu
{
    public partial class waffle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            VeriDoldur();
        }

        public void VeriDoldur()
        {
            Product p = new Product();
            lv_listProduct.DataSource = dm.ProductListWaffle();
            lv_listProduct.DataBind();
        }

        protected void lv_listProduct_ItemCommand1(object sender, ListViewCommandEventArgs e)
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
    }
}