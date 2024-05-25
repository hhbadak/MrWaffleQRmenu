using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMrWaffle
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataModel dm = new DataModel();
            rp_best.DataSource = dm.ProductListBestSellers();
            rp_best.DataBind();
            rp_waffle.DataSource = dm.ProductListWaffle();
            rp_waffle.DataBind();
            rp_cake.DataSource = dm.ProductListCake();
            rp_cake.DataBind();
            rp_coffee.DataSource = dm.ProductListCoffee();
            rp_coffee.DataBind();
            rp_hot.DataSource = dm.ProductListHotDrink();
            rp_hot.DataBind();
            rp_cold.DataSource = dm.ProductListColdDrink();
            rp_cold.DataBind();
            rp_coctail.DataSource = dm.ProductListCoctail();
            rp_coctail.DataBind();
            rp_food.DataSource = dm.ProductListFood();
            rp_food.DataBind();
        }
    }
}