<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageGood.aspx.cs" Inherits="trade.Manage.ManageGood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
        <tr>
            <td  style="width: 800px; height: 25px">商品管理：</td>

        </tr>
                <tr>
            <td align="center" style="width: 800px; height: 25px">请输入关键字：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>名称</asp:ListItem>
                    <asp:ListItem>类别</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
                    </td>

        </tr>
                <tr>
            <td align="center" style="width: 800px; height: 400px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="GoodID" HeaderText="商品ID" />
                        <asp:BoundField DataField="GoodName" HeaderText="商品名称" />
                        <asp:BoundField DataField="ClassID" HeaderText="所属类别" />
                        <asp:TemplateField HeaderText="原价">
                            <ItemTemplate>
                                <%# Eval("OriginalPrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="现价">
                            <ItemTemplate>
                                <%# Eval("CurrentPrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument='<%# Eval("GoodID") %>' CommandName="modify">修改</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server"  CommandArgument='<%# Eval("GoodID") %>' CommandName="del">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    </td>

        </tr>
                <tr style="width: 800px; height: 25px">
            <td>&nbsp;</td>

        </tr>
                <tr >
            <td>&nbsp;</td>

        </tr>
 
    </table>
</asp:Content>
