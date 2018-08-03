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

public partial class DSR_Monthly_vehicle_sale : System.Web.UI.Page
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
    decimal totalPricelbl12 = 0M;
    int totalItemslbl13 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", DropDownList1);
                gl.display("Monthly_vehicle_sale", GridView1);
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
                gl.update("Monthly_vehicle_sale", "Modelnm='" + DropDownList1.SelectedItem.Text + "', No_of_prospects='" + TextBox2.Text + "',No_of_enquiry='" + TextBox3.Text + "', No_of_sale='" + TextBox4.Text + "',  TSSL_hand='" + TextBox5.Text + "',  Conversion_ratio='" + TextBox6.Text + "',Pending_booking='" + TextBox7.Text + "', Date='" + TextBox8.Text + "'", "Vehicle_id", "'" + idd + "'");
                Label1.Text = "Updated Successfully";
            }
            else
            {
                //Modelnm,              No_of_prospects,        No_of_enquiry,          No_of_sale,              TSSL_hand,           Conversion_ratio,         Pending_booking             Date

                gl.insert("Monthly_vehicle_sale", "'" + DropDownList1.SelectedItem.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "'");

                Label1.Text = "Submitted Successfully";
            }
            gl.display("Monthly_vehicle_sale", GridView1);
        }
        catch { }
        DropDownList1.SelectedItem.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        Button1.Text = "submit";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Monthly_vehicle_sale.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
            gl.read1("Monthly_vehicle_sale", "Vehicle_id", "'" + idd + "'");
            string Modelnm = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();

            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Text == Modelnm)
                {
                    DropDownList1.Items[i].Selected = true;
                }
                else
                {
                    DropDownList1.Items[i].Selected = false;
                }
            }
            DropDownList1.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
            TextBox2.Text = gl.ds.Tables[0].Rows[0]["No_of_prospects"].ToString();
            TextBox3.Text = gl.ds.Tables[0].Rows[0]["No_of_enquiry"].ToString();
            TextBox4.Text = gl.ds.Tables[0].Rows[0]["No_of_sale"].ToString();
            TextBox5.Text = gl.ds.Tables[0].Rows[0]["TSSL_hand"].ToString();
            TextBox6.Text = gl.ds.Tables[0].Rows[0]["Conversion_ratio"].ToString();
            TextBox7.Text = gl.ds.Tables[0].Rows[0]["Pending_booking"].ToString();
            TextBox8.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
            Button1.Text = "update";
        }
        catch { }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Monthly_vehicle_sale", "Vehicle_id", "'" + id1 + "'");
            gl.display("Monthly_vehicle_sale", GridView1);
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
        }
        catch { }

    }
   
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double t1 = Convert.ToDouble(TextBox2.Text);
            double t2 = Convert.ToDouble(TextBox3.Text);
            double t3 = Convert.ToDouble(TextBox4.Text);
            double t4 = Convert.ToDouble(TextBox5.Text);
            double total = (t3 + t4) / (t2 + t1) * 100;
            TextBox6.Text = total.ToString();
        }
        catch { }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double t1 = Convert.ToDouble(TextBox2.Text);
            double t2 = Convert.ToDouble(TextBox3.Text);
            double t3 = Convert.ToDouble(TextBox4.Text);
            double t4 = Convert.ToDouble(TextBox5.Text);
            double total = (t3 + t4) / (t2 + t1) * 100;
            TextBox6.Text = total.ToString();
        }
        catch { }
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double t1 = Convert.ToDouble(TextBox2.Text);
            double t2 = Convert.ToDouble(TextBox3.Text);
            double t3 = Convert.ToDouble(TextBox4.Text);
            double t4 = Convert.ToDouble(TextBox5.Text);
            double total = (t3 + t4) / (t2 + t1) * 100;
            TextBox6.Text = total.ToString();
        }
        catch { }
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double t1 = Convert.ToDouble(TextBox2.Text);
            double t2 = Convert.ToDouble(TextBox3.Text);
            double t3 = Convert.ToDouble(TextBox4.Text);
            double t4 = Convert.ToDouble(TextBox5.Text);
            double total = (t3 + t4) / (t2 + t1) * 100;
            TextBox6.Text = total.ToString();
        }
        catch { }
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double t1 = Convert.ToDouble(TextBox2.Text);
            double t2 = Convert.ToDouble(TextBox3.Text);
            double t3 = Convert.ToDouble(TextBox4.Text);
            double t4 = Convert.ToDouble(TextBox5.Text);
            double total = (t3 + t4) / (t2 + t1) * 100;
            TextBox6.Text = total.ToString();
        }
        catch { }
    }
}