<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlbumUpload.aspx.cs" Inherits="AlbumUploadaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="pic_image">
            <asp:Image ID="pic" runat="server" />
        </div>
        <div><asp:FileUpload ID="pic_upload" runat="server" />
            <asp:Label ID="lbl_pic" runat="server" CssClass="pic_text"></asp:Label>
        </div>
        <div class="pic_label">上传图片格式为.jpg,.gif,.bmp,.png,图片大小不得超过8M</div>
        <div><asp:Button ID="btn_upload" runat="server" Text="上传" OnClick="btn_upload_Click" Height="47px" Width="96px"/>
       <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click"  Height="47px" Width="81px" />
     </div>
</asp:Content>

