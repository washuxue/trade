<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="trade.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 994px; height: 777px">
        <tr>
            <td align="center" valign="middle" style="height: 57px">
                <asp:Label ID="Label5" runat="server" Text="搜索商品："></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                &nbsp;<select id="Select1" name="D1" runat="server" style="width: 100px">
                    <option>商品名称</option>
                    <option>商品条码</option>
                    <option>商品价格</option>
                </select>
                <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
            </td>

        </tr>
        <tr>
            <td style="height: 30px; border: 1px solid #00FF00; background-color: #6699FF;">热销商品</td>

        </tr>
        <tr>
            <td align="center"  style="height: 330px;vertical-align:middle">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <table style="width:220px;height:150px">
                            <tr>
                                <td rowspan="4" style="width:80px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Photo") %>' Height="120px" Width="70px" />
                                </td>
                                <td style="width:140px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("GoodName")%>' CommandName="DetailSee" CommandArgument='<%# Eval("GoodID")%>'>LinkButton</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>原价： 
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("OriginalPrice") %>'></asp:Label>￥
                                </td>
                            </tr>
                            <tr>
                                <td>现价： 
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("CurrentPrice") %>'></asp:Label>￥
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buy.jpg" CommandName="buy" CommandArgument='<%# Eval("GoodID")%>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>

        </tr>
        <tr>
            <td style="height: 30px; border: 1px solid #000000; background-color: #FFFFCC;">最新商品</td>

        </tr>
        <tr>
            <td align="center" style="height: 330px;vertical-align:middle">
                <asp:DataList ID="DataList2" runat="server" RepeatColumns="4" OnItemCommand="DataList2_ItemCommand">
                    <ItemTemplate>
                        <table style="width:220px;height:150px">
                            <tr>
                                <td rowspan="4" style="width:80px">
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Photo") %>' Height="120px" Width="70px" />
                                </td>
                                <td style="width:140px">
                                    <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("GoodName")%>' CommandName="DetailSee" CommandArgument='<%# Eval("GoodID")%>'>LinkButton</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>原价： 
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("OriginalPrice") %>'></asp:Label>￥
                                </td>
                            </tr>
                            <tr>
                                <td>现价： 
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("CurrentPrice") %>'></asp:Label>￥
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buy.jpg" CommandName="buy" CommandArgument='<%# Eval("GoodID")%>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>

        </tr>

    </table>
</asp:Content>
