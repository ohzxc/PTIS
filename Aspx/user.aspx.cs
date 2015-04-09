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

    protected void btnExchange_Click(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('查询成功！')</script>");
        /*if (this.xlframe.Style.Value == "display:block")
        {
            Response.Write("<script>alert('运行成功xl！')</script>");
        }
        else if (this.zdframe.Style.Value == "display:block")
        {
            Response.Write("<script>alert('运行成功！zd')</script>");
        }
        else Response.Write("<script>alert('运行成功！')</script>");*/
        string startStation = this.textqd.Value;
        string endStation = this.textzd.Value;
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT qmroute_address FROM Route WHERE qmroute_address LIKE N'" + startStation + "-" + endStation + "-%' OR qmroute_address LIKE N'" + startStation + "-%-" + endStation + "-%'OR qmroute_address LIKE N'" + startStation + "-%-" + endStation + "'OR qmroute_address LIKE N'%-" + startStation + "-" + endStation + "-%'OR qmroute_address LIKE N'%-" + startStation + "-%-" + endStation + "-%'OR qmroute_address LIKE N'%-" + startStation + "-%-" + endStation + "'OR qmroute_address LIKE N'%-" + startStation + "-" + endStation + "'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if ((startStation == "" || startStation == null) && (endStation == "" || endStation == null))
        {
            Response.Write("<script>alert('请完整输入起点和终点')</script>");
        }
        else
        {
            if (sdr.Read())
            {
                Response.Write("<script>alert('查询成功！')<script>");
                this.frmResult.Src="showbetweenstation?startstation="+startStation+"&endstation="+endStation;
            }
        }
        con.Close();
        sdr.Close();
    }
    protected void btnFind_Click1(object sender, EventArgs e)
    {
        string busName = this.txtLineName.Value;
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + busName + "'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        //int count = Convert.ToInt32(cmd.ExecuteScalar());
        
        if(busName==""||busName==null)
        {
            Response.Write("<script>alert('请输入公交名称！')</script>");
        }
        else
        {
            if (sdr.Read())
            {
                Response.Write("<script>alert('查询成功,！')</script>");
                this.frmResult.Src = "showbus.aspx?busName=" + busName;
            }
        }
        con.Close();
        sdr.Close();

    }
    protected void btnFind_Click2(object sender, EventArgs e)
    {
        string ZDName = this.StationName.Value;
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Station WHERE qmstation_name=N'" + ZDName + "'", con);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        if (ZDName == "" || ZDName == null)
        {
            Response.Write("<script>alert('请输入站点名！')</script>");
        }
        else
        {
            if (count !=null)
            {
                Response.Write("<script>alert('查询成功,！')</script>");
                this.frmResult.Src = "showstation.aspx?StationName=" + ZDName;
            }
            else
            {
                Response.Write("<script>alert('无结果！')<script>");
            }
        }


    }
}