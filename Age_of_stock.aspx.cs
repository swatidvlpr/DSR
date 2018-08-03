using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Text;
using System.Drawing;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
public partial class DSR_Age_of_stock : System.Web.UI.Page
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
                gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", DropDownList1);
                gl.display("Age_of_stock1", GridView1);
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
                gl.update("Age_of_stock1", "Model='" + DropDownList1.SelectedItem.Text + "',Lessthan_onemonth='" + TextBox2.Text + "',Btwnone_threemonth='" + TextBox3.Text + "', Btwnthree_sixmonth='" + TextBox4.Text + "',  Morethan_sixmonth='" + TextBox5.Text + "',  Total_stock='" + TextBox6.Text + "', Date='" + TextBox7.Text + "'", "stock_id", "'" + idd + "'");
                Label1.Text = "Updated Successfully";
            }
            else
            {

                // Model,            Lessthan_onemonth,     Btwnone_threemonth,     Btwnthree_sixmonth,     Morethan_sixmonth,          Total_stock             Date

                gl.insert("Age_of_stock1", "'" + DropDownList1.SelectedItem.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "'");

                Label1.Text = "Submitted Successfully";
            }
            gl.display("Age_of_stock1", GridView1);
        }
            catch { }
            DropDownList1.SelectedItem.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            Button1.Text = "submit";
       
}
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
            gl.read1("Age_of_stock1", "stock_id", "'" + idd + "'");
            string model = gl.ds.Tables[0].Rows[0]["Model"].ToString();

            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Text == model)
                {
                    DropDownList1.Items[i].Selected = true;
                }
                else
                {
                    DropDownList1.Items[i].Selected = false;
                }
            }
            DropDownList1.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Model"].ToString();
            TextBox2.Text = gl.ds.Tables[0].Rows[0]["Lessthan_onemonth"].ToString();
            TextBox3.Text = gl.ds.Tables[0].Rows[0]["Btwnone_threemonth"].ToString();
            TextBox4.Text = gl.ds.Tables[0].Rows[0]["Btwnthree_sixmonth"].ToString();
            TextBox5.Text = gl.ds.Tables[0].Rows[0]["Morethan_sixmonth"].ToString();
            TextBox6.Text = gl.ds.Tables[0].Rows[0]["Total_stock"].ToString();
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
            gl.delete("Age_of_stock1", "stock_id", "'" + id1 + "'");
            gl.display("Age_of_stock1", GridView1);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Age_of_stock.aspx");
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int t1 = Convert.ToInt32(TextBox2.Text);
            int t2 = Convert.ToInt32(TextBox3.Text);
            int t3 = Convert.ToInt32(TextBox4.Text);
            int t4 = Convert.ToInt32(TextBox5.Text);
            int total = t1 + t2 + t3 + t4;
            TextBox6.Text = total.ToString();
        }
        catch { }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox2.Text);
        int t2 = Convert.ToInt32(TextBox3.Text);
        int t3 = Convert.ToInt32(TextBox4.Text);
        int t4 = Convert.ToInt32(TextBox5.Text);
        int total = t1 + t2 + t3 + t4;
        TextBox6.Text = total.ToString();
              }
        catch { }
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        try
        {
        int t1 = Convert.ToInt32(TextBox2.Text);
        int t2 = Convert.ToInt32(TextBox3.Text);
        int t3 = Convert.ToInt32(TextBox4.Text);
        int t4 = Convert.ToInt32(TextBox5.Text);
        int total = t1 + t2 + t3 + t4;
        TextBox6.Text = total.ToString();
             }
        catch { }
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox2.Text);
        int t2 = Convert.ToInt32(TextBox3.Text);
        int t3 = Convert.ToInt32(TextBox4.Text);
        int t4 = Convert.ToInt32(TextBox5.Text);
        int total = t1 + t2 + t3 + t4;
        TextBox6.Text = total.ToString();
              }
        catch { }
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        try
        {
        int t1 = Convert.ToInt32(TextBox2.Text);
        int t2 = Convert.ToInt32(TextBox3.Text);
        int t3 = Convert.ToInt32(TextBox4.Text);
        int t4 = Convert.ToInt32(TextBox5.Text);
        int total = t1 + t2 + t3 + t4;
        TextBox6.Text = total.ToString();
        }
        catch { }
    }
}