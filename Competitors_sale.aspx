<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Competitors_sale.aspx.cs" Inherits="DSR_Competitors_sale" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
   <div class="main-page">
      <div id="form1" class="forms validation">
         <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
               <h4>Competitors sale entry</h4>
               </div>
               <div class="form-body" id="form">
               <div class="col-md-6 form-group">
                <label >Category</label>
                  <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                   
                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ErrorMessage="Enter category" ControlToValidate="TextBox1" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >Class</label>
               
                   <br />
               
                   <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ErrorMessage="Enter class" ControlToValidate="TextBox8" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Tata</label>
                    <br />
                      <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" 
                        AutoPostBack="True" ontextchanged="TextBox9_TextChanged">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="TextBox9_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox9">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ErrorMessage="Enter tata" ControlToValidate="TextBox9" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                
                
                <div class="col-md-6 form-group">
                <label >Al</label>
                  <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                        ontextchanged="TextBox2_TextChanged">0</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="TextBox2_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox2">
                    </cc1:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ErrorMessage="Enter Al" ControlToValidate="TextBox2" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
              <div class="col-md-6 form-group">
                <label >AMW</label>
                  <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                      ontextchanged="TextBox3_TextChanged">0</asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="TextBox3_FilteredTextBoxExtender" 
                      runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox3">
                  </cc1:FilteredTextBoxExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                           ErrorMessage="Enter amw" ControlToValidate="TextBox3" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               <div class="col-md-6 form-group">
                <label >M&m</label>
                  <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                       ontextchanged="TextBox4_TextChanged">0</asp:TextBox>
                   
                    <cc1:FilteredTextBoxExtender ID="TextBox4_FilteredTextBoxExtender" 
                       runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox4">
                   </cc1:FilteredTextBoxExtender>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                           ErrorMessage="Enter m&m" ControlToValidate="TextBox4" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
               
                <div class="col-md-6 form-group">
                <label >Man</label>
                  <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                        ontextchanged="TextBox5_TextChanged">0</asp:TextBox>
                   
                    <cc1:FilteredTextBoxExtender ID="TextBox5_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox5">
                    </cc1:FilteredTextBoxExtender>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                           ErrorMessage="Enter man" ControlToValidate="TextBox5" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                <label >Eicher</label>
                  <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                        ontextchanged="TextBox6_TextChanged">0</asp:TextBox>
                   
                    <cc1:FilteredTextBoxExtender ID="TextBox6_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox6">
                    </cc1:FilteredTextBoxExtender>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                           ErrorMessage="Enter eicher" ControlToValidate="TextBox6" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                  <label >Benz</label>
                &nbsp;<asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                        ontextchanged="TextBox7_TextChanged">0</asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="TextBox7_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBox7">
                    </cc1:FilteredTextBoxExtender>
                    
                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                           ErrorMessage="Enter benz" ControlToValidate="TextBox7" 
                              ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                  <label >Total</label>
                &nbsp;<asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine" AutoPostBack="True" 
                        ontextchanged="TextBox10_TextChanged"></asp:TextBox>
                    
                   &nbsp;</div>
            <div class="col-md-6 form-group">
                  <label >Date</label>
                &nbsp;<asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" 
                                            TextMode="SingleLine"></asp:TextBox>
                   
                   <cc1:CalendarExtender ID="TextBox11_CalendarExtender" runat="server" 
                      Enabled="True" PopupPosition="TopRight" TargetControlID="TextBox11">
                  </cc1:CalendarExtender>
                   
                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                           ErrorMessage="Enter date" ControlToValidate="TextBox11" 
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
                                      onrowdeleting="GridView1_RowDeleting" 
                                      onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                      DataKeyNames="Sale_id" HorizontalAlign="Center" ShowFooter="True" 
                                      onrowdatabound="GridView1_RowDataBound">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <Columns>
                                         
                                             <asp:TemplateField HeaderText="Category"  HeaderStyle-HorizontalAlign="Center">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label2" runat="server" Text='<%#Bind("Category")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label3" runat="server" Text="TOTAL:" ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                             </asp:TemplateField>
                                            <asp:BoundField DataField="Class" HeaderText="Class"/>
                                         
                                              <asp:TemplateField HeaderText="Tata">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label4" runat="server" Text='<%#Bind("Tata")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label5" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Al">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label6" runat="server" Text='<%#Bind("Al")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label7" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Amw">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label8" runat="server" Text='<%#Bind("Amw")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label9" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M&m">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label10" runat="server" Text='<%#Bind("Mm")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label11" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Man">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label12" runat="server" Text='<%#Bind("Man")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label13" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Eicher">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label14" runat="server" Text='<%#Bind("Eicher")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label15" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Benz">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label16" runat="server" Text='<%#Bind("Benz")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label17" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Total">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label18" runat="server" Text='<%#Bind("Total")%>'></asp:Label>
                                             </ItemTemplate>
                                             <FooterTemplate>
                                                 <asp:Label ID="Label19" runat="server"  ForeColor="Blue"></asp:Label>
                                             </FooterTemplate>
                                             </asp:TemplateField>
                                               <asp:BoundField DataField="Date" HeaderText="Date" />
                                            <%-- <asp:BoundField DataField="Al" HeaderText="Al" />
                                              <asp:BoundField DataField="Amw" HeaderText="Amw" />
                                               <asp:BoundField DataField="Mm" HeaderText="M&m" />
                                                <asp:BoundField DataField="Man" HeaderText="Man" />
                                                 <asp:BoundField DataField="Eicher" HeaderText="Eicher" />
                                                  <asp:BoundField DataField="Benz" HeaderText="Benz" />
                                          --%>
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

