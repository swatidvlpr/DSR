<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/Payroll.master" AutoEventWireup="true" CodeFile="Attendancelog_search.aspx.cs" Inherits="Payroll_Attendancelog_search" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

        function PrintGridData() {

            var prtGrid = document.getElementById('ContentPlaceHolder1_GridView2');

            prtGrid.border = 0;

            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');


            prtwin.document.write(prtGrid.outerHTML);

            prtwin.document.close();

            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
			<div class="main-page">
                <div id="form1" class="forms validation">
                     <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                         <div class="form-title">
							<h4>Attendance show:</h4>
						</div>
                           <div class="form-body" id="form">
                               <asp:ScriptManager ID="ScriptManager2" runat="server">
                 </asp:ScriptManager>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                               <div class="col-md-6 form-group">
                                       <label >Month</label>                                      
                                    <asp:DropDownList ID="DropDownList1" runat="server" Class="form-control">
                                       <asp:ListItem Value="0">---Select Month----</asp:ListItem>
                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                   <asp:ListItem Value="06">Jun</asp:ListItem>
                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                    <asp:ListItem Value="09">Sep</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                   </div>   
                               <div class="col-md-6 form-group">
                                       <label >Year</label>
                                       <asp:DropDownList ID="DropDownList2" runat="server" Class="form-control">
                                          <asp:ListItem Value="0">---Select Year---</asp:ListItem>
                                      </asp:DropDownList>
                                   </div> 
                               
                                <div class="col-md-6 form-group">
                                       <label >Employee id</label>
                                       <asp:TextBox ID="txtempid" runat="server" Class="form-control" placeholder="Employee id" data-error="Please enter employee id"  ValidationGroup="a"></asp:TextBox>
                                   </div>    
                               
                               <div class="col-md-6 form-group">
                                       <label >Date</label>
                                       <asp:TextBox ID="txtdate" runat="server" Class="form-control" ValidationGroup="a"></asp:TextBox>
                                       <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Enabled="True" PopupPosition="TopRight" TargetControlID="txtdate">
                                       </cc1:CalendarExtender>
                                   </div>
                      </ContentTemplate>
                 </asp:UpdatePanel>  
                              <div class="col-md-12 form-group">
                                    <asp:Button ID="submit" runat="server" Class=" btn btn-warning " Text="Search" ValidationGroup="a" OnClick="submit_Click" />
                                   &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" ValidationGroup="a" OnClick="Button2_Click" />
                                   <asp:Button ID="Button3" runat="server" Text="Export To Excel" 
          Class="btn btn-danger" OnClick="Button3_Click"/>
                              </div>

                                 <div class="col-md-12 grid-margin">
                 <div class="table-responsive" >
<table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" >
    <asp:Panel runat="server" ID="Panel1">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="80%"
                            DataKeyNames="Attendance_LogId" OnRowDeleting="GridView1_RowDeleting" >
                            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="Employee_id" HeaderText="Employee id">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="Indevice_id" HeaderText="Indevice id">
                                <HeaderStyle HorizontalAlign="Left"  />
                                <ItemStyle HorizontalAlign="Left"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="Outdevice_id" HeaderText="Outdevice id">
                                <HeaderStyle HorizontalAlign="Left"  />
                                <ItemStyle HorizontalAlign="Left"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="Attendance_date" HeaderText="Date">
                                <HeaderStyle HorizontalAlign="Left"  />
                                <ItemStyle HorizontalAlign="Left"  />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("Attendance_LogId","Attendancelog_show.aspx?id={0}") %>' Text="Detail"></asp:HyperLink>

                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
        </asp:Panel>
</table>                                
    
         </div>
                                     <div style="display:none">
                                    
    <table id="Table1" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
     <asp:Panel runat="server" ID="Panel2">
         <asp:Label ID="Label1" runat="server" Text="Attendance Show" Style="font-weight: bold;
                    color:black;"></asp:Label>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Attendance_LogId" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
             <asp:TemplateField ControlStyle-CssClass="" HeaderText="SN">
                            <ItemTemplate>
                          
                                <%#GridView2.Rows.Count + 1%>
                               
                            </ItemTemplate>
                            <ControlStyle />
                            <FooterStyle />
                            <HeaderStyle CssClass="" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <ItemStyle CssClass="" HorizontalAlign="Left" />
                        </asp:TemplateField> 
                        <asp:BoundField DataField="Attendance_date" HeaderText="Attendance date" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Employee_id" HeaderText="Employee id"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Intime" HeaderText="Intime"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Indevice_id" HeaderText="Indevice id"  >                        
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Outdevice_id" HeaderText="Outdevice id"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Duration" HeaderText="Duration"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LateBy" HeaderText="Late By">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EarlyBy" HeaderText="Early By">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsOnLeave" HeaderText="Is OnLeave" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Leave_type" HeaderText="Leave type"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Leave_duration" HeaderText="Leave duration"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WeeklyOff" HeaderText="Weekly Off"  >                        
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Holiday" HeaderText="Holiday"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Leave_remarks" HeaderText="Leave remarks"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Punch_records" HeaderText="Punch records">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Shift_id" HeaderText="Shift id">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Present" HeaderText="Present" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Absent" HeaderText="Absent"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status_code" HeaderText="Status code"  >                        
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="P1status" HeaderText="P1status"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="P2status" HeaderText="P2status"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="P3status" HeaderText="P3status">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsonSpecialOff" HeaderText="Is on Special Off">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpecialOffType" HeaderText="Special Off Type"  >                        
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpecialOffRemark" HeaderText="Special Off Remark"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpecialOffDuration" HeaderText="Special Off Duration"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Overtime" HeaderText="Overtime">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OvertimeE" HeaderText="OvertimeE">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MissedOut_punch" HeaderText="Missed Out punch" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MissedIn_punch" HeaderText="Missed In punch"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="C1" HeaderText="C1"  >                        
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="C2" HeaderText="C2"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="C3" HeaderText="C3"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="C4" HeaderText="C4">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="C5" HeaderText="C5">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="C6" HeaderText="C6"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="C7" HeaderText="C7">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Leave_type_id" HeaderText="Leave type id">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
            </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
       
    </asp:GridView>

    </asp:Panel>                
   
                 </table>
             </div>  
    
  </div>
                 </div>
                  
             </div>

        </div>
         </div>
     
           </div>
                           
</asp:Content>

