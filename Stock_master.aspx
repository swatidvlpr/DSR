<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Stock_master.aspx.cs" Inherits="DSR_Stock_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Stock master entry</h4>
               </div>
               <div class="form-body" id="form">
                <div class="col-md-6 form-group">
                <label >Company name</label>
  
                   <asp:DropDownList ID="ddlcmpnynm" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlcmpnynm_SelectedIndexChanged">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                           ErrorMessage="Select company name" ControlToValidate="ddlcmpnynm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                 <div class="col-md-6 form-group">
                <label>Category name</label>
  
                   <asp:DropDownList ID="ddlctgrynm" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlctgrynm_SelectedIndexChanged" AutoPostBack="True">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                           ErrorMessage="Select category name" ControlToValidate="ddlctgrynm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                 <div class="col-md-6 form-group">
                <label >Model name</label>
                   <asp:DropDownList ID="ddlmdlnm" runat="server" CssClass="form-control" 
                         AutoPostBack="True" onselectedindexchanged="ddlmdlnm_SelectedIndexChanged">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                           ErrorMessage="Select model name" ControlToValidate="ddlmdlnm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Model no</label>
                   <asp:TextBox ID="txtmdlno" runat="server" CssClass="form-control"></asp:TextBox>                                    
                   
                   <br />
                   
                </div>
               <div class="col-md-6 form-group">
                <label >Opening </label>
                           <br />
               
                   <asp:TextBox ID="txtopng" runat="server" CssClass="form-control" 
                       AutoPostBack="True" OnTextChanged="txtopng_TextChanged">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Enter opening" ControlToValidate="txtopng" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Purchage </label>
                    <br />
                      <asp:TextBox ID="txtpurchage" runat="server" CssClass="form-control" 
                        AutoPostBack="True" ontextchanged="txtprvsstck_TextChanged">0</asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Enter Purachage" ControlToValidate="txtpurchage" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>                
                
                
              <div class="col-md-6 form-group">
                <label >Sale </label>
                  <asp:TextBox ID="txtsale" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                      ontextchanged="txtsale_TextChanged">0</asp:TextBox>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ErrorMessage="Enter Sale" ControlToValidate="txtsale" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>

                 <div class="col-md-6 form-group">
                <label >Stock</label>
                  <asp:TextBox ID="txtstock" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" OnTextChanged="txtstock_TextChanged"></asp:TextBox>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                           ErrorMessage="Enter stock" ControlToValidate="txtstock" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                             <div class="col-md-6 form-group">
                <label >Date</label>
                  <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                  
                                 <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                                     Enabled="True" TargetControlID="txtdate" PopupPosition="TopRight">
                                 </cc1:CalendarExtender>
                  
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                           ErrorMessage="Enter date" ControlToValidate="txtdate" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>              
           
                 <div class="col-md-12 form-group">
                                 <asp:Button ID="Button1" runat="server" Text="Submit" 
                                     Class=" btn btn-warning " ValidationGroup="a" onclick="Button1_Click"/>
                                  &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " 
                                     Text="reset" ValidationGroup="b" onclick="Button2_Click"/>
                                     &nbsp;
          
                                <br />
                                 <asp:Label ID="Label1" runat="server"></asp:Label>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
                             </div>
                             <div class="col-md-12 grid-margin">
                              <div class="table-responsive">
                              <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0"   >
                                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                      ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None" 
                                      DataKeyNames="Stock_id" onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged" Width="100%">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                       <asp:BoundField DataField="companyname" HeaderText="Companynm"/>
                                       <asp:BoundField DataField="Categorynm" HeaderText="Categorynm"/>
                                       <asp:BoundField DataField="Modelnm" HeaderText="Modelnm"/>
                                       <asp:BoundField DataField="Model_no" HeaderText="Modelno"/>
                                       <asp:BoundField DataField="Opening_stock" HeaderText="Opening Balance"/>
                                      
                                       <asp:BoundField DataField="Purchase" HeaderText="Purchase"/>
                                       <asp:BoundField DataField="Sale" HeaderText="Sale"/>
                                       <asp:BoundField DataField="Stack" HeaderText="Stack"/>                                      
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

