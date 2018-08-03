<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Financier_wise_sale_report.aspx.cs" Inherits="DSR_Financier_wise_sale_report" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
<div class="main-page">
    <div id="form1" class="forms validation">
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
			<h4>FINANCIER WISE SALE :</h4>
			</div>
             <div class="form-body" id="form">                 
                 <div class="col-md-6 form-group">
    <label >Month </label>
      <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
           <asp:ListItem Value="0">---Select Month----</asp:ListItem>
                <asp:ListItem Value="1">Jan</asp:ListItem>
                <asp:ListItem Value="2">Feb</asp:ListItem>
                <asp:ListItem Value="3">Mar</asp:ListItem>
                <asp:ListItem Value="4">Apr</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
               <asp:ListItem Value="6">Jun</asp:ListItem>
                <asp:ListItem Value="7">Jul</asp:ListItem>
                <asp:ListItem Value="8">Aug</asp:ListItem>
                <asp:ListItem Value="9">Sep</asp:ListItem>
                <asp:ListItem Value="10">Oct</asp:ListItem>
                <asp:ListItem Value="11">Nov</asp:ListItem>
                <asp:ListItem Value="12">Dec</asp:ListItem>

      </asp:DropDownList>
</div>
<div class="col-md-6 form-group">
    <label >Year </label>
    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
        <asp:ListItem Value="0">--Select--</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="col-md-6 form-group">
    <label >Date </label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox1" PopupPosition="TopRight">
    </cc1:CalendarExtender>
</div> 

<div class="col-md-12 form-group">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Button ID="Button1" runat="server" Text="SEARCH" onclick="Button1_Click" Class=" btn btn-warning " />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" OnClick="Button2_Click" ValidationGroup="a" />&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Export To Excel" 
        Class="btn btn-danger" onclick="Button3_Click"  />
        </div>
                 <div class="col-md-12 grid-margin">
<div class="table-responsive" >                 
<table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
       <asp:Panel runat="server" ID="Panel1">
         <asp:Label ID="lblCaption" runat="server" Text="FINANCIER WISE SALE" Style="font-weight: bold;
                    color:black;"></asp:Label>

                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Financiersale_id" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="100%" 
                     OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
       
              <asp:TemplateField HeaderText="Financier" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%#Eval("Financier") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal1" runat="server" Text="TOTAL" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
             </asp:TemplateField>

                 <asp:BoundField DataField="Model" HeaderText="Model" />

             <asp:TemplateField HeaderText="Sale_Qty" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%#Eval("Sale_Qty") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal2" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal3" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                         </asp:TemplateField>
                                           <asp:TemplateField HeaderText="T_S_In_Hand" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%#Eval("T_S_In_Hand") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal4" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                         </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Total_T_Sheet" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label5" runat="server" Text='<%#Eval("Total_T_Sheet") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal5" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                         </asp:TemplateField>
             <asp:BoundField DataField="date" HeaderText="date" /> 
                       
            
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

