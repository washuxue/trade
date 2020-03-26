<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageAdmin.aspx.cs" Inherits="trade.Manage.ManageAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
    <tr>
        <td style="width: 800px; height: 25px">管理员管理：</td>
      
    </tr>
            <tr>
        <td align="center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="AdminID" HeaderText="管理员ID" />
                    <asp:BoundField DataField="AdminName" HeaderText="管理员名称" />
                    <asp:BoundField DataField="RealName" HeaderText="真实姓名" />
                    <asp:BoundField DataField="Email" HeaderText="邮箱" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("AdminID") %>' CommandName="del">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </td>
      
    </tr>
            <tr>
        <td>&nbsp;</td>
      
    </tr>
</table>
</asp:Content>
