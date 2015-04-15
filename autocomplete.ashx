<%@ WebHandler Language="C#" Class="autocomplete" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class autocomplete : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
    }

    private void GetAutoComplete(HttpContext context)
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        string q = context.Request.QueryString["q"].ToString();
        sda.SelectCommand = new SqlCommand("SELECT qmstation_name FROM Station", con);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        int j=ds.Tables[0].Rows.Count;
        for (int i = 0; i < j; i++)
        {
            DataRow dr = ds.Tables[0].Rows[i];
            context.Response.Write(string.Format("{0}\n", dr["qmstation_name"]));
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}