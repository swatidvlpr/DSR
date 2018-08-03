<%@ Page Language="C#" AutoEventWireup="true" CodFile="Deliveryreport.aspx.cs" Inherits="Deliveryreport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                      <div class="form-body" id="form">
                          <div class="col-md-4 form-group">
                              Log
                          </div>
                           <div class="col-md-4 form-group">
                               <h3>Delivery Challan</h3>
                          </div>
                           <div class="col-md-4 form-group">
GST No.21AAFCS4922812Y<br />
                               CIN No.U50101OR1998PLC005520
                          </div>
                          <div class="col-md-12 form-group">
                              <h1>SHREE BHARAT MOTORS LTD.</h1>

                          </div>
                          <div class="col-md-8 form-group">
                             Name&nbsp;<asp:Label ID="Label1" runat="server" Text='<%#Eval("Customer_name") %>'></asp:Label>

                          </div>
                          <div class="col-md-8 form-group">
                             Mobile no&nbsp;<asp:Label ID="Label3" runat="server" Text='<%#Eval("Mobile_no") %>'></asp:Label>

                          </div>
                          <div class="col-md-8 form-group">
                             Address&nbsp;<asp:Label ID="Label2" runat="server" Text='<%#Eval("Address") %>'></asp:Label>

                          </div>
                           
                          <div class="col-md-4 form-group">
                              Challan No  &nbsp;<asp:Label ID="Label4" runat="server" Text='<%#Eval("Challlan_no") %>'></asp:Label>

                          </div>
                            <div class="col-md-4 form-group">
                              Order No &nbsp;<asp:Label ID="Label5" runat="server" Text='<%#Eval("Order_no") %>'></asp:Label>

                          </div>
                           <div class="col-md-4 form-group">
                              Date &nbsp;<asp:Label ID="Label6" runat="server" Text='<%#Eval("Date") %>'></asp:Label>

                          </div>

                           <div class="col-md-12 form-group">
                               Hirepurchase lease hypothecated with M/s&nbsp;<asp:Label ID="Label7" runat="server" Text='<%#Eval("Hirepurchase_lease_hypothecated_with_ms") %>'></asp:Label>
                           </div>
                           <div class="col-md-12 form-group">
                               <asp:GridView ID="GridView2" runat="server">
                                   <Columns>
                                        <asp:TemplateField ControlStyle-CssClass="" HeaderText="SN">
                            <ItemTemplate>
                          
                                <%#Container.DataItemIndex+1 %>
                               
                            </ItemTemplate>
                            <ControlStyle />
                            <FooterStyle />
                            <HeaderStyle CssClass="" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <ItemStyle CssClass="" HorizontalAlign="Left" />
                        </asp:TemplateField> 
                           <asp:BoundField DataField="Qty" HeaderText="Qty" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Description" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                                       <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("Amount","{0:n}")%>'></asp:Label>
                            
                            </ItemTemplate>
                            <FooterTemplate>
                                 <asp:Label ID="Label14" runat="server" Text=""></asp:Label>

                            </FooterTemplate>
                                           </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>

                           </div>
                      </div>

                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>


        </asp:GridView>

    

    </div>
    </form>
</body>
</html>
