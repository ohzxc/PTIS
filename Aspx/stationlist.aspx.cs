using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Aspx_stationlist : System.Web.UI.Page
{
    //数据绑定
    private void dgDataBind()
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand("SELECT * FROM Station", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "dt");
        this.dgStationRoute.DataSource = ds.Tables["dt"].DefaultView;
        this.dgStationRoute.DataBind();
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
    protected void dgStationRoute_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.dgStationRoute.CurrentPageIndex = e.NewPageIndex;
        this.dgDataBind();
    }
}