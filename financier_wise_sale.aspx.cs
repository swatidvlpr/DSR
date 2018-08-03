using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_financier_wise_sale : System.Web.UI.Page
{
    global gl = new global();
    public int total = 0;
    decimal totalPrice = 0M;
    decimal totalPrice1 = 0M;
    decimal totalPrice2 = 0M;
    decimal totalPrice3 = 0M;
    decimal totalPrice4 = 0M;
    int totalItems = 0;
    int totalItems1 = 0;
    int totalItems2= 0;
    int totalItems3 = 0;
    int totalItems4 = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                

                gl.ddl_select("Financiermaster", "Financier_id,Financiername", "Financiername", "Financier_id", "0", "'Select'", ddlfinancier);
                gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", ddlmodel);

                gl.display("FINANCIER_WISE_SALE", GridView1);
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
                gl.update("FINANCIER_WISE_SALE", "Financier='" + ddlfinancier.SelectedItem.Text + "',Model='" + ddlmodel.SelectedItem.Text + "',Sale_Qty='" + txtSaleQty.Text + "',Total='" + txttotal.Text + "',T_S_In_Hand='" + txtT_S_In_Hand.Text + "',Total_T_Sheet='" + txtTotal_T_Sheet.Text + "',date='" + txtdate.Text + "'", " Financiersale_id", "'" + idd + "'");
            }
            else
            {
                gl.insert1("FINANCIER_WISE_SALE", "Financier, Model, Sale_Qty, Total, T_S_In_Hand, Total_T_Sheet, date", "'" + ddlfinancier.SelectedItem.Text + "','" + ddlmodel.SelectedItem.Text + "','" + txtSaleQty.Text + "','" + txttotal.Text + "','" + txtT_S_In_Hand.Text + "','" + txtTotal_T_Sheet.Text + "','" + txtdate.Text + "'");
            
            }
            gl.display("FINANCIER_WISE_SALE", GridView1);
            ddlfinancier.SelectedIndex = 0;
            ddlmodel.SelectedIndex = 0;
            txtSaleQty.Text = "0";
            txttotal.Text = "0";
            txtT_S_In_Hand.Text = "0";
            txtTotal_T_Sheet.Text = "0";
            txtdate.Text = "";         

        }
        catch
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("financier_wise_sale.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            gl.read1("FINANCIER_WISE_SALE", "Financiersale_id", "'" + id + "'");
            //ddlfinancier.SelectedItem.Text = 
            string financier1=gl.ds.Tables[0].Rows[0]["Financier"].ToString();
            for (int i = 0; i < ddlfinancier.Items.Count; i++)
            {
                if (ddlfinancier.Items[i].Text == financier1)
                {
                    ddlfinancier.Items[i].Selected = true;
                }
                else
                {
                    ddlfinancier.Items[i].Selected = false;
                }
            }
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
            txtSaleQty.Text = gl.ds.Tables[0].Rows[0]["Sale_Qty"].ToString();
            txttotal.Text = gl.ds.Tables[0].Rows[0]["Total"].ToString();
            txtT_S_In_Hand.Text = gl.ds.Tables[0].Rows[0]["T_S_In_Hand"].ToString();
            txtTotal_T_Sheet.Text = gl.ds.Tables[0].Rows[0]["Total_T_Sheet"].ToString();
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
            gl.delete("FINANCIER_WISE_SALE", "Financiersale_id", "'" + idd + "'");
            gl.display("FINANCIER_WISE_SALE", GridView1);
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
}