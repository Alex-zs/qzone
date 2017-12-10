<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Permission.aspx.cs" Inherits="Permission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4>空间访问设置：谁能访问我的空间</h4>
   
    <h5><asp:DropDownList ID="visitPermission" runat="server" >
        <asp:ListItem Selected="True">所有人</asp:ListItem>
        <asp:ListItem>仅好友</asp:ListItem>
        <asp:ListItem>仅自己</asp:ListItem>
        </asp:DropDownList></h5>
     <h5>目前设置：<asp:Label ID="nowQzonePermission" runat="server" ></asp:Label></h5>
    <h4>
       说说设置：谁能看我的说说
    </h4>
   
    <h5>
         <asp:DropDownList ID="talkPermission" runat="server" >
          <asp:ListItem Selected="True">所有人</asp:ListItem>
        <asp:ListItem>仅好友</asp:ListItem>
        <asp:ListItem>仅自己</asp:ListItem>
        </asp:DropDownList>
    </h5>
     <h5>
       目前设置： <asp:Label ID="nowTalkPermission" runat="server"></asp:Label>
    </h5>
    <asp:Button ID="submit" runat="server" Text="确定" OnClick="submit_Click" />
</asp:Content>

