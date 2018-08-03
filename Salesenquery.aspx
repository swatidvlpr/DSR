<%@ Page Title="" Language="C#" MasterPageFile="~/DSR/DSR.master" AutoEventWireup="true" CodeFile="Salesenquery.aspx.cs" Inherits="DSR_Salesenquery" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
<div class="main-page">
    <div id="form1" class="forms validation">
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
							<h4>Sales Enquery:</h4>
						</div>
             <div class="form-body" id="form">
                  <div class="col-md-6 form-group">
                     <label >Source of Enquiry:</label>
                      <asp:DropDownList ID="ddlsource" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="Select source name" ControlToValidate="ddlsource" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>
                  <div class="col-md-6 form-group">
                     <label >Model Name:</label>
                      <asp:DropDownList ID="ddlmodelnm" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ErrorMessage="Select model name" ControlToValidate="ddlmodelnm" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>
                  <%--<div class="col-md-6 form-group">
                     <label >Model:</label>
                      <asp:DropDownList ID="ddlmodel" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Select model name" ControlToValidate="ddlmodel" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>--%>
                  <div class="col-md-6 form-group">
                     <label >Modelno :</label> 
                      <asp:TextBox ID="txtModelno" runat="server" CssClass="form-control" OnTextChanged="txthot_TextChanged" AutoPostBack="True">0</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtModelno_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtModelno">
                      </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  
                          ErrorMessage="Enter hot" ControlToValidate="txtModelno" ValidationGroup="a" ></asp:RequiredFieldValidator>
                 </div>
                 <div class="col-md-6 form-group">
                    <label >Warm :</label>                      
                     
                     <asp:TextBox ID="txtwarm" runat="server" CssClass="form-control" OnTextChanged="txtwarm_TextChanged" AutoPostBack="True">0</asp:TextBox>                    
                     <cc1:FilteredTextBoxExtender ID="txtwarm_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtwarm">
                     </cc1:FilteredTextBoxExtender>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter worm" ControlToValidate="txtwarm" ValidationGroup="a" ></asp:RequiredFieldValidator>
   
                 </div>

                   <div class="col-md-6 form-group">
                    <label >Total :</label>                      
                       <asp:TextBox ID="txttotal" runat="server" CssClass="form-control"></asp:TextBox>
                      
                       <cc1:FilteredTextBoxExtender ID="txttotal_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txttotal">
                       </cc1:FilteredTextBoxExtender>
                      
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
                     <asp:Button ID="Button1" runat="server" Text="submit" onclick="Button1_Click" Class=" btn btn-warning " ValidationGroup="a" />
                       &nbsp;<asp:Button ID="Button2" runat="server" Class=" btn btn-info " Text="Reset" OnClick="Button2_Click" />
                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                 </div>
                 <div class="col-md-12 grid-margin">
                 <div class="table-responsive" >
<table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="nextmonthplan_id" onrowdeleting="GridView1_RowDeleting" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Model" HeaderText="Model" />
         <%--<asp:BoundField DataField="Hot" HeaderText="Hot" />--%>
              <asp:TemplateField HeaderText="Hot" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%#Eval("Hot") %>'></asp:Label>
                     </ItemTemplate>
                     <FooterTemplate>
                         <asp:Label ID="lbltotal1" runat="server" Text="" ForeColor="White"></asp:Label>
                     </FooterTemplate>

                            <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                             <HeaderStyle HorizontalAlign="Left" />

                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
             </asp:TemplateField>

                <%--<asp:BoundField DataField="Warm" HeaderText="Warm" />--%>

             <asp:TemplateField HeaderText="Warm" ItemStyle-HorizontalAlign="Right" 
                                    FooterStyle-HorizontalAlign="Left">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%#Eval("Warm") %>'></asp:Label>
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
             <asp:BoundField DataField="date" HeaderText="date" /> 
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
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
       
    </asp:GridView>
   

</table>

                 </div>
                   <div class="col-md-12 form-group">

                   </div>     

             </div>

             </div>

        </div>


    </div>

</div>

    </div>
</asp:Content>

