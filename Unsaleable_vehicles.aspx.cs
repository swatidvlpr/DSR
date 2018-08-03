using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSR_Unsaleable_vehicles : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
            gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcmpnynm);
            //gl.ddl_select("Categorymaster", "Category_id,Categorynm", "Categorynm", "Category_id", "0", "'Select'", ddlctgrynm);
            //gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", ddlmdlnm);           

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "update")
        {
            int idd = Convert.ToInt32(GridView1.SelectedValue);
            gl.update("Unsaleable_vehicles", "Company_id='" + ddlcmpnynm.SelectedValue + "',Category_id='" + ddlctgrynm.SelectedValue + "',Modelid='" + ddlmdlnm.SelectedValue + "',Model_no='" + txtmdlno.Text + "',Color='" + txtcolor.Text + "',Engine_no='" + txtegnno.Text + "', VIN_no='" + txtvinno.Text + "',  Date='" + txtdate.Text + "'", "Unsale_id", "'" + idd + "'");
            Label1.Text = "Updated Successfully";
        }
        else
        {
                                                          //Company_id,              Category_id,                        Modelid,                          Model_no,                         Color,               Engine_no,               VIN_no,           Date
            gl.insert("Unsaleable_vehicles", "'" + ddlcmpnynm.SelectedValue + "','" + ddlctgrynm.SelectedValue+ "','" + ddlmdlnm.SelectedValue + "','" + txtmdlno.Text + "','" + txtcolor.Text + "','" + txtegnno.Text + "','" + txtvinno.Text + "','" + txtdate.Text + "'");

            Label1.Text = "Submitted Successfully";
        }
       
        display();
        ddlcmpnynm.SelectedItem.Text = "";
        ddlctgrynm.SelectedItem.Text = "";
        ddlmdlnm.SelectedItem.Text = "";
        txtmdlno.Text = "";
        txtcolor.Text = "";
        txtegnno.Text = "";
        txtvinno.Text = "";       
        txtdate.Text = "";
        Button1.Text = "submit";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Unsaleable_vehicles.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
        gl.read1("Unsaleable_vehicles", "Unsale_id", "'" + idd + "'");
        string companyname = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();

        for (int i = 0; i < ddlcmpnynm.Items.Count; i++)
        {
            if (ddlcmpnynm.Items[i].Text == companyname)
            {
                ddlcmpnynm.Items[i].Selected = true;
            }
            else
            {
                ddlcmpnynm.Items[i].Selected = false;
            }
        }
        string Categorynm = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();

        for (int i = 0; i < ddlctgrynm.Items.Count; i++)
        {
            if (ddlctgrynm.Items[i].Text == Categorynm)
            {
                ddlctgrynm.Items[i].Selected = true;
            }
            else
            {
                ddlctgrynm.Items[i].Selected = false;
            }
        }
        string Modelid = gl.ds.Tables[0].Rows[0]["Modelid"].ToString();

        for (int i = 0; i < ddlmdlnm.Items.Count; i++)
        {
            if (ddlmdlnm.Items[i].Text == Modelid)
            {
                ddlmdlnm.Items[i].Selected = true;
            }
            else
            {
                ddlmdlnm.Items[i].Selected = false;
            }
        }
       
        ddlcmpnynm.SelectedValue= gl.ds.Tables[0].Rows[0]["Company_id"].ToString();
        ddlctgrynm.SelectedValue = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        ddlmdlnm.SelectedValue = gl.ds.Tables[0].Rows[0]["Modelid"].ToString();
        txtmdlno.Text = gl.ds.Tables[0].Rows[0]["Model_no"].ToString();
        txtcolor.Text = gl.ds.Tables[0].Rows[0]["Color"].ToString();
        txtegnno.Text = gl.ds.Tables[0].Rows[0]["Engine_no"].ToString();
        txtvinno.Text = gl.ds.Tables[0].Rows[0]["VIN_no"].ToString();       
        txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
        Button1.Text = "update";
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("Unsaleable_vehicles", "Unsale_id", "'" + id1 + "'");
        
        display();
        
    } 
   
    public void display()
    {
        gl.query("SELECT dbo.companymaster.companyname, dbo.Categorymaster.Categorynm, dbo.Modelmaster.Modelnm, dbo.Unsaleable_vehicles.Unsale_id,dbo.Unsaleable_vehicles.Model_no, dbo.Unsaleable_vehicles.Color, dbo.Unsaleable_vehicles.Engine_no, dbo.Unsaleable_vehicles.VIN_no, dbo.Unsaleable_vehicles.Date FROM  dbo.Unsaleable_vehicles INNER JOIN dbo.companymaster ON dbo.Unsaleable_vehicles.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Categorymaster ON dbo.Unsaleable_vehicles.Category_id = dbo.Categorymaster.Category_id INNER JOIN dbo.Modelmaster ON dbo.Unsaleable_vehicles.Modelid = dbo.Modelmaster.Modelid");
        GridView1.DataSource = gl.ds;
        GridView1.DataBind();

    }

    protected void ddlmdlnm_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.query("select * from Modelmaster where Modelnm='" + ddlmdlnm.SelectedItem.Text + "'");
        txtmdlno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
    }
    protected void ddlcmpnynm_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcmpnynm.SelectedValue + "'", ddlctgrynm);
        //gl.query("SELECT Category_id, companyid, Categorynm FROM  dbo.Categorymaster where companyid='" + ddlcmpnynm.SelectedValue + "' union select 0,0,'select'");
        //ddlctgrynm.DataSource = gl.ds;
        //ddlctgrynm.DataValueField = "Category_id";
        //ddlctgrynm.DataTextField = "Categorynm";
        //ddlctgrynm.DataBind();
    }
    protected void ddlctgrynm_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlctgrynm.SelectedValue + "'", ddlmdlnm);
        //gl.query("SELECT Modelid, Category_id, Modelnm FROM  dbo.Modelmaster where Category_id='" + ddlctgrynm.SelectedValue + "' union select 0,0,0,'select'");
        //ddlmdlnm.DataSource = gl.ds;
        //ddlmdlnm.DataValueField = "Modelid";
        //ddlmdlnm.DataTextField = "Modelnm";
        //ddlmdlnm.DataBind();
    }
}