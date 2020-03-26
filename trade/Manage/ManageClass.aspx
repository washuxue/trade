<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageClass.aspx.cs" Inherits="trade.Manage.ManageClass1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
        <tr>
            <td style="width: 800px; height: 25px">类别管理：</td>
        </tr>
         <tr>
            <td align="center" style="width: 800px; height: 300px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="ClassID" HeaderText="类别ID" />
                        <asp:BoundField DataField="ClassName" HeaderText="类别名称" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ClassID") %>' CommandName="del">删除</asp:LinkButton>
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
