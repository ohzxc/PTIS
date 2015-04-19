using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;

public partial class Aspx_showbetweenstation : System.Web.UI.Page
{
    public string result;
    protected void Page_Load(object sender, EventArgs e)
    {
        string startStation = Request.QueryString["startstation"].ToString();
        string endStation = Request.QueryString["endstation"].ToString();
        string[] startBusName={};
        string[] endBusName={};
        SqlConnection con = Database.createCon();
        con.Open();
        //下面找到过起点的所有公交路线
        SqlCommand cmd = new SqlCommand("SELECT * FROM Station WHERE qmstation_name=N'" + startStation + "'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            startBusName = sdr["qmstation_bus"].ToString().Split('-');
        }
        sdr.Close();
        //下面找通过终点的所有路线
        cmd.CommandText = "SELECT * FROM Station WHERE qmstation_name=N'" + endStation + "'";
        sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            endBusName = sdr["qmstation_bus"].ToString().Split('-');
        }
        sdr.Close();
        var shareBusName = startBusName.Where(a => endBusName.Contains(a)).ToArray();
        if (shareBusName.Length != 0)
        {
            result += "从" + startStation + "到" + endStation + "的车次有:<br />";
            for (int i = 0; i < shareBusName.Length; i++)
            {
                cmd.CommandText = "SELECT qmroute_address FROM Route WHERE qmroute_name=N'"+shareBusName[i]+"'";
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    result += shareBusName[i] + ":<br />" + sdr["qmroute_address"].ToString() + "<br />";
                sdr.Close();
            }
            result = result.Replace(startStation, "<font color=red>" + startStation + "</font>");
            result = result.Replace(endStation, "<font color=red>" + endStation + "</font>");
        }
        else
        {
            Response.Write("<script>alert('没有直达公交,待处理')</script>");
        }
        con.Close();
        /*ArrayList busName = new ArrayList();
        ArrayList busRoute = new ArrayList();
        //string busAddress = "";
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT qmroute_name,qmroute_address FROM Route WHERE qmroute_address LIKE N'" + startStation + "-" + endStation + "-%' OR qmroute_address LIKE N'" + startStation + "-%-" + endStation + "-%'OR qmroute_address LIKE N'" + startStation + "-%-" + endStation + "'OR qmroute_address LIKE N'%-" + startStation + "-" + endStation + "-%'OR qmroute_address LIKE N'%-" + startStation + "-%-" + endStation + "-%'OR qmroute_address LIKE N'%-" + startStation + "-%-" + endStation + "'OR qmroute_address LIKE N'%-" + startStation + "-" + endStation + "'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            busName.Add(sdr.GetValue(0));
            busRoute.Add(sdr.GetValue(1));
            //busAddress = sdr.GetString(0);
        }
        sdr.Close();
        result += "从" + startStation + "到" + endStation + "的车次有:<br />";
        for (int i = 0; i < busName.Count; i++)
        {
            result += busName[i] + ":<br />" + busRoute[i] + "<br />";
        }
        result = result.Replace(startStation, "<font color=red>" + startStation + "</font>");
        result = result.Replace(endStation, "<font color=red>" + endStation + "</font>");*/
    }
}