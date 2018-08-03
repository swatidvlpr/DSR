<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Age_of_stock.aspx.cs" Inherits="DSR_Age_of_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Age of stock entry</h4>
               </div>
               <div class="form-body" id="form">
               <div class="col-md-6 form-group">
                <label >Model</label>
                   <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                   </asp:DropDownList>                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ErrorMessage="Select model" ControlToValidate="DropDownList1" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Less than 1 month old</label>
               
                   <br />
               
                   <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" 
                       AutoPostBack="True" ontextchanged="TextBox2_TextChanged">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="TextBox2_FilteredTextBoxExtender" 
                       runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox2">
                   </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Enter lessthan 1month" ControlToValidate="TextBox2" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Between 1 & 3 months old</label>
                    <br />
                      <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" 
                        AutoPostBack="True" ontextchanged="TextBox3_TextChanged" >0</asp:TextBox>
                  
                    <cc1:FilteredTextBoxExtender ID="TextBox3_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox3">
                    </cc1:FilteredTextBoxExtender>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Enter between 1 & 3 months" ControlToValidate="TextBox3" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                
                
                <div class="col-md-6 form-group">
                <label >Between 3 & 6 months old</label>
                  <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                        ontextchanged="TextBox4_TextChanged">0</asp:TextBox>
                   
                    <cc1:FilteredTextBoxExtender ID="TextBox4_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox4">
                    </cc1:FilteredTextBoxExtender>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ErrorMessage="Enter between 1 & 3 months" ControlToValidate="TextBox4" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
              <div class="col-md-6 form-group">
                <label >More than 6 months old</label>
                  <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                      ontextchanged="TextBox5_TextChanged">0</asp:TextBox>
                   
                    
                    <cc1:FilteredTextBoxExtender ID="TextBox5_FilteredTextBoxExtender" 
                      runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox5">
                  </cc1:FilteredTextBoxExtender>
                   
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                           ErrorMessage="Enter more than 6 months" ControlToValidate="TextBox5" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Total stock</label>
                  <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                       ontextchanged="TextBox6_TextChanged"></asp:TextBox>
              
                </div>
               <div class="col-md-6 form-group">
                <label >Date</label>
                  <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                  
                    <cc1:CalendarExtender ID="TextBox7_CalendarExtender" runat="server" 
                       Enabled="True" PopupPosition="TopRight" TargetControlID="TextBox7">
                   </cc1:CalendarExtender>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                           ErrorMessage="Enter date" ControlToValidate="TextBox7" 
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
                                      onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                      DataKeyNames="stock_id">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                     <asp:TemplateField HeaderText="Model" HeaderStyle-HorizontalAlign="Center">
                                          <ItemTemplate>
                                           <asp:Label ID="Label12" runat="server" Text='<%#Bind("Model")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label13" runat="server" Text="TOTAL" ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                              <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="< 1 month">
                                          <ItemTemplate>
                                           <asp:Label ID="Label2" runat="server" Text='<%#Bind("Lessthan_onemonth")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label3" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Btw 1&3 month">
                                          <ItemTemplate>
                                           <asp:Label ID="Label4" runat="server" Text='<%#Bind("Btwnone_threemonth")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label5" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Btwn 3&6 month">
                                          <ItemTemplate>
                                           <asp:Label ID="Label6" runat="server" Text='<%#Bind("Btwnthree_sixmonth")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label7" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                          </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Morethan 6 month">
                                          <ItemTemplate>
                                           <asp:Label ID="Label8" runat="server" Text='<%#Bind("Morethan_sixmonth")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label9" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Total stock">
                                          <ItemTemplate>
                                           <asp:Label ID="Label10" runat="server" Text='<%#Bind("Total_stock")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label11" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
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

