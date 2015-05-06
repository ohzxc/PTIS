using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_showbusdetail : System.Web.UI.Page
{
    public string result = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string busName = Request.QueryString["busname"].ToString();
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Bus WHERE qmbus_name=N'"+busName+"'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            result = sdr["qmbus_name"].ToString() + "：" + sdr["qmbus_rate"].ToString() + "；" + sdr["qmbus_ratebz"].ToString() + "；" + sdr["qmbus_starttime"].ToString() + "；" + sdr["qmbus_endtime"].ToString() + "；" + sdr["qmbus_class"].ToString();
        }
        cmd.CommandText = "SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + busName + "'";
        sdr.Close();
        sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            result += "<br />线路：<br />" + sdr["qmroute_address"].ToString();
        }
        sdr.Close();
    }
}