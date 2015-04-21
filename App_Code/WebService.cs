using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    //private string[] autoComplete =null ;
    [WebMethod]
    public string[] GetTextString(string prefixText, int count)
   {
       if (string.IsNullOrEmpty(prefixText) == true)
           return null;
       else //if (autoComplete == null)
       {
           SqlConnection con = Database.createCon();
           con.Open();
           SqlDataAdapter sda = new SqlDataAdapter();
           sda.SelectCommand = new SqlCommand("SELECT qmstation_name From Station WHERE qmstation_name LIKE N'%"+prefixText+"%'", con);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           string[] temp = new string[ds.Tables[0].Rows.Count];
           int i=0;
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               temp[i] = dr["qmstation_name"].ToString();
               i++;               
           }
           return temp;
       }
       //else return null;
    }
    [WebMethod]
    public string[] GetTextString2(string prefixText, int count)
    {
        if (string.IsNullOrEmpty(prefixText) == true)
            return null;
        else //if (autoComplete == null)
        {
            SqlConnection con = Database.createCon();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = new SqlCommand("SELECT qmbus_name From Bus WHERE qmbus_name LIKE N'%" + prefixText + "%'", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            string[] temp = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                temp[i] = dr["qmbus_name"].ToString();
                i++;
            }
            return temp;
        }
        //else return null;
    }

}
