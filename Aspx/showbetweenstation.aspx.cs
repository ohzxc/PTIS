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
        ArrayList busName = new ArrayList();
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
        result = result.Replace(endStation, "<font color=red>" + endStation + "</font>");
    }
}