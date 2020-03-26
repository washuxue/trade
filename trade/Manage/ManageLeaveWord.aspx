<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageLeaveWord.aspx.cs" Inherits="trade.Manage.ManageLeaveWord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:800px;height:600px">
        <tr>
            <td style="width:800px;height:50px">所有留言：</td>
     
        </tr>
        <tr>
            <td align="center" style="vertical-align:top">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <table style="border: thin solid #808080; width:800px; height:150px">
                            <tr>
                                <td style="width:100px;height:25px">
                                    主题：<asp:Label ID="Label1" runat="server" Text='<%# Eval("LeaveTheme") %>' ></asp:Label>
                                </td>
                                <td style="width:225px;height:25px">
                                    留言人：<asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                </td>
                                <td style="width:225px;height:25px">
                                    留言时间：<asp:Label ID="Label3" runat="server" Text='<%# Eval("LeaveTime") %>'></asp:Label>
                                </td>
                                <td style="width:150px;height:25px">
                                    留言IP：<asp:Label ID="Label4" runat="server" Text='<%# Eval("UserIP") %>'></asp:Label>
                                </td>
                                <td rowspan="4" align="center" style="border-width: thin; border-color: #000000; width:100px; height:100px; border-left-style: solid;vertical-align:middle;">
                                    <asp:Button ID="Button1" runat="server" Text="回复" CommandName="reply" CommandArgument='<%# Eval("WordID")%>' />
                                </td>
                            </tr>
                            <tr >
                               
                                <td colspan="4"  style="width:800px;height:25px">
                                    留言内容：<asp:Label ID="Label5" runat="server" Text='<%# Eval("LeaveContent") %>'></asp:Label>
                                </td>
                     
                            </tr>
                            <tr>
                                
                                <td style="width:100px;height:25px">
                                    回复人：<asp:Label ID="Label6" runat="server" Text='<%# Eval("AdminName") %>'></asp:Label>
                                </td>
                                <td style="width:225px;height:25px">
                                    回复时间：<asp:Label ID="Label7" runat="server" Text='<%# Eval("ReplyTime") %>'></asp:Label>
                                </td>
                                <td style="width:225px;height:25px">
                                    回复人IP:<asp:Label ID="Label8" runat="server" Text='<%# Eval("AdminIP") %>'></asp:Label>
                                </td>
                                <td style="width:150px;height:25px"></td>
                                
                            </tr>
                                                        <tr >
                                                            
                                <td colspan="4" style="width:800px;height:25px">
                                    回复内容：<asp:Label ID="Label9" runat="server" Text='<%# Eval("ReplyContent") %>'></asp:Label>
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
        <tr>
            <td>&nbsp;</td>
   
        </tr>
    </table>
</asp:Content>
