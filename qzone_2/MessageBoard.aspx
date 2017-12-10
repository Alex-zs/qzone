<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MessageBoard.aspx.cs" Inherits="MessageBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Repeater ID="messageList" runat="server" OnItemCommand="messageList_ItemCommand">
       <ItemTemplate>
          <h4><asp:Image ID="head" runat="server" ImageUrl='<%# Eval("picture") %>'  Width="50px" Height="50px"/>
              <asp:Label ID="name" runat="server" Text='<%# Eval("userName") %>'></asp:Label>
              <asp:LinkButton ID="delete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
          </h4> 
          <h5> <asp:Label ID="time" runat="server" Text='<%#Eval("time") %>'></asp:Label></h5>
           <h5><asp:Label ID="text" runat="server" Text='<%#Eval("text") %>'></asp:Label></h5>
           <br />
       </ItemTemplate>
   </asp:Repeater>
     <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> 
        <asp:Button ID="btnUp" Text="上一页" runat="server" OnClick="btnUp_Click" Height="25px" Width="100px" />
      <asp:Button ID="btnDown" Text="下一页" runat="server" OnClick="btnDown_Click" Height="25px" Width="100px"/>
      <asp:Button ID="btnFirst" Text="首页" runat="server" OnClick="btnFirst_Click" Height="25px" style="margin-top: 0px" Width="100px" />
      <asp:Button ID="btnLast" Text="尾页" runat="server" OnClick="btnLast_Click" Height="25px" Width="100px"/>
      页次：<asp:Label ID="lbNow" Text="1" runat="server"></asp:Label>
      / <asp:Label ID="lbTotal" Text="1" runat="server"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" Width="25px" Height="15px" runat="server"></asp:TextBox>
      <asp:Button ID="btnJump" Text="Go" runat="server" OnClick="btnJump_Click" Height="25px" Width="100px"/>
</asp:Content>

