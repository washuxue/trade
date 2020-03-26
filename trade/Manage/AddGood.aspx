<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="AddGood.aspx.cs" Inherits="trade.Manage.AddGood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
        <tr>
            <td align="left" style="width: 200px; height: 25px">商品添加：</td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px">商品名称：</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px">所属类别：</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px">原价：</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px"现价</td>
                现价：<td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px">图像：</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 100px"></td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" />
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px">品牌：</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px">是否推荐：</td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 25px">是否上新：</td>
            <td>
                <asp:CheckBox ID="CheckBox2" runat="server" />
            </td>

        </tr>
        <tr>
            <td align="right" style="width: 200px; height: 100px">介绍：</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Width="200px" Height="80px"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td style="width: 200px; height: 25px"></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" />
            </td>

        </tr>
        <tr><td></td><td></td></tr>
    </table>
</asp:Content>
