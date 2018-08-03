using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Financiermaster : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            string id1 = Convert.ToInt32(GridView1.SelectedValue).ToString();
            using (gl.cmd = new SqlCommand("update Financiermaster set Financiername=@Financiername where Financier_id=@Financier_id", gl.con))
            {
                gl.cmd.Parameters.AddWithValue("@Financier_id", id1);
                gl.cmd.Parameters.AddWithValue("@Financiername", txtfinancier.Text);
                gl.con.Open();
                gl.cmd.ExecuteNonQuery();
                gl.con.Close();
                display();
                Label1.Text = "Sucessfully updated";
                txtfinancier.Text = "";
            }

        }
        else
        {
            using (gl.cmd = new SqlCommand("insert into Financiermaster values(@Financiername)", gl.con))
            {


                gl.cmd.Parameters.AddWithValue("@Financiername",txtfinancier.Text);
                gl.con.Open();
                gl.cmd.ExecuteNonQuery();
                gl.con.Close();
                display();
                Label1.Text = "Sucessfully submitted";
                txtfinancier.Text = "";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Financiermaster.aspx");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("Financiermaster", "Financier_id", "'" + idd + "'");
        display();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id1 = Convert.ToInt32(GridView1.SelectedValue).ToString();
        gl.query("SELECT * from  Financiermaster where Financier_id ='" + id1 + "'");
        txtfinancier.Text = gl.ds.Tables[0].Rows[0]["Financiername"].ToString();
        Button1.Text = "Update";

    }

    public void display()
    {
        gl.query("select * from Financiermaster");
        GridView1.DataSource = gl.ds;
        GridView1.DataBind();

    }

}