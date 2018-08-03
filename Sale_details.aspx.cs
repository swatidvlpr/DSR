using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DSR_Sale_details : System.Web.UI.Page
{
    global gl = new global();
    public SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString());
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    int status = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
           
            gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);
            gl.ddl_select("Enquryform", "Enquryid,Customer_name", "Customer_name", "Enquryid", "'0'", "'Select'", ddlcustomer);            
            gl.ddl_select("Financiermaster", "Financier_id,Financiername", "Financiername", "Financier_id", "'0'", "'Select'", ddlfinancier);
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", ddlbranch);
            gl.display("Sale_Do_Data_Details", GridView1);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            int idd = Convert.ToInt32(GridView1.SelectedValue);
            using (SqlCommand cmd = new SqlCommand("Update Sale_Do_Data_Details set company_id=@company_id,Category_id=@Category_id,Branchid=@Branchid,Modelnm=@Modelnm,Modelno=@Modelno,Customer_name=@Customer_name,Actual_delivery_date=@Actual_delivery_date,Financiername=@Financiername Sale_target=@Sale_target,DO_status=@DO_status,DO_Date=@DO_Date where sale_id=@sale_id", gl.con))
            {
                cmd.Parameters.AddWithValue("@sale_id", idd);
                cmd.Parameters.AddWithValue("@company_id", ddlcompany.SelectedValue);
                cmd.Parameters.AddWithValue("@Category_id", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Modelnm", ddlmodelnm.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                cmd.Parameters.AddWithValue("@Branchid", ddlbranch.SelectedValue);
                cmd.Parameters.AddWithValue("@Customer_name", ddlcustomer.SelectedValue);               
                cmd.Parameters.AddWithValue("@Actual_delivery_date", txtdeliverydt.Text);
                cmd.Parameters.AddWithValue("@Financiername", ddlfinancier.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Sale_target", txtsaletrgt.Text);
                cmd.Parameters.AddWithValue("@DO_Date", txtdate.Text);
                gl.con.Open();
                cmd.ExecuteNonQuery();
                gl.con.Close();
                Label2.Text = "Updatted Sucessfully";
                //...
            }

        }
        else
        {
            //                                                              company_id, Category_id, Branchid, Modelnm, Modelno, Customer_name, Actual_delivery_date, Financiername, Sale_target, DO_status, DO_Date

            using (SqlCommand cmd = new SqlCommand("insert into Sale_Do_Data_Details(company_id, Category_id, Branchid, Modelnm, Modelno, Customer_name, Actual_delivery_date, Financiername, Sale_target, DO_status, DO_Date) values(@company_id,@Category_id,@Branchid,@Modelnm,@Modelno,@Customer_name,@Actual_delivery_date,@Financiername,@Sale_target,@DO_status,@DO_Date)", gl.con))
            {

                cmd.Parameters.AddWithValue("@company_id", ddlcompany.SelectedValue);
                cmd.Parameters.AddWithValue("@Category_id", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Modelnm", ddlmodelnm.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                cmd.Parameters.AddWithValue("@Branchid", ddlbranch.SelectedValue);
                cmd.Parameters.AddWithValue("@Customer_name", ddlcustomer.SelectedItem.Text);               
                cmd.Parameters.AddWithValue("@Actual_delivery_date",txtdeliverydt.Text);
                cmd.Parameters.AddWithValue("@Financiername", ddlfinancier.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Sale_target",txtsaletrgt.Text);
                cmd.Parameters.AddWithValue("@DO_status",status);
                cmd.Parameters.AddWithValue("@DO_Date", txtdate.Text);                                          
                gl.con.Open();
                cmd.ExecuteNonQuery();
                gl.con.Close();
                Label2.Text = "Submitted Sucessfully";
                //...
            }
            gl.display("Sale_Do_Data_Details", GridView1);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sale_details.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);        
        gl.ddl_select("Enquryform", "Enquryid,Customer_name", "Customer_name", "Enquryid", "'0'", "'Select'", ddlcustomer);
        string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
        gl.read1("Sale_Do_Data_Details", "sale_id", "'" + idd + "'");
       
        string Customername = gl.ds.Tables[0].Rows[0]["Customer_name"].ToString();
        string Company_id = gl.ds.Tables[0].Rows[0]["company_id"].ToString();
        txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();

        string Category_id = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        string Modelname = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
       
        string Finacier = gl.ds.Tables[0].Rows[0]["Finaciername"].ToString();
        string branchid = gl.ds.Tables[0].Rows[0]["Branchid"].ToString();

       
        for (int i = 0; i < ddlcustomer.Items.Count; i++)
        {
            if (ddlcustomer.Items[i].Value == Customername)
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
            if (ddlcompany.Items[i].Value == Company_id)
            {
                ddlcompany.Items[i].Selected = true;
                da = new SqlDataAdapter("select Category_id,Categorynm,companyid from Categorymaster where companyid='" + Company_id + "'", con);
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
            if (ddlCategory.Items[i].Value == Category_id)
            {
                ddlCategory.Items[i].Selected = true;
                ds.Reset();
                da = new SqlDataAdapter("select Modelid,Modelnm,Category_id from Modelmaster where Category_id='" + Category_id + "'", con);
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
            if (ddlmodelnm.Items[i].Value == Modelname)
            {
                ddlmodelnm.Items[i].Selected = true;
            }
            else
            {
                ddlmodelnm.Items[i].Selected = false;
            }

        }       

        for (int i = 0; i < ddlfinancier.Items.Count; i++)
        {
            if (ddlfinancier.Items[i].Text == Finacier)
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
        txtdeliverydt.Text = gl.ds.Tables[0].Rows[0]["Actual_delivery_date"].ToString();
        txtsaletrgt.Text = gl.ds.Tables[0].Rows[0]["Sale_target"].ToString();       
        Button1.Text = "Update";
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("Sale_Do_Data_Details", "sale_id", "'" + id1 + "'");
        gl.display("Sale_Do_Data_Details", GridView1);
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcompany.SelectedValue + "'", ddlCategory);
        ddlCategory.SelectedIndex = 0;
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlCategory.SelectedValue + "'", ddlmodelnm);
        ddlmodelnm.SelectedIndex = 0;
    }
    protected void ddlCategory_DataBound(object sender, EventArgs e)
    {
        // Convert.ToInt32(ddlCategory.SelectedValue);
        ddlCategory.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
    protected void ddlmodelnm_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.query("select * from Modelmaster where Modelid='" + ddlmodelnm.SelectedValue + "'");
        txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
    }
    protected void ddlmodelnm_DataBound(object sender, EventArgs e)
    {
        //Convert.ToInt32(ddlmodelnm.SelectedValue);
        ddlmodelnm.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
//    protected void ddlcustomer_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        gl.query("Select * from Enquryform where Enquryid='" + ddlcustomer.SelectedValue + "'");
//        if (gl.ds.Tables[0].Rows.Count != 0)
//        {

//            string Company_id = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();
//            string Category_id = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
           
//            string Branchid = gl.ds.Tables[0].Rows[0]["Branchid"].ToString();
//            for (int i = 0; i < ddlcompany.Items.Count; i++)
//            {
//                if (ddlcompany.Items[i].Value == Company_id)
//                {
//                    ddlcompany.Items[i].Selected = true;
//                    da = new SqlDataAdapter("select Category_id,Categorynm,companyid from Categorymaster where companyid='" + Company_id + "'", con);
//                    da.Fill(ds);
//                    ddlCategory.DataSource = ds;
//                    ddlCategory.DataTextField = "Categorynm";
//                    ddlCategory.DataValueField = "Category_id";
//                    ddlCategory.DataBind();

//                }
//                else
//                {
//                    ddlcompany.Items[i].Selected = false;
//                }
//            }

//            for (int i = 0; i < ddlCategory.Items.Count; i++)
//            {
//                if (ddlCategory.Items[i].Value == Category_id)
//                {
//                    ddlCategory.Items[i].Selected = true;
//                    ds.Reset();
//                    da = new SqlDataAdapter("select Modelid,Modelnm,Category_id from Modelmaster where Category_id='" + Category_id + "'", con);
//                    da.Fill(ds);
//                    ddlmodelnm.DataSource = ds;
//                    ddlmodelnm.DataTextField = "Modelnm";
//                    ddlmodelnm.DataValueField = "Modelid";
//                    ddlmodelnm.DataBind();
//                }
//                else
//                {
//                    ddlCategory.Items[i].Selected = false;
//                }

//            }
            
//            for (int i = 0; i < ddlbranch.Items.Count; i++)
//            {
//                if (ddlbranch.Items[i].Value == Branchid)
//                {
//                    ddlbranch.Items[i].Selected = true;
//                }
//                else
//                {
//                    ddlbranch.Items[i].Selected = false;
//                }

//            }

//            txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
//        }
//    }
//    protected void ddlcustomer_DataBound(object sender, EventArgs e)
//    {
//        //  Convert.ToInt32(ddlcustomer.SelectedValue);
//        ddlcustomer.Items.Insert(0, new ListItem("-Select-", "-Select-"));
//    }
}