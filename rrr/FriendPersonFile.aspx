<%@ Page Title="" Language="C#" MasterPageFile="~/VisitFriend.master" AutoEventWireup="true" CodeFile="FriendPersonFile.aspx.cs" Inherits="FriendPersonFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4>昵称： <asp:Label ID="userName" runat="server" ></asp:Label></h4>
  <h4>  年龄：<asp:Label ID="userAge" runat="server"></asp:Label></h4>
   <h4> 生日： <asp:Label ID="userBirth" runat="server"></asp:Label></h4>
   <h4> 星座：<asp:Label ID="constellation" runat="server"></asp:Label></h4>
   <h4> 现居地：<asp:Label ID="AdressNow" runat="server" ></asp:Label></h4>
    <h4>婚姻状况：<asp:Label ID="marry" runat="server"></asp:Label></h4>
   <h4> 血型:<asp:Label ID="blood" runat="server"></asp:Label></h4>
   <h4> 故乡：<asp:Label ID="hometown" runat="server" ></asp:Label></h4>
   <h4> 职业：<asp:Label ID="job" runat="server"></asp:Label></h4>
    <h4>爱好：<asp:Label ID="hobby" runat="server"></asp:Label></h4>
</asp:Content>

