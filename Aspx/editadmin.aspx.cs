using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_editadmin : System.Web.UI.Page
{
    private void htmlDataBind(string strUsername)
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Admin WHERE qmadmin_user=N'"+strUsername+"'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            this.txtUsername.Text = sdr["qmadmin_user"].ToString();
            this.txtNickname.Text = sdr["qmadmin_name"].ToString();
        }
        sdr.Close();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = Request.QueryString["user"].ToString();
            this.htmlDataBind(userName);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE Admin SET qmadmin_user=N'" + this.txtUsername.Text + "',qmadmin_name=N'" + this.txtNickname.Text + "',qmadmin_pass=N'" + this.txtPSWD.Text + "' WHERE qmadmin_user=N'" + Request.QueryString["user"].ToString() + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        htmlDataBind(Request.QueryString["user"].ToString());
    }
}