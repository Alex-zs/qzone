<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SettingPage.aspx.cs" Inherits="SettingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <asp:PlaceHolder ID="form1" runat="server" Visible="true">
  <asp:Button ID="changePic" runat="server" Text="修改头像" OnClick="changePic_Click" />
    <asp:Button ID="permission" runat="server" Text="权限设置" OnClick="permission_Click" />
    <asp:Button ID="deleteTalk" runat="server" Text="管理说说" OnClick="deleteTalk_Click" />
        <asp:Button ID="logout" runat="server" Text="注销" OnClick="logout_Click"/>
        </asp:PlaceHolder>
    <asp:PlaceHolder ID="form2" runat="server" Visible="false">
        <asp:Repeater ID="talkList" runat="server" OnItemCommand="talkList_ItemCommand">
            <ItemTemplate>
             <h3>   <asp:Image ID="head" runat="server" ImageUrl='<%# Eval("picture") %>' Height="50px" Width="50px" />
               <%# Eval("userName") %>
                 <asp:LinkButton ID="delete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("talkID") %>'></asp:LinkButton>
             </h3> 
                <h5><%# Eval("time") %></h5>
                <h4><%# Eval("text") %></h4>
            </ItemTemplate>
        </asp:Repeater>
    </asp:PlaceHolder>
</asp:Content>


