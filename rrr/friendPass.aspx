<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="friendPass.aspx.cs" Inherits="friendPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="friendList" runat="server" OnItemCommand="friendList_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>
                        好友申请
                    </th>
                    <th>
                        用户名
                    </th>
                    <th>
                        邮箱
                    </th>
                    <th>
                        操作
                    </th>
                    <th>
                       操作
                    </th>
                </tr>
                  </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                     <asp:Image ID="userHead" runat="server" ImageUrl='<%# Eval("picture") %>' Width="50px" Height="50px" />
                </td>
                <td>
                    <%# Eval("userName") %>
                </td>
                <td>
                       <%# Eval("userMail") %>
                </td>
                <td>
                    <asp:LinkButton ID="agree" runat="server" Text="同意" CommandName="agree" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="disagree" runat="server" Text="拒绝" CommandName="disagree" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
              </table>

        </FooterTemplate>
    </asp:Repeater>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" Height="25px" Width="100px" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" Height="25px" Width="100px"/>
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" Height="25px" style="margin-top: 0px" Width="100px" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" Height="25px" Width="100px"/>
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="25px" Height="15px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" Height="25px" Width="100px"/>
</asp:Content>

