<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/Payroll.master" AutoEventWireup="true" CodeFile="Attendancelog_show.aspx.cs" Inherits="Payroll_Attendancelog_show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="page-wrapper">
         <div class="main-page">
             <div id="form1" class="forms validation">
                 <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                     <div class="form-title">
							<h4>Attendance Detail:</h4>
						</div>
                     <div class="form-body" id="form">
                         <div class="col-md-12 form-group">
<asp:FormView ID="FormView1" runat="server" Width="100%" DataKeyNames="Attendance_LogId">
     <ItemTemplate>
 <table Width="100%">
     <tr>
         <td colspan="2">
              <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("Attendance_LogId","Attendance_log.aspx?id={0}")%>' Text="Edit"></asp:HyperLink>
         </td>          
 </tr>
     <tr><td></td></tr>
     <tr>
         <td>
 Employee id
 </td><td>
    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Employee_id")%>'></asp:Label></td> 
 </tr>
 <tr>
 <td>
Intime
 </td><td>
     <asp:Label ID="Label2" runat="server" Text='<%#Eval("Intime")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Indevice id
 </td><td>
     <asp:Label ID="Label3" runat="server" Text='<%#Eval("Indevice_id")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
 Outdevice id
 </td><td>
     <asp:Label ID="Label4" runat="server" Text='<%#Eval("Outdevice_id")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Duration
 </td><td>
     <asp:Label ID="Label5" runat="server" Text='<%#Eval("Duration")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
Late By
 </td><td>
     <asp:Label ID="Label6" runat="server" Text='<%#Eval("LateBy")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
 Early By
 </td><td>
     <asp:Label ID="Label7" runat="server" Text='<%#Eval("EarlyBy")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Is On Leave 
 </td><td>
     <asp:Label ID="Label8" runat="server" Text='<%#Eval("IsOnLeave")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Leave type
 </td><td>
     <asp:Label ID="Label9" runat="server" Text='<%#Eval("Leave_type")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Leave duration
 </td><td>
     <asp:Label ID="Label10" runat="server" Text='<%#Eval("Leave_duration")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Weekly Off
 </td><td>
     <asp:Label ID="Label11" runat="server" Text='<%#Eval("WeeklyOff")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
Holiday
 </td><td>
     <asp:Label ID="Label12" runat="server" Text='<%#Eval("Holiday")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Leave remarks
 </td><td>
     <asp:Label ID="Label13" runat="server" Text='<%#Eval("Leave_remarks")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
Punch records
 </td><td>
     <asp:Label ID="Label14" runat="server" Text='<%#Eval("Punch_records")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
Shift id
 </td><td>
     <asp:Label ID="Label15" runat="server" Text='<%#Eval("Shift_id")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
Present 
 </td><td>
     <asp:Label ID="Label16" runat="server" Text='<%#Eval("Present")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Absent
 </td><td>
     <asp:Label ID="Label17" runat="server" Text='<%#Eval("Absent")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
Status
 </td><td>
     <asp:Label ID="Label18" runat="server" Text='<%#Eval("Status")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Status code
 </td><td>
     <asp:Label ID="Label19" runat="server" Text='<%#Eval("Status_code")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
P1 status
 </td>
 <td><asp:Label ID="Label20" runat="server" Text='<%#Eval("P1status")%>'></asp:Label>
     </td>
 </tr>
 <tr>
 <td>
P2 status
 </td><td>
     <asp:Label ID="Label21" runat="server" Text='<%#Eval("P2status")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
P3 status
 </td><td>
     <asp:Label ID="Label22" runat="server" Text='<%#Eval("P3status")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Is on Special Off
 </td><td>
     <asp:Label ID="Label23" runat="server" Text='<%#Eval("IsonSpecialOff")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Special Off Type
 </td><td>
     <asp:Label ID="Label24" runat="server" Text='<%#Eval("SpecialOffType")%>'></asp:Label></td>
 </tr>
     <tr>
 <td>
Special Off Remark
 </td><td>
     <asp:Label ID="Label28" runat="server" Text='<%#Eval("SpecialOffRemark")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Special Off Duration
 </td><td>
     <asp:Label ID="Label29" runat="server" Text='<%#Eval("SpecialOffDuration")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Over time
 </td>
 <td><asp:Label ID="Label30" runat="server" Text='<%#Eval("Overtime")%>'></asp:Label>
     </td>
 </tr>
 <tr>
 <td>
Over timeE
 </td><td>
     <asp:Label ID="Label31" runat="server" Text='<%#Eval("OvertimeE")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Missed Out punch
 </td><td>
     <asp:Label ID="Label32" runat="server" Text='<%#Eval("MissedOut_punch")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Remarks
 </td><td>
     <asp:Label ID="Label33" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Missed In punch
 </td><td>
     <asp:Label ID="Label34" runat="server" Text='<%#Eval("MissedIn_punch")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
C1
 </td><td>
     <asp:Label ID="Label35" runat="server" Text='<%#Eval("C1")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
C2
 </td><td>
     <asp:Label ID="Label36" runat="server" Text='<%#Eval("C2")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
C1
 </td><td>
     <asp:Label ID="Label38" runat="server" Text='<%#Eval("C1")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
C4
 </td><td>
     <asp:Label ID="Label39" runat="server" Text='<%#Eval("C4")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
C5
 </td><td>
     <asp:Label ID="Label40" runat="server" Text='<%#Eval("C5")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
C6
 </td><td>
     <asp:Label ID="Label41" runat="server" Text='<%#Eval("C6")%>'></asp:Label></td>
 </tr>
<tr>
 <td>
C7
 </td><td>
     <asp:Label ID="Label42" runat="server" Text='<%#Eval("C7")%>'></asp:Label></td>
 </tr> 
 <tr>
 <td>
Leave type id
 </td><td>
     <asp:Label ID="Label37" runat="server" Text='<%#Eval("Leave_type_id")%>'></asp:Label></td>
 </tr>
     
 <tr>
 <td>
Date
 </td><td>
     <asp:Label ID="Label25" runat="server" Text='<%#Eval("Attendance_date")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Month
 </td><td>
     <asp:Label ID="Label26" runat="server" Text='<%#Eval("mnth")%>'></asp:Label></td>
 </tr>
 <tr>
 <td>
Year
 </td>
     <td>
     <asp:Label ID="Label27" runat="server" Text='<%#Eval("year")%>'></asp:Label></td>
 </tr>     
</table>  
    </ItemTemplate>
    </asp:FormView>
                         </div>                        
                     </div>
                 </div>

             </div>

         </div>

     </div>
</asp:Content>

