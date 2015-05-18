using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;

public partial class Aspx_DisplayZDResult : System.Web.UI.Page
{
    public string result = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        /*string StationName = "";
        if (Request.QueryString["StationName"] != null)
        {
            StationName = Request.QueryString["StationName"].ToString();
        } */
        string StationName = Request.QueryString["StationName"].ToString();
        //ArrayList albus = new ArrayList();
        string buslist = "";
        string strRoute = "";
        //ArrayList alSatation = new ArrayList();
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT count(qmstation_bus) FROM Station WHERE qmstation_name=N'"+StationName+"'", con);
        if (System.Convert.ToInt32(cmd.ExecuteScalar()) <= 0)
        {
            result += "无此站点。";
            //Response.Write("<script>alert('无此站点')</script>");
            return;
        }
        cmd.CommandText = "SELECT qmstation_bus FROM Station WHERE qmstation_name=N'" + StationName + "'";
        SqlDataReader sdr = cmd.ExecuteReader();
        while  (sdr.Read())
        {
            //buslist = sdr["qmstation_bus"].ToString();
            buslist = sdr.GetString(0);
        }
        string[] arrbus = buslist.Split('-');
        sdr.Close();
        result += "经过" + StationName + "的线路有：<br />";
        for (int i = 0; i < arrbus.Length; i++)
        {
            strRoute="";
            cmd.CommandText = "SELECT qmroute_address FROM Route WHERE qmroute_name = N'" + arrbus[i]+"'";
            SqlDataReader sdrRoute = cmd.ExecuteReader();
            while (sdrRoute.Read())
            {
                strRoute=Convert.ToString(sdrRoute.GetValue(0));
            }
            sdrRoute.Close();
            result += "<strong>" + arrbus[i] + "</strong>：<br />" + strRoute + "<br />";
        }
        result = result.Replace(StationName, "<font color=red>" + StationName + "</font>");
    }
}