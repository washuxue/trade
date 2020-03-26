<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageImage.aspx.cs" Inherits="trade.Manage.ManageImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 800px; height: 600px">
        <tr>
            <td align="center" style="width: 800px; height: 30px">
                上传商品图片：<asp:FileUpload ID="FileUpload1" runat="server" />
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传" />
            </td>
      
        </tr>
                <tr>
            <td style="width: 800px; height: 30px">
                <asp:Label ID="point" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                            <tr>
            <td align="center" style="width: 800px; height: 400px;vertical-align:top;">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="6" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <table style="width: 100px; height: 120px">
                            <tr>
                                <td style="width: 100px; height: 80px">
                                    <asp:Image ID="Image1" runat="server" Width="90px" Height="80px" ImageUrl='<%# Eval("ImageUrl")%>'/>
                                </td>
                            
                            </tr>
                                                        <tr>
                                <td style="width: 100px; height: 20px">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ImageName") %>'></asp:Label>
                                                            </td>
                            
                            </tr>
                                                        <tr>
                                <td style="width: 100px; height: 20px">
                                    <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="del" CommandArgument='<%# Eval("ImageID")%>'>删除</asp:LinkButton>
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
      
        </tr>
                <tr>
            <td>&nbsp;</td>
      
        </tr>
    </table>
</asp:Content>
