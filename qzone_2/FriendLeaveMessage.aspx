<%@ Page Title="" Language="C#" MasterPageFile="~/VisitFriend.master" AutoEventWireup="true" CodeFile="FriendLeaveMessage.aspx.cs" Inherits="FriendLeaveMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>好友留言</h2>
    <asp:Button ID="write" runat="server" OnClick="write_Click" Text="写留言" />
    <asp:TextBox ID="message" runat="server" Visible="false"></asp:TextBox>
    <asp:Button ID="submit" runat="server" Text="确定" Visible="false" OnClick="submit_Click" />
    <asp:Repeater ID="LeaveMessage" runat="server" OnItemCommand="LeaveMessage_ItemCommand">
        <ItemTemplate>
          <h3>  <asp:Image ID="friendHead" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("picture") %>' />
            <asp:Label ID="friendName" runat="server" Text='<%# Eval("userName") %>'></asp:Label></h3>
         <h4>   <asp:Label ID="time" Text='<%# Eval("time") %>' runat="server"></asp:Label></h4>
          <h4>  <asp:Label ID="text" Text='<%# Eval("text") %>' runat="server"></asp:Label></h4>
        </ItemTemplate>
    </asp:Repeater>
    <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />
        <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" Height="43px" Width="137px" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" Height="42px" Width="134px"/>
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" Height="46px" style="margin-top: 0px" Width="102px" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" Height="45px" Width="98px"/>
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="38px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" Height="43px" Width="83px"/>
</asp:Content>

