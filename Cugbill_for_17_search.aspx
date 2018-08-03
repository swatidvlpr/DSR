﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Cugbill_for_17_search.aspx.cs" Inherits="DSR_Cugbill_for_17_show" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">

    function PrintGridData() {

        var prtGrid = document.getElementById('ContentPlaceHolder1_GridView1');

        prtGrid.border = 0;

        var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');


        prtwin.document.write(prtGrid.outerHTML);

        prtwin.document.close();

        prtwin.focus();
        prtwin.print();
        prtwin.close();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="page-wrapper">
<div class="main-page">
    <div id="form1" class="forms validation">
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
			<h4>Cugbill show:</h4>
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
       
    <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
        Enabled="True" PopupPosition="TopRight" TargetControlID="TextBox1">
    </cc1:CalendarExtender>
       
</div> 

<div class="col-md-12 form-group">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Button ID="Button1" runat="server" Text="SEARCH" 
        Class=" btn btn-warning " onclick="Button1_Click" />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " 
        Text="Reset" ValidationGroup="a" onclick="Button2_Click" />&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Export To Excel" 
        Class="btn btn-danger" onclick="Button3_Click"  />
        </div>
                 <div class="col-md-12 grid-margin">
               <div class="table-responsive" >                 
             <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">


                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Cug_id" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="True" 
                     onrowdatabound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
                <asp:BoundField DataField="Allocated_to" HeaderText="Name"/>
                                      <asp:BoundField DataField="branchname" HeaderText="Branch name"/>                                      
                                      <asp:BoundField DataField="Number" HeaderText="Number"/>
                                      <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Center">
                                           <ItemTemplate>
                                           <asp:Label ID="Label1" runat="server" Text='<%#Bind("Amount")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label2" runat="server" Text="TOTAL" ForeColor="White"></asp:Label>
                                             </FooterTemplate>
                                              <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Limit" HeaderStyle-HorizontalAlign="Center">
                                           <ItemTemplate>
                                           <asp:Label ID="Label3" runat="server" Text='<%#Bind("Limit")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label4" runat="server" Text="" ForeColor="White"></asp:Label>
                                             </FooterTemplate>
                                              <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                          </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Deduction" HeaderStyle-HorizontalAlign="Center">
                                           <ItemTemplate>
                                           <asp:Label ID="Label5" runat="server" Text='<%#Bind("Deduction")%>'></asp:Label>
                                          </ItemTemplate>
                                          <FooterTemplate>
                                                 <asp:Label ID="Label6" runat="server" Text="" ForeColor="White"></asp:Label>
                                             </FooterTemplate>
                                              <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                                          </asp:TemplateField>                                     
                                       <asp:BoundField DataField="Date" HeaderText="Date"/>

        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
       
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

