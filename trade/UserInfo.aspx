<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="trade.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:994px;height:777px">
        <tr>
            <td style="width:200px;height:25px">账号信息：</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td align="right" style="height:25px">用户名：</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
             </td>
        </tr>
                 <tr>
            <td align="right" style="height:25px">密码：</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
        </tr>
                      <tr>
            <td align="right" style="height:25px">确认密码：</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
        </tr>
                 <tr>
            <td align="right" style="height:25px">姓名：</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                     </td>
        </tr>
                 <tr>
            <td align="right" style="height:25px">性别:</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                     </td>
        </tr>
                 <tr>
            <td align="right" style="height:25px">电话：</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                     </td>
        </tr>
                         <tr>
            <td align="right" style="height:25px">邮箱：</td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                             </td>
        </tr>
                         <tr>
            <td align="right" style="height:50px">地址：</td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server" TextMode="MultiLine"></asp:TextBox>
                             </td>
        </tr>
                 <tr>
            <td>&nbsp;</td>
            <td style="height:25px">
                <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" />
                     </td>
        </tr>
        <tr><td></td></tr>
    </table>
</asp:Content>
