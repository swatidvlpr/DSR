<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Stockentry.aspx.cs" Inherits="DSR_Stockentry" %>
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
  
                   <asp:DropDownList ID="ddlctgrynm" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlctgrynm_SelectedIndexChanged" AutoPostBack="True" OnDataBound="ddlctgrynm_DataBound">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                           ErrorMessage="Select category name" ControlToValidate="ddlctgrynm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                 <div class="col-md-6 form-group">
                <label >Model name</label>
                   <asp:DropDownList ID="ddlmdlnm" runat="server" CssClass="form-control" 
                         AutoPostBack="True" onselectedindexchanged="ddlmdlnm_SelectedIndexChanged" OnDataBound="ddlmdlnm_DataBound">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                           ErrorMessage="Select model name" ControlToValidate="ddlmdlnm" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Model no</label>
                   <asp:TextBox ID="txtmdlno" runat="server" CssClass="form-control"></asp:TextBox>                                    
                   
                </div>

                <div class="col-md-6 form-group">
            <label >Branch Name </label> 
            <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control">                 
              </asp:DropDownList>           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"  
                    ControlToValidate="ddlbranch" ErrorMessage="Select branch name" ValidationGroup="a"></asp:RequiredFieldValidator>
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
                   
                     <div class="col-md-6 form-group">
                <label >Particulars</label>
                  <asp:TextBox ID="txtparticulars" runat="server" CssClass="form-control"  TextMode="SingleLine"></asp:TextBox>                
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="Enter particulars" ControlToValidate="txtparticulars"  ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>  
                       <div class="col-md-6 form-group">
                <label >Recived Qnty</label>
                  <asp:TextBox ID="txtrecivedqnty" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtrecivedqnty_TextChanged">0</asp:TextBox>                
                            <cc1:FilteredTextBoxExtender ID="txtrecivedqnty_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtrecivedqnty">
                           </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="Enter recived qnty" ControlToValidate="txtrecivedqnty"  ValidationGroup="a"></asp:RequiredFieldValidator>
                </div> 
                      
               <div class="col-md-6 form-group">
                <label >Recived Price</label>
                  <asp:TextBox ID="txtrecivedprice" runat="server" CssClass="form-control"  TextMode="SingleLine" AutoPostBack="True" OnTextChanged="txtrecivedprice_TextChanged">00.00</asp:TextBox>     
                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers, Custom"
    ValidChars=".," TargetControlID="txtrecivedprice" />           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="Enter recived price" ControlToValidate="txtrecivedprice"  ValidationGroup="a"></asp:RequiredFieldValidator>
                
               </div>
                   <div class="col-md-6 form-group">
                <label >Issue Qnty</label>
                  <asp:TextBox ID="txtissueqnty" runat="server" CssClass="form-control"  TextMode="SingleLine" AutoPostBack="True" OnTextChanged="txtissueqnty_TextChanged">0</asp:TextBox>                
                            <cc1:FilteredTextBoxExtender ID="txtissueqnty_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtissueqnty">
                       </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ErrorMessage="Enter issue qnty" ControlToValidate="txtissueqnty"  ValidationGroup="a"></asp:RequiredFieldValidator>
                </div> 
               <div class="col-md-6 form-group">
                <label >Issue Price</label>
                  <asp:TextBox ID="txtissueprice" runat="server" CssClass="form-control"  TextMode="SingleLine" AutoPostBack="True" OnTextChanged="txtissueprice_TextChanged">00.00</asp:TextBox>   
                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers, Custom"
                        ValidChars=".," TargetControlID="txtissueprice" />                
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ErrorMessage="Enter issue qnty" ControlToValidate="txtissueqnty"  ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>   
                   
               <div class="col-md-6 form-group">
                <label >Balance Qnty</label>
                  <asp:TextBox ID="txtbalanceqnty" runat="server" CssClass="form-control"  TextMode="SingleLine">0</asp:TextBox>  
                                 
                            <cc1:FilteredTextBoxExtender ID="txtbalanceqnty_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtbalanceqnty">
                   </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ErrorMessage="Enter issue qnty" ControlToValidate="txtissueqnty"  ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>    
                   
                   <div class="col-md-6 form-group">
                <label >Balance Price</label>
                  <asp:TextBox ID="txtbalanceprice" runat="server" CssClass="form-control"  TextMode="SingleLine">00.00</asp:TextBox>   
                       <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers, Custom"
                        ValidChars=".," TargetControlID="txtbalanceprice" />                
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  ErrorMessage="Enter balance price" ControlToValidate="txtbalanceprice"  ValidationGroup="a"></asp:RequiredFieldValidator>
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
                              <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0"></table>
                                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                      ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None" 
                                      DataKeyNames="Stock_id" onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged" Width="100%">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                       <asp:BoundField DataField="companyname" HeaderText="Company"/>
                                       <asp:BoundField DataField="Categorynm" HeaderText="Category"/>
                                       <asp:BoundField DataField="Modelnm" HeaderText="Model"/>
                                       <asp:BoundField DataField="Model_no" HeaderText="Model No"/>
                                       <asp:BoundField DataField="branchname" HeaderText="Branch"/>                                    
                                       <asp:BoundField DataField="Particulars" HeaderText="Particulars"/>
                                       <asp:BoundField DataField="Recived_qty" HeaderText="Recived Qty"/>
                                       <asp:BoundField DataField="Recived_price" HeaderText="Recived Price" DataFormatString="{0:n}"/>
                                       <asp:BoundField DataField="Issue_qty" HeaderText="Issue Qty"/>
                                       <asp:BoundField DataField="Issue_price" HeaderText="Issue Price" DataFormatString="{0:n}"/>
                                       <asp:BoundField DataField="Balance_qty" HeaderText="Balance Qty"/>
                                       <asp:BoundField DataField="Balance_price" HeaderText="Balance Price" DataFormatString="{0:n}"/>                                                                          
                                       <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:d}"/>

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
                               
                              </div>
                             </div>
                          </div>
                      </div>
                  </div>
             </div>
       </div>
</asp:Content>

