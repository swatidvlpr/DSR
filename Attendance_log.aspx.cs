using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class Payroll_Attendance_log : System.Web.UI.Page
{
     global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                    string idd = Request.QueryString["id"].ToString();
                    gl.read1("AttendanceLogs", "Attendance_LogId", "'" + idd + "'");
                    txtEmpid.Text = gl.ds.Tables[0].Rows[0]["Employee_id"].ToString();
                    txtabsnt.Text = gl.ds.Tables[0].Rows[0]["Absent"].ToString();
                    txtdate.Text = gl.ds.Tables[0].Rows[0]["Attendance_date"].ToString();
                    txtduration.Text = gl.ds.Tables[0].Rows[0]["Duration"].ToString();
                    txtearlyby.Text = gl.ds.Tables[0].Rows[0]["EarlyBy"].ToString();
                    txthlday.Text = gl.ds.Tables[0].Rows[0]["Holiday"].ToString();
                    txtindvcid.Text = gl.ds.Tables[0].Rows[0]["Indevice_id"].ToString();
                    txtintime.Text = gl.ds.Tables[0].Rows[0]["Intime"].ToString();
                    txtisonlv.Text = gl.ds.Tables[0].Rows[0]["IsOnLeave"].ToString();
                    txtIsonSpecialOff.Text = gl.ds.Tables[0].Rows[0]["IsonSpecialOff"].ToString();
                    txtlateby.Text = gl.ds.Tables[0].Rows[0]["LateBy"].ToString();
                    txtleavetype.Text = gl.ds.Tables[0].Rows[0]["Leave_type"].ToString();
                    txtLeavetypeid.Text = gl.ds.Tables[0].Rows[0]["Leave_type_id"].ToString();
                    txtlvduration.Text = gl.ds.Tables[0].Rows[0]["Leave_duration"].ToString();
                    txtlvremarks.Text = gl.ds.Tables[0].Rows[0]["Leave_remarks"].ToString();
                    txtMissedIn.Text = gl.ds.Tables[0].Rows[0]["MissedIn_punch"].ToString();
                    txtMissedOut.Text = gl.ds.Tables[0].Rows[0]["MissedOut_punch"].ToString();
                    txtoutdvcid.Text = gl.ds.Tables[0].Rows[0]["Outdevice_id"].ToString();
                    txtOvertime.Text = gl.ds.Tables[0].Rows[0]["Overtime"].ToString();
                    txtOvertimeE.Text = gl.ds.Tables[0].Rows[0]["OvertimeE"].ToString();
                    txtp1status.Text = gl.ds.Tables[0].Rows[0]["P1status"].ToString();
                    txtp2status.Text = gl.ds.Tables[0].Rows[0]["P2status"].ToString();
                    txtp3status.Text = gl.ds.Tables[0].Rows[0]["P3status"].ToString();
                    txtprsnt.Text = gl.ds.Tables[0].Rows[0]["Present"].ToString();
                    txtpunchrcd.Text = gl.ds.Tables[0].Rows[0]["Punch_records"].ToString();
                    txtRemarks.Text = gl.ds.Tables[0].Rows[0]["Remarks"].ToString();
                    txtshiftid.Text = gl.ds.Tables[0].Rows[0]["Shift_id"].ToString();
                    txtSpecialOffDuration.Text = gl.ds.Tables[0].Rows[0]["SpecialOffDuration"].ToString();
                    txtSpecialOffRemark.Text = gl.ds.Tables[0].Rows[0]["SpecialOffRemark"].ToString();
                    txtSpecialOffType.Text = gl.ds.Tables[0].Rows[0]["SpecialOffType"].ToString();
                    txtstatus.Text = gl.ds.Tables[0].Rows[0]["Status"].ToString();
                    txtstscode.Text = gl.ds.Tables[0].Rows[0]["Status_code"].ToString();
                    txtweelyof.Text = gl.ds.Tables[0].Rows[0]["WeeklyOff"].ToString();
                    txtC1.Text = gl.ds.Tables[0].Rows[0]["C1"].ToString();
                    txtC2.Text = gl.ds.Tables[0].Rows[0]["C2"].ToString();
                    txtC3.Text = gl.ds.Tables[0].Rows[0]["C3"].ToString();
                    txtC4.Text = gl.ds.Tables[0].Rows[0]["C4"].ToString();
                    txtC5.Text = gl.ds.Tables[0].Rows[0]["C5"].ToString();
                    txtC6.Text = gl.ds.Tables[0].Rows[0]["C6"].ToString();
                    txtC7.Text = gl.ds.Tables[0].Rows[0]["C7"].ToString();
                    Button1.Text = "Update";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            string idd = Request.QueryString["id"].ToString();
            string Intime = txtintime.Text + DropDownList3.SelectedValue;
            DateTime crnttime = Convert.ToDateTime(txtdate.Text);
            TimeZoneInfo tzn = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime IndianTme = TimeZoneInfo.ConvertTime(crnttime, tzn);
            string time = IndianTme.ToString("dd/MM/yyyy");
            string mnth = IndianTme.ToString("MM");
            string year = IndianTme.ToString("yyyy");

            // Attendance_date,                Employee_id,           Intime,           Indevice_id,               Outdevice_id,            Duration,           LateBy,          EarlyBy,          IsOnLeave,             Leave_type,              Leave_duration,                WeeklyOff,          Holiday,           Leave_remarks,                Punch_records,                 Shift_id,         Present,         Absent,         Status,            Status_code,            P1status,            P2status,            P3status,             IsonSpecialOff,               SpecialOffType,                  SpecialOffRemark,                       SpecialOffDuration,              Overtime,            OvertimeE,               MissedOut_punch,               Remarks,               MissedIn_punch,          C1,     C2,     C3,     C4,     C5,     C6,     C7,          Leave_type_id
            using (SqlCommand cmd = new SqlCommand("update AttendanceLogs set Attendance_date=@Attendance_date, Employee_id=@Employee_id, Intime=@Intime, Indevice_id=@Indevice_id, Outdevice_id=@Outdevice_id, Duration=@Duration, LateBy=@LateBy, EarlyBy=@EarlyBy, IsOnLeave=@IsOnLeave, Leave_type=@Leave_type, Leave_duration=@Leave_duration, WeeklyOff=@WeeklyOff, Holiday=@Holiday, Leave_remarks=@Leave_remarks, Punch_records=@Punch_records, Shift_id=@Shift_id, Present=@Present, Absent=@Absent, Status=@Status, Status_code=@Status_code, P1status=@P1status, P2status=@P2status, P3status=@P3status, IsonSpecialOff=@IsonSpecialOff, SpecialOffType=@SpecialOffType, SpecialOffRemark=@SpecialOffRemark, SpecialOffDuration=@SpecialOffDuration, Overtime=@Overtime, OvertimeE=@OvertimeE, MissedOut_punch=@MissedOut_punch, Remarks=@Remarks,  MissedIn_punch=@MissedIn_punch, C1=@C1, C2=@C2, C3=@C3, C4=@C4, C5=@C5, C6=@C6, C7=@C7, Leave_type_id=@Leave_type_id where Attendance_LogId=@Attendance_LogId", gl.con))
            {

                cmd.Parameters.AddWithValue("@Attendance_LogId", idd);
                cmd.Parameters.AddWithValue("@Attendance_date", txtdate.Text);
                cmd.Parameters.AddWithValue("@Employee_id", txtEmpid.Text);
                cmd.Parameters.AddWithValue("@Intime", Intime);
                cmd.Parameters.AddWithValue("@Indevice_id", txtindvcid.Text);
                cmd.Parameters.AddWithValue("@Outdevice_id", txtoutdvcid.Text);
                cmd.Parameters.AddWithValue("@Duration", txtduration.Text);
                cmd.Parameters.AddWithValue("@LateBy", txtlateby.Text);
                cmd.Parameters.AddWithValue("@EarlyBy", txtearlyby.Text);
                cmd.Parameters.AddWithValue("@IsOnLeave", txtisonlv.Text);
                cmd.Parameters.AddWithValue("@Leave_type", txtleavetype.Text);
                cmd.Parameters.AddWithValue("@Leave_duration", txtlvduration.Text);
                cmd.Parameters.AddWithValue("@WeeklyOff", txtweelyof.Text);
                cmd.Parameters.AddWithValue("@Holiday", txthlday.Text);
                cmd.Parameters.AddWithValue("@Leave_remarks", txtlvremarks.Text);
                cmd.Parameters.AddWithValue("@Punch_records", txtpunchrcd.Text);
                cmd.Parameters.AddWithValue("@Shift_id", txtshiftid.Text);
                cmd.Parameters.AddWithValue("@Present", txtprsnt.Text);
                cmd.Parameters.AddWithValue("@Absent", txtabsnt.Text);
                cmd.Parameters.AddWithValue("@Status", txtstatus.Text);
                cmd.Parameters.AddWithValue("@Status_code", txtstscode.Text);
                cmd.Parameters.AddWithValue("@P1status", txtp1status.Text);
                cmd.Parameters.AddWithValue("@P2status", txtp2status.Text);
                cmd.Parameters.AddWithValue("@P3status", txtp3status.Text);
                cmd.Parameters.AddWithValue("@IsonSpecialOff", txtIsonSpecialOff.Text);
                cmd.Parameters.AddWithValue("@SpecialOffType", txtSpecialOffType.Text);
                cmd.Parameters.AddWithValue("@SpecialOffRemark", txtSpecialOffRemark.Text);
                cmd.Parameters.AddWithValue("@SpecialOffDuration", txtSpecialOffDuration.Text);
                cmd.Parameters.AddWithValue("@Overtime", txtOvertime.Text);
                cmd.Parameters.AddWithValue("@OvertimeE", txtOvertimeE.Text);
                cmd.Parameters.AddWithValue("@MissedOut_punch", txtMissedOut.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@MissedIn_punch", txtMissedIn.Text);
                cmd.Parameters.AddWithValue("@C1", txtC1.Text);
                cmd.Parameters.AddWithValue("@C2", txtC2.Text);
                cmd.Parameters.AddWithValue("@C3", txtC3.Text);
                cmd.Parameters.AddWithValue("@C4", txtC4.Text);
                cmd.Parameters.AddWithValue("@C5", txtC5.Text);
                cmd.Parameters.AddWithValue("@C6", txtC6.Text);
                cmd.Parameters.AddWithValue("@C7", txtC7.Text);
                cmd.Parameters.AddWithValue("@Leave_type_id", txtLeavetypeid.Text);
                //cmd.Parameters.AddWithValue("@month", mnth);
                //cmd.Parameters.AddWithValue("@year", year);
                gl.con.Open();
                cmd.ExecuteNonQuery();
                gl.con.Close();
                //...
                Label1.Text = "Updated Successfully";
            }
     
      
            using (SqlCommand cmd = new SqlCommand("update AttendanceLogs set Attendance_date=@Attendance_date, Employee_id=@Employee_id, Intime=@Intime, Indevice_id=@Indevice_id, Outdevice_id=@Outdevice_id, Duration=@Duration, LateBy=@LateBy, EarlyBy=@EarlyBy, IsOnLeave=@IsOnLeave, Leave_type=@Leave_type, Leave_duration=@Leave_duration, WeeklyOff=@WeeklyOff, Holiday=@Holiday, Leave_remarks=@Leave_remarks, Punch_records=@Punch_records, Shift_id=@Shift_id, Present=@Present, Absent=@Absent, Status=@Status, Status_code=@Status_code, P1status=@P1status, P2status=@P2status, P3status=@P3status, IsonSpecialOff=@IsonSpecialOff, SpecialOffType=@SpecialOffType, SpecialOffRemark=@SpecialOffRemark, SpecialOffDuration=@SpecialOffDuration, Overtime=@Overtime, OvertimeE=@OvertimeE, MissedOut_punch=@MissedOut_punch, Remarks=@Remarks,  MissedIn_punch=@MissedIn_punch, C1=@C1, C2=@C2, C3=@C3, C4=@C4, C5=@C5, C6=@C6, C7=@C7, Leave_type_id=@Leave_type_id where Attendance_LogId=@Attendance_LogId", gl.con))
            {

                cmd.Parameters.AddWithValue("@Attendance_LogId", idd);
                cmd.Parameters.AddWithValue("@Attendance_date", txtdate.Text);
                cmd.Parameters.AddWithValue("@Employee_id", txtEmpid.Text);
                cmd.Parameters.AddWithValue("@Intime", Intime);
                cmd.Parameters.AddWithValue("@Indevice_id", txtindvcid.Text);
                cmd.Parameters.AddWithValue("@Outdevice_id", txtoutdvcid.Text);
                cmd.Parameters.AddWithValue("@Duration", txtduration.Text);
                cmd.Parameters.AddWithValue("@LateBy", txtlateby.Text);
                cmd.Parameters.AddWithValue("@EarlyBy", txtearlyby.Text);
                cmd.Parameters.AddWithValue("@IsOnLeave", txtisonlv.Text);
                cmd.Parameters.AddWithValue("@Leave_type", txtleavetype.Text);
                cmd.Parameters.AddWithValue("@Leave_duration", txtlvduration.Text);
                cmd.Parameters.AddWithValue("@WeeklyOff", txtweelyof.Text);
                cmd.Parameters.AddWithValue("@Holiday", txthlday.Text);
                cmd.Parameters.AddWithValue("@Leave_remarks", txtlvremarks.Text);
                cmd.Parameters.AddWithValue("@Punch_records", txtpunchrcd.Text);
                cmd.Parameters.AddWithValue("@Shift_id", txtshiftid.Text);
                cmd.Parameters.AddWithValue("@Present", txtprsnt.Text);
                cmd.Parameters.AddWithValue("@Absent", txtabsnt.Text);
                cmd.Parameters.AddWithValue("@Status", txtstatus.Text);
                cmd.Parameters.AddWithValue("@Status_code", txtstscode.Text);
                cmd.Parameters.AddWithValue("@P1status", txtp1status.Text);
                cmd.Parameters.AddWithValue("@P2status", txtp2status.Text);
                cmd.Parameters.AddWithValue("@P3status", txtp3status.Text);
                cmd.Parameters.AddWithValue("@IsonSpecialOff", txtIsonSpecialOff.Text);
                cmd.Parameters.AddWithValue("@SpecialOffType", txtSpecialOffType.Text);
                cmd.Parameters.AddWithValue("@SpecialOffRemark", txtSpecialOffRemark.Text);
                cmd.Parameters.AddWithValue("@SpecialOffDuration", txtSpecialOffDuration.Text);
                cmd.Parameters.AddWithValue("@Overtime", txtOvertime.Text);
                cmd.Parameters.AddWithValue("@OvertimeE", txtOvertimeE.Text);
                cmd.Parameters.AddWithValue("@MissedOut_punch", txtMissedOut.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@MissedIn_punch", txtMissedIn.Text);
                cmd.Parameters.AddWithValue("@C1", txtC1.Text);
                cmd.Parameters.AddWithValue("@C2", txtC2.Text);
                cmd.Parameters.AddWithValue("@C3", txtC3.Text);
                cmd.Parameters.AddWithValue("@C4", txtC4.Text);
                cmd.Parameters.AddWithValue("@C5", txtC5.Text);
                cmd.Parameters.AddWithValue("@C6", txtC6.Text);
                cmd.Parameters.AddWithValue("@C7", txtC7.Text);
                cmd.Parameters.AddWithValue("@Leave_type_id", txtLeavetypeid.Text);
                //cmd.Parameters.AddWithValue("@month", mnth);
                //cmd.Parameters.AddWithValue("@year", year);
                gl.con.Open();
                cmd.ExecuteNonQuery();
                gl.con.Close();
                //...
                Label1.Text = "Updated Successfully";


               }
              
        }

        else
        {
            DateTime crnttime = Convert.ToDateTime(txtdate.Text);
            TimeZoneInfo tzn = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime IndianTme = TimeZoneInfo.ConvertTime(crnttime, tzn);
            string time = IndianTme.ToString("dd/MM/yyyy");
            string mnth = IndianTme.ToString("MM");
            string year = IndianTme.ToString("yyyy");
                                                                                // Attendance_date, Employee_id, Intime, Indevice_id, Outdevice_id, Duration, LateBy, EarlyBy, IsOnLeave, Leave_type, Leave_duration, WeeklyOff, Holiday,Leave_remarks, Punch_records, Shift_id, Present, Absent, Status, Status_code, P1status, P2status, P3status, IsonSpecialOff, SpecialOffType, SpecialOffRemark,SpecialOffDuration, Overtime, OvertimeE, MissedOut_punch, Remarks, MissedIn_punch, C1, C2, C3, C4, C5, C6, C7, Leave_type_id,month,year
                using (SqlCommand cmd = new SqlCommand("insert into AttendanceLogs(Attendance_date, Employee_id, Intime, Indevice_id, Outdevice_id, Duration, LateBy, EarlyBy, IsOnLeave, Leave_type, Leave_duration, WeeklyOff, Holiday, Leave_remarks, Punch_records, Shift_id, Present, Absent, Status, Status_code, P1status, P2status, P3status, IsonSpecialOff, SpecialOffType, SpecialOffRemark, SpecialOffDuration, Overtime, OvertimeE, MissedOut_punch, Remarks, MissedIn_punch, C1, C2, C3, C4, C5, C6, C7, Leave_type_id,mnth,year) values(@Attendance_date, @Employee_id, @Intime, @Indevice_id, @Outdevice_id, @Duration, @LateBy, @EarlyBy, @IsOnLeave, @Leave_type, @Leave_duration, @WeeklyOff, @Holiday, @Leave_remarks, @Punch_records, @Shift_id, @Present, @Absent, @Status, @Status_code, @P1status, @P2status, @P3status, @IsonSpecialOff, @SpecialOffType, @SpecialOffRemark, @SpecialOffDuration, @Overtime, @OvertimeE, @MissedOut_punch, @Remarks, @MissedIn_punch, @C1, @C2, @C3, @C4, @C5, @C6, @C7, @Leave_type_id, @mnth, @year)", gl.con))
                    {
                        string Intime = txtintime.Text + DropDownList3.SelectedValue;
                        cmd.Parameters.AddWithValue("@Attendance_date", txtdate.Text);
                        cmd.Parameters.AddWithValue("@Employee_id", txtEmpid.Text);
                        cmd.Parameters.AddWithValue("@Intime",Intime);
                        cmd.Parameters.AddWithValue("@Indevice_id", txtindvcid.Text);
                        cmd.Parameters.AddWithValue("@Outdevice_id",txtoutdvcid.Text);
                        cmd.Parameters.AddWithValue("@Duration",txtduration.Text);
                        cmd.Parameters.AddWithValue("@LateBy",txtlateby.Text);
                        cmd.Parameters.AddWithValue("@EarlyBy",txtearlyby.Text);
                        cmd.Parameters.AddWithValue("@IsOnLeave",txtisonlv.Text);
                        cmd.Parameters.AddWithValue("@Leave_type",txtleavetype.Text);
                        cmd.Parameters.AddWithValue("@Leave_duration",txtlvduration.Text);
                        cmd.Parameters.AddWithValue("@WeeklyOff",txtweelyof.Text);
                        cmd.Parameters.AddWithValue("@Holiday",txthlday.Text);
                        cmd.Parameters.AddWithValue("@Leave_remarks", txtlvremarks.Text);
                        cmd.Parameters.AddWithValue("@Punch_records",txtpunchrcd.Text);
                        cmd.Parameters.AddWithValue("@Shift_id",txtshiftid.Text);
                        cmd.Parameters.AddWithValue("@Present",txtprsnt.Text);
                        cmd.Parameters.AddWithValue("@Absent",txtabsnt.Text);
                        cmd.Parameters.AddWithValue("@Status",txtstatus.Text);
                        cmd.Parameters.AddWithValue("@Status_code",txtstscode.Text);
                        cmd.Parameters.AddWithValue("@P1status",txtp1status.Text);
                        cmd.Parameters.AddWithValue("@P2status",txtp2status.Text);
                        cmd.Parameters.AddWithValue("@P3status",txtp3status.Text);
                        cmd.Parameters.AddWithValue("@IsonSpecialOff",txtIsonSpecialOff.Text);
                        cmd.Parameters.AddWithValue("@SpecialOffType",txtSpecialOffType.Text);
                        cmd.Parameters.AddWithValue("@SpecialOffRemark",txtSpecialOffRemark.Text);
                        cmd.Parameters.AddWithValue("@SpecialOffDuration",txtSpecialOffDuration.Text);
                        cmd.Parameters.AddWithValue("@Overtime",txtOvertime.Text);
                        cmd.Parameters.AddWithValue("@OvertimeE",txtOvertimeE.Text);
                        cmd.Parameters.AddWithValue("@MissedOut_punch",txtMissedOut.Text);
                        cmd.Parameters.AddWithValue("@Remarks",txtRemarks.Text);
                        cmd.Parameters.AddWithValue("@MissedIn_punch",txtMissedIn.Text);
                        cmd.Parameters.AddWithValue("@C1", txtC1.Text);
                        cmd.Parameters.AddWithValue("@C2", txtC2.Text);
                        cmd.Parameters.AddWithValue("@C3", txtC3.Text);
                        cmd.Parameters.AddWithValue("@C4", txtC4.Text);
                        cmd.Parameters.AddWithValue("@C5", txtC5.Text);
                        cmd.Parameters.AddWithValue("@C6", txtC6.Text);
                        cmd.Parameters.AddWithValue("@C7", txtC7.Text);
                        cmd.Parameters.AddWithValue("@Leave_type_id",txtLeavetypeid.Text);
                        cmd.Parameters.AddWithValue("@mnth", mnth);
                        cmd.Parameters.AddWithValue("@year", year);
                        gl.con.Open();
                        cmd.ExecuteNonQuery();
                        gl.con.Close();
                        //...
                        Label1.Text = "Submitted Successfully";
                        Button1.Text = "Submit";
                    }
           }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Attendance_log.aspx");
    }
}