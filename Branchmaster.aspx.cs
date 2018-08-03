using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Branchmaster : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                gl.display("Branchmaster", GridView1);
            }
        }
        catch
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (Button1.Text == "update")
            {
                int idd = Convert.ToInt32(GridView1.SelectedValue);
                gl.update("Branchmaster", "branchname='" + txtbranch.Text + "',address='" + txtaddress.Text + "',phone='" + txtphone.Text + "',email='" + txtemail.Text + "'", "Branchid", "'" + idd + "'");
            }
            else
            {
                gl.insert1("Branchmaster","branchname, address, phone, email, date", "'" + txtbranch.Text + "','" + txtaddress.Text + "','" + txtphone.Text + "','" + txtemail.Text + "','" + txtdate.Text + "'");
            }
            gl.display("Branchmaster", GridView1);

            txtbranch.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            txtdate.Text = "";
        }
        catch
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Branchmaster.aspx");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Branchmaster", "Branchid", "'" + idd + "'");
            gl.display("Branchmaster", GridView1);
        }
        catch { }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            gl.read1("Branchmaster", "Branchid", "'" + id + "'");
            txtbranch.Text = gl.ds.Tables[0].Rows[0]["branchname"].ToString();
            txtaddress.Text = gl.ds.Tables[0].Rows[0]["address"].ToString();
            txtphone.Text = gl.ds.Tables[0].Rows[0]["phone"].ToString();
            txtemail.Text = gl.ds.Tables[0].Rows[0]["email"].ToString();
            txtdate.Text = gl.ds.Tables[0].Rows[0]["date"].ToString();
           

            Button1.Text = "update";
        }
        catch { }
    }
}