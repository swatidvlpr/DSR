<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Sale_details.aspx.cs" Inherits="DSR_Sale_details" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
<div class="main-page">
<div id="form1" class="forms validation">
<div class="form-grids row widget-shadow" data-example-id="basic-forms">
    <div class="form-title">
	<h4>Sale Details</h4>
	</div>
    <div class="form-body" id="form">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


        
        
         <div class="col-md-6 form-group">
            <label >Company Name </label>           
             <asp:DropDownList ID="ddlcompany" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                 
              </asp:DropDownList>           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  
                    ControlToValidate="ddlcompany" ErrorMessage="Enter company name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-6 form-group">
            <label >Category Name </label>           
             <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnDataBound="ddlCategory_DataBound" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">                 
              </asp:DropDownList>           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  
                    ControlToValidate="ddlCategory" ErrorMessage="Enter category name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
          
          <div class="col-md-6 form-group">
            <label >Model Name </label>          
             <asp:DropDownList ID="ddlmodelnm" runat="server" CssClass="form-control" AutoPostBack="True" OnDataBound="ddlmodelnm_DataBound" OnSelectedIndexChanged="ddlmodelnm_SelectedIndexChanged">                 
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="ddlbranch" ErrorMessage="Select branch name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
                <div class="col-md-6 form-group">
             <label >Customer Name</label>
          <asp:DropDownList ID="ddlcustomer" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
       ControlToValidate="ddlcustomer" ErrorMessage="Select customer name" ValidationGroup="a"></asp:RequiredFieldValidator>
    </div>
                <div class="col-md-6 form-group">
            <label >Financier</label>
            <asp:DropDownList ID="ddlfinancier" runat="server" CssClass="form-control"></asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlfinancier" ErrorMessage="Select financier" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-6 form-group">
            <label >Actual delivery date</label> 
            <asp:TextBox ID="txtdeliverydt" runat="server" CssClass="form-control"></asp:TextBox>
                       
                <cc1:CalendarExtender ID="txtdeliverydt_CalendarExtender" runat="server" Enabled="True" PopupPosition="TopRight" TargetControlID="txtdeliverydt">
             </cc1:CalendarExtender>
                       
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  
                    ControlToValidate="txtdeliverydt" ErrorMessage="Enter actual delivery date" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Sale target</label> 
            <asp:TextBox ID="txtsaletrgt" runat="server" CssClass="form-control">0</asp:TextBox>
                       
                <cc1:FilteredTextBoxExtender ID="txtsaletrgt_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtsaletrgt">
            </cc1:FilteredTextBoxExtender>
                       
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  
                    ControlToValidate="txtsaletrgt" ErrorMessage="Enter sale target" ValidationGroup="a"></asp:RequiredFieldValidator>
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
            <asp:Button ID="Button1" runat="server" Text="SUBMIT" Class=" btn btn-warning " ValidationGroup="a" OnClick="Button1_Click" />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" OnClick="Button2_Click"/>
        &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
        <div class="col-md-12 grid-margin">
                 <div class="table-responsive" >
         <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="sale_id" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"> 
                   
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
                        
                        <asp:BoundField DataField="companyname" HeaderText="Company" />
                        <asp:BoundField DataField="Categorynm" HeaderText="Category" />                        
                        <asp:BoundField DataField="Modelnm" HeaderText="Model" />  
                         <asp:BoundField DataField="Modelno" HeaderText="Modelno" />
                        <asp:BoundField DataField="branchname" HeaderText="Branch" />
                        <asp:BoundField DataField="Customer_name" HeaderText="Customer" />
                        <asp:BoundField DataField="Financiername" HeaderText="Finacier" />
                         <asp:BoundField DataField="Actual_delivery_date" HeaderText="Delivery date" />
                        <asp:BoundField DataField="Sale_target" HeaderText="Sale target" />                       
                        <asp:BoundField DataField="DO_Date" HeaderText="Date" />  
                      
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

