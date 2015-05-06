using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_adminguide : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignout_Click(object sender, EventArgs e)
    {
        Session["flag"] = null;
        Response.Redirect("~/Default.aspx");
    }
}