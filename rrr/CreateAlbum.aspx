<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateAlbum.aspx.cs" Inherits="CreateAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4>相册名称：<asp:TextBox ID="albumName" runat="server" ></asp:TextBox></h4>
    
    <h4>相册介绍：<asp:TextBox ID="introduce" runat="server"></asp:TextBox></h4>
    <h4>
       相册封面：<asp:FileUpload ID="pic_upload" runat="server" />
         <asp:Label ID="lbl_pic" runat="server" CssClass="pic_text"></asp:Label>
       
       上传图片格式为.jpg,.gif,.bmp,.png,图片大小不得超过8M
    </h4>
    <h4>
        <asp:Button ID="create" OnClick="create_Click" Text="创建" runat="server" />
    </h4>
</asp:Content>

