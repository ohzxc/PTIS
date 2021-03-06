﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Aspx_adminlist : System.Web.UI.Page
{
    private void dgDataBind()
    {
        SqlConnection con = Database.createCon();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand("SELECT * FROM Admin", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "dt");
        this.dgAdmin.DataSource = ds.Tables["dt"].DefaultView;
        this.dgAdmin.DataBind();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["flag"] == null))
        {
            Response.Redirect("admin.aspx");
        }
        else if(!IsPostBack)
        {
            this.dgDataBind();
        }
    }
    protected void dgAdmin_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (dgAdmin.Items.Count == 1)
            {
                if (dgAdmin.CurrentPageIndex != 0)
                    dgAdmin.CurrentPageIndex = dgAdmin.CurrentPageIndex - 1;
            }
            SqlConnection con = Database.createCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Admin WHERE qmadmin_user=N'"+e.Item.Cells[1].Text+"'", con);
            cmd.ExecuteNonQuery();
            this.dgDataBind();
            Response.Write("<script>alert('删除完成！')</script>");
        }
    }
    protected void dgAdmin_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.dgAdmin.CurrentPageIndex = e.NewPageIndex;
        this.dgDataBind();
    }
    protected void dgAdmin_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("editadmin.aspx?user=" + e.Item.Cells[1].Text);
    }
}