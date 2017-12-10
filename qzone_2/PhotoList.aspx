<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoList.aspx.cs" Inherits="PhotoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="upload" Text="上传照片" runat="server" OnClick="upload_Click" />
    <br />
    <asp:Repeater ID="photos" runat="server" OnItemCommand="photos_ItemCommand" OnItemDataBound="photos_ItemDataBound">
        <ItemTemplate>
             <asp:UpdatePanel ID="update" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional"><ContentTemplate>
            <asp:Image ID="pic" runat="server" Width="180px" Height="180px" ImageUrl='<%# Eval("image") %>' />
            <h3> <asp:LinkButton ID="reply" runat="server" Text="评论" CommandName="reply" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></h3>
            
            <asp:Repeater ID="comment" runat="server" OnItemCommand="comment_ItemCommand">
                <ItemTemplate>
                <h3>   
                    <asp:Label ID="userName" runat="server" Text='<%# Eval("userName") %>'></asp:Label>
                    ：<asp:Label ID="text" runat="server" Text='<%# Eval("text") %>'></asp:Label>
                </h3>
                 
                </ItemTemplate>
            </asp:Repeater>
           
           
         <br />
            <asp:TextBox ID="txt" runat="server" Visible="false" ></asp:TextBox>
            <asp:Button ID="submit" runat="server" Text="发表" OnClick="submit_Click" Visible="false" />
                 <asp:Button ID="back" runat="server" Text="取消" OnClick="back_Click" Visible="false" />
                </ContentTemplate></asp:UpdatePanel>
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

