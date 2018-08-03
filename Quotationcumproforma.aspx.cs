using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Quotationcumproforma : System.Web.UI.Page
{
    global gl = new global();
    public int total = 0;
    decimal totalPrice = 0M;
    int totalItems = 0;

    public int total1 = 0;
    decimal totalPrice1 = 0M;
    int totalItems1 = 0;

    string companyid;
    string categoryid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Particularid"), new DataColumn("Particularnm"), new DataColumn("per_unit_price"), new DataColumn("qty"), new DataColumn("total_price") });
            ViewState["billing"] = dt;
            this.BindGrid();
           // gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);
           // gl.ddl_select("Enquryform", "Enquryid,Customer_name", "Customer_name", "Enquryid", "'0'", "'Select'", ddlcustomer);
           // gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", ddlbranch);
            display();
        }
    }

    protected void BindGrid()
    {
        GridView1.DataSource = (DataTable)ViewState["billing"];
        GridView1.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //string invoice = "Invoice_id";

        string hrs = string.Format("{0:hh}", DateTime.Now);
        int flg = 0;
        DataTable dt = (DataTable)ViewState["billing"];
        dt.Rows.Add(HiddenField1.Value, txtParticular.Text, txtPrice.Text, txtQty.Text, txttprice.Text);
        ViewState["billing"] = dt;
        this.BindGrid();
        txtParticular.Text = string.Empty;
        txtPrice.Text ="00.00";
        txtQty.Text = "0";
        txttprice.Text = "00.00";
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPrice = (Label)e.Row.FindControl("Label1");
            decimal price = Decimal.Parse(lblPrice.Text);
            totalPrice += price;
            totalItems += 1;

            Label lblPrice1 = (Label)e.Row.FindControl("Label3");
            decimal price1 = Decimal.Parse(lblPrice1.Text);
            totalPrice1 += price1;
            totalItems1 += 1;
           
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalPrice = (Label)e.Row.FindControl("Label2");
            lblTotalPrice.Text = Convert.ToDecimal(totalPrice).ToString("N");
            HiddenField1.Value = lblTotalPrice.Text;

            Label lblTotalPrice1 = (Label)e.Row.FindControl("Label4");
            lblTotalPrice1.Text = Convert.ToDecimal(totalPrice1).ToString("N");
            HiddenField1.Value = lblTotalPrice1.Text;
           
            //Label lbl_sub_total = (Label)e.Row.FindControl("Label8");
        }


    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {


        }
        else
        {
            gl.query("select * from Vw_Quotationaddreturn where Challlan_no='" + txtChallano.Text + "'");
            if (gl.ds.Tables[0].Rows.Count != 0)
            {
                hdncompanyid.Value = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();              
                hdncategoryid.Value = gl.ds.Tables[0].Rows[0]["Customer_id"].ToString();
                
            }

            using (SqlCommand cmd1 = new SqlCommand("insert into Quotation_proforma_invoice(Challanno,orderno,Customername, Address, mobile, Hypothecated_with, companyname, Categorynm, Modelnm, Modelno, engine_no, Chassis_no, Variant_no, QTN_NO,emailid,date,branchnm,Customer_id,company_id,Category_id) values(@Challanno,@orderno,@Customername,@Address,@mobile,@Hypothecated_with,@companyname,@Categorynm,@Modelnm,@Modelno,@engine_no,@Chassis_no,@Variant_no,@QTN_NO,@emailid,@date,@branchnm,@Customer_id,@company_id,@Category_id)", gl.con))
            {

                cmd1.Parameters.AddWithValue("@Challanno", txtChallano.Text);
                cmd1.Parameters.AddWithValue("@orderno", txtOrderno.Text);
                cmd1.Parameters.AddWithValue("@Customername", txtcustomer.Text);
                cmd1.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd1.Parameters.AddWithValue("@mobile", txtmobile.Text);
                cmd1.Parameters.AddWithValue("@Hypothecated_with", txthire_purchase.Text);
                cmd1.Parameters.AddWithValue("@companyname", txtcompany.Text);
                cmd1.Parameters.AddWithValue("@Categorynm", txtCategory.Text);
                cmd1.Parameters.AddWithValue("@Modelnm", txtmodel.Text);
                cmd1.Parameters.AddWithValue("@Modelno", txtmodelno.Text);
                cmd1.Parameters.AddWithValue("@engine_no", txtEngineno.Text);
                cmd1.Parameters.AddWithValue("@Chassis_no", txtChassisno.Text);
                cmd1.Parameters.AddWithValue("@Variant_no", txtvariantno.Text);
                cmd1.Parameters.AddWithValue("@QTN_NO", txtqtnno.Text);
                cmd1.Parameters.AddWithValue("@emailid", txtemailid.Text);
                cmd1.Parameters.AddWithValue("@date", txtdate.Text);
                cmd1.Parameters.AddWithValue("@branchnm", txtbranch.Text);
                cmd1.Parameters.AddWithValue("@Customer_id",HiddenField2.Value);
                cmd1.Parameters.AddWithValue("@company_id",hdncompanyid.Value);
                cmd1.Parameters.AddWithValue("@Category_id", hdncategoryid.Value);
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
                string QTN_NO = txtqtnno.Text;
                string Particularnm = dt.Rows[i]["Particularnm"].ToString();
                string per_unit_price = dt.Rows[i]["per_unit_price"].ToString();
                string qty = dt.Rows[i]["qty"].ToString();
                string total_price = dt.Rows[i]["total_price"].ToString();
                string date = txtdate.Text;


                using (SqlCommand cmd1 = new SqlCommand("insert into Particularmaster(QTN_NO,Particularnm,per_unit_price,qty,total_price,date) values(@QTN_NO,@Particularnm,@per_unit_price,@qty,@total_price,@date)", gl.con))
                {

                    cmd1.Parameters.AddWithValue("@QTN_NO", QTN_NO);
                    cmd1.Parameters.AddWithValue("@Particularnm", Particularnm);
                    cmd1.Parameters.AddWithValue("@per_unit_price", per_unit_price);
                    cmd1.Parameters.AddWithValue("@qty", qty);
                    cmd1.Parameters.AddWithValue("@total_price", total_price);
                    cmd1.Parameters.AddWithValue("@date", date);
                    gl.con.Open();
                    cmd1.ExecuteNonQuery();
                    gl.con.Close();
                    Label2.Text = "Submitted Sucessfully";
                    //...
                }

            }
        }
        display();
       // gl.query("Select * from Stock_master where Company_id='"++"' and ");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Quotationcumproforma.aspx");
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        double per_rate = Convert.ToDouble(txtPrice.Text);
        double qnt = Convert.ToDouble(txtQty.Text);
        double total_rt = per_rate * qnt;
        txttprice.Text = total_rt.ToString("N");

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["billing"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["billing"] = dt;
        BindGrid();
    }
    protected void txtChallano_TextChanged(object sender, EventArgs e)
    {
        gl.query("select * from Vw_Quotationaddreturn where Challlan_no='" + txtChallano.Text + "'");
        if (gl.ds.Tables[0].Rows.Count != 0)
        {
            txtOrderno.Text = gl.ds.Tables[0].Rows[0]["Order_no"].ToString();
            txtcustomer.Text = gl.ds.Tables[0].Rows[0]["Customer_name"].ToString();
            txtemailid.Text = gl.ds.Tables[0].Rows[0]["Email_id"].ToString();
            txtmobile.Text = gl.ds.Tables[0].Rows[0]["Mobile_no"].ToString();
            txtaddress.Text = gl.ds.Tables[0].Rows[0]["Address"].ToString();
            txthire_purchase.Text = gl.ds.Tables[0].Rows[0]["Hirepurchase_lease_hypothecated_with_ms"].ToString();
            txtcompany.Text = gl.ds.Tables[0].Rows[0]["companyname"].ToString();
            txtCategory.Text = gl.ds.Tables[0].Rows[0]["Categorynm"].ToString();
            txtmodel.Text = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
            txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Model_no"].ToString();
            txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Model_no"].ToString();
            txtEngineno.Text = gl.ds.Tables[0].Rows[0]["Engine_no"].ToString();
            txtChassisno.Text = gl.ds.Tables[0].Rows[0]["Chassis_no"].ToString();
            txtbranch.Text = gl.ds.Tables[0].Rows[0]["branchname"].ToString();
            HiddenField2.Value = gl.ds.Tables[0].Rows[0]["Customer_id"].ToString();
            companyid = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();
           // hdncompanyid.Value = companyid;
            categoryid = gl.ds.Tables[0].Rows[0]["Customer_id"].ToString();
            // hdncategoryid.Value = categoryid;companyid,categoryid
        }
      
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string idd = GridView2.DataKeys[e.RowIndex].Value.ToString();
            gl.delete("Quotation_proforma_invoice", "QTN_NO", "'" + idd + "'");
            gl.delete("Particularmaster", "QTN_NO", "'" + idd + "'");
            display();

        }
        catch { }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id1 = Convert.ToInt32(GridView2.SelectedValue).ToString();
        gl.query("select * from Quotation_proforma_invoice where Quotationid='" + id1 + "'");
       
        if (gl.ds.Tables[0].Rows.Count != 0)
        {
            txtChallano.Text = gl.ds.Tables[0].Rows[0]["Challanno"].ToString();
            txtqtnno.Text = gl.ds.Tables[0].Rows[0]["QTN_NO"].ToString();
            txtOrderno.Text = gl.ds.Tables[0].Rows[0]["orderno"].ToString();
            txtcustomer.Text = gl.ds.Tables[0].Rows[0]["Customername"].ToString();
            txtemailid.Text = gl.ds.Tables[0].Rows[0]["emailid"].ToString();
            txtmobile.Text = gl.ds.Tables[0].Rows[0]["mobile"].ToString();
            txtaddress.Text = gl.ds.Tables[0].Rows[0]["Address"].ToString();
            txthire_purchase.Text = gl.ds.Tables[0].Rows[0]["Hypothecated_with"].ToString();
            txtcompany.Text = gl.ds.Tables[0].Rows[0]["companyname"].ToString();
            txtCategory.Text = gl.ds.Tables[0].Rows[0]["Categorynm"].ToString();
            txtmodel.Text = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
            txtmodelno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();
            txtEngineno.Text = gl.ds.Tables[0].Rows[0]["engine_no"].ToString();
            txtChassisno.Text = gl.ds.Tables[0].Rows[0]["Chassis_no"].ToString();
            txtvariantno.Text = gl.ds.Tables[0].Rows[0]["Variant_no"].ToString();
            //txtbranch.Text = gl.ds.Tables[0].Rows[0]["Variant_no"].ToString();
            txtbranch.Text = gl.ds.Tables[0].Rows[0]["branchnm"].ToString();
            txtdate.Text = gl.ds.Tables[0].Rows[0]["date"].ToString();
            Button1.Text = "Update";
        }
    }

    public void display()
    {
        if (txtChallano.Text == "")
        {
            gl.query("Select * from Quotation_proforma_invoice");
            GridView2.DataSource = gl.ds;
            GridView2.DataBind();
        }
        else
        {
            gl.query("Select * from Quotation_proforma_invoice where Challanno='" + txtChallano.Text + "'");
            GridView2.DataSource = gl.ds;
            GridView2.DataBind();
        }
    
    }
}