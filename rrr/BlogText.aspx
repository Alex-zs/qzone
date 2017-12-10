<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BlogText.aspx.cs" Inherits="BlogText" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
        <asp:Label ID="title" runat="server" ></asp:Label>
    </h1>
    <h4>
        <asp:Label ID="text" runat="server"></asp:Label>
    </h4>
    <h4>评论</h4>
    <asp:Repeater ID="blogReplies" runat="server" OnItemCommand="blogReplies_ItemCommand">
        <ItemTemplate>
            <asp:Image ID="head" runat="server" ImageUrl='<%# Eval("picture") %>' Width="50px" Height="50px" />
            <asp:Label ID="name" runat="server" Text='<%# Eval("userName") %>'></asp:Label>
          <h5>  <asp:Label ID="time" runat="server" Text='<%# Eval("time") %>'></asp:Label></h5>
            <h4><asp:Label ID="text" runat="server" Text='<%# Eval("text") %>'></asp:Label></h4>

        </ItemTemplate>
    </asp:Repeater>
    <asp:Button ID="comment" runat="server" Text="评论" OnClick="comment_Click" />
    <br />
    <asp:TextBox ID="commentTxt" runat="server" Visible="false" ></asp:TextBox>
    <asp:Button ID="submit" runat="server" Text="发表" Visible="false" OnClick="submit_Click" />
    <asp:Button ID="back" Text="返回" runat="server" OnClick="back_Click" />
</asp:Content>

