<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="trade.Manage.AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
        <tr>
            <td style="width: 200px; height: 25px">添加管理员：</td>
            <td>&nbsp;</td>

        </tr>
               <tr>
            <td align="right" style="width: 200px; height: 25px">管理员名称：</td>
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
            <td align="right" style="width: 200px; height: 25px">邮箱：</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                   </td>

        </tr>
                <tr>
            <td style="width: 200px; height: 25px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="保存" />
                    </td>

        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>

        </tr>

    </table>
</asp:Content>
