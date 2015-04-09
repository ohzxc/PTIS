using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Aspx_busroutelist : System.Web.UI.Page
{
    //数据绑定
    private void dgDataBind()
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand("SELECT * FROM Route", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "dt");
        this.dgBusRoute.DataSource = ds.Tables["dt"].DefaultView;
        this.dgBusRoute.DataBind();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.dgDataBind();
        }
    }
    //分页事件
    protected void dgBusRoute_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.dgBusRoute.CurrentPageIndex=e.NewPageIndex;
        this.dgDataBind();
    }
    protected void dgBusRoute_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("editbusroute.aspx?BusName=" + ((HyperLink)e.Item.Cells[1].Controls[0]).Text);
    }
}