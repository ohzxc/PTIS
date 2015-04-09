using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Aspx_deletebus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtBusName.Text == "" || txtBusName.Text == null)
        {
            Response.Write("<script>alert('请输入公交名称！')</script>");
        }
        else
        {
            SqlConnection con = Database.createCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bus WHERE qmbus_name=N'"+txtBusName.Text+"'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                sdr.Close();
                //删除公交和路线信息
                cmd.CommandText = "DELETE FROM Bus WHERE qmbus_name=N'" + txtBusName.Text + "';DELETE FROM Route WHERE qmroute_name=N'"+txtBusName.Text+"'";
                cmd.ExecuteNonQuery();
                //删除站点信息
                cmd.CommandText = "SELECT * FROM Station WHERE qmstation_bus LIKE('%"+txtBusName.Text+"%')";
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {

                }
                Response.Write("<script>alert('删除成功！')</script>");
            }
            else
            {
                sdr.Close();
                Response.Write("<script>alert('没有该交通工具！')</script>");
            }
            con.Close();
        }
    }
}