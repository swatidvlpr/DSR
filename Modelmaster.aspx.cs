using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Modelmaster : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
            gl.ddl_select("Categorymaster", "Category_id,Categorynm", "Categorynm", "Category_id","0","'Select'",ddlcategory);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Button1.Text == "Update")
            {
                string id1 = Convert.ToInt32(GridView1.SelectedValue).ToString();
                using (gl.cmd = new SqlCommand("update Modelmaster set Modelnm=@Modelnm,Modelno=@Modelno,Category_id=@Category_id where Modelid=@Modelid", gl.con))
                {
                    gl.cmd.Parameters.AddWithValue("@Modelid", id1);
                    gl.cmd.Parameters.AddWithValue("@Modelnm", txtModel.Text);
                    gl.cmd.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                    gl.cmd.Parameters.AddWithValue("@Category_id", ddlcategory.SelectedValue);
                    gl.con.Open();
                    gl.cmd.ExecuteNonQuery();
                    gl.con.Close();
                    display();
                    Label1.Text = "Sucessfully updated";
                    txtModel.Text = "";
                }

            }
            else
            {
                using (gl.cmd = new SqlCommand("insert into Modelmaster(Modelnm,Modelno,Category_id) values(@Modelnm,@Modelno,@Category_id)", gl.con))
                {
                    gl.cmd.Parameters.AddWithValue("@Modelnm", txtModel.Text);
                    gl.cmd.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                    gl.cmd.Parameters.AddWithValue("@Category_id",ddlcategory.SelectedValue);
                    gl.con.Open();
                    gl.cmd.ExecuteNonQuery();
                    gl.con.Close();
                    display();
                    Label1.Text = "Sucessfully submitted";
                    txtModel.Text = "";
                }
            }
        }
        catch { }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Modelmaster.aspx");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Modelmaster", "Modelid", "'" + idd + "'");
            display();
        }
        catch { }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string id1 = Convert.ToInt32(GridView1.SelectedValue).ToString();
            gl.query("SELECT     dbo.Categorymaster.Category_id, dbo.Categorymaster.Categorynm, dbo.Modelmaster.Modelid, dbo.Modelmaster.Modelnm, dbo.Modelmaster.Modelno FROM   dbo.Categorymaster INNER JOIN   dbo.Modelmaster ON dbo.Categorymaster.Category_id = dbo.Modelmaster.Category_id where dbo.Modelmaster.Modelid ='" + id1 + "'");
            string cid = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
            for (int i = 0; i < ddlcategory.Items.Count; i++)
            {
                if (ddlcategory.Items[i].Value == cid)
                {
                    ddlcategory.Items[i].Selected = true;
                }
                else
                {
                    ddlcategory.Items[i].Selected = false;
                }

            }
                txtModel.Text = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
                txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
            Button1.Text = "Update";
        }
        catch { }
    }

    public void display()
    {
        try
        {
            gl.query("SELECT     dbo.Categorymaster.Category_id, dbo.Categorymaster.Categorynm, dbo.Modelmaster.Modelid, dbo.Modelmaster.Modelnm, dbo.Modelmaster.Modelno FROM   dbo.Categorymaster INNER JOIN   dbo.Modelmaster ON dbo.Categorymaster.Category_id = dbo.Modelmaster.Category_id");
            GridView1.DataSource = gl.ds;
            GridView1.DataBind();
        }
        catch { }
    }
}