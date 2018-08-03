using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Enquryform : System.Web.UI.Page
{
    global gl = new global();
   
    public SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString());
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);
                gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'",ddlbranch);
                gl.query("Select Emp_id,EmployeeCode,Name,Departmentnm from Employee_Reg where Departmentnm ='Sale'");
                ddlemployee.DataSource = gl.ds;
                ddlemployee.DataTextField = "Name";
                ddlemployee.DataValueField = "EmployeeCode";
                ddlemployee.DataBind();
                ddlemployee.SelectedIndex = 0;
                gl.ddl_select("Sourcemaster", "Source_id,Sourcename", "Sourcename", "Source_id", "0", "'Select'", ddlEnquirysource);
                gl.display("Enquryform", GridView1);
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
      
        if (Button1.Text == "Update")
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            using (SqlCommand cmd = new SqlCommand("Update Enquryform set Customer_name=@Customer_name,Email_id=@Email_id,Mobile_no=@Mobile_no,Site_location=@Site_location,Address=@Address,Pincode=@Pincode,State=@State,City=@State,District=@District,Account_Category=@Account_Category,FleetSize=@FleetSize,Company_id=@Company_id,Category_id=@Category_id,Modelname=@Modelname,Modelno=@Modelno,Unit_of_required=@Unit_of_required,EmployeeCode=@EmployeeCode,Purchaseplan=@Purchaseplan,Enquirysource=@Enquirysource,Date=@Date,Branchid=@Branchid,Status=@Status where Enquryid=@Enquryid", gl.con))
            {
                cmd.Parameters.AddWithValue("@Enquryid", id);                
                cmd.Parameters.AddWithValue("@Customer_name", txtcustomernm.Text);
                cmd.Parameters.AddWithValue("@Email_id", txtemailid.Text);
                cmd.Parameters.AddWithValue("@Mobile_no", txtmobileno.Text);
                cmd.Parameters.AddWithValue("@Site_location", txtsitelocation.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Pincode", txtpincode.Text);              
                cmd.Parameters.AddWithValue("@State", txtstate.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@Account_Category", ddlAccountCategory.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@FleetSize", ddlfleetsize.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Company_id", ddlcompany.SelectedValue);
                cmd.Parameters.AddWithValue("@Category_id", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Modelname", ddlmodelnm.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                cmd.Parameters.AddWithValue("@Unit_of_required", txtUnit_of_required.Text);
                cmd.Parameters.AddWithValue("@EmployeeCode", ddlemployee.SelectedValue);               
                cmd.Parameters.AddWithValue("@Purchaseplan", txtpurchaseplan.Text);
                cmd.Parameters.AddWithValue("@Enquirysource", ddlEnquirysource.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Date", txtdate.Text);
                cmd.Parameters.AddWithValue("@Branchid", ddlbranch.SelectedValue);
                cmd.Parameters.AddWithValue("@Status", RadioButtonList1.SelectedItem.Text);
                gl.con.Open();
                cmd.ExecuteNonQuery();
                gl.con.Close();
                Label2.Text = "Updatted Sucessfully";
                //...
            }

            //using (SqlCommand cmd1 = new SqlCommand("Update Customerdtl set Customername=@Customername,Email_id=@Email_id,Mobileno=@Mobileno,Address=@Address,Pincode=@Pincode,State=@State,City=@City,District=@District where Customerid=@Customerid)", gl.con))
            //{

            //    cmd1.Parameters.AddWithValue("@Customerid", txtcustomernm.Text);
            //    cmd1.Parameters.AddWithValue("@Customername", txtcustomernm.Text);
            //    cmd1.Parameters.AddWithValue("@Email_id", txtemailid.Text);
            //    cmd1.Parameters.AddWithValue("@Mobileno", txtmobileno.Text);
            //    cmd1.Parameters.AddWithValue("@Address", txtaddress.Text);
            //    cmd1.Parameters.AddWithValue("@Pincode", txtpincode.Text);

            //    cmd1.Parameters.AddWithValue("@State", txtstate.Text);
            //    cmd1.Parameters.AddWithValue("@City", txtcity.Text);
            //    cmd1.Parameters.AddWithValue("@District", txtdistrict.Text);
            //    gl.con.Open();
            //    cmd1.ExecuteNonQuery();
            //    gl.con.Close();
            //    Label2.Text = "Submitted Sucessfully";
            //    //...
            //}

        }
        else
        {
            using (SqlCommand cmd = new SqlCommand("insert into Enquryform(Customer_name, Email_id, Mobile_no, Site_location, Address, Pincode, State, City, District, Account_Category, FleetSize, Company_id, Category_id, Modelname,Modelno, Unit_of_required, EmployeeCode, Purchaseplan, Enquirysource, Date,Branchid,Status) values(@Customer_name,@Email_id,@Mobile_no,@Site_location,@Address,@Pincode,@State,@City,@District,@Account_Category,@FleetSize,@Company_id,@Category_id,@Modelname,@Modelno,@Unit_of_required,@EmployeeCode,@Purchaseplan,@Enquirysource,@Date,@Branchid,@Status)", gl.con))
            {
              
                cmd.Parameters.AddWithValue("@Customer_name", txtcustomernm.Text);
                cmd.Parameters.AddWithValue("@Email_id", txtemailid.Text);
                cmd.Parameters.AddWithValue("@Mobile_no", txtmobileno.Text);
                cmd.Parameters.AddWithValue("@Site_location", txtsitelocation.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Pincode", txtpincode.Text);
                //cmd.Parameters.AddWithValue("@State", ddlState.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@State", txtstate.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@Account_Category", ddlAccountCategory.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@FleetSize", ddlfleetsize.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Company_id", ddlcompany.SelectedValue);
                cmd.Parameters.AddWithValue("@Category_id", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Modelname", ddlmodelnm.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                cmd.Parameters.AddWithValue("@Unit_of_required", txtUnit_of_required.Text);
                cmd.Parameters.AddWithValue("@EmployeeCode", ddlemployee.SelectedValue);
                //cmd.Parameters.AddWithValue("@Purchaseplan",ddlPurchaseplan.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Purchaseplan", txtpurchaseplan.Text);
                cmd.Parameters.AddWithValue("@Enquirysource", ddlEnquirysource.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Date", txtdate.Text);
                cmd.Parameters.AddWithValue("@Branchid", ddlbranch.SelectedValue);
                cmd.Parameters.AddWithValue("@Status",RadioButtonList1.SelectedItem.Text);
                gl.con.Open();
                cmd.ExecuteNonQuery();
                gl.con.Close();
               Label2.Text = "Submitted Sucessfully";
                //...
            }

            using (SqlCommand cmd1 = new SqlCommand("insert into Customerdtl(Customername,Email_id,Mobileno,Address,Pincode,State,City,District) values(@Customername,@Email_id,@Mobileno,@Address,@Pincode,@State,@City,@District)", gl.con))
            {
                cmd1.Parameters.AddWithValue("@Customername", txtcustomernm.Text);
                cmd1.Parameters.AddWithValue("@Email_id", txtemailid.Text);
                cmd1.Parameters.AddWithValue("@Mobileno", txtmobileno.Text);               
                cmd1.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd1.Parameters.AddWithValue("@Pincode", txtpincode.Text);
                
                cmd1.Parameters.AddWithValue("@State", txtstate.Text);
                cmd1.Parameters.AddWithValue("@City", txtcity.Text);
                cmd1.Parameters.AddWithValue("@District", txtdistrict.Text);
                gl.con.Open();
                cmd1.ExecuteNonQuery();
                gl.con.Close();
                Label2.Text = "Submitted Sucessfully";
                //...
            }

        }
        gl.display("Enquryform", GridView1);
        }
        catch
        {


        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Enquryform.aspx");
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcompany.SelectedValue + "'", ddlCategory);
            ddlCategory.SelectedIndex = 0;
        }
        catch { }
       
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlCategory.SelectedValue + "'", ddlmodelnm);
            ddlmodelnm.SelectedIndex = 0;
        }
        catch { }
       
    }
    protected void ddlmodelnm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try{
        gl.query("select * from Modelmaster where Modelid='" + ddlmodelnm.SelectedValue+ "'");
        txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
        }
        catch
        {
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Enquryform", "Enquryid", "'" + idd + "'");
            gl.display("Enquryform", GridView1);
        }
        catch { }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        //gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcompany.SelectedValue + "'", ddlCategory);
        int id = Convert.ToInt32(GridView1.SelectedValue);
        gl.read1("Enquryform", "Enquryid", "'" + id + "'");
        txtcustomernm.Text = gl.ds.Tables[0].Rows[0]["Customer_name"].ToString();
        txtemailid.Text = gl.ds.Tables[0].Rows[0]["Email_id"].ToString();
        txtmobileno.Text = gl.ds.Tables[0].Rows[0]["Mobile_no"].ToString();
        txtsitelocation.Text = gl.ds.Tables[0].Rows[0]["Site_location"].ToString();
        txtaddress.Text = gl.ds.Tables[0].Rows[0]["Address"].ToString();
        txtpincode.Text = gl.ds.Tables[0].Rows[0]["Pincode"].ToString();
        txtstate.Text = gl.ds.Tables[0].Rows[0]["State"].ToString();
        txtcity.Text = gl.ds.Tables[0].Rows[0]["City"].ToString();
        txtdistrict.Text = gl.ds.Tables[0].Rows[0]["District"].ToString();
        txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
        txtUnit_of_required.Text = gl.ds.Tables[0].Rows[0]["Unit_of_required"].ToString();
        txtpurchaseplan.Text = gl.ds.Tables[0].Rows[0]["Purchaseplan"].ToString();
        txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();

        string esource = gl.ds.Tables[0].Rows[0]["Enquirysource"].ToString();
        string Status = gl.ds.Tables[0].Rows[0]["Status"].ToString(); 
        

        
        for (int i = 0; i < ddlEnquirysource.Items.Count; i++)
        {
            if (ddlEnquirysource.Items[i].Text == esource)
            {
                ddlEnquirysource.Items[i].Selected = true;
            }
            else
            {
                ddlEnquirysource.Items[i].Selected = false;
            }
        
        
        }

        string EmployeeCode = gl.ds.Tables[0].Rows[0]["EmployeeCode"].ToString();
        for (int i = 0; i < ddlemployee.Items.Count; i++)
        {
            if (ddlemployee.Items[i].Value == EmployeeCode)
            {
                ddlemployee.Items[i].Selected = true;

            }
            else
            {
                ddlemployee.Items[i].Selected = false;
            
            }
        
        }

        string Account_Category = gl.ds.Tables[0].Rows[0]["Account_Category"].ToString();      

        for (int i = 0; i < ddlAccountCategory.Items.Count; i++)
        {
            if (ddlAccountCategory.Items[i].Text == Account_Category)
            {
                ddlAccountCategory.Items[i].Selected = true;
            }
            else
            {
                ddlAccountCategory.Items[i].Selected = false;
            }
        }

        string Branchid = gl.ds.Tables[0].Rows[0]["Branchid"].ToString();

        for (int i = 0; i < ddlbranch.Items.Count; i++)
        {
            if (ddlbranch.Items[i].Value== Branchid)
            {
                ddlbranch.Items[i].Selected = true;
            }
            else
            {
                ddlbranch.Items[i].Selected = false;
            }
        }
        string FleetSize = gl.ds.Tables[0].Rows[0]["FleetSize"].ToString();

        for (int i = 0; i < ddlfleetsize.Items.Count; i++)
        {
            if (ddlfleetsize.Items[i].Text == FleetSize)
            {
                ddlfleetsize.Items[i].Selected = true;
            }
            else
            {
                ddlfleetsize.Items[i].Selected = false;
            }
        }

        string Company_id = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();

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
    
        //string Category_id = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        //if (ddlCategory.Items.FindByValue(Category_id) != null)
        //{

        //    ddlCategory.Items.FindByValue(Category_id).Selected = true;
        //}
        string cte_name = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        for (int ii = 0; ii < ddlCategory.Items.Count; ii++)
        {
            if (ddlCategory.Items[ii].Value == cte_name)
            {
                ddlCategory.Items[ii].Selected = true;
                ds.Reset();
                da = new SqlDataAdapter("select Modelid,Modelnm,Category_id from Modelmaster where Category_id='" + cte_name + "'", con);
                da.Fill(ds);
                ddlmodelnm.DataSource = ds;
                ddlmodelnm.DataTextField = "Modelnm";
                ddlmodelnm.DataValueField = "Modelid";
                ddlmodelnm.DataBind();

            }
            else
            {
                ddlCategory.Items[ii].Selected = false;
            }
        }
        string mdl_name = gl.ds.Tables[0].Rows[0]["Modelname"].ToString();
        for (int i2 = 0; i2 < ddlmodelnm.Items.Count; i2++)
        {
            if (ddlmodelnm.Items[i2].Text == mdl_name)
            {

                ddlmodelnm.Items[i2].Selected = true;
            }
            else
            {

                ddlmodelnm.Items[i2].Selected = false;
            }
        
        }

        for (int i3 = 0; i3 < RadioButtonList1.Items.Count; i3++)
        {
            if (RadioButtonList1.Items[i3].Text == Status)
            {
                RadioButtonList1.Items[i3].Selected = true;
            }
            else
            {
                RadioButtonList1.Items[i3].Selected = false;
            }
        
        }


            Button1.Text = "Update";
        }
        catch
        {
        }
    }
    protected void ddlCategory_DataBound(object sender, EventArgs e)
    {
        Convert.ToInt32(ddlCategory.SelectedValue);
        ddlCategory.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
    protected void ddlmodelnm_DataBound(object sender, EventArgs e)
    {
        Convert.ToInt32(ddlmodelnm.SelectedValue);
        ddlmodelnm.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
    protected void ddlemployee_DataBound(object sender, EventArgs e)
    {
        Convert.ToInt32(ddlemployee.SelectedValue);
        ddlemployee.Items.Insert(0, new ListItem("-Select-", "-Select-")); 

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}