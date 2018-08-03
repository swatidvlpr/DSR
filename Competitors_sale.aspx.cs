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

public partial class DSR_Competitors_sale : System.Web.UI.Page
{
    global gl = new global();

    public int total = 0;
    decimal totalPrice = 0M;
    int totalItems = 0;
    decimal totalPricelbl6 = 0M;
    int totalItemslbl7 = 0;
    decimal totalPricelbl8 = 0M;
    int totalItemslbl9 = 0;
    decimal totalPricelbl10 = 0M;
    int totalItemslbl11 = 0;
    decimal totalPricelbl12 = 0M;
    int totalItemslbl13 = 0;
    decimal totalPricelbl14 = 0M;
    int totalItemslbl15 = 0;
    decimal totalPricelbl16 = 0M;
    int totalItemslbl17 = 0;
    decimal totalPricelbl18 = 0M;
    int totalItemslbl19 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gl.display("Competitors_sale", GridView1);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Button1.Text == "update")
            {
                int idd = Convert.ToInt32(GridView1.SelectedValue);
                gl.update("Competitors_sale", "Category='" + TextBox1.Text + "',Class='" + TextBox8.Text + "',Tata='" + TextBox9.Text + "', Al='" + TextBox2.Text + "', Amw='" + TextBox3.Text + "',  Mm='" + TextBox4.Text + "',Man='" + TextBox5.Text + "', Eicher='" + TextBox6.Text + "', Benz='" + TextBox7.Text + "',Total='" + TextBox10.Text + "',Date='" + TextBox11.Text + "'", "Sale_id", "'" + idd + "'");
                Label1.Text = "Updated Successfully";
            }
            else
            {
                //Category,                 Class,                 Tata,                      Al,                   Amw,                     Mm,                    Man,                  Eicher,                   Benz                  Total                        Date

                gl.insert("Competitors_sale", "'" + TextBox1.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "'");

                Label1.Text = "Submitted Successfully";
            }
            gl.display("Competitors_sale", GridView1);

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            Button1.Text = "submit";
        }
        catch { }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Competitor_sale.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
            gl.read1("Competitors_sale", "Sale_id", "'" + idd + "'");
            TextBox1.Text = gl.ds.Tables[0].Rows[0]["Category"].ToString();
            TextBox8.Text = gl.ds.Tables[0].Rows[0]["Class"].ToString();
            TextBox9.Text = gl.ds.Tables[0].Rows[0]["Tata"].ToString();
            TextBox2.Text = gl.ds.Tables[0].Rows[0]["Al"].ToString();
            TextBox3.Text = gl.ds.Tables[0].Rows[0]["Amw"].ToString();
            TextBox4.Text = gl.ds.Tables[0].Rows[0]["Mm"].ToString();
            TextBox5.Text = gl.ds.Tables[0].Rows[0]["Man"].ToString();
            TextBox6.Text = gl.ds.Tables[0].Rows[0]["Eicher"].ToString();
            TextBox7.Text = gl.ds.Tables[0].Rows[0]["Benz"].ToString();
            TextBox10.Text = gl.ds.Tables[0].Rows[0]["Total"].ToString();
            TextBox11.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
            Button1.Text = "update";
        }
        catch { }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Competitors_sale", "Sale_id", "'" + id1 + "'");
            gl.display("Competitors_sale", GridView1);
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

                totalPrice += price;

                totalItems += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label5");


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


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label12");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl12 += price;

                totalItemslbl13 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label13");


                lblTotalPrice.Text = totalPricelbl12.ToString();

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label14");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl14 += price;

                totalItemslbl15 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label15");


                lblTotalPrice.Text = totalPricelbl14.ToString();

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label16");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl16 += price;

                totalItemslbl17 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label17");


                lblTotalPrice.Text = totalPricelbl16.ToString();

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label18");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPricelbl18 += price;

                totalItemslbl19 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label19");


                lblTotalPrice.Text = totalPricelbl18.ToString();

            }
        }
        catch { }
    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {
        try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
        }
        catch{}
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
    }
        catch{}
}
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
             }
        catch{}
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
        }
        catch{}
   }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
              }
        catch{}
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
              }
        catch{}
    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
        }
        catch{}
   }
    protected void TextBox10_TextChanged(object sender, EventArgs e)
    {
         try
        {
        int t1 = Convert.ToInt32(TextBox9.Text);
        int t2 = Convert.ToInt32(TextBox2.Text);
        int t3 = Convert.ToInt32(TextBox3.Text);
        int t4 = Convert.ToInt32(TextBox4.Text);
        int t5 = Convert.ToInt32(TextBox5.Text);
        int t6 = Convert.ToInt32(TextBox6.Text);
        int t7 = Convert.ToInt32(TextBox7.Text);
        int total = t1 + t2 + t3 + t4 + t5 + t6 + t7;
        TextBox10.Text = total.ToString();
        }
         catch{}
    }
}