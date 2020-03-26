<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageOrderDetail.aspx.cs" Inherits="trade.Manage.ManageOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #000000; width: 800px; height: 200px">
        <tr>
            <td style="width:800px;height:25px; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000;">订单编号：<asp:Label ID="id" runat="server" Text="Label"></asp:Label>
                &nbsp; 下单时间：<asp:Label ID="generatetime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="GoodID" HeaderText="商品ID" />
                        <asp:BoundField DataField="GoodName" HeaderText="商品名称" />
                        <asp:BoundField DataField="ClassName" HeaderText="类别" />
                        <asp:BoundField DataField="Brand" HeaderText="品牌" />
                        <asp:BoundField DataField="GoodNum" HeaderText="数量" />
                        <asp:TemplateField HeaderText="单价">

                            <ItemTemplate>
                                <%# Eval("GoodPrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="总价">
                            <ItemTemplate>
                                <%# Eval("TotalPrice") %>￥
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
     
    </table>
     <table><tr><td style="width: 800px; height: 25px"></td></tr></table>
    <table style="border: thin solid #000000; width: 800px; height: 75px">
        <tr>
            <td style="width: 300px; height: 25px">订单状态：<asp:Label ID="state" runat="server" Text="Label"></asp:Label>
            </td>
            <td>商品费用：<asp:Label ID="goodprice" runat="server" Text="Label"></asp:Label>
                ￥</td>

        </tr>
        <tr>
            <td style="width: 300px; height: 25px">配送方式：<asp:Label ID="carriageway" runat="server" Text="Label"></asp:Label>
            </td>
            <td>配送费：<asp:Label ID="carriageprice" runat="server" Text="Label"></asp:Label>
                ￥</td>

        </tr>
        <tr>
            <td style="width: 300px; height: 25px"></td>
            <td>总费用：<asp:Label ID="totalprice" runat="server" Text="Label"></asp:Label>
                ￥</td>

        </tr>

    </table>
    <table><tr><td style="width: 800px; height: 25px"></td></tr></table>
    <table style="border: thin solid #000000; width: 800px; height: 125px">

        <tr>
            <td style="width: 800px; height: 25px">收货人姓名：<asp:Label ID="receivername" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="width: 800px; height: 25px">联系电话：<asp:Label ID="receiverphone" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="border-width: thin; border-color: #000000; width: 800px; height: 25px">邮箱：<asp:Label ID="receiveremail" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="border-width: thin; border-color: #000000; width: 800px; height: 25px">地址：<asp:Label ID="receiveraddress" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="border-width: thin; border-color: #000000; width: 800px; height: 25px">备注：<asp:Label ID="remark" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>



    </table>
    <table>
        <tr>
            <td align="center" style="width: 800px; height: 40px">&nbsp;<asp:Button ID="Button1" runat="server" Text="发货" OnClick="Button1_Click" />
            &nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="退款" />
            </td>
        </tr>
    </table>
</asp:Content>
