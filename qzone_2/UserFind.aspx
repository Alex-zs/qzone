<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserFind.aspx.cs" Inherits="UserFind" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv= "Pragma " content= "no-cache " />
<meta http-equiv= "Cache-Control " content= "no-cache " />
<meta http-equiv= "Expires " content= "0 " />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" visible ="true">
        <div>
           通过邮箱找回:
            <asp:TextBox ID="emailAdress" runat="server" ></asp:TextBox>
            <asp:Button ID="send" runat="server" OnClick="send_Click" Text="发送验证码" />

        </div>
    </form>
    <form id="form2" runat="server" visible="false">
        请输入验证码：
        <asp:TextBox ID="validateCode" runat="server" ></asp:TextBox>
        <asp:Button ID="validate" runat="server" OnClick="validate_Click" Text="找回" />
    </form>
</body>
</html>
