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
    private string startStation = "";
    private string endStation = "";
    private string[] startBusName = { };//所有通过起点的车辆
    private string[] endBusName = { };//所有同过终点的车辆
    private string[,] startBusAllStation = new string[5,100];//startBusName包含的所有站点
    private string[,] endBusAllStation = new string[5, 100];//endBusName包含的所有站点
    private string[] OnceHuanCheng/*一次换乘查询函数,返回直达车辆*/(string startStation, string endStation){
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
        //求交集
        return startBusName.Where(a => endBusName.Contains(a)).ToArray();
    }
    private ArrayList TwiceHuanCheng/*两次换乘查询函数，返回*/(string[] startBusName, string[] endBusName)
    {
        SqlConnection con = Database.createCon();
        con.Open();
        //读取所有startBusAllStation
        for (int i = 0; i < startBusName.Length; i++)
        {
            SqlCommand cmd = new SqlCommand("SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + startBusName[i] + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var tmp = sdr["qmroute_address"].ToString().Split('-');
                for (int j = 0; j < tmp.Length; j++)
                    startBusAllStation[i, j] = tmp[j];
            } 
            sdr.Close();
        }
        //读取所有endBusAllStaion
        for (int i = 0; i < endBusName.Length; i++)
        {
            SqlCommand cmd = new SqlCommand("SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + endBusName[i] + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var tmp = sdr["qmroute_address"].ToString().Split('-');
                for (int j = 0; j < tmp.Length; j++) 
                    endBusAllStation[i,j]=tmp[j];
            }
            sdr.Close();
        }
        ArrayList shareStation = new ArrayList();
        ArrayList shareBus = new ArrayList();
        for (int i = 0; i <= startBusAllStation.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= startBusAllStation.GetUpperBound(1); j++)
            {
                for (int m = 0; m <= endBusAllStation.GetUpperBound(0); m++)
                {
                    for (int n = 0; n <= endBusAllStation.GetUpperBound(1); n++)
                    {
                        if ((startBusAllStation[i, j] == endBusAllStation[m, n]) && endBusAllStation[m, n] != null)
                        {
                            result +="在"+startStation+"搭"+ startBusName[i] + "，在" + startBusAllStation[i, j] +"下车，换"+endBusName[m]+ "到达目的地<br />";
                        }
                    }
                }
            }
        }
        /*  foreach (string i in startBusAllStation)
          {
              foreach (string j in endBusAllStation)
              {
                  if (i == j)
                  {
                      shareStation.Add(i);
                      //result += startBusName[Array.IndexOf(i, startBusAllStation)];
                  }
              }
          }*/
        return shareStation;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        startStation = Request.QueryString["startstation"].ToString();
        endStation = Request.QueryString["endstation"].ToString();
        /*string[] startBusName={};
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
        */
        string[] shareBusName = OnceHuanCheng(startStation, endStation);
        SqlConnection con = Database.createCon();
        con.Open();
        if (shareBusName.Length != 0)
        {
            result += "从" + startStation + "到" + endStation + "的车次有:<br />";
            for (int i = 0; i < shareBusName.Length; i++)
            {
                SqlCommand cmd = new SqlCommand("SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + shareBusName[i] + "'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    result += shareBusName[i] + ":<br />" + sdr["qmroute_address"].ToString() + "<br />";
                sdr.Close();
            }
            con.Close();
            result = result.Replace(startStation, "<font color=red>" + startStation + "</font>");
            result = result.Replace(endStation, "<font color=red>" + endStation + "</font>");
        }
        else
        {
            var shareStation = TwiceHuanCheng(startBusName, endBusName);
            if (shareStation.Count != 0)
            {
                foreach (string i in shareStation)
                {
                    Array.Clear(shareBusName, 0, shareBusName.Length);
                    shareBusName = OnceHuanCheng(startStation, i);

                }
            }
            //开始二次换乘查询
            //比较过起点的路线过还是过终点的路线多，少的站点存finalStation，路线数组存finalBus
            /*SqlCommand cmd = new SqlCommand("SELECT qmstation_bus FROM Station WHERE qmstation_name=N'" + startStation + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            string[] startStationBus = { }, endStationBus = { };
            while(sdr.Read())
            {
                startStationBus = sdr["qmstation_bus"].ToString().Split('-');
            }
            sdr.Close();
            cmd.CommandText = "SELECT qmstation_bus FROM Station WHERE qmstation_name=N'" + endStation + "'";
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                endStationBus = sdr["qmstation_bus"].ToString().Split('-');
            }
            sdr.Close();
            var finalStaion = startStationBus.Length < endStationBus.Length ? endStation : startStation;
            var finalBus = startStationBus.Length < endStationBus.Length ? startStationBus : endStationBus;
            string strAvailableBus = "";
            string[] AvailableBus = { };
            for (int i = 0; i < finalBus.Length; i++)
            {
                var tmp = TwiceHuanCheng(finalStaion, finalBus[i]);
                if (tmp.Length != 0)
                    strAvailableBus += string.Join("-", tmp) + "-";
            }
            result = finalBus[0] + "转" + strAvailableBus;*/

        }
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