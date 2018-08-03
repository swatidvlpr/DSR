<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Prospects_feb_month.aspx.cs" Inherits="DSR_Prospects_feb_month" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Prospects entry</h4>
               </div>
               <div class="form-body" id="form">
               <div class="col-md-6 form-group">
                <label >Branch</label>
                   <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                       <asp:ListItem Value="0">Select</asp:ListItem>
                       <asp:ListItem Value="2">DO in hand</asp:ListItem>
                       <asp:ListItem Value="2">CF hot cases</asp:ListItem>
                       <asp:ListItem Value="3">BDCN</asp:ListItem>
                       <asp:ListItem Value="4">BHM</asp:ListItem>
                       <asp:ListItem Value="5">BLS</asp:ListItem>
                       <asp:ListItem Value="6">ANG</asp:ListItem>
                       <asp:ListItem Value="7">KJR</asp:ListItem>
                       <asp:ListItem Value="8">SBP</asp:ListItem>
                       <asp:ListItem Value="9">RKL</asp:ListItem>
                   </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Select branch" ControlToValidate="DropDownList5" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Customer name</label>
                  <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ErrorMessage="Enter customer name" ControlToValidate="TextBox1" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                
                <div class="col-md-6 form-group">
                <label >Department name</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Select department name" ControlToValidate="DropDownList1" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Executive name</label>
                     <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" 
                        ValidationGroup="a">
                    </asp:DropDownList>
                                       
                </div>
                
                <div class="col-md-6 form-group">
                <label >Location</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                           ErrorMessage="Select location" ControlToValidate="DropDownList2" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Model</label>
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                           ErrorMessage="Select model" ControlToValidate="DropDownList3" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Units</label>
                  <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                           ErrorMessage="Enter units" ControlToValidate="TextBox2" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Finance</label>
                  <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                           ErrorMessage="Enter finance" ControlToValidate="TextBox3" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                 <div class="col-md-6 form-group">
                <label >Status</label>
                  <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                           ErrorMessage="Enter status" ControlToValidate="TextBox4" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Date</label>
                  <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                                       <cc1:CalendarExtender ID="txtdate_CalendarExtender" 
                        runat="server" Enabled="True" PopupPosition="TopRight" 
                        TargetControlID="txtdate">
                    </cc1:CalendarExtender>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
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
                                      CellPadding="4" ForeColor="#333333" GridLines="None" 
                                      onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                                      DataKeyNames="Prospect_id">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                      <asp:BoundField DataField="Branch" HeaderText="Branch"/>
                                          <asp:BoundField DataField="Customer_name" HeaderText="Customer name"/>
                                           <asp:BoundField DataField="Departmentnm" HeaderText="Department name"/>
                                            <asp:BoundField DataField="Name" HeaderText="Name"/>
                                            <asp:BoundField DataField="Location_name" HeaderText="Location"/>
                                            <asp:TemplateField HeaderText="Model" HeaderStyle-HorizontalAlign="Center">
                                           <ItemTemplate>
                                           <asp:Label ID="Label2" runat="server" Text='<%#Bind("Modelnm")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label3" runat="server" Text="TOTAL" ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                              <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Units">
                                           <ItemTemplate>
                                           <asp:Label ID="Label4" runat="server" Text='<%#Bind("Units")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label5" runat="server" ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:BoundField DataField="Finance" HeaderText="Finance"/>
                                              <asp:BoundField DataField="Status" HeaderText="Status"/>
                                               <asp:BoundField DataField="Date" HeaderText="Date"/>

                                             <%-- <asp:TemplateField HeaderText="Date">
                                                    <itemtemplate>
                              <asp:TextBox ID="txtdate" runat="server" class="form-control"></asp:TextBox>
                                                       
                                       </itemtemplate>
                                            </asp:TemplateField>--%>
             
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
                                         <%-- <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
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

