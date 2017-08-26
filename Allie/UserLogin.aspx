<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Allie.UserLogin1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 321px">
            <asp:Label ID="CompanyNameLabel" runat="server" Text="CompanyName"></asp:Label>
            <br />
            <br />
            <asp:Label ID="NewUserLabel" runat="server" EnableTheming="True" Text="New User?"></asp:Label>
&nbsp;<asp:HyperLink ID="RequestNewAccountHyerLink" runat="server" Font-Underline="True">Request New Account</asp:HyperLink>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="UserNameLabel" runat="server" Text="UserName"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="PasswordTextBox" type="password" /><br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DynamicHyperLink ID="ForgotPasswordDynamicHyperLink" runat="server" Font-Underline="True">Forgot Password ?</asp:DynamicHyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="LoginButton" runat="server" Text="Login" />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="BackButton" runat="server" Text="Back" />
        </div>
    </form>
</body>
</html>
