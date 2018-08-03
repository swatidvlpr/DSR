using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSR_Target_for_nextmonth : System.Web.UI.Page
{
    global gl = new global();
    public int total = 0;
    decimal totalPrice = 0M;
    decimal totalPrice1 = 0M;
    decimal totalPrice2 = 0M;
    decimal totalPrice3 = 0M;
    int totalItems = 0;
    int totalItems1 = 0;
    int totalItems2 = 0;
    int totalItems3 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", ddlBranch);
                display();
               
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
                gl.update("Target_for_next_month", " Branch_id='" + ddlBranch.SelectedValue + "', From_ho='" + txtFromHO.Text + "', Retail='" + txtRetail.Text + "', Bulkk='" + txtbulk.Text + "',Total='" + txttotal.Text + "', date='" + txtdate.Text + "'", "Target_nxt_mnth_id", "'" + idd + "'");
            }
            else
            {
                gl.insert1("Target_for_next_month", " Branch_id, From_ho, Retail, Bulkk, Total,date", "'" + ddlBranch.SelectedValue + "','" + txtFromHO.Text + "','" + txtRetail.Text + "','" + txtbulk.Text + "','"+txttotal.Text+"','" + txtdate.Text + "'");

            }
            display();

            ddlBranch.SelectedIndex = 0;
            txtFromHO.Text = "0";
            txtbulk.Text = "0";
            txtRetail.Text = "0";
            txttotal.Text = "0";
            txtdate.Text = "";



        }
        catch
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Target_for_nextmonth.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label1");

                decimal price = Decimal.Parse(lblPrice.Text);


                totalPrice += price;

                totalItems += 1;

                Label lblPrice1 = (Label)e.Row.FindControl("Label2");

                decimal price1 = Decimal.Parse(lblPrice1.Text);
                totalPrice1 += price1;
                totalItems1 += 1;

                Label lblPrice2 = (Label)e.Row.FindControl("Label3");
                decimal price2 = Decimal.Parse(lblPrice2.Text);
                totalPrice2 += price2;
                totalItems2 += 1;

                Label lblPrice3 = (Label)e.Row.FindControl("Label4");
                decimal price3 = Decimal.Parse(lblPrice3.Text);
                totalPrice3 += price3;
                totalItems3 += 1;


            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lbltotal1");
                lblTotalPrice.Text = totalPrice.ToString();

                Label lblTotalPrice1 = (Label)e.Row.FindControl("lbltotal2");
                lblTotalPrice1.Text = totalPrice1.ToString();
                Label lblTotalPrice3 = (Label)e.Row.FindControl("lbltotal3");
                lblTotalPrice3.Text = totalPrice2.ToString();
                Label lblTotalPrice4 = (Label)e.Row.FindControl("lbltotal4");
                lblTotalPrice4.Text = totalPrice3.ToString();
            }
        }
        catch { }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            gl.read1("Target_for_next_month", "Target_nxt_mnth_id", "'" + id + "'");

            string branch = gl.ds.Tables[0].Rows[0]["Branch_id"].ToString();

            for (int i = 0; i < ddlBranch.Items.Count; i++)
            {
                if (ddlBranch.Items[i].Value == branch)
                {
                    ddlBranch.Items[i].Selected = true;
                }
                else
                {
                    ddlBranch.Items[i].Selected = false;
                }
            }
            txtFromHO.Text = gl.ds.Tables[0].Rows[0]["From_ho"].ToString();
            txtRetail.Text = gl.ds.Tables[0].Rows[0]["Retail"].ToString();
            txtbulk.Text = gl.ds.Tables[0].Rows[0]["Bulkk"].ToString();
            txttotal.Text = gl.ds.Tables[0].Rows[0]["Total"].ToString();
            txtdate.Text = gl.ds.Tables[0].Rows[0]["date"].ToString();

            Button1.Text = "update";
        }
        catch { }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Target_for_next_month", "Target_nxt_mnth_id", "'" + idd + "'");
            display();
        }
        catch { }
    }
    protected void txtRetail_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int Retail = Convert.ToInt32(txtRetail.Text);
            int Bulkk = Convert.ToInt32(txtbulk.Text);
            int total = Retail + Bulkk;
            txttotal.Text = total.ToString();
        }
        catch { }
    }
    protected void txtbulk_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int Retail = Convert.ToInt32(txtRetail.Text);
            int Bulkk = Convert.ToInt32(txtbulk.Text);
            int total = Retail + Bulkk;
            txttotal.Text = total.ToString();
        }
        catch { }
    }

    public void display()
    {
        try
        {
            gl.query("SELECT     dbo.Branchmaster.branchname, dbo.Target_for_next_month.Target_nxt_mnth_id, dbo.Target_for_next_month.From_ho, dbo.Target_for_next_month.Retail,dbo.Target_for_next_month.Bulkk, dbo.Target_for_next_month.Total, dbo.Target_for_next_month.date FROM  dbo.Branchmaster INNER JOIN dbo.Target_for_next_month ON dbo.Branchmaster.Branchid = dbo.Target_for_next_month.Branch_id");
            GridView1.DataSource = gl.ds;
            GridView1.DataBind();
        }
        catch { }
    }
}