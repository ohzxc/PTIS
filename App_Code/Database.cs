using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Database 的摘要说明
/// </summary>
public class Database
{
	public Database()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static SqlConnection createCon()
    {
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        return con;
    }
}