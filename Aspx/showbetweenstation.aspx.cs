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
    public string result = "";//要显示的查询结果
    private string startStation = "";
    private string endStation = "";
    private string[] startBusName = { };//所有通过起点的车辆
    private string[] endBusName = { };//所有同过终点的车辆
    private string[,] startBusAllStation = new string[5,100];//startBusName包含的所有站点
    private string[,] endBusAllStation = new string[5, 100];//endBusName包含的所有站点
    private string[] OnceHuanCheng/*直达查询函数,返回直达车辆*/(string startStation, string endStation){
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
    private void TwiceHuanCheng/*换乘一次查询函数*/(string[] startBusName, string[] endBusName)
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
        string tmpResult = "";
        for (int i = 0; i < startBusName.Length; i++)
        {
            for (int m = 0; m < endBusName.Length; m++ )
            {
                for (int j = 0; j <= startBusAllStation.GetUpperBound(1); j++)
                {
                    for (int n = 0; n <= endBusAllStation.GetUpperBound(1); n++)
                    {
                        if ((startBusAllStation[i, j] == endBusAllStation[m, n]) && endBusAllStation[m, n] != null)
                        {
                            tmpResult += startBusAllStation[i, j] + @"\";
                            //result += "在" + startStation + "搭" + startBusName[i] + "，在" + startBusAllStation[i, j] + "下车，换" + endBusName[m] + "到达目的地<br />";
                        }
                    }
                    if (j == startBusAllStation.GetUpperBound(1))
                    {
                        if (tmpResult.Length != 0)
                        {
                            tmpResult = tmpResult.Substring(0, tmpResult.Length - 1);
                            result += "<a href=showbusdetail.aspx?busname=" + startBusName[i] + " target=blank><strong>" + startBusName[i] + "</strong></a>-<a href=showbusdetail.aspx?busname=" + endBusName[m] + " target=blank><strong>" + endBusName[m] + "</strong></a>：<br />" + "在" + startStation + "搭<font color=red>" + startBusName[i] + "</font>，<br />在<font color=red>" + tmpResult + "</font>下车，<br />换<font color=red>" + endBusName[m] + "</font>到达目的地" + endStation + "。<br /><br />";
                        }
                        tmpResult = "";
                    }
                }
            }
        }
        if (result.Length < 1)
        {
            result = "无结果";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        startStation = Request.QueryString["startstation"].ToString();
        endStation = Request.QueryString["endstation"].ToString();
        if (startStation == endStation)
        {
            result += "同一站点还搭车啊？";
            return;
        }
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
            result += "从" + startStation + "到" + endStation + "的直达线路有:<br />";
            for (int i = 0; i < shareBusName.Length; i++)
            {
                SqlCommand cmd = new SqlCommand("SELECT qmroute_address FROM Route WHERE qmroute_name=N'" + shareBusName[i] + "'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    result += @"<a href=showbusdetail.aspx?busname=" + shareBusName[i] + @" target=blank><strong>" + shareBusName[i] + "</strong></a>:<br />" + sdr["qmroute_address"].ToString() + "<br />";
                sdr.Close();
            }
            con.Close();
            result = result.Replace(startStation, "<font color=red>" + startStation + "</font>");
            result = result.Replace(endStation, "<font color=red>" + endStation + "</font>");
        }
        else
        {
            TwiceHuanCheng(startBusName, endBusName);
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