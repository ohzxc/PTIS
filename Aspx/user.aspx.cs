using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Form.DefaultButton = this.btnFind.UniqueID;
    }
    //换乘查询(重写)
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (this.textqd.Text == "" || this.textzd.Text == "")
        {
            Response.Write("<script>alert('请完整输入起点和终点')</script>");
        }
        else
            this.frmResult.Src = "showbetweenstation?startstation=" + this.textqd.Text + "&endstation=" + this.textzd.Text;
        //Response.Cookies["iframe"].Value = "hccx";
    }
    //线路查询
    protected void btnFind_Click1(object sender, EventArgs e)
    {
        string busName = this.txtLineName.Text;
        if(busName==""||busName==null)
        {
            Response.Write("<script>alert('请输入公交名称！')</script>");
            return;
        }
        else
        {
            this.frmResult.Src = "showbus.aspx?busName=" + busName;
        }
        //Response.Cookies["iframe"].Value = "xlcx";
    }
    //站点查询
    protected void btnFind_Click2(object sender, EventArgs e)
    {
        string ZDName = this.StationName.Text;
        if (ZDName == "" || ZDName == null)
        {
            Response.Write("<script>alert('请输入站点名！')</script>");
        }
        else
        {
            this.frmResult.Src = "showstation.aspx?StationName=" + ZDName;
        }
        //Response.Cookies["iframe"].Value = "zdcx";
    }
}