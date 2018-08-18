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


public partial class DSR_Enquiry_form_search : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", DropDownList3);

                gl.query("select * from Vw_enquryform WHERE MONTH(Date) = MONTH(dateadd(dd, -1, GetDate()))");
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
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
            if (DropDownList1.SelectedIndex == 0)
            {

                if (TextBox1.Text == "")
                {
                    if (DropDownList2.SelectedIndex == 0)
                    {
                        if (DropDownList3.SelectedIndex == 0)
                        {
                            if (DropDownList4.SelectedIndex == 0)
                            {

                            }
                            else
                            {
                                gl.query("select * from Vw_enquryform WHERE Status ='" + DropDownList4.SelectedValue + "'");
                                GridView1.DataSource = gl.ds;
                                GridView1.DataBind();
                                GridView2.DataSource = gl.ds;
                                GridView2.DataBind();

                            }

                        }
                        else
                        {
                            gl.query("select * from Vw_enquryform WHERE Branchid ='" + DropDownList3.SelectedValue + "'");
                            GridView1.DataSource = gl.ds;
                            GridView1.DataBind();
                            GridView2.DataSource = gl.ds;
                            GridView2.DataBind();


                        }
                    }
                    else
                    {
                        gl.query("select * from Vw_enquryform WHERE YEAR(Date) ='" + DropDownList2.SelectedValue + "'");
                        GridView1.DataSource = gl.ds;
                        GridView1.DataBind();
                        GridView2.DataSource = gl.ds;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    gl.query("select * from Vw_enquryform WHERE Date ='" + TextBox1.Text + "'");
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
                    gl.query("select * from Vw_enquryform WHERE MONTH(Date)='" + DropDownList1.SelectedValue + "' and YEAR(Date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();
                    GridView2.DataSource = gl.ds;
                    GridView2.DataBind();

                }

            }
        //}
        //catch { }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Enquiry_form_search.aspx");
    }
    private void ExportGridToExcel()
    {
        // GridView1.Columns[0].Visible = false;
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Enquiry form" + DateTime.Now + ".xls";
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
        try
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
        catch { }
    }
}