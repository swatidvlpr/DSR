﻿using System;
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

public partial class DSR_Trade_plate_show : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                gl.query("select * from Trade_plate WHERE MONTH(date) = MONTH(dateadd(dd, -1, GetDate()))");
                GridView1.DataSource = gl.ds;
                GridView1.DataBind();

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
        try
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
                        gl.query("select * from Trade_plate WHERE YEAR(date) ='" + DropDownList2.SelectedValue + "'");
                        GridView1.DataSource = gl.ds;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    gl.query("Select * from Trade_plate WHERE Date ='" + TextBox1.Text + "'");
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
                    gl.query("select * from Trade_plate WHERE MONTH(date)='" + DropDownList1.SelectedValue + "' and YEAR(date) ='" + DropDownList2.SelectedValue + "'");
                    GridView1.DataSource = gl.ds;
                    GridView1.DataBind();

                }

            }
        }
        catch { }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Trade_plate_search.aspx");
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
            string FileName = "Trade plate" + DateTime.Now + ".xls";
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
        try
        {
            ExportGridToExcel();
        }
        catch { }
    }
}