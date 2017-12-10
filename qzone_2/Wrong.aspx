<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Wrong.aspx.cs" Inherits="Wrong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            该页面为注销页面，若您未注销，请重新登录！<br />
            <asp:Button runat="server" ID="login" Text="登录" OnClick="login_Click" />
             <script type="text/javascript"> 
<!-- 
    javascript: window.history.forward(1);
//--> 
</script>
           
        </div>
    </form>

</body>
</html>
