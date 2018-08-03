<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Deliverychallan.aspx.cs" Inherits="DSR_Deliverychallan" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>

        .header_menu_bg 
        {
            background:url(icon/Buttonmenu.JPG);
            padding:10px 24px;
            color:White;
       
        }
        .ali_wid 
        {
            background:#fFf;
            padding:6px 24px;
            color:#333;
       
        }
   
   
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
<div class="main-page">
<div id="form1" class="forms validation">
<div class="form-grids row widget-shadow" data-example-id="basic-forms">
    <div class="form-title">
	<h4>Delivery Challan</h4>
	</div>
    <div class="form-body" id="form">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


           

  <div class="col-md-6 form-group">
    <label >Customer Name</label>
    <asp:DropDownList ID="ddlcustomer" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlcustomer_SelectedIndexChanged"></asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
      ControlToValidate="ddlcustomer" ErrorMessage="Select customer name" ValidationGroup="a"></asp:RequiredFieldValidator>
</div>
   <div class="col-md-6 form-group">
    <label >Email Id</label>
              <asp:TextBox ID="txtemailid" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
      ControlToValidate="txtemailid" ErrorMessage="Enter emailid " ValidationGroup="a"></asp:RequiredFieldValidator>
</div>
 
<div class="col-md-6 form-group">
    <label >Mobile No</label>
              <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
      ControlToValidate="txtmobile" ErrorMessage="Enter customer name" ValidationGroup="a"></asp:RequiredFieldValidator>
</div>
  <div class="col-md-6 form-group">
    <label >Address</label>
              <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
      ControlToValidate="txtaddress" ErrorMessage="Enter address" ValidationGroup="a"></asp:RequiredFieldValidator>
</div>
                <div class="col-md-6 form-group">
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
           <%-- <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>--%>
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
        </div>

         <div class="col-md-6 form-group">
            <label >Branch Name</label>
             <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="ddlbranch" ErrorMessage="Select branch name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-6 form-group">
            <label >Challan No </label> 
            <asp:TextBox ID="txtChallano" runat="server" CssClass="form-control"></asp:TextBox>                    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  
                    ControlToValidate="txtChallano" ErrorMessage="Enter challan no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Order No </label> 
            <asp:TextBox ID="txtOrderno" runat="server" CssClass="form-control"></asp:TextBox>                    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  
                    ControlToValidate="txtOrderno" ErrorMessage="Enter order no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         
          
         <div class="col-md-6 form-group">
            <label >Hire Purchase/Lease/Hypothecated</label> 
           <%-- <asp:TextBox ID="txthire_purchase" runat="server" CssClass="form-control"></asp:TextBox>--%>
             <asp:DropDownList ID="ddlhire_purchase" runat="server" CssClass="form-control"></asp:DropDownList>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="ddlhire_purchase" ErrorMessage="Enter hire Hurchase/Lease/Hypothecated" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Engine No</label> 
            <asp:TextBox ID="txtengineno" runat="server" CssClass="form-control"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtengineno" ErrorMessage="Enter engine no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Chassis No</label> 
            <asp:TextBox ID="txtchassisno" runat="server" CssClass="form-control"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="txtchassisno" ErrorMessage="Enter chassis no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-6 form-group">
            <label >Ingnition Key No</label> 
            <asp:TextBox ID="txtIngnitionkeyno" runat="server" CssClass="form-control"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                    ControlToValidate="txtIngnitionkeyno" ErrorMessage="Enter ingnition key no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
          <div class="col-md-6 form-group">
            <label >Battery Make</label> 
            <asp:TextBox ID="txtBatterymake" runat="server" CssClass="form-control"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                    ControlToValidate="txtBatterymake" ErrorMessage="Enter battery make no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-6 form-group">
            <label >Battery No</label> 
            <asp:TextBox ID="txtBatteryno" runat="server" CssClass="form-control"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                    ControlToValidate="txtBatteryno" ErrorMessage="Enter battery no" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Tyre make</label> 
            <asp:TextBox ID="txtTyremake" runat="server" CssClass="form-control"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                    ControlToValidate="txtTyremake" ErrorMessage="Enter Tyre make" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>


         
        <div class="col-md-6 form-group">
            <label >Date</label> 
            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtdate" PopupPosition="TopRight">
            </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="Enter date" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-12 form-group">

        </div>
         
       <div class="col-md-2 form-group">
          

       </div>
        <div class="col-md-5 form-group">
          

       </div>
      <div class="col-md-3 form-group">
          

       </div>
         <div class="col-md-2 form-group">
          

       </div>
            <div class="col-md-2 form-group">
                <label > Qty</label>
                <asp:TextBox ID="txtqty" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:HiddenField ID="HiddenField1" runat="server" />
       </div>
        <div class="col-md-5 form-group">
            <label > DESCRIPTION</label>
          <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

       </div>
      <div class="col-md-3 form-group">
          <label > Amount</label>
        <asp:TextBox ID="txtamt" runat="server" CssClass="form-control">00.00</asp:TextBox>

        

       </div>
         <div class="col-md-2 form-group">
              <label > Action</label><br />
             <asp:Button ID="Button3" runat="server" Text="+ ADD" CssClass="btn btn-success" OnClick="Button3_Click" />

       </div>
        <div class="col-md-12 form-group">
            <div class="table-responsive" >
<table id="Table1" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Challan_Desc_id" onrowdatabound="GridView1_RowDataBound" 
                    onrowdeleting="GridView1_RowDeleting" ShowFooter="True" 
                    Width="100%">
                    <Columns>
                        <asp:TemplateField ControlStyle-CssClass="header_menu_bg" HeaderText="SN">
                            <ItemTemplate>
                          
                                <%#GridView1.Rows.Count + 1%>
                               
                            </ItemTemplate>
                            <ControlStyle CssClass="header_menu_bg" />
                            <FooterStyle CssClass="ali_wid" />
                            <HeaderStyle CssClass="header_menu_bg" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <ItemStyle CssClass="ali_wid" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Description" HeaderText="Description" FooterText="Total">
                        <FooterStyle CssClass="ali_wid" />
                        <HeaderStyle CssClass="header_menu_bg" HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" CssClass="ali_wid" />
                        </asp:BoundField>
                      
                        <asp:TemplateField FooterStyle-HorizontalAlign="Right" 
                            ItemStyle-HorizontalAlign="Right">
                            <HeaderTemplate>
                                Amount
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Amount","{0:n}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                            <table>
                            <tr>
                            <td>
                             <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            </td>
                            </tr>
                        
                            </table>

                               
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" CssClass="ali_wid" />
                            <HeaderStyle CssClass="header_menu_bg" HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" CssClass="ali_wid" />
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True">
                        <FooterStyle CssClass="ali_wid" />
                        <HeaderStyle CssClass="header_menu_bg" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ali_wid" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>   

</table></div>
        </div>
        <div class="col-md-12 form-group">
            
            <asp:Button ID="Button1" runat="server" Text="SUBMIT" onclick="Button1_Click" Class=" btn btn-warning " ValidationGroup="a" />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" OnClick="Button2_Click" />
        &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:HiddenField ID="hdn_Mobile_no" runat="server" />
            <asp:HiddenField ID="hdn_Email_id" runat="server" />
            <asp:HiddenField ID="hdn_Address" runat="server" />
        </div>
        <div class="col-md-12 grid-margin">
                 <div class="table-responsive" >
<table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">

               <%--    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Follow_id" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    onrowdeleting="GridView1_RowDeleting" Width="100%" >
                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>                        
                        <asp:BoundField DataField="Customer_name" HeaderText="Customer" />
                        <asp:BoundField DataField="companyname" HeaderText="Company" />
                        <asp:BoundField DataField="Categorynm" HeaderText="Category" />                        
                        <asp:BoundField DataField="Modelnm" HeaderText="Model" />  
                         <asp:BoundField DataField="Modelno" HeaderText="Model No" /> 
                        <asp:BoundField DataField="Followup_type" HeaderText="Followup Type" />  
                        <asp:BoundField DataField="Followup_status" HeaderText="Followup Status" />  
                        <asp:BoundField DataField="date" HeaderText="Date" />  
                        
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
                </asp:GridView>--%>

</table>

                 </div>
                        

             </div>
 </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</div>

</div>

</div>

      </div>
</asp:Content>

