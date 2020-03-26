<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="trade.Manage.ManageClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
        <tr>
            <td align="left" style="width:200px;height:25px">类别添加：</td>
            <td>&nbsp;</td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height:25px">类别名：</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height:25px">图像：</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                    </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height:100px">&nbsp;</td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" />
                    </td>
        </tr>
                <tr>
            <td align="right" style="width:200px;height:25px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" />
                    </td>
        </tr>
               <tr>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
