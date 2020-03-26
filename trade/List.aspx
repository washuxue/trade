<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="trade.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:994px;height:777px">
        <tr>
            <td style="height:50px">&nbsp;</td>
 
        </tr>
        <tr>
            <td align=center style="vertical-align:top">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <table style="width:220px;height:150px">
                            <tr>
                                <td rowspan="4" style="width:80px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Photo") %>' Height="120px" Width="70px" />
                                </td>
                                <td  style="width:140px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("GoodName")%>' CommandName="DetailSee" CommandArgument='<%# Eval("GoodID")%>'>LinkButton</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>原价： 
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("OriginalPrice") %>'></asp:Label>￥
                                </td>
                            </tr>
                            <tr>
                                <td>现价： 
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("CurrentPrice") %>'></asp:Label>￥
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buy.jpg" CommandName="buy" CommandArgument='<%# Eval("GoodID")%>' />
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
   
        </tr>

    </table>
</asp:Content>
