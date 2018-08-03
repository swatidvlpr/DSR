using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSR_Dealer_form : System.Web.UI.Page
{
    global gl = new global();
    public int total = 0;
    decimal totalPrice = 0M;
    int totalItems = 0;
    decimal totalPricelbl4 = 0M;
    int totalItemslbl5 = 0;
    decimal totalPricelbl6 = 0M;
    int totalItemslbl7 = 0;
    decimal totalPricelbl8 = 0M;
    int totalItemslbl9 = 0;
    decimal totalPricelbl10 = 0M;
    int totalItemslbl11 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", DropDownList1);

                gl.ddl_select("Categorymaster", "Category_id,Categorynm", "Categorynm", "Category_id", "0", "'Select'", DropDownList2);

                gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", DropDownList3);

                gl.display("Dealer", GridView1);

            }
        }
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Button1.Text == "update")
            {
                int idd = Convert.ToInt32(GridView1.SelectedValue);
                gl.update("Dealer", "companyname='" + DropDownList1.SelectedItem.Text + "',Categorynm='" + DropDownList2.SelectedItem.Text + "', Branch='" + DropDownList3.SelectedItem.Text + "', Target='" + TextBox3.Text + "',  Achievement='" + TextBox4.Text + "',TSSL_hand='" + TextBox5.Text + "', Percentage_achvmnt='" + TextBox6.Text + "', Date='" + TextBox7.Text + "'", "dealer_id", "'" + idd + "'");
                Label1.Text = "Updated Successfully";
            }
            else
            {
                //companyname,                           Categorynm,                              Branch,                   Target,             Achievement,            TSSL_hand,           Percentage_achvmnt,           Date

                gl.insert("Dealer", "'" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "'");

                Label1.Text = "Submitted Successfully";
            }
            gl.display("Dealer", GridView1);
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            DropDownList1.SelectedItem.Text = "";
            DropDownList2.SelectedItem.Text = "";
            DropDownList3.SelectedItem.Text = "";
            Button1.Text = "submit";
        }
        catch { }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dealer_form.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
            gl.read1("Dealer", "dealer_id", "'" + idd + "'");
            string companyname = gl.ds.Tables[0].Rows[0]["companyname"].ToString();
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Text == companyname)
                {
                    DropDownList1.Items[i].Selected = true;
                }
                else
                {
                    DropDownList1.Items[i].Selected = false;
                }

            }
            string Categorynm = gl.ds.Tables[0].Rows[0]["Categorynm"].ToString();
            for (int i = 0; i < DropDownList2.Items.Count; i++)
            {
                if (DropDownList2.Items[i].Text == Categorynm)
                {
                    DropDownList2.Items[i].Selected = true;
                }
                else
                {
                    DropDownList2.Items[i].Selected = false;
                }

            }
            string branchname = gl.ds.Tables[0].Rows[0]["branchname"].ToString();
            for (int i = 0; i < DropDownList3.Items.Count; i++)
            {
                if (DropDownList3.Items[i].Text == branchname)
                {
                    DropDownList3.Items[i].Selected = true;
                }
                else
                {
                    DropDownList3.Items[i].Selected = false;
                }

            }

            DropDownList1.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["companyname"].ToString();
            DropDownList2.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Categorynm"].ToString();
            DropDownList3.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["branchname"].ToString();
            TextBox3.Text = gl.ds.Tables[0].Rows[0]["Target"].ToString();
            TextBox4.Text = gl.ds.Tables[0].Rows[0]["Achievement"].ToString();
            TextBox5.Text = gl.ds.Tables[0].Rows[0]["TSSL_hand"].ToString();
            TextBox6.Text = gl.ds.Tables[0].Rows[0]["Percentage_achvmnt"].ToString();
            TextBox7.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
            Button1.Text = "update";
        }
        catch { }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Dealer", "dealer_id", "'" + id1 + "'");
            gl.display("Dealer", GridView1);
        }
        catch { }
    }
   
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label4");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl4 += price;

                totalItemslbl5 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label5");


                lblTotalPrice.Text = totalPricelbl4.ToString();

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label6");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl6 += price;

                totalItemslbl7 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label7");


                lblTotalPrice.Text = totalPricelbl6.ToString();

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label8");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl8 += price;

                totalItemslbl9 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label9");


                lblTotalPrice.Text = totalPricelbl8.ToString();

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label10");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl10 += price;

                totalItemslbl11 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label11");


                lblTotalPrice.Text = totalPricelbl10.ToString();
            }
        }
        catch { }

    }
   
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        try{
        double t1 = Convert.ToDouble(TextBox3.Text);
        double t2 = Convert.ToDouble(TextBox4.Text);
        double t3 = Convert.ToDouble(TextBox5.Text);
        double total = (t2 + t3) / t1 * 100;
        TextBox6.Text = total.ToString();
        }
        catch{}
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        try{
        double t1 = Convert.ToDouble(TextBox3.Text);
        double t2 = Convert.ToDouble(TextBox4.Text);
        double t3 = Convert.ToDouble(TextBox5.Text);
        double total = (t2 + t3) / t1 * 100;
        TextBox6.Text = total.ToString();
            }
        catch{}
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        try{
        double t1 = Convert.ToDouble(TextBox3.Text);
        double t2 = Convert.ToDouble(TextBox4.Text);
        double t3 = Convert.ToDouble(TextBox5.Text);
        double total = (t2 + t3) / t1 * 100;
        TextBox6.Text = total.ToString();
            }
        catch{}
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        try{
        double t1 = Convert.ToDouble(TextBox3.Text);
        double t2 = Convert.ToDouble(TextBox4.Text);
        double t3 = Convert.ToDouble(TextBox5.Text);
        double total = (t2 + t3) / t1 * 100;
        TextBox6.Text = total.ToString();
        }
        catch { }
    }
}