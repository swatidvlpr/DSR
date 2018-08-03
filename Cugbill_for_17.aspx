<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Cugbill_for_17.aspx.cs" Inherits="DSR_Cugbill_for_17" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Cugbill entry</h4>
               </div>
               <div class="form-body" id="form">
                <div class="col-md-6 form-group">
                <label >Name</label>
                           <br />
                   <asp:TextBox ID="txtname" runat="server" CssClass="form-control" 
                       AutoPostBack="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                           ErrorMessage="Enter name" ControlToValidate="txtname" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Branch name</label>
                   <asp:DropDownList ID="ddlbrnchnm" runat="server" CssClass="form-control">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ErrorMessage="Select branch name" ControlToValidate="ddlbrnchnm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Number</label>
                      <asp:TextBox ID="txtnmbr" runat="server" CssClass="form-control"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtnmbr_FilteredTextBoxExtender" 
                       runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtnmbr">
                   </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Enter number" ControlToValidate="txtnmbr" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Amount</label>
                    <br />
                      <asp:TextBox ID="txtamnt" runat="server" CssClass="form-control" 
                        AutoPostBack="True" ontextchanged="txtamnt_TextChanged">00.00</asp:TextBox>
                  
                    <cc1:FilteredTextBoxExtender ID="txtamnt_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtamnt" 
                        ValidChars=".,">
                    </cc1:FilteredTextBoxExtender>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Enter amount" ControlToValidate="txtamnt" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               
                <div class="col-md-6 form-group">
                <label >Limit</label>
                  <asp:TextBox ID="txtlmt" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                        ontextchanged="txtlmt_TextChanged">00.00</asp:TextBox>
                   
                    <cc1:FilteredTextBoxExtender ID="txtlmt_FilteredTextBoxExtender" runat="server" 
                        Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtlmt" ValidChars=".,">
                    </cc1:FilteredTextBoxExtender>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ErrorMessage="Enter limit" ControlToValidate="txtlmt" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
              <div class="col-md-6 form-group">
                <label >Deduction</label>
                  <asp:TextBox ID="txtdtctn" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                      ontextchanged="txtdtctn_TextChanged">00.00</asp:TextBox>
                  
                    <cc1:FilteredTextBoxExtender ID="txtdtctn_FilteredTextBoxExtender" 
                      runat="server" Enabled="True" FilterType="Numbers,Custom" TargetControlID="txtdtctn" 
                      ValidChars=".,">
                  </cc1:FilteredTextBoxExtender>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                           ErrorMessage="Enter deduction" ControlToValidate="txtdtctn" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               
               <div class="col-md-6 form-group">
                <label >Date</label>
                  <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                  
                    <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                       Enabled="True" TargetControlID="txtdate">
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
                                      DataKeyNames="Cug_id" onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                      onrowdatabound="GridView1_RowDataBound">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                      <asp:BoundField DataField="Allocated_to" HeaderText="Name"/>
                                      <asp:BoundField DataField="branchname" HeaderText="Branch name"/>                                      
                                      <asp:BoundField DataField="Number" HeaderText="Number"/>
                                      <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Center">
                                           <ItemTemplate>
                                           <asp:Label ID="Label4" runat="server" Text='<%#Bind("Amount")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label5" runat="server" Text="TOTAL" ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                              <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                          </asp:TemplateField>
                                          <asp:BoundField DataField="Limit" HeaderText="Limit"/>
                                        <asp:TemplateField HeaderText="Deduction" HeaderStyle-HorizontalAlign="Center">
                                           <ItemTemplate>
                                           <asp:Label ID="Label2" runat="server" Text='<%#Bind("Deduction")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label3" runat="server" Text="" ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                              <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                          </asp:TemplateField>                                     
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

