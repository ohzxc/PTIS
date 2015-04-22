using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_showBus : System.Web.UI.Page
{
    public string result = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string busName = Request.QueryString["busName"].ToString();
        string busAddress = "";
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT count(qmroute_address) FROM Route WHERE qmroute_name=N'" + busName + "'",con);
        if (System.Convert.ToInt32(cmd.ExecuteScalar()) <= 0)
        {
            Response.Write("<script>alert('无此车次！')</script>");
            return;
        }
        cmd.CommandText = "SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + busName + "'";
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            busAddress = sdr.GetString(0);
        }
        sdr.Close();
        result += busName + "的路线为：<br />"+busAddress+"。";
    }
}