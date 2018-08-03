using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Oppertunity : System.Web.UI.Page
{
    global gl = new global();
    public SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString());
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        if (!IsPostBack)
        {
            display();
            gl.query("select Emp_id,EmployeeCode,Departmentnm,Name from Employee_Reg where Departmentnm='Sale' union select 0,'0','0','Select' order by Emp_id");
            ddlsales.DataSource = gl.ds;
            ddlsales.DataTextField = "Name";
            ddlsales.DataValueField = "EmployeeCode";
            ddlsales.DataBind();
            gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);
            gl.ddl_select("Purchaseplanmaster", "Purchaseplan_id,Purchaseplan", "Purchaseplan", "Purchaseplan_id", "'0'", "'Select'", ddlpurchageplan);
            gl.ddl_select("Sourcemaster", "Source_id,Sourcename", "Sourcename", "Source_id", "'0'", "'Select'",ddlenquirysource);
            //gl.ddl_select("Enquryform", "Enquryid,Customer_name", "Customer_name", "Enquryid", "'0'", "'Select'", ddlcustomer);
            gl.query("Select Enquryid,Status,Customer_name from Enquryform where Status='Opportunity'");
            ddlcustomer.DataSource = gl.ds;
            ddlcustomer.DataTextField = "Customer_name";
            ddlcustomer.DataValueField = "Enquryid";
            ddlcustomer.DataBind();
            ddlcustomer.SelectedIndex = 0;


            gl.ddl_select("Financiermaster", "Financier_id,Financiername", "Financiername", "Financier_id", "'0'", "'Select'", ddlfinancier);
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", ddlbranch);
        }
        //}
        //catch
        //{

        //}
    }

    public void display()
    {
        gl.usepro("pro_Oppertunity", "");
        GridView1.DataSource = gl.ds;
        GridView1.DataBind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Oppertunity", "Opportunity_id", "'" + idd + "'");
            display();
        }
        catch { }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
            gl.query("select Emp_id,EmployeeCode,Departmentnm,Name from Employee_Reg where Departmentnm='Sale' union select 0,'0','0','Select' order by Emp_id");
            ddlsales.DataSource = gl.ds;
            ddlsales.DataTextField = "Name";
            ddlsales.DataValueField = "EmployeeCode";
            ddlsales.DataBind();
            gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);
            gl.ddl_select("Purchaseplanmaster", "Purchaseplan_id,Purchaseplan", "Purchaseplan", "Purchaseplan_id", "'0'", "'Select'", ddlpurchageplan);
            gl.ddl_select("Sourcemaster", "Source_id,Sourcename", "Sourcename", "Source_id", "'0'", "'Select'", ddlenquirysource);
            gl.ddl_select("Enquryform", "Enquryid,Customer_name", "Customer_name", "Enquryid", "'0'", "'Select'", ddlcustomer);

            string id1 = Convert.ToInt32(GridView1.SelectedValue).ToString();
            gl.usepro("return_Oppertunity", "'" + id1 + "'");

            string saleid = gl.ds.Tables[0].Rows[0]["Saleman_id"].ToString();
            string Customer_id1 = gl.ds.Tables[0].Rows[0]["Customer_id"].ToString();
            string Company_id1 = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();
            txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();

            string cid = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
            string Modelname1 = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();

            string Purchase_plan1 = gl.ds.Tables[0].Rows[0]["Purchase_plan"].ToString();
            string Enquiry_source1 = gl.ds.Tables[0].Rows[0]["Enquiry_source"].ToString();
            string Finacier1 = gl.ds.Tables[0].Rows[0]["Finacier"].ToString();
            string branchid = gl.ds.Tables[0].Rows[0]["Branchid"].ToString();

            for (int i = 0; i < ddlsales.Items.Count; i++)
            {
                if (ddlsales.Items[i].Value == saleid)
                {
                    ddlsales.Items[i].Selected = true;
                }
                else
                {
                    ddlsales.Items[i].Selected = false;
                }
            }

            for (int i = 0; i < ddlcustomer.Items.Count; i++)
            {
                if (ddlcustomer.Items[i].Value == Customer_id1)
                {
                    ddlcustomer.Items[i].Selected = true;
                }
                else
                {
                    ddlcustomer.Items[i].Selected = false;
                }
            }

            for (int i = 0; i < ddlcompany.Items.Count; i++)
            {
                if (ddlcompany.Items[i].Value == Company_id1)
                {
                    ddlcompany.Items[i].Selected = true;
                    da = new SqlDataAdapter("select Category_id,Categorynm,companyid from Categorymaster where companyid='" + Company_id1 + "'", con);
                    da.Fill(ds);
                    ddlCategory.DataSource = ds;
                    ddlCategory.DataTextField = "Categorynm";
                    ddlCategory.DataValueField = "Category_id";
                    ddlCategory.DataBind();

                }
                else
                {
                    ddlcompany.Items[i].Selected = false;
                }
            }

            for (int i = 0; i < ddlCategory.Items.Count; i++)
            {
                if (ddlCategory.Items[i].Value == cid)
                {
                    ddlCategory.Items[i].Selected = true;
                    ds.Reset();
                    da = new SqlDataAdapter("select Modelid,Modelnm,Category_id from Modelmaster where Category_id='" + cid + "'", con);
                    da.Fill(ds);
                    ddlmodelnm.DataSource = ds;
                    ddlmodelnm.DataTextField = "Modelnm";
                    ddlmodelnm.DataValueField = "Modelid";
                    ddlmodelnm.DataBind();
                }
                else
                {
                    ddlCategory.Items[i].Selected = false;
                }

            }


            for (int i = 0; i < ddlmodelnm.Items.Count; i++)
            {
                if (ddlmodelnm.Items[i].Value == Modelname1)
                {
                    ddlmodelnm.Items[i].Selected = true;
                }
                else
                {
                    ddlmodelnm.Items[i].Selected = false;
                }

            }

            for (int i = 0; i < ddlpurchageplan.Items.Count; i++)
            {
                if (ddlpurchageplan.Items[i].Text == Purchase_plan1)
                {
                    ddlpurchageplan.Items[i].Selected = true;
                }
                else
                {
                    ddlpurchageplan.Items[i].Selected = false;
                }

            }

            for (int i = 0; i < ddlenquirysource.Items.Count; i++)
            {
                if (ddlenquirysource.Items[i].Text == Enquiry_source1)
                {
                    ddlenquirysource.Items[i].Selected = true;
                }
                else
                {
                    ddlenquirysource.Items[i].Selected = false;
                }

            }

            for (int i = 0; i < ddlfinancier.Items.Count; i++)
            {
                if (ddlfinancier.Items[i].Text == Finacier1)
                {
                    ddlfinancier.Items[i].Selected = true;
                }
                else
                {
                    ddlfinancier.Items[i].Selected = false;
                }

            }

            for (int i = 0; i < ddlbranch.Items.Count; i++)
            {
                if (ddlbranch.Items[i].Value == branchid)
                {
                    ddlbranch.Items[i].Selected = true;
                }
                else
                {
                    ddlbranch.Items[i].Selected = false;
                }

            }

            txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
            txtquantity.Text = gl.ds.Tables[0].Rows[0]["Quantity"].ToString();
            txtcolor.Text = gl.ds.Tables[0].Rows[0]["Color"].ToString();
            //txtcustomercomparingprice.Text = Convert.ToDecimal(rate).ToString("N");
            Button1.Text = "Update";
        //}
        //catch { }
    }



    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcompany.SelectedValue + "'", ddlCategory);
            ddlCategory.SelectedIndex = 0;
        }
        catch
        {
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gl.ddlcond("Modelmaster", "Modelnm","Modelid", "Category_id", "'" + ddlCategory.SelectedValue + "'", ddlmodelnm);
            ddlmodelnm.SelectedIndex = 0;
        }
        catch
        {
        }
    }
    protected void ddlmodelnm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gl.query("select * from Modelmaster where Modelid='" + ddlmodelnm.SelectedValue + "'");
            txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
        }
        catch
        {
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{

        if (Button1.Text == "Update")
        {
            int idd = Convert.ToInt32(GridView1.SelectedValue);
            using (SqlCommand cmd1 = new SqlCommand("Update Oppertunity set Company_id=@Company_id,Category_id=@Category_id,Modelnm=@Modelnm,Modelno=@Modelno,Color=@Color,Quantity=@Quantity,Purchase_plan=@Purchase_plan,Enquiry_source=@Enquiry_source,Finacier=@Finacier,Date=@Date,Saleman_id=@Saleman_id,Customer_id=@Customer_id,Branchid=@Branchid where Opportunity_id=@Opportunity_id", gl.con))
            {
                cmd1.Parameters.AddWithValue("@Opportunity_id", idd);
                cmd1.Parameters.AddWithValue("@Company_id", ddlcompany.SelectedValue);
                cmd1.Parameters.AddWithValue("@Category_id", ddlCategory.SelectedValue);
                cmd1.Parameters.AddWithValue("@Modelnm", ddlmodelnm.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                cmd1.Parameters.AddWithValue("@Color", txtcolor.Text);
                cmd1.Parameters.AddWithValue("@Quantity", txtquantity.Text);

                cmd1.Parameters.AddWithValue("@Purchase_plan", ddlpurchageplan.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@Enquiry_source", ddlenquirysource.SelectedItem.Text);

                cmd1.Parameters.AddWithValue("@Finacier", ddlfinancier.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@Date", txtdate.Text);
                cmd1.Parameters.AddWithValue("@Saleman_id", ddlsales.SelectedValue);
                cmd1.Parameters.AddWithValue("@Customer_id", ddlcustomer.SelectedValue);
                cmd1.Parameters.AddWithValue("@Branchid", ddlbranch.SelectedValue);
                gl.con.Open();
                cmd1.ExecuteNonQuery();
                gl.con.Close();
                Label2.Text = "Updatted Sucessfully";
                //...
            }

        }
        else
        {

            using (SqlCommand cmd1 = new SqlCommand("insert into Oppertunity(Company_id,Category_id, Modelnm, Modelno, Color, Quantity, Purchase_plan, Enquiry_source, Finacier, Date, Saleman_id, Customer_id,Branchid) values(@Company_id,@Category_id,@Modelnm,@Modelno,@Color,@Quantity,@Purchase_plan,@Enquiry_source,@Finacier,@Date,@Saleman_id,@Customer_id,@Branchid)", gl.con))
            {
               
                cmd1.Parameters.AddWithValue("@Company_id", ddlcompany.SelectedValue);
                cmd1.Parameters.AddWithValue("@Category_id", ddlCategory.SelectedValue);
                cmd1.Parameters.AddWithValue("@Modelnm", ddlmodelnm.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                cmd1.Parameters.AddWithValue("@Color", txtcolor.Text);
                cmd1.Parameters.AddWithValue("@Quantity", txtquantity.Text);

                cmd1.Parameters.AddWithValue("@Purchase_plan",ddlpurchageplan.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@Enquiry_source", ddlenquirysource.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@Finacier", ddlfinancier.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@Date", txtdate.Text);
                cmd1.Parameters.AddWithValue("@Saleman_id", ddlsales.SelectedValue);
                cmd1.Parameters.AddWithValue("@Customer_id", ddlcustomer.SelectedValue);
                cmd1.Parameters.AddWithValue("@Branchid", ddlbranch.SelectedValue);
                gl.con.Open();
                cmd1.ExecuteNonQuery();
                gl.con.Close();
                Label2.Text = "Submitted Sucessfully";
                //...
            }
        }
        display();

        //}
        //catch
        //{
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Oppertunity.aspx");
    }
    protected void ddlCategory_DataBound(object sender, EventArgs e)
    {
       // Convert.ToInt32(ddlCategory.SelectedValue);
        ddlCategory.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
    protected void ddlmodelnm_DataBound(object sender, EventArgs e)
    {
        //Convert.ToInt32(ddlmodelnm.SelectedValue);
        ddlmodelnm.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
   
    protected void ddlcustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  gl.query("Select * from Enquryform where Customer_name='" + ddlcustomer.SelectedItem.Text + "' and EmployeeCode='"+ddlsales.SelectedValue+"'");
        gl.query("Select * from Enquryform where Enquryid='" + ddlcustomer.SelectedValue + "'");
        if (gl.ds.Tables[0].Rows.Count != 0)
        {

            string Company_id1 = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();
            string cid = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
            string Modelname1 = gl.ds.Tables[0].Rows[0]["Modelname"].ToString();
            string branch_id = gl.ds.Tables[0].Rows[0]["Branchid"].ToString();
            for (int i = 0; i < ddlcompany.Items.Count; i++)
            {
                if (ddlcompany.Items[i].Value == Company_id1)
                {
                    ddlcompany.Items[i].Selected = true;
                    da = new SqlDataAdapter("select Category_id,Categorynm,companyid from Categorymaster where companyid='" + Company_id1 + "'", con);
                    da.Fill(ds);
                    ddlCategory.DataSource = ds;
                    ddlCategory.DataTextField = "Categorynm";
                    ddlCategory.DataValueField = "Category_id";
                    ddlCategory.DataBind();

                }
                else
                {
                    ddlcompany.Items[i].Selected = false;
                }
            }

            for (int i = 0; i < ddlCategory.Items.Count; i++)
            {
                if (ddlCategory.Items[i].Value == cid)
                {
                    ddlCategory.Items[i].Selected = true;
                    ds.Reset();
                    da = new SqlDataAdapter("select Modelid,Modelnm,Category_id from Modelmaster where Category_id='" + cid + "'", con);
                    da.Fill(ds);
                    ddlmodelnm.DataSource = ds;
                    ddlmodelnm.DataTextField = "Modelnm";
                    ddlmodelnm.DataValueField = "Modelid";
                    ddlmodelnm.DataBind();
                }
                else
                {
                    ddlCategory.Items[i].Selected = false;
                }

            }


            for (int i = 0; i < ddlmodelnm.Items.Count; i++)
            {
                if (ddlmodelnm.Items[i].Text == Modelname1)
                {
                    ddlmodelnm.Items[i].Selected = true;
                }
                else
                {
                    ddlmodelnm.Items[i].Selected = false;
                }

            }

            for (int i = 0; i < ddlbranch.Items.Count; i++)
            {
                if (ddlbranch.Items[i].Value == branch_id)
                {
                    ddlbranch.Items[i].Selected = true;
                }
                else
                {
                    ddlbranch.Items[i].Selected = false;
                }

            }

            txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
        }
    }

    protected void ddlcustomer_DataBound(object sender, EventArgs e)
    {
      //  Convert.ToInt32(ddlcustomer.SelectedValue);
        ddlcustomer.Items.Insert(0, new ListItem("-Select-", "-Select-"));
    }
}