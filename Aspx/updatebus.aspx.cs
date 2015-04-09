using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_updatebus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["flag"] == null)
        {
            // Response.Redirect("admin.aspx");
        }
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT qmbus_name FROM Bus ORDER BY qmbus_name ASC", con);
        SqlDataReader bus = cmd.ExecuteReader();
        this.ddlBusName.DataSource = bus;
        this.ddlBusName.DataTextField = "qmbus_name";
        this.ddlBusName.DataValueField = "qmbus_name";
        this.ddlBusName.DataBind();
        bus.Close();
        con.Close();
    }

    private bool Check()
    {
        if (this.txtRate.Text == "" || this.ddlRatebz.Text == "" || this.txtStartTime.Text == "" || this.txtEndTime.Text == "" || this.txtRoute.Text == "")
            return false;
        return true;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Check())
        {
            SqlConnection con = Database.createCon();
            con.Open();
            //插入公交和路线信息
            SqlCommand cmd = new SqlCommand("INSERT INTO Bus(qmbus_name,qmbus_ratebz,qmbus_rate,qmbus_starttime,qmbus_endtime,qmbus_class)VALUES(N'" + this.ddlBusName.Text + "',N'" + this.ddlRatebz.Text + "',N'" + this.txtRate.Text + "','" + this.txtStartTime.Text + "','" + this.txtEndTime.Text + "',N'" + this.ddlBusClass.Text + "');INSERT INTO Route(qmroute_name,qmroute_address) VALUES(N'" + ddlBusName.Text + "',N'" + txtRoute.Text + "')", con);
            cmd.ExecuteNonQuery();
            //插入站点信息
            string[] aryStation = this.txtRoute.Text.Split('-');
            string busName = "";
            for (int i = 0; i < aryStation.Length; i++)
            {
                cmd.CommandText = "SELECT qmstation_bus FROM Station WHERE qmstation_name=N'" + aryStation[i] + "'";//"INSERT INTO Station(qmstation_bus,qmstation_name)VALUES(N'" + txtBusName.Text + "',N'" + aryStation[i] + "')";
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    busName = sdr.GetString(0);
                    cmd.CommandText = "UPDATE Station SET qmstation_bus=N'" + busName + "-" + ddlBusName.Text + "' WHERE qmstation_name=N'" + aryStation[i] + "'";
                    sdr.Close();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Station(qmstation_bus,qmstation_name)VALUES(N'" + ddlBusName.Text + "',N'" + aryStation[i] + "')";
                    sdr.Close();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Write("<script>alert('添加成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('请检查信息完整！')</script>");
        }
    }


}