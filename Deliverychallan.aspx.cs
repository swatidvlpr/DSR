using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Deliverychallan : System.Web.UI.Page
{
    global gl = new global();
    public SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString());

    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Challan_Desc_id"), new DataColumn("Qty"), new DataColumn("Description"), new DataColumn("Amount"), new DataColumn("Challlan_no") });
            ViewState["billing"] = dt;
            this.BindGrid();            
            gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);            
            gl.ddl_select("Enquryform", "Enquryid,Customer_name", "Customer_name", "Enquryid", "'0'", "'Select'", ddlcustomer);
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", ddlbranch);
            gl.ddl_select("Financiermaster", "Financier_id,Financiername", "Financiername", "Financier_id", "0", "'Select'", ddlhire_purchase);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlCommand cmd1 = new SqlCommand("insert into Delivery_challan_add(Customer_id, Customer_name, Mobile_no, Email_id, Address, Challlan_no, Order_no, Date, Company_id, Category_id, Modelnm, Model_no,Hirepurchase_lease_hypothecated_with_ms,Engine_no, Chassis_no, Ingnition_key_no, Battery_make, Batteryno, Tyremake,Branchid,branchname) values(@Customer_id,@Customer_name,@Mobile_no,@Email_id,@Address,@Challlan_no,@Order_no,@Date,@Company_id,@Category_id,@Modelnm,@Model_no,@Hirepurchase_lease_hypothecated_with_ms,@Engine_no,@Chassis_no,@Ingnition_key_no,@Battery_make,@Batteryno,@Tyremake,@Branchid,@branchname)", gl.con))
        {

            cmd1.Parameters.AddWithValue("@Customer_id",ddlcustomer.SelectedValue);
            cmd1.Parameters.AddWithValue("@Customer_name", ddlcustomer.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@Mobile_no", hdn_Mobile_no.Value);
            cmd1.Parameters.AddWithValue("@Email_id", hdn_Email_id.Value);
            cmd1.Parameters.AddWithValue("@Address",hdn_Address.Value);
            cmd1.Parameters.AddWithValue("@Challlan_no", txtChallano.Text);
            cmd1.Parameters.AddWithValue("@Order_no",txtOrderno.Text);
            cmd1.Parameters.AddWithValue("@Date", txtdate.Text);
            cmd1.Parameters.AddWithValue("@Company_id",ddlcompany.SelectedValue);
            cmd1.Parameters.AddWithValue("@Category_id", ddlCategory.SelectedValue);
            cmd1.Parameters.AddWithValue("@Modelnm", ddlmodelnm.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@Model_no", txtmodelno.Text);
            cmd1.Parameters.AddWithValue("@Hirepurchase_lease_hypothecated_with_ms", ddlhire_purchase.SelectedItem.Text);
           // @Engine_no,@Chassis_no,@Ingnition_key_no,@Battery_make,@Batteryno,@Tyremake
            cmd1.Parameters.AddWithValue("@Engine_no", txtengineno.Text);
            cmd1.Parameters.AddWithValue("@Chassis_no", txtchassisno.Text);
            cmd1.Parameters.AddWithValue("@Ingnition_key_no", txtIngnitionkeyno.Text);
            cmd1.Parameters.AddWithValue("@Battery_make", txtBatterymake.Text);
            cmd1.Parameters.AddWithValue("@Batteryno", txtBatteryno.Text);
            cmd1.Parameters.AddWithValue("@Tyremake", txtTyremake.Text);
            cmd1.Parameters.AddWithValue("@Branchid", ddlbranch.SelectedValue);
            cmd1.Parameters.AddWithValue("@branchname", ddlbranch.SelectedItem.Text);
            gl.con.Open();
            cmd1.ExecuteNonQuery();
            gl.con.Close();
            Label2.Text = "Submitted Sucessfully";
            //...
        }


        DataTable dt = (DataTable)ViewState["billing"];
        ViewState["billing"] = dt;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string Challan_Desc_id = dt.Rows[i]["Challan_Desc_id"].ToString();
            string Qty = dt.Rows[i]["Qty"].ToString();
            string Description = dt.Rows[i]["Description"].ToString();
            string Amount = dt.Rows[i]["Amount"].ToString();
            string Challlan_no = dt.Rows[i]["Challlan_no"].ToString();

            using (SqlCommand cmd1 = new SqlCommand("insert into Delivery_challan_Desc(Qty,Description,Amount,Challlan_no) values(@Qty,@Description,@Amount,@Challlan_no)", gl.con))
            {

                //cmd1.Parameters.AddWithValue("@Challan_id", Challan_Desc_id);
                cmd1.Parameters.AddWithValue("@Qty", Qty);
                cmd1.Parameters.AddWithValue("@Description", Description);
                cmd1.Parameters.AddWithValue("@Amount", Amount);
                cmd1.Parameters.AddWithValue("@Challlan_no", Challlan_no);                
                gl.con.Open();
                cmd1.ExecuteNonQuery();
                gl.con.Close();
                Label2.Text = "Submitted Sucessfully";
                //...
            }

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Deliverychallan.aspx");
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
            gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlCategory.SelectedValue + "'", ddlmodelnm);
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        //DateTime crnttime = Convert.ToDateTime(txtdate.Text);
        //TimeZoneInfo tzn = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        //DateTime IndianTme = TimeZoneInfo.ConvertTime(crnttime, tzn);
        //string time = IndianTme.ToString("dd/MM/yyyy");
        //string mnth = IndianTme.ToString("MM");
        //string year = IndianTme.ToString("yyyy");


        string invoice = "Invoice_id";

        string hrs = string.Format("{0:hh}", DateTime.Now);
        int flg = 0;
        DataTable dt = (DataTable)ViewState["billing"];
        dt.Rows.Add(HiddenField1.Value,txtqty.Text, txtdesc.Text, txtamt.Text,txtChallano.Text);
        ViewState["billing"] = dt;
        this.BindGrid();
        txtqty.Text = string.Empty;
        txtdesc.Text = string.Empty;
        txtamt.Text = string.Empty;
       
    }
    protected void BindGrid()
    {
        GridView1.DataSource = (DataTable)ViewState["billing"];
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["billing"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["billing"] = dt;
        BindGrid();
    }
    protected void ddlcustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        //gl.query("select * from Enquryform where Enquryid='"+ddlcustomer.SelectedValue+"'");
        //if (gl.ds.Tables[0].Rows.Count != null)
        //{
            
        //}

        gl.query("Select * from Enquryform where Enquryid='" + ddlcustomer.SelectedValue + "'");
        if (gl.ds.Tables[0].Rows.Count != 0)
        {
            hdn_Email_id.Value = gl.ds.Tables[0].Rows[0]["Email_id"].ToString();
            hdn_Mobile_no.Value = gl.ds.Tables[0].Rows[0]["Mobile_no"].ToString();
            hdn_Address.Value = gl.ds.Tables[0].Rows[0]["Address"].ToString();
            txtemailid.Text = gl.ds.Tables[0].Rows[0]["Email_id"].ToString();
            txtmobile.Text = gl.ds.Tables[0].Rows[0]["Mobile_no"].ToString();
            txtaddress.Text = gl.ds.Tables[0].Rows[0]["Address"].ToString();

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
        gl.query("select * from Oppertunity where Customer_id='" + ddlcustomer.SelectedValue + "' order by Customer_id");
        if (gl.ds.Tables[0].Rows.Count != 0)
        {
            string fincernm = gl.ds.Tables[0].Rows[0]["Finacier"].ToString();
            for (int i = 0; i < ddlhire_purchase.Items.Count; i++)
            {
                if (ddlhire_purchase.Items[i].Text == fincernm)
                {
                    ddlhire_purchase.Items[i].Selected = true;
                }
                else
                {
                    ddlhire_purchase.Items[i].Selected = false;
                }

            }
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
}