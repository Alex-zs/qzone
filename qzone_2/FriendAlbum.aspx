<%@ Page Title="" Language="C#" MasterPageFile="~/VisitFriend.master" AutoEventWireup="true" CodeFile="FriendAlbum.aspx.cs" Inherits="FriendAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2>相册</h2>
    <asp:Repeater ID="album" runat="server" OnItemCommand="album_ItemCommand">
        <ItemTemplate>
          <h4>  <asp:Image ID="album_cover" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("picture")%>' /></h4>
         <h4><asp:LinkButton ID="albumName" runat="server" Text='<%# Eval("albumName") %>' PostBackUrl='<%# "FriendPhotoList.aspx?id="+Eval("id") %>'  CommandName="albumName" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
        </h4>
            <h5>相册介绍：<asp:Label ID="intro" runat="server" Text='<%# Eval("introduce") %>'></asp:Label></h5>
            <br /><br /><br />
        </ItemTemplate>
    </asp:Repeater>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" Height="43px" Width="137px" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" Height="42px" Width="134px"/>
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" Height="46px" style="margin-top: 0px" Width="102px" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" Height="45px" Width="98px"/>
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="38px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" Height="43px" Width="83px"/>
  
</asp:Content>

