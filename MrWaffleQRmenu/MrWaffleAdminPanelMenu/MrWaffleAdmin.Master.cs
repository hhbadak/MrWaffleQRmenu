using MenuAdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MrWaffleQRmenu.MrWaffleAdminPanelMenu
{
    public partial class MrWaffleAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                Admin a = (Admin)Session["yonetici"];
            }
            else
            {
                Response.Redirect("../MrWaffleAdminPanelMenu/admin.aspx");
            }
        }
    }
}