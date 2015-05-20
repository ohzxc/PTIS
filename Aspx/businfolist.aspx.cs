using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Aspx_businfolist : System.Web.UI.Page
{
    private void dgDataBind()
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand(" SELECT * FROM Bus", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "dt");
        this.dgBusInfo.DataSource = ds.Tables["dt"].DefaultView;
        this.dgBusInfo.DataBind();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["flag"] == null))
        {
            Response.Redirect("admin.aspx");
        } 
        else if (!IsPostBack)
        {
            this.dgDataBind();
        }
    }
    //删除bus表和route表
    protected void dgBusInfo_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if(e.CommandName=="Delete")
        {
            if (dgBusInfo.Items.Count == 1)
            {
                if (dgBusInfo.CurrentPageIndex != 0)
                    dgBusInfo.CurrentPageIndex = dgBusInfo.CurrentPageIndex - 1;
            }
            SqlConnection con = Database.createCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE  FROM Bus WHERE qmbus_name=N'" + ((HyperLink)e.Item.Cells[1].Controls[0]).Text + "';DELETE FROM Route WHERE qmroute_name=N'" + ((HyperLink)e.Item.Cells[1].Controls[0]).Text + "'", con);
            cmd.ExecuteNonQuery();
            //Response.Write("<script>alert('删除完成！')</script>");
            this.dgDataBind();
            Response.Write("<script>alert('删除完成！')</script>");
        }
    }
    //分页事件
    protected void dgBusInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.dgBusInfo.CurrentPageIndex = e.NewPageIndex;
        this.dgDataBind();
    }
    //编辑公交信息
    protected void dgBusInfo_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("editbusinfo.aspx?BusName="+((HyperLink)e.Item.Cells[1].Controls[0]).Text);
    }
}