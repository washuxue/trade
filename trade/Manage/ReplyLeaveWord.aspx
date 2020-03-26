<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ReplyLeaveWord.aspx.cs" Inherits="trade.Manage.ReplyLeaveWord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:800px;height:600px">
        <tr>
            <td style="height:25px">回复留言：</td>
    
        </tr>
                <tr><td style="width:100px;"></td>
            <td style="height:25px">留言主题：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
    
        </tr>
                <tr><td style="width:100px;"></td>
            <td style="height:50px">留言内容：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
    
        </tr>
                     <tr><td style="width:100px;"></td>
            <td style="height:25px">回复：</td>
    
        </tr>
                <tr><td style="width:100px;"></td>
            <td style="height:100px;vertical-align:middle;"><asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="400px" Height="80px"></asp:TextBox>
                    </td>
    
        </tr>
                <tr><td style="width:100px;"></td>
            <td style="height:25px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                    </td>
    
        </tr>
                <tr><td style="width:100px;"></td>
            <td style="height:25px"></td>
    
        </tr>
             <tr><td style="width:100px;"></td>
            <td>&nbsp;</td>
    
        </tr>
  
    </table>
</asp:Content>
