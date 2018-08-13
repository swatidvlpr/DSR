<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/Payroll.master" AutoEventWireup="true" CodeFile="Attendance_log.aspx.cs" Inherits="Payroll_Attendance_log" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Attendance</h4>
               </div>
               <div class="form-body" id="form">
               <div class="col-md-6 form-group">
                <label >Employee id</label>
                 <%--  <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="form-control" 
                       Width="402px" AutoPostBack="True" 
                       onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                   </asp:DropDownList>--%>
                   <asp:TextBox ID="txtEmpid" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Enter smployee id" ControlToValidate="txtEmpid" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 form-group">
                <label >Intime</label>
                    <br />                  
                    <asp:TextBox ID="txtintime" runat="server" CssClass="form-control">00:00:00</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtintime_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtintime" ValidChars=":;:;">
                    </cc1:FilteredTextBoxExtender>
                    <div class="col-md-3 form-group">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>select</asp:ListItem>
                        <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>PM</asp:ListItem>
                    </asp:DropDownList>                  
                      </div> 
                </div>
                    
                <div class="col-md-6 form-group">
                <label >Indevice id</label>
                  <asp:TextBox ID="txtindvcid" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Enter indevice id" ControlToValidate="txtindvcid" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Outdevice id</label>
                  <asp:TextBox ID="txtoutdvcid" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ErrorMessage="Enter outdevice id" ControlToValidate="txtoutdvcid" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Duration</label>
                  <asp:TextBox ID="txtduration" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0.0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtduration_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtduration" ValidChars=".,">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                           ErrorMessage="Enter duration" ControlToValidate="txtduration" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >LateBy</label>
                  <asp:TextBox ID="txtlateby" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtlateby_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtlateby">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                           ErrorMessage="Enter lateby" ControlToValidate="txtlateby" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6 form-group">
                <label >EarlyBy</label>
                  <asp:TextBox ID="txtearlyby" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="txtearlyby_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtearlyby">
                    </cc1:FilteredTextBoxExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                           ErrorMessage="Enter  earlyby" ControlToValidate="txtearlyby" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >IsOnLeave</label>
                  <asp:TextBox ID="txtisonlv" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtisonlv_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtisonlv">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                           ErrorMessage="Enter isonleave" ControlToValidate="txtisonlv" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Leave type</label>
                  <asp:TextBox ID="txtleavetype" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                           ErrorMessage="Enter leave type" ControlToValidate="txtleavetype" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Leave duration</label>
                  <asp:TextBox ID="txtlvduration" runat="server" CssClass="form-control"
                                            TextMode="SingleLine">0.0</asp:TextBox>                    
                    <cc1:FilteredTextBoxExtender ID="txtlvduration_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtlvduration" ValidChars=".,">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                           ErrorMessage="Enter leave duration" ControlToValidate="txtlvduration" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Weekly Off</label>
                  <asp:TextBox ID="txtweelyof" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtweelyof_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtweelyof">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ErrorMessage="Enter weeklyOff" ControlToValidate="txtweelyof" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Holiday</label>
                  <asp:TextBox ID="txthlday" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txthlday_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txthlday">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                           ErrorMessage="Enter holiday" ControlToValidate="txthlday" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Leave remarks</label>
                  <asp:TextBox ID="txtlvremarks" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                </div>
                <div class="col-md-6 form-group">
                <label >Punch records</label>
                  <asp:TextBox ID="txtpunchrcd" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                           ErrorMessage="Enter punch records" ControlToValidate="txtpunchrcd" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6 form-group">
                <label >Shift id</label>
                  <asp:TextBox ID="txtshiftid" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="txtshiftid_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtshiftid">
                    </cc1:FilteredTextBoxExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                           ErrorMessage="Enter  shift id" ControlToValidate="txtshiftid" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Present</label>
                  <asp:TextBox ID="txtprsnt" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0.0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtprsnt_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtprsnt">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                           ErrorMessage="Enter present" ControlToValidate="txtprsnt" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Absent</label>
                  <asp:TextBox ID="txtabsnt" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0.0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtabsnt_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtabsnt">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                           ErrorMessage="Enter absent" ControlToValidate="txtabsnt" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Status</label>
                  <asp:TextBox ID="txtstatus" runat="server" CssClass="form-control"
                                            TextMode="SingleLine"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                           ErrorMessage="Enter status" ControlToValidate="txtstatus" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-md-6 form-group">
                <label >Status code</label>
                  <asp:TextBox ID="txtstscode" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                           ErrorMessage="Enter status code" ControlToValidate="txtstscode" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >P1status</label>
                  <asp:TextBox ID="txtp1status" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                           ErrorMessage="Enter p1status" ControlToValidate="txtp1status" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >P2status</label>
                  <asp:TextBox ID="txtp2status" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                           ErrorMessage="Enter p2status" ControlToValidate="txtp2status" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >P3status</label>
                  <asp:TextBox ID="txtp3status" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                           ErrorMessage="Enter p3status" ControlToValidate="txtp3status" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6 form-group">
                <label >Is onSpecial Off</label>
                  <asp:TextBox ID="txtIsonSpecialOff" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="txtIsonSpecialOff_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtIsonSpecialOff">
                    </cc1:FilteredTextBoxExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                           ErrorMessage="Enter  isonspeciaoff" ControlToValidate="txtIsonSpecialOff" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Special Off Type</label>
                  <asp:TextBox ID="txtSpecialOffType" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                           ErrorMessage="Enter specialofftype" ControlToValidate="txtSpecialOffType" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Special Off Remark</label>
                  <asp:TextBox ID="txtSpecialOffRemark" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                           ErrorMessage="Enter specialoffremark" ControlToValidate="txtSpecialOffRemark" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Special Off Duration</label>
                  <asp:TextBox ID="txtSpecialOffDuration" runat="server" CssClass="form-control"
                                            TextMode="SingleLine">0</asp:TextBox>                    
                    <cc1:FilteredTextBoxExtender ID="txtSpecialOffDuration_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSpecialOffDuration">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                           ErrorMessage="Enter specialoffduration" ControlToValidate="txtSpecialOffDuration" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-md-6 form-group">
                <label >Overtime</label>
                  <asp:TextBox ID="txtOvertime" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtOvertime_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtOvertime">
                        </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                           ErrorMessage="Enter overtime" ControlToValidate="txtOvertime" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >OvertimeE</label>
                  <asp:TextBox ID="txtOvertimeE" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtOvertimeE_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtOvertimeE">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                           ErrorMessage="Enter overtimeE" ControlToValidate="txtOvertimeE" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >MissedOut punch</label>
                  <asp:TextBox ID="txtMissedOut" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtMissedOut_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMissedOut">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                           ErrorMessage="Enter missedout punch" ControlToValidate="txtMissedOut" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Remarks</label>
                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" 
                           ErrorMessage="Enter remarks" ControlToValidate="txtRemarks" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6 form-group">
                <label >MissedIn punch</label>
                  <asp:TextBox ID="txtMissedIn" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="txtMissedIn_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMissedIn">
                    </cc1:FilteredTextBoxExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" 
                           ErrorMessage="Enter  missedIn punch" ControlToValidate="txtMissedIn" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >C1</label>
                  <asp:TextBox ID="txtC1" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" 
                           ErrorMessage="Enter C1" ControlToValidate="txtC1" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >C2</label>
                  <asp:TextBox ID="txtC2" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                           ErrorMessage="Enter C2" ControlToValidate="txtC2" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >C3</label>
                  <asp:TextBox ID="txtC3" runat="server" CssClass="form-control"
                                            TextMode="SingleLine"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" 
                           ErrorMessage="Enter C3" ControlToValidate="txtC3" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                    <div class="col-md-6 form-group">
                <label >C4</label>
                  <asp:TextBox ID="txtC4" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" 
                           ErrorMessage="Enter C4" ControlToValidate="txtC4" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >C5</label>
                  <asp:TextBox ID="txtC5" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" 
                           ErrorMessage="Enter C5" ControlToValidate="txtC5" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >C6</label>
                  <asp:TextBox ID="txtC6" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" 
                           ErrorMessage="Enter C6" ControlToValidate="txtC6" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >C7</label>
                  <asp:TextBox ID="txtC7" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" 
                           ErrorMessage="Enter C7" ControlToValidate="txtC7" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6 form-group">
                <label >Leave type id</label>
                  <asp:TextBox ID="txtLeavetypeid" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine">0</asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="txtLeavetypeid_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLeavetypeid">
                    </cc1:FilteredTextBoxExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" 
                           ErrorMessage="Enter  Leavetyp id" ControlToValidate="txtLeavetypeid" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               
                <div class="col-md-6 form-group">
                <label >Date</label>
                  <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtdate1_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtdate" PopupPosition="TopRight">
                    </cc1:CalendarExtender>
                </div>
                 <div class="col-md-12 form-group">
                                 <asp:Button ID="Button1" runat="server" Text="Submit" 
                                     Class=" btn btn-warning " ValidationGroup="a" 
                                     Width="93px" OnClick="Button1_Click" />
                                  &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " 
                                     Text="reset" ValidationGroup="a" OnClick="Button2_Click"/>
                                     &nbsp;
          
                                <br />
                                 <asp:Label ID="Label1" runat="server"></asp:Label>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
                              </div>                     

               </div>
         </div>
      </div>
   </div>
</div>
</asp:Content>

