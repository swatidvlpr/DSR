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

public partial class DSR_Financier_wise_sale_report : System.Web.UI.Page
{   global gl = new global();
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
                gl.query("select * from FINANCIER_WISE_SALE WHERE MONTH(date) = MONTH(dateadd(dd, -1, GetDate()))");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();

                for (int i = 2018; i <= 2045; i++)
                {
                    DropDownList2.Items.Add(i.ToString());
                }

            }
        }
        catch
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0)
        {

            if (TextBox1.Text == "")
            {
                if (DropDownList2.SelectedIndex == 0)
                {

                }
                else
                {
                    gl.query("select * from FINANCIER_WISE_SALE WHERE YEAR(date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();
                }
            }
            else
            {
                gl.query("Select * from FINANCIER_WISE_SALE WHERE date ='" + TextBox1.Text + "'");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();
            }

        }
        else
        {
            if (DropDownList1.SelectedIndex == 0 && DropDownList2.SelectedIndex == 0)
            {

            }
            else
            {
                gl.query("select * from FINANCIER_WISE_SALE WHERE MONTH(date)='" + DropDownList1.SelectedValue + "' and YEAR(date) ='" + DropDownList2.SelectedValue + "'");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();

            }

        }
    }
    private void ExportGridToExcel()
    {
        try
        {
            // GridView1.Columns[0].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Financier wise sale" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            // GridView1.AllowPaging = false;
            // GridView1.Columns.RemoveAt(0);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);

            GridView1.DataBind();
            Response.Write(strwritter.ToString());
            Response.End();
        }
        catch { }
    }
        protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Financier_wise_sale_report.aspx");
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


              Label lblPrice1 = (Label)e.Row.FindControl("Label3");

              decimal price1 = Decimal.Parse(lblPrice1.Text);

              totalPrice1 += price1;

              totalItems1 += 1;


              Label lblPrice2 = (Label)e.Row.FindControl("Label4");

              decimal price2 = Decimal.Parse(lblPrice2.Text);

              totalPrice2 += price2;

              totalItems2 += 1;


              Label lblPrice3 = (Label)e.Row.FindControl("Label5");

              decimal price3 = Decimal.Parse(lblPrice3.Text);

              totalPrice3 += price3;

              totalItems3 += 1;

          }

          if (e.Row.RowType == DataControlRowType.Footer)
          {
              Label lblTotalPrice = (Label)e.Row.FindControl("lbltotal2");
              lblTotalPrice.Text = totalPrice.ToString();

              Label lblTotalPrice1 = (Label)e.Row.FindControl("lbltotal3");
              lblTotalPrice1.Text = totalPrice1.ToString();

              Label lblTotalPrice2 = (Label)e.Row.FindControl("lbltotal4");
              lblTotalPrice2.Text = totalPrice2.ToString();

              Label lblTotalPrice3 = (Label)e.Row.FindControl("lbltotal5");
              lblTotalPrice3.Text = totalPrice3.ToString();

          }
      }

      protected void Button3_Click(object sender, EventArgs e)
      {
          try
          {
             // ExportGridToExcel();
              Response.Clear();
              Response.Buffer = true;
              string FileName = "FINANCIER WISE SALE" + DateTime.Now + ".xls";
              Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
              Response.Charset = "";
              Response.ContentType = "application/vnd.ms-excel";
              using (StringWriter sw = new StringWriter())
              {
                  HtmlTextWriter hw = new HtmlTextWriter(sw);
                  Panel1.RenderControl(hw);
                  Response.Output.Write(sw.ToString());
                  Response.Flush();
                  Response.End();
              }

          }
          catch { }
      }
}