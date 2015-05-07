using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Aspx_editbusroute : System.Web.UI.Page
{
    private void htmlDataBind(string strBusName)
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Route WHERE qmroute_name=N'"+strBusName+"'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            //Response.Write("<script>alert('读取成功!')</script>");
            this.txtBusName.Text = sdr["qmroute_name"].ToString();
            this.txtRoute.Text = sdr["qmroute_address"].ToString();
        }
        sdr.Close();
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
            string busName = Request.QueryString["BusName"].ToString();
            htmlDataBind(busName);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (this.txtBusName.Text == "" || this.txtRoute.Text == "")
        {
            Response.Write("<script>alert('请检查信息完整')</script>");
        }
        else
        {
            SqlConnection con = Database.createCon();
            con.Open();
            //更新路线信息
            SqlCommand cmd = new SqlCommand("UPDATE Route SET qmroute_name=N'"+this.txtBusName.Text+"',qmroute_address=N'"+this.txtRoute.Text+"' WHERE qmroute_name=N'"+Request.QueryString["BusName"].ToString()+"'",con);
            cmd.ExecuteNonQuery();
            //缺少更新站点信息
            con.Close();
        }
    }
}