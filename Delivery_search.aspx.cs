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

using System.Data;
using System.Data.SqlClient;

public partial class DSR_Delivery_search : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         //   gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcompany);
            gl.ddl_select("Delivery_challan_add", "Challan_id,Challlan_no", "Challlan_no", "Challan_id", "0", "'Select'", ddlchallan);
            gl.ddl_select("Delivery_challan_add", "Challan_id,Order_no", "Order_no", "Challan_id", "0", "'Select'", ddlorder);
            //gl.ddl_select("Modelmaster", "Modelid,Modelno", "Modelno", "Modelid", "0", "'Select'", ddlmodel);

            gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Delivery_challan_add.Tyremake, dbo.Delivery_challan_add.Battery_make,dbo.Delivery_challan_add.Batteryno, dbo.Delivery_challan_add.Ingnition_key_no, dbo.Delivery_challan_add.Chassis_no, dbo.Delivery_challan_add.Engine_no,dbo.Delivery_challan_add.Hirepurchase_lease_hypothecated_with_ms, dbo.Delivery_challan_add.Model_no, dbo.Delivery_challan_add.Modelnm,dbo.Delivery_challan_add.Date, dbo.Delivery_challan_add.Order_no, dbo.Delivery_challan_add.Challlan_no, dbo.Delivery_challan_add.Address,dbo.Delivery_challan_add.Email_id, dbo.Delivery_challan_add.Mobile_no, dbo.Delivery_challan_add.Customer_name, dbo.Delivery_challan_add.Challan_id FROM  dbo.Categorymaster INNER JOIN dbo.Delivery_challan_add ON dbo.Categorymaster.Category_id = dbo.Delivery_challan_add.Category_id INNER JOIN dbo.companymaster ON dbo.Delivery_challan_add.Company_id = dbo.companymaster.company_id WHERE MONTH(dbo.Delivery_challan_add.Date) = MONTH(dateadd(dd, -1, GetDate()))");
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
        if (DropDownList1.SelectedIndex == 0)
        {

            if (TextBox1.Text == "")
            {
                if (DropDownList2.SelectedIndex == 0)
                {
                
                    if (ddlchallan.SelectedIndex == 0)
                    {
                        if (ddlorder.SelectedIndex == 0)
                        {

                        }
                        else
                        {
                            gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Delivery_challan_add.Tyremake, dbo.Delivery_challan_add.Battery_make,dbo.Delivery_challan_add.Batteryno, dbo.Delivery_challan_add.Ingnition_key_no, dbo.Delivery_challan_add.Chassis_no, dbo.Delivery_challan_add.Engine_no,dbo.Delivery_challan_add.Hirepurchase_lease_hypothecated_with_ms, dbo.Delivery_challan_add.Model_no, dbo.Delivery_challan_add.Modelnm,dbo.Delivery_challan_add.Date, dbo.Delivery_challan_add.Order_no, dbo.Delivery_challan_add.Challlan_no, dbo.Delivery_challan_add.Address,dbo.Delivery_challan_add.Email_id, dbo.Delivery_challan_add.Mobile_no, dbo.Delivery_challan_add.Customer_name, dbo.Delivery_challan_add.Challan_id FROM  dbo.Categorymaster INNER JOIN dbo.Delivery_challan_add ON dbo.Categorymaster.Category_id = dbo.Delivery_challan_add.Category_id INNER JOIN dbo.companymaster ON dbo.Delivery_challan_add.Company_id = dbo.companymaster.company_id WHERE dbo.Delivery_challan_add.Order_no ='" + ddlorder.SelectedItem.Text + "'");
                            GridView1.DataSource = gl.ds;
                            GridView1.DataBind();
                            GridView2.DataSource = gl.ds;
                            GridView2.DataBind();
                        }
                    }
                    else
                    {
                        gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Delivery_challan_add.Tyremake, dbo.Delivery_challan_add.Battery_make,dbo.Delivery_challan_add.Batteryno, dbo.Delivery_challan_add.Ingnition_key_no, dbo.Delivery_challan_add.Chassis_no, dbo.Delivery_challan_add.Engine_no,dbo.Delivery_challan_add.Hirepurchase_lease_hypothecated_with_ms, dbo.Delivery_challan_add.Model_no, dbo.Delivery_challan_add.Modelnm,dbo.Delivery_challan_add.Date, dbo.Delivery_challan_add.Order_no, dbo.Delivery_challan_add.Challlan_no, dbo.Delivery_challan_add.Address,dbo.Delivery_challan_add.Email_id, dbo.Delivery_challan_add.Mobile_no, dbo.Delivery_challan_add.Customer_name, dbo.Delivery_challan_add.Challan_id FROM  dbo.Categorymaster INNER JOIN dbo.Delivery_challan_add ON dbo.Categorymaster.Category_id = dbo.Delivery_challan_add.Category_id INNER JOIN dbo.companymaster ON dbo.Delivery_challan_add.Company_id = dbo.companymaster.company_id WHERE dbo.Delivery_challan_add.Challlan_no ='" + ddlchallan.SelectedItem.Text + "'");
                        GridView1.DataSource = gl.ds;
                        GridView1.DataBind();
                        GridView2.DataSource = gl.ds;
                        GridView2.DataBind();
                    }
                   
                }
                else
                {
                    gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Delivery_challan_add.Tyremake, dbo.Delivery_challan_add.Battery_make,dbo.Delivery_challan_add.Batteryno, dbo.Delivery_challan_add.Ingnition_key_no, dbo.Delivery_challan_add.Chassis_no, dbo.Delivery_challan_add.Engine_no,dbo.Delivery_challan_add.Hirepurchase_lease_hypothecated_with_ms, dbo.Delivery_challan_add.Model_no, dbo.Delivery_challan_add.Modelnm,dbo.Delivery_challan_add.Date, dbo.Delivery_challan_add.Order_no, dbo.Delivery_challan_add.Challlan_no, dbo.Delivery_challan_add.Address,dbo.Delivery_challan_add.Email_id, dbo.Delivery_challan_add.Mobile_no, dbo.Delivery_challan_add.Customer_name, dbo.Delivery_challan_add.Challan_id FROM  dbo.Categorymaster INNER JOIN dbo.Delivery_challan_add ON dbo.Categorymaster.Category_id = dbo.Delivery_challan_add.Category_id INNER JOIN dbo.companymaster ON dbo.Delivery_challan_add.Company_id = dbo.companymaster.company_id WHERE YEAR(dbo.Delivery_challan_add.Date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();
                    GridView2.DataSource = gl.ds;
                    GridView2.DataBind();
                }
            }
            else
            {
                gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Delivery_challan_add.Tyremake, dbo.Delivery_challan_add.Battery_make,dbo.Delivery_challan_add.Batteryno, dbo.Delivery_challan_add.Ingnition_key_no, dbo.Delivery_challan_add.Chassis_no, dbo.Delivery_challan_add.Engine_no,dbo.Delivery_challan_add.Hirepurchase_lease_hypothecated_with_ms, dbo.Delivery_challan_add.Model_no, dbo.Delivery_challan_add.Modelnm,dbo.Delivery_challan_add.Date, dbo.Delivery_challan_add.Order_no, dbo.Delivery_challan_add.Challlan_no, dbo.Delivery_challan_add.Address,dbo.Delivery_challan_add.Email_id, dbo.Delivery_challan_add.Mobile_no, dbo.Delivery_challan_add.Customer_name, dbo.Delivery_challan_add.Challan_id FROM  dbo.Categorymaster INNER JOIN dbo.Delivery_challan_add ON dbo.Categorymaster.Category_id = dbo.Delivery_challan_add.Category_id INNER JOIN dbo.companymaster ON dbo.Delivery_challan_add.Company_id = dbo.companymaster.company_id WHERE dbo.Delivery_challan_add.Date ='" + TextBox1.Text + "'");
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
                gl.query("SELECT dbo.Categorymaster.Categorynm, dbo.companymaster.companyname, dbo.Delivery_challan_add.Tyremake, dbo.Delivery_challan_add.Battery_make,dbo.Delivery_challan_add.Batteryno, dbo.Delivery_challan_add.Ingnition_key_no, dbo.Delivery_challan_add.Chassis_no, dbo.Delivery_challan_add.Engine_no,dbo.Delivery_challan_add.Hirepurchase_lease_hypothecated_with_ms, dbo.Delivery_challan_add.Model_no, dbo.Delivery_challan_add.Modelnm,dbo.Delivery_challan_add.Date, dbo.Delivery_challan_add.Order_no, dbo.Delivery_challan_add.Challlan_no, dbo.Delivery_challan_add.Address,dbo.Delivery_challan_add.Email_id, dbo.Delivery_challan_add.Mobile_no, dbo.Delivery_challan_add.Customer_name, dbo.Delivery_challan_add.Challan_id FROM  dbo.Categorymaster INNER JOIN dbo.Delivery_challan_add ON dbo.Categorymaster.Category_id = dbo.Delivery_challan_add.Category_id INNER JOIN dbo.companymaster ON dbo.Delivery_challan_add.Company_id = dbo.companymaster.company_id WHERE MONTH(dbo.Delivery_challan_add.Date)='" + DropDownList1.SelectedValue + "' and YEAR(dbo.Delivery_challan_add.Date) ='" + DropDownList2.SelectedValue + "'");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();
                GridView2.DataSource = gl.ds;
                GridView2.DataBind();

            }

        }      

      
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Delivery_search.aspx");
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
            string FileName = "Delivery challan" + DateTime.Now + ".xls";
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //ExportGridToExcel();
        Response.Clear();
        Response.Buffer = true;
        string FileName = "Enquiry form" + DateTime.Now + ".xls";
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
    //protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcompany.SelectedValue + "'", ddlCategory);
    //        ddlCategory.SelectedIndex = 0;
    //    }
    //    catch
    //    {
    //    }
    //}
    //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlCategory.SelectedValue + "'", ddlmodelnm);
    //        ddlmodelnm.SelectedIndex = 0;
    //    }
    //    catch
    //    {
    //    }
    //}
    //protected void ddlmodelnm_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //try
    //    //{
    //    //    gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlCategory.SelectedValue + "'", ddlmodelnm);
    //    //    ddlmodelnm.SelectedIndex = 0;
    //    //}
    //    //catch
    //    //{
    //    //}
    //}
    //protected void ddlCategory_DataBound(object sender, EventArgs e)
    //{
    //    //Convert.ToInt32(ddlCategory.SelectedValue);
    //    //ddlCategory.Items.Insert(0, new ListItem("-Select-", "-Select-"));
    //}
    //protected void ddlmodelnm_DataBound(object sender, EventArgs e)
    //{
    //    //Convert.ToInt32(ddlmodelnm.SelectedValue);
    //    //ddlmodelnm.Items.Insert(0, new ListItem("-Select-", "-Select-"));
    //}
   
}