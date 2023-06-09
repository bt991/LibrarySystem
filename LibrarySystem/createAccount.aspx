<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="LibrarySystem.createAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library</title>
    <link href="Style/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="body">
            <asp:HiddenField ID="hfAccountID" runat="server" />
            <div class="defHeader"><p>Welcome to the library system</p></div>
            <div class="accountContent">
                <table class="tableFormat" >
                    <tr>
                        <td>
                            <asp:Label Text="Account type:" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="accountBox" runat="server" width="175px">
                                <asp:ListItem>User</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label Text="*" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Username:" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="userTextBox" runat="server" />
                            <asp:Label Text="*" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Password:" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="passTextBox" runat="server" TextMode="Password" />
                            <asp:Label Text="*" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="First Name:" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="firstNameBox" runat="server" />
                            <asp:Label Text="*" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Last Name:" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="lastNameBox" runat="server" />
                            <asp:Label Text="*" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Email:" runat="server" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox ID="emailBox" runat="server" />
                            <asp:Label Text="*" runat="server" ForeColor="Red" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="labelMessage" runat="server" Text="" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="returnButton" runat="server" Text="Return to home" OnClick="returnButton_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="defFooter">Developed by Brett Thornton</div>
        </div>
    </form>
</body>
</html>
