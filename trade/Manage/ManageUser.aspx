<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="trade.Manage.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
    <tr>
        <td style="width: 800px; height: 25px">&nbsp;</td>
       
    </tr>
            <tr>
        <td align="center" style="width: 800px; height: 300px">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="会员ID" />
                    <asp:BoundField DataField="UserName" HeaderText="会员名称" />
                    <asp:BoundField DataField="RealName" HeaderText="真实姓名" />
                    <asp:BoundField DataField="Sex" HeaderText="性别" />
                    <asp:BoundField DataField="Phone" HeaderText="电话号码" />
                    <asp:BoundField DataField="Email" HeaderText="邮箱" />
                    <asp:BoundField DataField="Address" HeaderText="地址" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="del">删除</asp:LinkButton>
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
