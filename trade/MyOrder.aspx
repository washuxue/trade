<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyOrder.aspx.cs" Inherits="trade.MyOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 40px;
            width: 100px;
        }
        .auto-style3 {
            height: 120px;
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:994px;height:777px">
        <tr>
            <td style="width:994px;height:50px">&nbsp;</td>
         
        </tr>
               <tr>
            <td>
                <asp:DataList ID="DataList2" runat="server" OnItemDataBound="DataList2_ItemDataBound" RepeatColumns="1" OnItemCommand="DataList2_ItemCommand">
                    <ItemTemplate>
                        <table style="border: thin solid #CCCCCC; width:800px; height:200px">
                            <tr>
                                <td colspan="3" style="width:800px;height:40px; background-color: #CCCCCC;">
                                    下单时间：<asp:Label ID="generatetime" runat="server" Text='<%# Eval("GenerateTime") %>'></asp:Label>
                                    &nbsp; 订单号：<asp:Label ID="orderid" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                                </td>
         
                            </tr>
                                     <tr>
                                <td style="width:500px;height:160px">
                                    <asp:DataList ID="DataList3" runat="server">
                                        <ItemTemplate>
                                            <table style="border: thin solid #CCCCCC; width:500px; height:160px">
                                                <tr>
                                                    <td rowspan="2" style="width:100px;height:160px">
                                                        <asp:Image ID="photo" runat="server" ImageUrl='<%# Eval("Photo") %>' Width="70px" Height="120px"/>
                                                    </td>
                                        <td style="width:200px;height:40px">
                                            商品名称：<asp:Label ID="goodname" runat="server" Text='<%# Eval("GoodName") %>'></asp:Label>
                                                    </td>
                                                    <td style="width:100px;height:40px">
                                                        数量：<asp:Label ID="goodnum" runat="server" Text='<%# Eval("GoodNum") %>'></asp:Label>
                                                    </td>
                                                    <td class="auto-style2">
                                                        价格：<asp:Label ID="currentprice" runat="server" Text='<%# Eval("CurrentPrice") %>'></asp:Label>￥
                                                    </td>
                                                </tr>
                                                                                                <tr>
                                                 
                                        <td style="width:200px;height:120px;vertical-align:top" >
                                            品牌：<asp:Label ID="brand" runat="server" Text='<%# Eval("Brand") %>'></asp:Label>
                                                                                                    </td>
                                                    <td style="width:100px;height:120px">&nbsp;</td>
                                                    <td class="auto-style3">&nbsp;</td>
                                                </tr>
                             
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                         </td>
                                <td style="border: thin solid #C0C0C0; width:150px; height:160px;vertical-align:top">
                                    订单总金额：<asp:Label ID="totalprice" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>￥
                                         <br />
                                    <br />
                                    状态：<asp:Label ID="Label1" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                                         </td>
                                <td align="center" style="border: thin solid #C0C0C0; width:150px; height:160px;vertical-align:middle">
                                    <asp:Button ID="Button1" runat="server" Text="确认收货" CommandName="receive" CommandArgument='<%# Eval("OrderID")%>' Visible="False"/>
                                         <asp:Button ID="Button2" runat="server" Text="付款" Visible="False" CommandName="pay" CommandArgument='<%# Eval("OrderID")%>' />
                                         </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <p align =center >
                <asp:Label ID="labCP" runat="server" Text="当前页码为："></asp:Label>
                                [
                                <asp:Label ID="labPage" runat="server" Text="1"></asp:Label>
                                &nbsp;]
                                <asp:Label ID="labTP" runat="server" Text="总页码为："></asp:Label>
                                [
                                <asp:Label ID="labBackPage" runat="server"></asp:Label>
                                &nbsp;]<asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton> &nbsp; &nbsp; </p>
                   </td>
         
        </tr>       <tr>
            <td>&nbsp;</td>
         
        </tr>
    </table>
</asp:Content>
