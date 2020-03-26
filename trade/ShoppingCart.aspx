<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="trade.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:994px;height:777px">
        <tr>
            <td style="height:30px">&nbsp;</td>

        </tr>
                <tr>
            <td style="height:30px">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>

        </tr>
                        <tr>
            <td align="center" style="height:30px">
                购物车总计：<asp:Label ID="Label2" runat="server" Text="0.00"></asp:Label>￥
                            </td>

        </tr>
        <tr>
            <td align="center" style="height:260px;vertical-align:top" >
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="No" HeaderText="序号" ReadOnly="True" />
                        <asp:BoundField DataField="GoodID" HeaderText="商品编号" ReadOnly="True" />
                        <asp:BoundField DataField="GoodName" HeaderText="商品名称" ReadOnly="True" />
                        <asp:TemplateField HeaderText="数量">
                            <ItemTemplate>
                                <asp:TextBox ID="GoodNum" runat="server" Width="50px" Text='<%# Eval("GoodNum") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="GoodNum" ErrorMessage="❌" ValidationExpression="^\+?[1-9][0-9]*$"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="单价">
                            <ItemTemplate>
                                <%# Eval("GoodPrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="总价">                            <ItemTemplate>
                                <%# Eval("TotalPrice") %>￥
                            </ItemTemplate></asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("GoodID") %>' OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <p  >

                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">更新购物车</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">清空购物车</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">继续购物</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">结算</asp:LinkButton>

                </p>
            </td>
    
        </tr>
                <tr>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td>&nbsp;</td>

        </tr>
    </table>
</asp:Content>
