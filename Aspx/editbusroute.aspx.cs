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
            //删除旧路线信息且更新路线信息
            var AddressList = this.txtRoute.Text.Split('-');
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UPDATE Station SET qmstation_bus = REPLACE(qmstation_bus,N'-" + this.txtBusName.Text + "-','') WHERE qmstation_bus like N'%-" + this.txtBusName.Text + "-%';UPDATE Station SET qmstation_bus = REPLACE(qmstation_bus,N'" + this.txtBusName.Text + "-','') WHERE qmstation_bus like N'%" + this.txtBusName.Text + "-%';UPDATE Station SET qmstation_bus = REPLACE(qmstation_bus,N'-" + this.txtBusName.Text + "','') WHERE qmstation_bus like N'%-" + this.txtBusName.Text + "%';DELETE  FROM Station WHERE qmstation_bus=N'" + this.txtBusName.Text + "';UPDATE Route SET qmroute_name=N'"+this.txtBusName.Text+"',qmroute_address=N'"+this.txtRoute.Text+"' WHERE qmroute_name=N'"+Request.QueryString["BusName"].ToString()+"'";
            cmd.ExecuteNonQuery();
            //加入新站点信息，此处于添加公交有重复代码
            string[] aryStation = this.txtRoute.Text.Split('-');
            string busName = "";
            for (int i = 0; i < aryStation.Length; i++)
            {
                cmd.CommandText = "SELECT qmstation_bus FROM Station WHERE qmstation_name=N'" + aryStation[i] + "'";
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    busName = sdr.GetString(0);
                    cmd.CommandText = "UPDATE Station SET qmstation_bus=N'" + busName + "-" + txtBusName.Text + "' WHERE qmstation_name=N'" + aryStation[i] + "'";
                    sdr.Close();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Station(qmstation_bus,qmstation_name)VALUES(N'" + txtBusName.Text + "',N'" + aryStation[i] + "')";
                    sdr.Close();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Write("<script>alert('修改成功！')</script>");
            con.Close();
        }
    }
}