using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_addbus : System.Web.UI.Page
{
    #region 窗体加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["flag"] == null)
        {
           // Response.Redirect("admin.aspx");
        }
    }
    #endregion

    #region 自定义方法
    private bool Check()
    {
        if (this.txtBusName.Text==""||this.txtRate.Text==""||this.ddlRatebz.Text==""||this.txtStartTime.Text==""||this.txtEndTime.Text==""||this.txtRoute.Text=="")
            return false;
        return true;
    }
    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Check())
        {
            SqlConnection con = Database.createCon();
            con.Open();
            //检查是否重名
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bus WHERE qmbus_name=N'" + this.txtBusName.Text + "'", con);
            if (System.Convert.ToInt32(cmd.ExecuteScalar())>0)
            {
                Response.Write("<script>alert('公交已存在，请点击“公交信息列表”进行管理！')</script>");
                return;
            }
            //插入公交和路线信息
            cmd.CommandText= "INSERT INTO Bus(qmbus_name,qmbus_ratebz,qmbus_rate,qmbus_starttime,qmbus_endtime,qmbus_class)VALUES(N'" + this.txtBusName.Text + "',N'" + this.ddlRatebz.Text + "',N'" + this.txtRate.Text + "','" + this.txtStartTime.Text + "','" + this.txtEndTime.Text + "',N'" + this.ddlBusClass.Text + "');INSERT INTO Route(qmroute_name,qmroute_address) VALUES(N'" + txtBusName.Text + "',N'" + txtRoute.Text + "')";
            cmd.ExecuteNonQuery();
            //插入站点信息
            string[] aryStation=this.txtRoute.Text.Split('-');
            string busName = "";
            for (int i = 0; i < aryStation.Length; i++)
            {
                cmd.CommandText = "SELECT qmstation_bus FROM Station WHERE qmstation_name=N'"+aryStation[i]+"'";//"INSERT INTO Station(qmstation_bus,qmstation_name)VALUES(N'" + txtBusName.Text + "',N'" + aryStation[i] + "')";
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    busName = sdr.GetString(0);
                    cmd.CommandText = "UPDATE Station SET qmstation_bus=N'"+busName+"-"+txtBusName.Text+"' WHERE qmstation_name=N'"+aryStation[i]+"'";
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
            Response.Write("<script>alert('添加成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('请检查信息完整！')</script>");
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage.aspx");
    }
}