<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserChange.aspx.cs" Inherits="UserChange" %>

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
    <form id="form1" runat="server" visible="true">
        请输入邮箱：
        <asp:TextBox ID="emailAdress" runat="server" ></asp:TextBox>
        <asp:Button ID="send" runat="server" OnClick="send_Click" Text="发送验证码" />
    </form>
    <form id="form2" runat="server" visible="false">
        请输入验证码：
        <asp:TextBox ID="validate" runat="server" ></asp:TextBox>
        <asp:Button ID="click" runat="server" OnClick="click_Click" Text="验证" />
    </form>
    <form id="form3" runat="server" visible ="false">
        <div>
            请输入新密码：
            <asp:TextBox ID="userPassword" runat="server" TextMode="Password" ></asp:TextBox><br />
            请再次输入：
            <asp:TextBox ID="userPasswords" runat="server" TextMode="Password"></asp:TextBox><br />
            验证码：
            <input runat="server" id="txtValidate" />  
        <img src="/ValidateCode.aspx?ValidateCodeType=1&0.011150883024061309" onclick="this.src='/ValidateCode.aspx?ValidateCodeType=1&'+Math.random();" id="imgValidateCode" alt="点击刷新验证码" title="点击刷新验证码" style="cursor: pointer;" />
            <br />
            <asp:Button ID="changePwd" runat="server" OnClick="changePwd_Click" Text="修改" />
        </div>
    </form>
</body>
</html>
