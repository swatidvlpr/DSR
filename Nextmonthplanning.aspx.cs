using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSR_Nextmonthplanning : System.Web.UI.Page
{
    global gl = new global();
    public int total = 0;
    decimal totalPrice = 0M;
    decimal totalPrice1 = 0M;
    decimal totalPrice2 = 0M;
    
    //decimal totalPrice4 = 0M;
    int totalItems = 0;
    int totalItems1 = 0;
    int totalItems2 = 0;
   
    //int totalItems4 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                
                gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", ddlmodel);
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
                gl.update("Nextmonthplanning", " Model='" + ddlmodel.SelectedItem.Text + "', Hot='" + txthot.Text + "', Warm='" + txtwarm.Text + "', Total='" + txttotal.Text + "', date='" + txtdate.Text + "'", "nextmonthplan_id", "'" + idd + "'");
            }
            else
            {
                gl.insert1("Nextmonthplanning", " Model, Hot, Warm, Total, date", "'" + ddlmodel.SelectedItem.Text + "','" + txthot.Text + "','" + txtwarm.Text + "','" + txttotal.Text + "','" + txtdate.Text + "'");

            }
            gl.display("Nextmonthplanning", GridView1);

            ddlmodel.SelectedIndex = 0;
            txthot.Text = "0";
            txttotal.Text = "0";
            txtwarm.Text = "0";
            txttotal.Text = "0";
            txtdate.Text = "";



        }
        catch
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Nextmonthplanning.aspx");
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

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lbltotal1");
                lblTotalPrice.Text = totalPrice.ToString();

                Label lblTotalPrice1 = (Label)e.Row.FindControl("lbltotal2");
                lblTotalPrice1.Text = totalPrice1.ToString();
                Label lblTotalPrice3 = (Label)e.Row.FindControl("lbltotal3");
                lblTotalPrice3.Text = totalPrice2.ToString();
            }
        }
        catch { }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            gl.read1("Nextmonthplanning", "nextmonthplan_id", "'" + id + "'");
                     
            string model = gl.ds.Tables[0].Rows[0]["Model"].ToString();

            for (int i = 0; i < ddlmodel.Items.Count; i++)
            {
                if (ddlmodel.Items[i].Text == model)
                {
                    ddlmodel.Items[i].Selected = true;
                }
                else
                {
                    ddlmodel.Items[i].Selected = false;
                }
            }
            txthot.Text = gl.ds.Tables[0].Rows[0]["Hot"].ToString();
            txtwarm.Text = gl.ds.Tables[0].Rows[0]["Warm"].ToString();
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
            gl.delete("Nextmonthplanning", "nextmonthplan_id", "'" + idd + "'");
            gl.display("Nextmonthplanning", GridView1);
        }
        catch { }
    }
   
    protected void txthot_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int hot = Convert.ToInt32(txthot.Text);
            int warm = Convert.ToInt32(txtwarm.Text);
            int total = hot + warm;
            txttotal.Text = total.ToString();
        }
        catch { }
    }
    protected void txtwarm_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int hot = Convert.ToInt32(txthot.Text);
            int warm = Convert.ToInt32(txtwarm.Text);
            int total = hot + warm;
            txttotal.Text = total.ToString();
        }
        catch { }
    }

    public void display()
    {
        gl.display("Nextmonthplanning", GridView1);
    
    }
}