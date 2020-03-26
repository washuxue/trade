<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="trade.Manage.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table align="center" style="width: 1000px; height: 700px; background-image: url('../images/登录界面.jpg');">
            <tr>
                <td style="width: 1000px; height: 200px"></td>
            </tr>
            <tr>
                <td align="center" style="width: 1000px; height: 300px">
                    <table style="width: 400px; height: 200px; background-color: #FFFFFF;">
                        <tr>
                            <td align="center" style="width: 400px; height: 50px; background-color: #F9F9F9; font-weight: bolder;">欢迎登录后台管理系统</td>

                        </tr>
                        <tr>
                            <td align="center" style="width: 400px; height: 50px; background-color: #F9F9F9;">用户名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td align="center" style="width: 400px; height: 50px; background-color: #F9F9F9;">密码：　<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                            </td>

                        </tr>
                                                <tr>
                            <td align="center" style="width: 400px; height: 50px; background-color: #F9F9F9;vertical-align:middle;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/登录.jpg" OnClick="ImageButton1_Click"  Width="70px"/>
                                                    </td>

                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td style="width: 1000px; height: 200px"></td>
            </tr>
        </table>

    </form>
</body>
</html>
