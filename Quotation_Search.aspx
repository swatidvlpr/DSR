<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Quotation_Search.aspx.cs" Inherits="DSR_Quotation_Search" %>
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
			<h4>Quotation Form show:</h4>
			</div>
             <div class="form-body" id="form">
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                
             <div class="col-md-6 form-group">
                   <label>Branch</label>
                   <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control">
                   <asp:ListItem Value="0">---Select---</asp:ListItem>                   
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

           <%--      <div class="col-md-6 form-group">
            <label >Company Name </label> 
         
             <asp:DropDownList ID="ddlcompany" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                 
              </asp:DropDownList>           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  
                    ControlToValidate="ddlcompany" ErrorMessage="Enter company name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-6 form-group">
            <label >Category Name </label> 
          
             <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" OnDataBound="ddlCategory_DataBound">                 
              </asp:DropDownList>           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  
                    ControlToValidate="ddlCategory" ErrorMessage="Enter category name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>

          <div class="col-md-6 form-group">
            <label >Model Name </label> 
          
             <asp:DropDownList ID="ddlmodelnm" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlmodelnm_SelectedIndexChanged" OnDataBound="ddlmodelnm_DataBound">                 
              </asp:DropDownList>           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"  
                    ControlToValidate="ddlmodelnm" ErrorMessage="Enter model name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-6 form-group">
            <label >Model No </label> 
            <asp:TextBox ID="txtmodelno" runat="server" CssClass="form-control"></asp:TextBox>
                       
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"  
                    ControlToValidate="txtmodelno" ErrorMessage="Enter model no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>--%>
 <div class="col-md-6 form-group">
            <label >Challan No </label> 
                                
     <asp:DropDownList ID="ddlchallan" runat="server" CssClass="form-control">
     </asp:DropDownList>  
        </div>
         <div class="col-md-6 form-group">
            <label >QTN NO </label> 
             <asp:DropDownList ID="ddlqutno" runat="server" CssClass="form-control">
             </asp:DropDownList>
        </div>    
              
                <div class="col-md-6 form-group">
            <label >Order No </label> 
                    <asp:DropDownList ID="ddlorder" runat="server" CssClass="form-control">
                    </asp:DropDownList>
        </div>

     <div class="col-md-6 form-group">
           
    <label >Customer Name</label>
            
         <asp:DropDownList ID="ddlcstmrnm" runat="server" CssClass="form-control">
         </asp:DropDownList>
</div>
 </ContentTemplate>
                 </asp:UpdatePanel>

<div class="col-md-12 form-group">
  
            <asp:Button ID="Button1" runat="server" Text="SEARCH" 
        Class=" btn btn-warning " onclick="Button1_Click" />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " 
        Text="Reset" ValidationGroup="a" onclick="Button2_Click" />&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Export To Excel" 
        Class="btn btn-danger" onclick="Button3_Click"  />
        </div>
                 <div class="col-md-12 grid-margin">

<div class="table-responsive" >   
    <table id="Table1" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
      <asp:Panel runat="server" ID="Panel2">
         <asp:Label ID="Label1" runat="server" Text="Quotation Show" Style="font-weight: bold;
                    color:black;"></asp:Label>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Quotationid" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField ControlStyle-CssClass="" HeaderText="SN">
                            <ItemTemplate>
                          
                                <%#GridView2.Rows.Count + 1%>
                               
                            </ItemTemplate>
                            <ControlStyle />
                            <FooterStyle />
                            <HeaderStyle CssClass="" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <ItemStyle CssClass="" HorizontalAlign="Left" />
                        </asp:TemplateField> 
                        <asp:BoundField DataField="Challanno" HeaderText="Challan No" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderno" HeaderText="Order No" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                         <asp:BoundField DataField="QTN_NO" HeaderText="QTN NO" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Customername" HeaderText="Customer Name" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       <%-- <asp:BoundField DataField="Email_id" HeaderText="Email Id"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="mobile" HeaderText="Mobile No"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="branchnm" HeaderText="Branch name"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Modelnm" HeaderText="Model Name"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Modelno" HeaderText="Model No"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Date" HeaderText="Date">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
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

    
    <div style="display:none;">               
<table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
     <asp:Panel runat="server" ID="Panel1">
         <asp:Label ID="lblCaption" runat="server" Text="Quotation Show" Style="font-weight: bold;
                    color:black;"></asp:Label>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Quotationid" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField ControlStyle-CssClass="" HeaderText="SN">
                            <ItemTemplate>
                          
                                <%#GridView1.Rows.Count + 1%>
                               
                            </ItemTemplate>
                            <ControlStyle />
                            <FooterStyle />
                            <HeaderStyle CssClass="" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <ItemStyle CssClass="" HorizontalAlign="Left" />
                        </asp:TemplateField> 
                        <asp:BoundField DataField="Challanno" HeaderText="ChallanNo" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderno" HeaderText="OrderNo" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                         <asp:BoundField DataField="QTN_NO" HeaderText="QTNNO" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Customername" HeaderText="Customer" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="emailid" HeaderText="EmailId"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mobile" HeaderText="Mobile"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="branchnm" HeaderText="Branch"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Modelnm" HeaderText="Model"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Modelno" HeaderText="ModelNo"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="companyname" HeaderText="Company"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Categorynm" HeaderText="Category"  >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Address" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="engine_no" HeaderText="engineno" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                         <asp:BoundField DataField="Chassis_no" HeaderText="Chassisno" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Variant_no" HeaderText="Variantno" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                                               
                        <asp:BoundField DataField="Hypothecated_with" HeaderText="Hypothecated"  >              
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="Date" HeaderText="Date">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
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
           </div>
</asp:Content>

