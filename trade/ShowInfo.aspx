<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShowInfo.aspx.cs" Inherits="trade.ShowInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:994px;height:777px">
        <tr>
            <td>详细信息</td>

        </tr>
        <tr>
            <td align="right" style="width:200px;height: 30px">
               所属类别 
            </td>
 <td><asp:TextBox ID="classname" runat="server" ReadOnly="True" Height="23px" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width:200px;height: 30px">商品名称</td>
            <td>
                <asp:TextBox ID="goodname" runat="server" ReadOnly="True" Height="23px" Width="300px"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height: 30px" >原价</td>
            <td>
                <asp:TextBox ID="originalprice" runat="server" ReadOnly="True" Height="23px" Width="300px"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height: 30px">现价</td>
            <td>
                <asp:TextBox ID="currentprice" runat="server" ReadOnly="True" Height="23px" Width="300px"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height: 30px">品牌</td>
            <td >
                <asp:TextBox ID="brand" runat="server" ReadOnly="True" Height="23px" Width="300px"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height: 120px">图像</td>
            <td>
                <asp:Image ID="photo" runat="server" Height="100px" Width="100px" />
                    </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height: 30px">是否推荐</td>
            <td>
                <asp:CheckBox ID="checkrecommend" runat="server" Enabled="False" />
                    </td>
        </tr>
                        <tr>
            <td align="right" style="width:200px;height: 30px">是否上新</td>
            <td>
                <asp:CheckBox ID="checknew" runat="server" Enabled="False" />
                    </td>
        </tr>
                        <tr>
            <td align="right" style="width:200px;height: 30px">介绍</td>
            <td>
                <asp:TextBox ID="introduction" runat="server" ReadOnly="True" TextMode="MultiLine" Height="80px" Width="300px"></asp:TextBox>
                            </td>
        </tr>
                        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
