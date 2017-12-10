<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Q_Zone.aspx.cs" Inherits="Q_Zone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #txtValidate {
            width: 60px;
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            空间登录<br />
            邮箱：<asp:TextBox ID = "txtUserMail" runat="server" Height="25px" Width="145px" ></asp:TextBox><br />
            密码：<asp:TextBox ID ="txtUserPwd" runat="server" TextMode="Password" Height="25px" Width="145px"></asp:TextBox><br />
            验证码:<input runat="server" id="txtValidate" />  
        <img src="/ValidateCode.aspx?ValidateCodeType=1&0.011150883024061309" onclick="this.src='/ValidateCode.aspx?ValidateCodeType=1&'+Math.random();" id="imgValidateCode" alt="点击刷新验证码" title="点击刷新验证码" style="cursor: pointer;" />
            <br />
        
            <asp:CheckBox ID="autoLogin" Text="自动登录" runat="server" />
            <br />
            <asp:Button ID="login" runat="server" OnClick="login_Click" Text="登录" Height="50px" Width="200px" /><br />
             <asp:Button ID="register" runat="server" OnClick="register_Click" Text="注册" Height="50px" Width="98px" />
            <asp:Button ID="findPwd" runat="server" OnClick="findPwd_Click" Text="忘记密码" Height="50px" Width="98px" /> 
        </div>
    </form>
</body>
</html>
