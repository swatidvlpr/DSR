using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSR_Cugbill_for_17 : System.Web.UI.Page
{
    global gl = new global();
    public int total = 0;
    decimal totalPrice = 0M;
    int totalItems = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'",ddlbrnchnm);
            gl.display("Cug_bill_17", GridView1);
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "update")
        {
            int idd = Convert.ToInt32(GridView1.SelectedValue);
            gl.update("Cug_bill_17", "Allocated_to='" + txtname.Text + "',branchname='" + ddlbrnchnm.SelectedItem.Text + "',Number='" + txtnmbr.Text + "',Amount='" + txtamnt.Text + "', Limit='" + txtlmt.Text + "' Deduction='" + txtdtctn.Text + "',  Date='" + txtdate.Text + "'", "Cug_id", "'" + idd + "'");
            Label1.Text = "Updated Successfully";
        }
        else
        {
            //Allocated_to                   branchname,                    Number,           Amount,         Limit,       Deduction,         Date

            gl.insert("Cug_bill_17", "'" + txtname.Text + "','" + ddlbrnchnm.SelectedItem.Text + "','" + txtnmbr.Text + "','" + txtamnt.Text + "','" + txtlmt.Text + "','" + txtdtctn.Text + "','" + txtdate.Text + "'");

            Label1.Text = "Submitted Successfully";
        }
        gl.display("Cug_bill_17", GridView1);       
        ddlbrnchnm.SelectedItem.Text = "";
        txtname.Text = "";
        txtnmbr.Text = "";
        txtamnt.Text = "";
        txtlmt.Text = "";
        txtdtctn.Text = "";
        txtdate.Text = "";
        Button1.Text = "submit";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cugbill_for_17.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
        gl.read1("Cug_bill_17", "Cug_id", "'" + idd + "'");
        string branchname = gl.ds.Tables[0].Rows[0]["branchname"].ToString();

        for (int i = 0; i < ddlbrnchnm.Items.Count; i++)
        {
            if (ddlbrnchnm.Items[i].Text == branchname)
            {
                ddlbrnchnm.Items[i].Selected = true;
            }
            else
            {
                ddlbrnchnm.Items[i].Selected = false;
            }
        }
        ddlbrnchnm.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Branchid"].ToString();
        
        txtname.Text = gl.ds.Tables[0].Rows[0]["Allocated_to"].ToString();
        txtnmbr.Text = gl.ds.Tables[0].Rows[0]["Number"].ToString();
        String Amount = gl.ds.Tables[0].Rows[0]["Amount"].ToString();
        txtamnt.Text = Convert.ToDecimal(Amount).ToString("N"); ;
        String Limit = gl.ds.Tables[0].Rows[0]["Limit"].ToString();
        txtlmt.Text = Convert.ToDecimal(Limit).ToString("N");
        String Deduction = gl.ds.Tables[0].Rows[0]["Deduction"].ToString();
        txtdtctn.Text = Convert.ToDecimal(Deduction).ToString("N"); 
        txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
        Button1.Text = "update";
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("Cug_bill_17", "Cug_id", "'" + id1 + "'");
        gl.display("Cug_bill_17", GridView1);
       
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

            Label lblPrice = (Label)e.Row.FindControl("Label2");

            decimal price = Decimal.Parse(lblPrice.Text);

            totalPrice += price;

            totalItems += 1;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalPrice = (Label)e.Row.FindControl("Label3");


            lblTotalPrice.Text = totalPrice.ToString();

        }
    }
    protected void txtlmt_TextChanged(object sender, EventArgs e)
    {
        double amount = Convert.ToDouble(txtamnt.Text);
        double limit = Convert.ToDouble(txtlmt.Text);
        double total = amount - limit;
        txtdtctn.Text = total.ToString("N");
    }
    protected void txtamnt_TextChanged(object sender, EventArgs e)
    {
        double amount = Convert.ToDouble(txtamnt.Text);
        double limit = Convert.ToDouble(txtlmt.Text);
        double total = amount - limit;
        txtdtctn.Text = total.ToString("N");
    }
    protected void txtdtctn_TextChanged(object sender, EventArgs e)
    {
        double amount = Convert.ToDouble(txtamnt.Text);
        double limit = Convert.ToDouble(txtlmt.Text);
        double total = amount - limit;
        txtdtctn.Text = total.ToString("N");
    }
   
}