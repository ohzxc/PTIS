using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Aspx_addadmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.txtNickname.Text == "" || this.txtUsername.Text == "" || this.txtPSWD.Text == "")
        {
            Response.Write("<script>alert('请检查信息完整！')</script>");
        }
        else
        {
            SqlConnection con = Database.createCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Admin WHERE qmadmin_user=N'" + this.txtUsername.Text + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Response.Write("<script>alert('改用户名已存在！')</script>");
                sdr.Close();
                con.Close();
                return;
            }
            else
            {
                cmd.CommandText = "INSERT INTO Admin(qmadmin_user,qmadmin_name,qmadmin_pass)VALUES(N'" + this.txtUsername.Text + "',N'" + this.txtNickname.Text + "',N'"+this.txtPSWD.Text+"')";
                sdr.Close();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('添加成功！')</script>");
                con.Close();
            }
        }
    }
}