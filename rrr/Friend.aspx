<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Friend.aspx.cs" Inherits="Friend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Button ID="insertFriend" runat="server" Text="添加" OnClick="insertFriend_Click" Width="100px" />
    <asp:Button ID="agreeFriend" runat="server" Text="好友申请" OnClick="agreeFriend_Click" Width="100px" />
    <br />
    <asp:Repeater ID="friendList" runat="server" OnItemCommand="friendList_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>好友</th>
                    <th>用户名</th>
                    <th>邮箱</th>
                    <th>操作</th>
                </tr>
                    </HeaderTemplate>
       <ItemTemplate>
           <tr>
               <td>
                   <asp:Image ID="userHead" runat="server" ImageUrl='<%# Eval("picture") %>' Width="50px" Height="50px" />
               </td>
               <td>
                   <asp:LinkButton ID="userName" runat="server" CommandName="userName" Text='<%# Eval("userName") %>' CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
               </td>
               <td>
                   <%# Eval("userMail") %>
               </td>
               <td>
                   <asp:LinkButton ID="delete" runat="server" Text="删除好友" CommandName="delete" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
               </td>
           </tr>
       </ItemTemplate>
        <FooterTemplate>
            </table>

        </FooterTemplate>
    </asp:Repeater>
     <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />
        <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" Height="25px" Width="100px" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" Height="25px" Width="100px"/>
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" Height="25px" style="margin-top: 0px" Width="100px" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" Height="25px" Width="100px"/>
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="25px" Height="15px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" Height="25px" Width="100px"/>
</asp:Content>

