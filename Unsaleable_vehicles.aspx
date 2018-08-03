<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Unsaleable_vehicles.aspx.cs" Inherits="DSR_Unsaleable_vehicles" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Unsaleable vehicle entry</h4>
               </div>
               <div class="form-body" id="form">
                <div class="col-md-6 form-group">
                <label >Company name</label>
                   <asp:DropDownList ID="ddlcmpnynm" runat="server" CssClass="form-control" 
                        AutoPostBack="True" onselectedindexchanged="ddlcmpnynm_SelectedIndexChanged">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                           ErrorMessage="Select company name" ControlToValidate="ddlcmpnynm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                 <div class="col-md-6 form-group">
                <label >Category name</label>
                   <asp:DropDownList ID="ddlctgrynm" runat="server" CssClass="form-control" 
                         AutoPostBack="True" onselectedindexchanged="ddlctgrynm_SelectedIndexChanged">
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
                <label >Color</label>
                           <br />
               
                   <asp:TextBox ID="txtcolor" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Enter color" ControlToValidate="txtcolor" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Engine no</label>
                    <br />
                      <asp:TextBox ID="txtegnno" runat="server" CssClass="form-control"></asp:TextBox>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Enter engine no" ControlToValidate="txtegnno" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>                
                
                <div class="col-md-6 form-group">
                <label >VIN no</label>
                  <asp:TextBox ID="txtvinno" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ErrorMessage="Enter vin no" ControlToValidate="txtvinno" 
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
                                      DataKeyNames="Unsale_id" onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                       <asp:BoundField DataField="companyname" HeaderText="Companyname"/>
                                       <asp:BoundField DataField="Categorynm" HeaderText="Categorynm"/>
                                       <asp:BoundField DataField="Modelnm" HeaderText="Modelname"/>
                                       <asp:BoundField DataField="Model_no" HeaderText="Modelno"/>
                                       <asp:BoundField DataField="Color" HeaderText="Color"/>
                                       <asp:BoundField DataField="Engine_no" HeaderText="Engine no"/>
                                       <asp:BoundField DataField="VIN_no" HeaderText="VIN no"/>                                      
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

