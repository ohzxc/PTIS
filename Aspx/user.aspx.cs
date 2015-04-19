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
       
    }
    //换乘查询(重写)
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if ((this.textqd.Text == "" || this.textqd.Text == null) && (this.textzd.Text == "" || this.textzd.Text == null))
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
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + busName + "'", con);
        SqlDataReader sdr = cmd.ExecuteReader();        
        if(busName==""||busName==null)
        {
            Response.Write("<script>alert('请输入公交名称！')</script>");
        }
        else
        {
            if (sdr.Read())
            {
                this.frmResult.Src = "showbus.aspx?busName=" + busName;
            }
        }
        sdr.Close();
        con.Close();
        //Response.Cookies["iframe"].Value = "xlcx";
    }
    //站点查询
    protected void btnFind_Click2(object sender, EventArgs e)
    {
        string ZDName = this.StationName.Text;
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Station WHERE qmstation_name=N'" + ZDName + "'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (ZDName == "" || ZDName == null)
        {
            Response.Write("<script>alert('请输入站点名！')</script>");
        }
        else
        {
            if (sdr.Read())
            {
                this.frmResult.Src = "showstation.aspx?StationName=" + ZDName;
            }
        }
        sdr.Close();
        con.Close();
        //Response.Cookies["iframe"].Value = "zdcx";
    }
}