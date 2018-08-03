<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Trade_plate.aspx.cs" Inherits="DSR_Trade_plate" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Trade plate entry</h4>
               </div>
               <div class="form-body" id="form">
               <div class="col-md-6 form-group">
                <label >Branch name</label>
                   <asp:DropDownList ID="ddlbrnchnm" runat="server" CssClass="form-control">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ErrorMessage="Select branch name" ControlToValidate="ddlbrnchnm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Vehicle name</label>
                           <br />
               
                   <asp:TextBox ID="txtvhclnm" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Enter vehicle name" ControlToValidate="Txtvhclnm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Trade plate no</label>
                    <br />
                      <asp:TextBox ID="txtpltno" runat="server" CssClass="form-control"></asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Enter trade plate no" ControlToValidate="txtpltno" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                
                
                <div class="col-md-6 form-group">
                <label >No of vehicle</label>
                  <asp:TextBox ID="txtvhclno" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ErrorMessage="Enter no of vehicle" ControlToValidate="txtvhclno" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
              <div class="col-md-6 form-group">
                <label >Valid upto</label>
                  <asp:TextBox ID="txtvalid" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                   
                    
                    <cc1:CalendarExtender ID="txtvalid_CalendarExtender" runat="server" 
                      Enabled="True" PopupPosition="TopRight" TargetControlID="txtvalid">
                  </cc1:CalendarExtender>
                   
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                           ErrorMessage="Enter valid upto" ControlToValidate="txtvalid" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Insurance</label>
                  <asp:TextBox ID="txtinsrnc" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
              
                    <cc1:CalendarExtender ID="txtinsrnc_CalendarExtender" runat="server" 
                       Enabled="True" PopupPosition="TopRight" TargetControlID="txtinsrnc">
                   </cc1:CalendarExtender>
              
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                           ErrorMessage="Enter insurance" ControlToValidate="txtinsrnc" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Date</label>
                  <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                  
                    <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                       Enabled="True" PopupPosition="TopRight" TargetControlID="txtdate">
                   </cc1:CalendarExtender>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                           ErrorMessage="Enter date" ControlToValidate="txtdate" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               
           
                 <div class="col-md-12 form-group">
                                 <asp:Button ID="Button1" runat="server" Text="Submit" 
                                     Class=" btn btn-warning " ValidationGroup="a" onclick="Button1_Click"/>
                                  &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " 
                                     Text="reset" ValidationGroup="b" onclick="Button2_Click" />
                                     &nbsp;
          
                                <br />
                                 <asp:Label ID="Label1" runat="server"></asp:Label>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
                             </div>
                             <div class="col-md-12 grid-margin">
                              <div class="table-responsive">
                              <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0"  >
                                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                      ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None" 
                                      DataKeyNames="Trade_id" onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                      <asp:BoundField DataField="branchname" HeaderText="Branch name"/>
                                      <asp:BoundField DataField="Vehicle_name" HeaderText="Vehicle name"/>
                                      <asp:BoundField DataField="Trade_plate_no" HeaderText="Trade plate no"/>
                                       <asp:BoundField DataField="No_of_vehicle" HeaderText="No of vehicle"/>
                                       <asp:BoundField DataField="Valid_upto" HeaderText="Valid upto"/>
                                          <asp:BoundField DataField="Insurance" HeaderText="Insurance"/>
                                          <asp:BoundField DataField="Date" HeaderText="Date"/>

                                          <asp:TemplateField  HeaderText="Edit">
                                 <ItemTemplate>
                                  <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/DSR/icon/edit.png" CommandName="Select"  />
                                 </ItemTemplate>
                                 </asp:TemplateField>
                               <asp:TemplateField  HeaderText="Delete">
                              <ItemTemplate>
                             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/DSR/icon/No.png"   CommandName="Delete" OnClientClick="return confirm('Do u delete Record?')" />
                        </ItemTemplate>
                        </asp:TemplateField>
                                          <%--<asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                          <asp:CommandField ShowDeleteButton="True" />--%>
                                      </Columns>
                                      <EditRowStyle BackColor="#999999" />
                                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                      <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                      <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                      <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                      <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                      <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                  </asp:GridView>
                                  </table>
                              </div>
                             </div>
                          </div>
                      </div>
                  </div>
             </div>
       </div>
</asp:Content>

