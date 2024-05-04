using MenuAdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MrWaffleQRmenu
{
    public partial class food : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
                rp_food.DataSource = dm.ProductListFood();
                rp_food.DataBind();
        }
    }
}