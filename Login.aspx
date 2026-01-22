<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeeManagement.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin Login</title>
    <link href="Content/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <h2>Admin Login</h2>

            <asp:TextBox ID="txtUsername" runat="server" CssClass="input" placeholder="Username" OnTextChanged="txtUsername_TextChanged" />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password" placeholder="Password" OnTextChanged="txtPassword_TextChanged" />

            <asp:Label ID="lblMessage" runat="server" CssClass="error" />

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn"
                OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
