﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRMrWaffle.YoneticiPaneli
{
    public partial class index : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                Admin a = (Admin)Session["yonetici"];

                rptCategories.DataSource = dm.ListActiveCategories();
                rptCategories.DataBind();
            }
            else
            {
                Response.Redirect("../YoneticiPaneli/sign.aspx");
            }
        }
    }
}