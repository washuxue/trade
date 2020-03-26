<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageOrderSend.aspx.cs" Inherits="trade.Manage.ManageOrderSend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width: 800px; height: 600px">
        <tr>
            <td style="width: 800px; height: 25px">未发货订单管理</td>
          
        </tr>
  
        <tr>
            <td style="width: 800px; height: 25px">&nbsp;</td>
           
        </tr>
              <tr>
            <td align="center" style="width: 800px; height: 500px;vertical-align:top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="GenerateTime" HeaderText="下单时间" />
                        <asp:BoundField DataField="OrderID" HeaderText="订单ID" />
                        <asp:BoundField DataField="UserID" HeaderText="用户ID" />
                        <asp:TemplateField HeaderText="商品费用">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("GoodPrice") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%# Eval("GoodPrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="配送费用">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CarriagePrice") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%# Eval("CarriagePrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="订单总费用">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%# Eval("TotalPrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ReceiverName" HeaderText="收货人姓名" />
                        <asp:BoundField DataField="State" HeaderText="订单状态" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="manage">管理</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="del">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                  </td>
           
        </tr>
        <tr>
            <td>&nbsp;</td>
       
        </tr>
    </table>
</asp:Content>
