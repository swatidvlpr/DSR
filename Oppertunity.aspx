<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Oppertunity.aspx.cs" Inherits="DSR_Oppertunity" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="page-wrapper">
<div class="main-page">
<div id="form1" class="forms validation">
<div class="form-grids row widget-shadow" data-example-id="basic-forms">
    <div class="form-title">
	<h4>Create Opportunity</h4>
	</div>
    <div class="form-body" id="form">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


          
<div class="col-md-6 form-group">
    <label >Sales Man Name</label>
    <asp:DropDownList ID="ddlsales" runat="server" CssClass="form-control"></asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
      ControlToValidate="ddlsales" ErrorMessage="Select sales man name" ValidationGroup="a"></asp:RequiredFieldValidator>
    
</div>
        <div class="col-md-6 form-group">
    <label >Customer Name</label>
    <asp:DropDownList ID="ddlcustomer" runat="server" CssClass="form-control" AutoPostBack="True" OnDataBound="ddlcustomer_DataBound" OnSelectedIndexChanged="ddlcustomer_SelectedIndexChanged"></asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
      ControlToValidate="ddlcustomer" ErrorMessage="Select customer name" ValidationGroup="a"></asp:RequiredFieldValidator>
</div>
        
         <div class="col-md-6 form-group">
            <label >Company Name </label> 
           <%-- <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>--%>
             <asp:DropDownList ID="ddlcompany" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                 
              </asp:DropDownList>           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  
                    ControlToValidate="ddlcompany" ErrorMessage="Enter company name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-6 form-group">
            <label >Category Name </label> 
           <%-- <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>--%>
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
            <label >Color </label> 
            <asp:TextBox ID="txtcolor" runat="server" CssClass="form-control"></asp:TextBox>
                       
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  
                    ControlToValidate="txtcolor" ErrorMessage="Enter color" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Quantity </label> 
            <asp:TextBox ID="txtquantity" runat="server" CssClass="form-control"></asp:TextBox>
                       
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  
                    ControlToValidate="txtquantity" ErrorMessage="Enter quantity" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>

<div class="col-md-6 form-group">
    <label >Purchase Plan</label>
    <asp:DropDownList ID="ddlpurchageplan" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlpurchageplan" ErrorMessage="Select purchase plan" ValidationGroup="a"></asp:RequiredFieldValidator>
</div>
         <div class="col-md-6 form-group">
            <label >Enquiry Source</label>
             <asp:DropDownList ID="ddlenquirysource" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlenquirysource" ErrorMessage="Select enquiry source" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 form-group">
            <label >Financier</label>
            <asp:DropDownList ID="ddlfinancier" runat="server" CssClass="form-control"></asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlfinancier" ErrorMessage="Select financier" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
       
         <div class="col-md-6 form-group">
            <label >Date</label> 
            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtdate" PopupPosition="TopRight">
            </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="Enter date" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
      <div class="col-md-6 form-group">
            <label >Branch Name</label>
             <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="ddlbranch" ErrorMessage="Select branch name" ValidationGroup="a"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-12 form-group">
            <asp:Button ID="Button1" runat="server" Text="SUBMIT" onclick="Button1_Click" Class=" btn btn-warning " ValidationGroup="a" />
              &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" OnClick="Button2_Click" />
        &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
        <div class="col-md-12 grid-margin">
                 <div class="table-responsive" >
<table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Opportunity_id" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    onrowdeleting="GridView1_RowDeleting" Width="100%" >
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
                        <asp:BoundField DataField="Name" HeaderText="Salesman" />
                        <asp:BoundField DataField="Customer_name" HeaderText="Customer" />
                        <asp:BoundField DataField="companyname" HeaderText="Company" />
                        <asp:BoundField DataField="Categorynm" HeaderText="Category" />                        
                        <asp:BoundField DataField="Modelnm" HeaderText="Model" />  
                         <asp:BoundField DataField="Modelno" HeaderText="Model No" />
                         <asp:BoundField DataField="Color" HeaderText="Color" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <%--<asp:BoundField DataField="Purchase_plan" HeaderText="Purchase Plan" />  
                        <asp:BoundField DataField="Enquiry_source" HeaderText="Enquiry Source" />  --%>
                         <asp:BoundField DataField="Finacier" HeaderText="Finacier" />
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

