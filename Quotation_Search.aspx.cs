using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.IO;
using System.Threading;
using System.Configuration;
using System.Text;
using System.Drawing;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Data;
using System.Data.SqlClient;
public partial class DSR_Quotation_Search : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", ddlbranch);
            gl.ddl_select("Quotation_proforma_invoice", "Quotationid,Challanno", "Challanno", "Quotationid", "0", "'Select'",ddlchallan);
            gl.ddl_select("Quotation_proforma_invoice", "Quotationid,orderno", "orderno", "Quotationid", "0", "'Select'",ddlorder);
            gl.ddl_select("Quotation_proforma_invoice", "Quotationid,QTN_NO", "QTN_NO", "Quotationid", "0", "'Select'",ddlqutno);
            gl.ddl_select("Quotation_proforma_invoice", "Quotationid,Customername", "Customername", "Quotationid", "0", "'Select'",ddlcstmrnm);
           
            //gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);

            gl.query("select * from Quotation_proforma_invoice WHERE MONTH(date) = MONTH(dateadd(dd, -1, GetDate()))");
            GridView1.DataSource = gl.ds;
            GridView1.DataBind();
            GridView2.DataSource = gl.ds;
            GridView2.DataBind();
            for (int i = 2018; i <= 2045; i++)
            {
                DropDownList2.Items.Add(i.ToString());
            }

        }
    }
 
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlbranch.SelectedIndex == 0)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                if (DropDownList2.SelectedIndex == 0)
                {
                    if (ddlchallan.SelectedIndex == 0)
                    {
                        if (ddlorder.SelectedIndex == 0)
                        {
                            if (ddlqutno.SelectedIndex == 0)
                            {
                                if (ddlcstmrnm.SelectedIndex == 0)
                                { }
                                else
                                {
                                    gl.query("select * from Quotation_proforma_invoice where Customername ='" + ddlcstmrnm.SelectedItem.Text + "'");
                                    GridView1.DataSource = gl.ds;
                                    GridView1.DataBind();
                                    GridView2.DataSource = gl.ds;
                                    GridView2.DataBind();
                                }
                            }
                            else
                            {
                                gl.query("select * from Quotation_proforma_invoice where QTN_NO ='" + ddlqutno.SelectedItem.Text + "'");
                                GridView1.DataSource = gl.ds;
                                GridView1.DataBind();
                                GridView2.DataSource = gl.ds;
                                GridView2.DataBind();
                            }
                        }
                        else
                        {
                            gl.query("select * from Quotation_proforma_invoice where orderno ='" + ddlorder.SelectedItem.Text + "'");
                            GridView1.DataSource = gl.ds;
                            GridView1.DataBind();
                            GridView2.DataSource = gl.ds;
                            GridView2.DataBind();
                        }
                    }
                    else
                    {
                        gl.query("select * from Quotation_proforma_invoice where Challanno ='" + ddlchallan.SelectedItem.Text + "'");
                        GridView1.DataSource = gl.ds;
                        GridView1.DataBind();
                        GridView2.DataSource = gl.ds;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    gl.query("select * from Quotation_proforma_invoice where YEAR(date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();
                    GridView2.DataSource = gl.ds;
                    GridView2.DataBind();
                
                }

            }
            else
            {
                if (DropDownList1.SelectedIndex == 0 && DropDownList2.SelectedIndex == 0)
                {

                }
                else
                {
                    gl.query("select * from Quotation_proforma_invoice where YEAR(date) ='" + DropDownList2.SelectedValue + "' and MONTH(date)='" + DropDownList1.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();
                    GridView2.DataSource = gl.ds;
                    GridView2.DataBind();
                
                }
            
            
            }
        }
        else
        {
            gl.query("select * from Quotation_proforma_invoice where branchnm='" + ddlbranch.SelectedItem.Text + "'");
            GridView1.DataSource = gl.ds;
            GridView1.DataBind();
            GridView2.DataSource = gl.ds;
            GridView2.DataBind();
        
        }
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Quotation_Search.aspx");
    }
    private void ExportGridToExcel()
    {
       
            // GridView1.Columns[0].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Quotation cumproforma" + DateTime.Now + ".xls";
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        string FileName = "Quotation cumproforma" + DateTime.Now + ".xls";
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
}