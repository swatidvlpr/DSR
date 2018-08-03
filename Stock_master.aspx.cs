using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Stock_master : System.Web.UI.Page
{
    global gl = new global();
    public SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString());
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
            gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcmpnynm);
         //        gl.ddl_select("Categorymaster", "Category_id,Categorynm", "Categorynm", "Category_id", "0", "'Select'", ddlctgrynm);
         //        gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", ddlmdlnm);             
        }
   }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        if (Button1.Text == "update")
        {
            int idd = Convert.ToInt32(GridView1.SelectedValue);
            gl.update("Stock_master", "Company_id='" + ddlcmpnynm.SelectedValue + "',Category_id='" + ddlctgrynm.SelectedValue + "',Modelnm='" + ddlmdlnm.SelectedItem.Text + "',Model_no='" + txtmdlno.Text + "',Opening_stock='" + txtopng.Text + "',Purchase='" + txtpurchage.Text + "',Sale='" + txtsale.Text + "',Stack='" + txtstock.Text + "',Date='" + txtdate.Text + "'", "Stock_id", "'" + idd + "'");
            Label1.Text = "Updated Successfully";
        }
        else
        {
            gl.query("select * from Stock_master where Company_id='" + ddlcmpnynm.SelectedValue + "' and Category_id='" + ddlctgrynm.SelectedValue + "' and Modelnm='" + ddlmdlnm.SelectedItem.Text + "'");
            if (gl.ds.Tables[0].Rows.Count == 0)
            {
                //Company_id,                       Category_id,                         Modelnm,                        Model_no,               Opening_stock,          Purchase,                  sale,                Stack,                     Date
                gl.insert("Stock_master", "'" + ddlcmpnynm.SelectedValue + "','" + ddlctgrynm.SelectedValue + "','" + ddlmdlnm.SelectedItem.Text + "','" + txtmdlno.Text + "','" + txtopng.Text + "','" + txtpurchage.Text + "','" + txtsale.Text + "','" + txtstock.Text + "','" + txtdate.Text + "'");
                Label1.Text = "Submitted Successfully";
            }
            else
            {
                //gl.update("Stock_master", "Company_id='" + ddlcmpnynm.SelectedValue + "',Category_id='" + ddlctgrynm.SelectedValue + "',Modelnm='" + ddlmdlnm.SelectedItem.Text + "',Model_no='" + txtmdlno.Text + "',Opening_stock='" + txtopng.Text + "',Purchase='" + txtpurchage.Text + "',Sale='" + txtsale.Text + "',Stack='" + txtstock.Text + "',Date='" + txtdate.Text + "'", "Stock_id", "'" + idd + "'");
                
                gl.query("update Stock_master set Opening_stock='" + txtopng.Text + "',sale='" + txtpurchage.Text + "',Stack='" + txtstock.Text + "' where Company_id='" + ddlcmpnynm.SelectedValue + "' and Category_id='" + ddlctgrynm.SelectedValue + "'  and Modelnm='" + ddlmdlnm.SelectedItem.Text + "'");

                Label1.Text = "Updated Successfully";
            }
        }
        //gl.display("Unsaleable_vehicles", GridView1);
        display();
        ddlcmpnynm.SelectedItem.Text = "";
        ddlctgrynm.SelectedItem.Text = "";
        ddlmdlnm.SelectedItem.Text = "";
        txtmdlno.Text = "";
        txtopng.Text = "0";
        txtpurchage.Text = "0";
       
        txtsale.Text = "0";
        txtstock.Text = "0";
        txtdate.Text = "";
        Button1.Text = "submit";
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Stock_master.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
        gl.read1("Stock_master", "Stock_id", "'" + idd + "'");
        //string companyname = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();

        //for (int i = 0; i < ddlcmpnynm.Items.Count; i++)
        //{
        //    if (ddlcmpnynm.Items[i].Value == companyname)
        //    {
        //        ddlcmpnynm.Items[i].Selected = true;
        //    }
        //    else
        //    {
        //        ddlcmpnynm.Items[i].Selected = false;
        //    }
        //}
        //string Categorynm = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();

        //for (int i = 0; i < ddlctgrynm.Items.Count; i++)
        //{
        //    if (ddlctgrynm.Items[i].Value == Categorynm)
        //    {
        //        ddlctgrynm.Items[i].Selected = true;
        //    }
        //    else
        //    {
        //        ddlctgrynm.Items[i].Selected = false;
        //    }
        //}

        string Company_id = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();

        for (int i = 0; i < ddlcmpnynm.Items.Count; i++)
        {
            if (ddlcmpnynm.Items[i].Value == Company_id)
            {
                ddlcmpnynm.Items[i].Selected = true;
                da = new SqlDataAdapter("select Category_id,Categorynm,companyid from Categorymaster where companyid='" + Company_id + "'", con);
                da.Fill(ds);
                ddlctgrynm.DataSource = ds;
                ddlctgrynm.DataTextField = "Categorynm";
                ddlctgrynm.DataValueField = "Category_id";
                ddlctgrynm.DataBind();

            }
            else
            {
                ddlcmpnynm.Items[i].Selected = false;
            }
        }

        //string Category_id = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        //if (ddlCategory.Items.FindByValue(Category_id) != null)
        //{

        //    ddlCategory.Items.FindByValue(Category_id).Selected = true;
        //}
        string cte_name = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        for (int ii = 0; ii < ddlctgrynm.Items.Count; ii++)
        {
            if (ddlctgrynm.Items[ii].Value == cte_name)
            {
                ddlctgrynm.Items[ii].Selected = true;
                ds.Reset();
                da = new SqlDataAdapter("select Modelid,Modelnm,Category_id from Modelmaster where Category_id='" + cte_name + "'", con);
                da.Fill(ds);
                ddlmdlnm.DataSource = ds;
                ddlmdlnm.DataTextField = "Modelnm";
                ddlmdlnm.DataValueField = "Modelid";
                ddlmdlnm.DataBind();

            }
            else
            {
                ddlctgrynm.Items[ii].Selected = false;
            }
        }

        string Modelnm = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();

        for (int i = 0; i < ddlmdlnm.Items.Count; i++)
        {
            if (ddlmdlnm.Items[i].Text == Modelnm)
            {
                ddlmdlnm.Items[i].Selected = true;
            }
            else
            {
                ddlmdlnm.Items[i].Selected = false;
            }
        }

        ddlcmpnynm.SelectedValue = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();
        ddlctgrynm.SelectedValue = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        //ddlmdlnm.SelectedValue = gl.ds.Tables[0].Rows[0]["Modelid"].ToString();
        txtmdlno.Text = gl.ds.Tables[0].Rows[0]["Model_no"].ToString();
        txtopng.Text = gl.ds.Tables[0].Rows[0]["Opening_stock"].ToString();
        txtpurchage.Text = gl.ds.Tables[0].Rows[0]["Purchase"].ToString();
        //txtcrntstck.Text = gl.ds.Tables[0].Rows[0]["Current_stock"].ToString();
        txtsale.Text = gl.ds.Tables[0].Rows[0]["Sale"].ToString();
        txtstock.Text = gl.ds.Tables[0].Rows[0]["Stack"].ToString();
        txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
        Button1.Text = "update";
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("Stock_master", "Stock_id", "'" + id1 + "'");
        //gl.display("Unsaleable_vehicles", GridView1);
        display();
    }
    protected void ddlmdlnm_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.query("select * from Modelmaster where Modelnm='" + ddlmdlnm.SelectedItem.Text + "'");
        txtmdlno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();

        ds.Clear();
        da = new SqlDataAdapter("select * from Stock_master where Company_id='" + ddlcmpnynm.SelectedValue + "' and Category_id='" + ddlctgrynm.SelectedValue + "' and Modelnm='"+ddlmdlnm.SelectedItem.Text+"'", con);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            txtopng.Text = "0";
        }
        else
        {
            txtopng.Text = ds.Tables[0].Rows[0]["Stack"].ToString();
        }
    }
    protected void txtprvsstck_TextChanged(object sender, EventArgs e)
    {
        int openingbal = Convert.ToInt32(txtopng.Text);
        int purchagebal = Convert.ToInt32(txtpurchage.Text);
        int sales = Convert.ToInt32(txtsale.Text);

        int stock1 = openingbal + purchagebal;
        int stock = stock1 - sales;
        txtstock.Text = stock.ToString();
        txtopng.Text = stock.ToString();
       // txtstock.Text = txtopng.Text;
        txtsale.Text = "0";
    }
 
    protected void txtsale_TextChanged(object sender, EventArgs e)
    {
        int openingbal = Convert.ToInt32(txtopng.Text);
        int purchagebal = Convert.ToInt32(txtpurchage.Text);
        int sales = Convert.ToInt32(txtsale.Text);
        int stock = openingbal + purchagebal - sales;
        txtstock.Text = stock.ToString();

    }   
   
    public void display()
    {
        gl.query("select * from Stockdeisplay");
        GridView1.DataSource = gl.ds;
        GridView1.DataBind();
    }
    protected void ddlcmpnynm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcmpnynm.SelectedValue + "'", ddlctgrynm);
        }
        catch
        {
        }
    }
    protected void ddlctgrynm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlctgrynm.SelectedValue + "'", ddlmdlnm);
        }
        catch
        {
        }
    }

    protected void txtopng_TextChanged(object sender, EventArgs e)
    {
        int openingbal = Convert.ToInt32(txtopng.Text);
        int purchagebal = Convert.ToInt32(txtpurchage.Text);
        int sales = Convert.ToInt32(txtsale.Text);
        int stock = openingbal + purchagebal - sales;
        txtstock.Text = stock.ToString();
       
    }
    protected void txtstock_TextChanged(object sender, EventArgs e)
    {

    }
}