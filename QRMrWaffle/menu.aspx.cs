using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
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

            rp_categories.DataSource = dm.ListCategoryMenu();
            rp_categories.DataBind();

            rp_menuCategory.DataSource = dm.GetCategoriesWithProducts(); // Kategoriler ve ürünler
            rp_menuCategory.DataBind();


            rp_popUp.DataSource = dm.Pop_UpList();
            rp_popUp.DataBind();
        }
       

        protected void rp_menuCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var category = e.Item.DataItem as Category;

                if (category != null)
                {
                    Repeater rp_menuProduct = e.Item.FindControl("rp_menuProduct") as Repeater;

                    if (rp_menuProduct != null)
                    {
                        rp_menuProduct.DataSource = category.Products;
                        rp_menuProduct.DataBind();
                    }
                }
            }
        }
    }
}