using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Aspx_editbusinfo : System.Web.UI.Page
{
    private void htmlDataBind( string strBusName)
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Bus WHERE qmbus_name=N'"+strBusName+"'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            Response.Write("<script>alert('读取成功！')</script>");
            this.txtBusName.Text = sdr["qmbus_name"].ToString();
            //类型
            this.ddlBusClass.SelectedIndex = ddlBusClass.Items.IndexOf(ddlBusClass.Items.FindByValue(sdr["qmbus_class"].ToString()));
            //票制
            this.ddlRatebz.SelectedIndex = ddlRatebz.Items.IndexOf(ddlRatebz.Items.FindByValue(sdr["qmbus_ratebz"].ToString()));
            this.txtRate.Text = sdr["qmbus_rate"].ToString();
            this.txtStartTime.Text = sdr["qmbus_starttime"].ToString();
            this.txtEndTime.Text = sdr["qmbus_endtime"].ToString();
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
    private bool Check()
    {
        if (this.txtBusName.Text == "" || this.ddlRatebz.Text == "" || this.txtStartTime.Text == "" || this.txtEndTime.Text == "" )
            return false;
        return true;
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (Check())
        {
            SqlConnection con = Database.createCon();
            con.Open();
            //更新公交信息
            SqlCommand cmd = new SqlCommand("UPDATE Bus SET qmbus_name = N'" + this.txtBusName.Text + "',qmbus_rate=N'"+this.txtRate.Text+"',qmbus_ratebz=N'"+this.ddlRatebz.Text+"',qmbus_starttime=N'"+this.txtStartTime.Text+"',qmbus_endtime=N'"+this.txtEndTime.Text+"',qmbus_class=N'"+this.ddlBusClass.Text+"' WHERE qmbus_name = N'" + Request.QueryString["BusName"].ToString() + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}