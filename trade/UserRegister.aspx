<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="trade.UserRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="width: 994px; height: 777px">
    <tr>
        <td style="width: 200px; height: 25px">注册会员：</td>
        <td>&nbsp;</td>
    </tr>
            <tr>
        <td align="right" style="width: 200px; height: 25px">会员名称：</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
    </tr>
            <tr>
        <td align="right" style="width: 200px; height: 25px">密码：</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
    </tr>
            <tr>
        <td align="right" style="width: 200px; height: 25px">真实姓名：</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
    </tr>
            <tr>
        <td align="right" style="width: 200px; height: 25px">性别:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
                </td>
    </tr>
                    <tr>
        <td align="right" style="width: 200px; height: 25px">电话:</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </td>
    </tr>
                    <tr>
        <td align="right" style="width: 200px; height: 25px">邮箱:</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </td>
    </tr>
                    <tr>
        <td align="right" style="width: 200px; height: 25px">地址:</td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </td>
    </tr>
            <tr>
        <td style="width: 200px; height: 25px">&nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="保存" />
                </td>
    </tr>
                    <tr>
        <td >&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
