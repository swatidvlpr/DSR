<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="financier_wise_sale.aspx.cs" Inherits="DSR_financier_wise_sale" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="page-wrapper">
<div class="main-page">
<div id="form1" class="forms validation">
<div class="form-grids row widget-shadow" data-example-id="basic-forms">
    <div class="form-title">
	<h4>Financier Wise Sale</h4>
	</div>
    <div class="form-body" id="form">
<div class="col-md-6 form-group">
    <label >Financier Name</label>
    <asp:DropDownList ID="ddlfinancier" runat="server" CssClass="form-control"></asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
      ControlToValidate="ddlfinancier" ErrorMessage="Select financier name" ValidationGroup="a"></asp:RequiredFieldValidator>
</div>
<div class="col-md-6 form-group">
    <label >Model</label>
    <%--<asp:TextBox ID="txtmodel" runat="server" CssClass="form-control"></asp:TextBox>--%>
    <asp:DropDownList ID="ddlmodel" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlmodel" ErrorMessage="enter valid address" ValidationGroup="a"></asp:RequiredFieldValidator>
</div>

        <div class="col-md-6 form-group">
            <label >Sale Qty</label>
            <asp:TextBox ID="txtSaleQty" runat="server" CssClass="form-control">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtSaleQty_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSaleQty">
            </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtSaleQty" ErrorMessage="Enter Sale Qty" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Total.</label>
            <asp:TextBox ID="txttotal" runat="server" CssClass="form-control">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txttotal_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txttotal">
            </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txttotal" ErrorMessage="enter total" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
          <label >T.S.In Hand</label>  
             <asp:TextBox ID="txtT_S_In_Hand" runat="server" CssClass="form-control">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtT_S_In_Hand_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtT_S_In_Hand">
            </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtT_S_In_Hand" ErrorMessage="enter T.S.In Hand" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Total T.Sheet</label> 
            <asp:TextBox ID="txtTotal_T_Sheet" runat="server" CssClass="form-control">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTotal_T_Sheet_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtTotal_T_Sheet">
            </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtTotal_T_Sheet" ErrorMessage="enter total t sheet" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>

         <div class="col-md-6 form-group">
            <label >Date</label> 
            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
               
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Enabled="True" PopupPosition="TopRight" TargetControlID="txtdate">
             </cc1:CalendarExtender>
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="enter date" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-12 form-group">
            <asp:Button ID="Button1" runat="server" Text="SUBMIT" onclick="Button1_Click" Class=" btn btn-warning " ValidationGroup="a" />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" OnClick="Button2_Click" ValidationGroup="a" />
        &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <div class="col-md-12 grid-margin">
                 <div class="table-responsive" >
<table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
                   

</table>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Financiersale_id" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    onrowdeleting="GridView1_RowDeleting" Width="100%" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" >
                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Financier" HeaderText="Financier" />
                        <asp:BoundField DataField="Model" HeaderText="Model" FooterText="Total" />

                        <asp:TemplateField HeaderText="Sale Qty" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%#Eval("Sale_Qty") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal1" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                      </asp:TemplateField>

                   
                        
                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal2" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                         </asp:TemplateField>
                       
                        
                        <asp:TemplateField HeaderText="T.S.In Hand" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%#Eval("T_S_In_Hand") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal3" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                         </asp:TemplateField>

                        
                        <asp:TemplateField HeaderText="Total T.Sheet" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%#Eval("Total_T_Sheet") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal4" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                         </asp:TemplateField>

                        <%--<asp:BoundField DataField="T_S_In_Hand" HeaderText="T.S.In Hand" />
                        <asp:BoundField DataField="Total_T_Sheet" HeaderText="Total T.Sheet" />--%>
                       <%-- <asp:CommandField SelectText="EDIT" ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />--%>
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
                    </Columns>

           <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Right"  />
        
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                 </div>
                        

             </div>
    </div>
</div>

</div>

</div>

      </div>

</asp:Content>

