using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMrWaffle.YoneticiPaneli
{
    public partial class categories : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            VeriDoldur();
        }
        public void VeriDoldur()
        {
            Category c = new Category();
            lv_listCategory.DataSource = dm.ListCategory();
            lv_listCategory.DataBind();
        }

        protected void lv_listCategory_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.DeleteCategory(id);
                Response.Redirect("~/YoneticiPaneli/categories.aspx");
            }
        }
    }
}