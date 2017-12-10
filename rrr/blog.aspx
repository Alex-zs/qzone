<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="blog.aspx.cs" Inherits="blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="writeblog" runat="server" Text="写日志" OnClick="writeblog_Click" />
    <br />
    <asp:Repeater ID="blogList" runat="server" OnItemCommand="blogList_ItemCommand">
      <HeaderTemplate>
          <table>
      </HeaderTemplate>
        <ItemTemplate>
        
        <tr>    <asp:LinkButton ID="title" runat="server" Text='<%# Eval("title") %>' PostBackUrl='<%#"BlogText.aspx?id="+Eval("JournalID")  %>' CommandName="title" CommandArgument='<%# Eval("JournalID") %>'></asp:LinkButton>
            <%# Eval("time") %>
      <asp:LinkButton ID="delete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("JournalID") %>'></asp:LinkButton>
            </tr>
          <br />
        </ItemTemplate>
      <FooterTemplate>
          </table>
      </FooterTemplate>
    </asp:Repeater>
      <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" Height="43px" Width="137px" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" Height="42px" Width="134px"/>
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" Height="46px" style="margin-top: 0px" Width="102px" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" Height="45px" Width="98px"/>
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="38px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" Height="43px" Width="83px"/>
</asp:Content>

