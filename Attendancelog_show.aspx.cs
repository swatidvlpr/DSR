using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payroll_Attendancelog_show : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string idd = Request.QueryString["id"].ToString();
            gl.formviewcond("AttendanceLogs", "Attendance_LogId", "'" + idd + "'", FormView1);
        }
    }
}