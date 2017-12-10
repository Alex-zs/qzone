<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertFriend.aspx.cs" Inherits="InsertFriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
            添加好友：<asp:DropDownList ID="search" runat="server">
                <asp:ListItem Selected="True">用户名</asp:ListItem>
                <asp:ListItem>邮箱</asp:ListItem>
               </asp:DropDownList>
            <asp:TextBox ID="btn_search" runat="server"></asp:TextBox>
            <asp:Button ID="submit" runat="server" Text="查找" OnClick="submit_Click"/>
        </div>
    <br />
     <asp:Repeater ID="friends" runat="server" OnItemCommand="friends_ItemCommand">
            <HeaderTemplate>
               <table>
                   <tr>               
                    <th></th>
                   <th>用户名</th>
                   <th>邮箱</th>
                       <th>操作</th>
                       </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                <td><asp:Image ID="userHeadPic" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("picture") %>' /></td>
                <td><%# Eval("userName") %></td>
                <td><%# Eval("userMail") %></td>
                    <td><asp:LinkButton ID="insert" runat="server" Text="添加" CommandName="insertFriend" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
               </table>

            </FooterTemplate>
        </asp:Repeater>
</asp:Content>

