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


public partial class Payroll_Attendancelog_search : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gl.query("select * from AttendanceLogs WHERE MONTH(Attendance_date) = MONTH(dateadd(dd, -1, GetDate()))");
            GridView1.DataSource = gl.ds;
            GridView1.DataBind();

            for (int i = 2016; i <= 2050; i++)
            {
                DropDownList2.Items.Add(i.ToString());


            }
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0)
        {

            if (txtdate.Text == "")
            {
                if (DropDownList2.SelectedIndex == 0)
                {
                    if (txtempid.Text == "")
                    { }
                    else
                    {
                        gl.query("Select * from AttendanceLogs WHERE Employee_id ='" + txtempid.Text + "'");
                        GridView1.DataSource = gl.ds;
                        GridView1.DataBind();

                        gl.query("Select * from AttendanceLogs WHERE Employee_id ='" + txtempid.Text + "'");
                        GridView2.DataSource = gl.ds;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    gl.query("select * from AttendanceLogs WHERE YEAR(Attendance_date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();

                    gl.query("select * from AttendanceLogs WHERE YEAR(Attendance_date) ='" + DropDownList2.SelectedValue + "'");
                    GridView2.DataSource = gl.ds;
                    GridView2.DataBind();
                }
            }
            else
            {
                gl.query("Select * from AttendanceLogs WHERE Attendance_date ='" + txtdate.Text + "'");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();

                gl.query("Select * from AttendanceLogs WHERE Attendance_date ='" + txtdate.Text + "'");
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
                gl.query("select * from AttendanceLogs WHERE MONTH(Attendance_date)='" + DropDownList1.SelectedValue + "' and YEAR(Attendance_date) ='" + DropDownList2.SelectedValue + "'");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();

                gl.query("select * from AttendanceLogs WHERE MONTH(Attendance_date)='" + DropDownList1.SelectedValue + "' and YEAR(Attendance_date) ='" + DropDownList2.SelectedValue + "'");
                GridView2.DataSource = gl.ds;
                GridView2.DataBind();

            }

        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("AttendanceLogs", "Attendance_LogId", "'" + idd + "'");
        gl.display("AttendanceLogs", GridView1);
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Attendancelog_search.aspx");
    }
    private void ExportGridToExcel()
    {
        // GridView1.Columns[0].Visible = false;
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Attendance Log" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        // GridView1.AllowPaging = false;
        // GridView1.Columns.RemoveAt(0);
        GridView2.GridLines = GridLines.Both;
        GridView2.HeaderStyle.Font.Bold = true;
        GridView2.RenderControl(htmltextwrtter);

        GridView2.DataBind();
        Response.Write(strwritter.ToString());
        Response.End();
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
        string FileName = "Attendance Log" + DateTime.Now + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel2.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}