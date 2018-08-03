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


public partial class DSR_Unsaleable_vehicle_search : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Modelmaster.Modelnm, dbo.Unsaleable_vehicles.Unsale_id,dbo.Unsaleable_vehicles.Model_no, dbo.Unsaleable_vehicles.Color, dbo.Unsaleable_vehicles.Engine_no, dbo.Unsaleable_vehicles.VIN_no,dbo.Unsaleable_vehicles.Date FROM  dbo.Categorymaster INNER JOIN dbo.Unsaleable_vehicles ON dbo.Categorymaster.Category_id = dbo.Unsaleable_vehicles.Category_id INNER JOIN dbo.companymaster ON dbo.Unsaleable_vehicles.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Modelmaster ON dbo.Unsaleable_vehicles.Modelid = dbo.Modelmaster.Modelid WHERE MONTH(dbo.Unsaleable_vehicles.Date) = MONTH(dateadd(dd, -1,GetDate()))");
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

                }
                else
                {
                    gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Modelmaster.Modelnm, dbo.Unsaleable_vehicles.Unsale_id,dbo.Unsaleable_vehicles.Model_no, dbo.Unsaleable_vehicles.Color, dbo.Unsaleable_vehicles.Engine_no, dbo.Unsaleable_vehicles.VIN_no,dbo.Unsaleable_vehicles.Date FROM  dbo.Categorymaster INNER JOIN dbo.Unsaleable_vehicles ON dbo.Categorymaster.Category_id = dbo.Unsaleable_vehicles.Category_id INNER JOIN dbo.companymaster ON dbo.Unsaleable_vehicles.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Modelmaster ON dbo.Unsaleable_vehicles.Modelid = dbo.Modelmaster.Modelid WHERE YEAR(dbo.Unsaleable_vehicles.Date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();
                }
            }
            else
            {
                gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Modelmaster.Modelnm, dbo.Unsaleable_vehicles.Unsale_id,dbo.Unsaleable_vehicles.Model_no, dbo.Unsaleable_vehicles.Color, dbo.Unsaleable_vehicles.Engine_no, dbo.Unsaleable_vehicles.VIN_no,dbo.Unsaleable_vehicles.Date FROM  dbo.Categorymaster INNER JOIN dbo.Unsaleable_vehicles ON dbo.Categorymaster.Category_id = dbo.Unsaleable_vehicles.Category_id INNER JOIN dbo.companymaster ON dbo.Unsaleable_vehicles.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Modelmaster ON dbo.Unsaleable_vehicles.Modelid = dbo.Modelmaster.Modelid WHERE dbo.Unsaleable_vehicles.Date ='" + TextBox1.Text + "'");
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
                gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Modelmaster.Modelnm, dbo.Unsaleable_vehicles.Unsale_id,dbo.Unsaleable_vehicles.Model_no, dbo.Unsaleable_vehicles.Color, dbo.Unsaleable_vehicles.Engine_no, dbo.Unsaleable_vehicles.VIN_no,dbo.Unsaleable_vehicles.Date FROM  dbo.Categorymaster INNER JOIN dbo.Unsaleable_vehicles ON dbo.Categorymaster.Category_id = dbo.Unsaleable_vehicles.Category_id INNER JOIN dbo.companymaster ON dbo.Unsaleable_vehicles.Company_id = dbo.companymaster.company_id INNER JOIN dbo.Modelmaster ON dbo.Unsaleable_vehicles.Modelid = dbo.Modelmaster.Modelid WHERE MONTH(dbo.Unsaleable_vehicles.Date)='" + DropDownList1.SelectedValue + "' and YEAR(dbo.Unsaleable_vehicles.Date) ='" + DropDownList2.SelectedValue + "'");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();

            }

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Unsaleable_vehicle_search.aspx");
    }
    private void ExportGridToExcel()
    {
        // GridView1.Columns[0].Visible = false;
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Unsaleable vehicle" + DateTime.Now + ".xls";
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
        ExportGridToExcel();
    }
}