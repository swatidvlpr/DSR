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


public partial class DSR_Oppertunity_search : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", DropDownList3);

            gl.query("SELECT     dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Branchmaster.branchname, dbo.Oppertunity.Date, dbo.Oppertunity.Finacier,dbo.Oppertunity.Enquiry_source, dbo.Oppertunity.Purchase_plan, dbo.Oppertunity.Quantity, dbo.Oppertunity.Color, dbo.Oppertunity.Modelno,dbo.Oppertunity.Modelnm, dbo.Oppertunity.Opportunity_id, dbo.Employee_Reg.Name, dbo.Oppertunity.Saleman_id, dbo.Oppertunity.Customer_id,dbo.Enquryform.Customer_name FROM dbo.Oppertunity INNER JOIN dbo.Categorymaster ON dbo.Oppertunity.Category_id = dbo.Categorymaster.Category_id INNER JOIN   dbo.companymaster ON dbo.Oppertunity.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Branchmaster ON dbo.Oppertunity.Branchid = dbo.Branchmaster.Branchid INNER JOIN dbo.Employee_Reg ON dbo.Oppertunity.Saleman_id = dbo.Employee_Reg.EmployeeCode INNER JOIN  dbo.Enquryform ON dbo.Oppertunity.Customer_id = dbo.Enquryform.Enquryid WHERE MONTH(dbo.Oppertunity.Date) = MONTH(dateadd(dd, -1, GetDate()))");
            GridView1.DataSource = gl.ds;
            GridView1.DataBind();

            for (int i = 2018; i <= 2045; i++)
            {
                DropDownList2.Items.Add(i.ToString());
            }
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
                    if (DropDownList3.SelectedIndex == 0)
                    {

                    }
                    else
                    {
                        gl.query("SELECT     dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Branchmaster.branchname, dbo.Oppertunity.Date, dbo.Oppertunity.Finacier,dbo.Oppertunity.Enquiry_source, dbo.Oppertunity.Purchase_plan, dbo.Oppertunity.Quantity, dbo.Oppertunity.Color, dbo.Oppertunity.Modelno,dbo.Oppertunity.Modelnm, dbo.Oppertunity.Opportunity_id, dbo.Employee_Reg.Name, dbo.Oppertunity.Saleman_id, dbo.Oppertunity.Customer_id,dbo.Enquryform.Customer_name FROM dbo.Oppertunity INNER JOIN dbo.Categorymaster ON dbo.Oppertunity.Category_id = dbo.Categorymaster.Category_id INNER JOIN   dbo.companymaster ON dbo.Oppertunity.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Branchmaster ON dbo.Oppertunity.Branchid = dbo.Branchmaster.Branchid INNER JOIN dbo.Employee_Reg ON dbo.Oppertunity.Saleman_id = dbo.Employee_Reg.EmployeeCode INNER JOIN  dbo.Enquryform ON dbo.Oppertunity.Customer_id = dbo.Enquryform.Enquryid WHERE dbo.Oppertunity.Branchid ='" + DropDownList3.SelectedValue + "'");
                        GridView1.DataSource = gl.ds;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    gl.query("SELECT     dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Branchmaster.branchname, dbo.Oppertunity.Date, dbo.Oppertunity.Finacier,dbo.Oppertunity.Enquiry_source, dbo.Oppertunity.Purchase_plan, dbo.Oppertunity.Quantity, dbo.Oppertunity.Color, dbo.Oppertunity.Modelno,dbo.Oppertunity.Modelnm, dbo.Oppertunity.Opportunity_id, dbo.Employee_Reg.Name, dbo.Oppertunity.Saleman_id, dbo.Oppertunity.Customer_id,dbo.Enquryform.Customer_name FROM dbo.Oppertunity INNER JOIN dbo.Categorymaster ON dbo.Oppertunity.Category_id = dbo.Categorymaster.Category_id INNER JOIN   dbo.companymaster ON dbo.Oppertunity.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Branchmaster ON dbo.Oppertunity.Branchid = dbo.Branchmaster.Branchid INNER JOIN dbo.Employee_Reg ON dbo.Oppertunity.Saleman_id = dbo.Employee_Reg.EmployeeCode INNER JOIN  dbo.Enquryform ON dbo.Oppertunity.Customer_id = dbo.Enquryform.Enquryid WHERE YEAR(dbo.Oppertunity.Date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();
                }
            }
            else
            {
                gl.query("SELECT     dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Branchmaster.branchname, dbo.Oppertunity.Date, dbo.Oppertunity.Finacier,dbo.Oppertunity.Enquiry_source, dbo.Oppertunity.Purchase_plan, dbo.Oppertunity.Quantity, dbo.Oppertunity.Color, dbo.Oppertunity.Modelno,dbo.Oppertunity.Modelnm, dbo.Oppertunity.Opportunity_id, dbo.Employee_Reg.Name, dbo.Oppertunity.Saleman_id, dbo.Oppertunity.Customer_id,dbo.Enquryform.Customer_name FROM dbo.Oppertunity INNER JOIN dbo.Categorymaster ON dbo.Oppertunity.Category_id = dbo.Categorymaster.Category_id INNER JOIN   dbo.companymaster ON dbo.Oppertunity.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Branchmaster ON dbo.Oppertunity.Branchid = dbo.Branchmaster.Branchid INNER JOIN dbo.Employee_Reg ON dbo.Oppertunity.Saleman_id = dbo.Employee_Reg.EmployeeCode INNER JOIN  dbo.Enquryform ON dbo.Oppertunity.Customer_id = dbo.Enquryform.Enquryid WHERE dbo.Oppertunity.Date ='" + TextBox1.Text + "'");
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
                gl.query("SELECT     dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Branchmaster.branchname, dbo.Oppertunity.Date, dbo.Oppertunity.Finacier,dbo.Oppertunity.Enquiry_source, dbo.Oppertunity.Purchase_plan, dbo.Oppertunity.Quantity, dbo.Oppertunity.Color, dbo.Oppertunity.Modelno,dbo.Oppertunity.Modelnm, dbo.Oppertunity.Opportunity_id, dbo.Employee_Reg.Name, dbo.Oppertunity.Saleman_id, dbo.Oppertunity.Customer_id,dbo.Enquryform.Customer_name FROM dbo.Oppertunity INNER JOIN dbo.Categorymaster ON dbo.Oppertunity.Category_id = dbo.Categorymaster.Category_id INNER JOIN   dbo.companymaster ON dbo.Oppertunity.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Branchmaster ON dbo.Oppertunity.Branchid = dbo.Branchmaster.Branchid INNER JOIN dbo.Employee_Reg ON dbo.Oppertunity.Saleman_id = dbo.Employee_Reg.EmployeeCode INNER JOIN  dbo.Enquryform ON dbo.Oppertunity.Customer_id = dbo.Enquryform.Enquryid WHERE MONTH(dbo.Oppertunity.Date)='" + DropDownList1.SelectedValue + "' and YEAR(dbo.Oppertunity.Date) ='" + DropDownList2.SelectedValue + "'");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();

            }

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Oppertunity_search.aspx");
    }
    private void ExportGridToExcel()
    {
        // GridView1.Columns[0].Visible = false;
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Oppertunity" + DateTime.Now + ".xls";
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
        string FileName = "Oppertunity" + DateTime.Now + ".xls";
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
    public void display()
    {
        gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Branchmaster.branchname, dbo.Oppertunity.Date, dbo.Oppertunity.Finacier,dbo.Oppertunity.Enquiry_source, dbo.Oppertunity.Purchase_plan, dbo.Oppertunity.Quantity, dbo.Oppertunity.Color, dbo.Oppertunity.Modelno,dbo.Oppertunity.Modelnm, dbo.Oppertunity.Opportunity_id FROM  dbo.Oppertunity INNER JOIN dbo.Categorymaster ON dbo.Oppertunity.Category_id = dbo.Categorymaster.Category_id INNER JOIN dbo.companymaster ON dbo.Oppertunity.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Branchmaster ON dbo.Oppertunity.Branchid = dbo.Branchmaster.Branchid");
        GridView1.DataSource = gl.ds;
        GridView1.DataBind();
    }
}