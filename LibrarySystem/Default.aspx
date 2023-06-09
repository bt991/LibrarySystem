<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library</title>
    <link href="Style/main.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="body">
            <div class="defHeader">
                <p>Welcome to the library system</p>
            </div>
            <div class="defContent">
                Please log in or create an account.
                <br />
                <br />
                <br />
                <table class="tableFormat">
                    <tr>
                        <td>
                            <asp:Label Text="Username:" runat="server" Width="100px" />
                        </td>
                        <td>
                            <asp:TextBox ID="userText" runat="server" Width="150px"/>
                            <asp:Label Text="*" runat="server" ForeColor="Red" Width="10px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Password:" runat="server" Width="100px" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox ID="passText" runat="server" TextMode="Password" Width="150px"/>
                            <asp:Label Text="*" runat="server" ForeColor="Red" Width="10px" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="logInButton" runat="server" Text="Log in" OnClick="logInButton_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="newUserButton" runat="server" Text="New user" OnClick="newUserButton_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label Text="" ID="errorMessage" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="defFooter">Developed by Brett Thornton</div>
        </div>
    </form>
</body>
</html>
