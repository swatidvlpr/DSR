<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Prospects_month_search.aspx.cs" Inherits="DSR_Prospects_month_search" %>

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
			<h4>Prospects month show:</h4>
			</div>
             <div class="form-body" id="form">
                   <div class="col-md-6 form-group">
                   <label>Branch</label>
                   <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                   <asp:ListItem Value="0">---Select---</asp:ListItem>
                   <asp:ListItem Value="1">DO in hand</asp:ListItem>
                    <asp:ListItem Value="2">CF hot cases</asp:ListItem>
                       <asp:ListItem Value="3">BDCN</asp:ListItem>
                       <asp:ListItem Value="4">BHM</asp:ListItem>
                       <asp:ListItem Value="5">BLS</asp:ListItem>
                       <asp:ListItem Value="6">ANG</asp:ListItem>
                       <asp:ListItem Value="7">KJR</asp:ListItem>
                       <asp:ListItem Value="8">SBP</asp:ListItem>
                       <asp:ListItem Value="9">RKL</asp:ListItem>
                   </asp:DropDownList>
                   </div> 
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
            <asp:Button ID="Button1" runat="server" Text="SEARCH" onclick="Button1_Click" Class=" btn btn-warning " />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" OnClick="Button2_Click" ValidationGroup="a" />&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Export To Excel" 
        Class="btn btn-danger"  OnClick="Button3_Click"  />
        </div>
                 <div class="col-md-12 grid-margin">
               <div class="table-responsive" >                 
             <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">


                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Prospect_id" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="100%" 
                     OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
         <asp:BoundField DataField="Branch" HeaderText="Branch"/>
                 <asp:BoundField DataField="Customer_name" HeaderText="Customer name"/>
                                           <asp:BoundField DataField="Departmentnm" HeaderText="Department name"/>
                                            <asp:BoundField DataField="Name" HeaderText="Name"/>
                                            <asp:BoundField DataField="Location_name" HeaderText="Location"/>
                  <asp:TemplateField HeaderText="Model" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                                   
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%#Eval("Modelnm") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="Label3" runat="server" Text="Total" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
             </asp:TemplateField> 
              <asp:TemplateField HeaderText="Units" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                                   
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%#Eval("Units") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal1" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
             </asp:TemplateField>
              <asp:BoundField DataField="Finance" HeaderText="Finance"/>
                                              <asp:BoundField DataField="Status" HeaderText="Status"/>
            
                       
                                          <asp:BoundField DataField="date" HeaderText="date" /> 
                       
            
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

