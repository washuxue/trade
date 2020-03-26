<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="trade.CreateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 994px; height: 300px">
        <tr>
            <td style="height: 30px">
                <asp:Label ID="Label1" runat="server" Text="确认订单信息"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="height: 30px">&nbsp;</td>

        </tr>
        <tr>
            <td align="center" style="height: 30px">
                总价：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                ￥&nbsp; 商品数量：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>

        <tr>
            <td align="center" style="vertical-align: top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" PageSize="100" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NO" HeaderText="序号" ReadOnly="True" />
                        <asp:BoundField DataField="GoodID" HeaderText="商品ID" ReadOnly="True" />
                        <asp:BoundField DataField="GoodName" HeaderText="商品名称" ReadOnly="True" />
                        <asp:BoundField DataField="GoodNum" HeaderText="商品数量" ReadOnly="True" />
                        <asp:BoundField DataField="GoodPrice" HeaderText="单价" ReadOnly="True" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="总价" ReadOnly="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>

        </tr>
    </table>
    <table style="width: 994px; height: 400px">
        <tr>
            <td align="right" style="width:400px;height: 30px">
                <asp:Label ID="Label4" runat="server" Text="配送费："></asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="23px" Width="300px">
                    <asp:ListItem>请选择配送方式</asp:ListItem>
                    <asp:ListItem Value="5">送货上门（5元）</asp:ListItem>
                    <asp:ListItem Value="0">自取免费</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:400px;height: 30px">
                <asp:Label ID="Label5" runat="server" Text="收货人姓名："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Height="23px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:400px;height: 30px">
                <asp:Label ID="Label6" runat="server" Text="电话号码："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Height="23px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:400px;height: 30px">
                <asp:Label ID="Label7" runat="server" Text="邮箱："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Height="23px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:400px;height: 70px">
                <asp:Label ID="Label8" runat="server" Text="收货人地址："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:400px;height: 100px">
                <asp:Label ID="Label9" runat="server" Text="备注："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交订单" />
            </td>
        </tr>
    </table>
</asp:Content>
