<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userConsole.aspx.cs" Inherits="LibrarySystem.userConsole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library</title>
    <link href="Style/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header"><p>Welcome to the library system</p></div>
            <div class="menu">
                <table id="userTable">
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Info" OnClick="Button2_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button3" runat="server" Text="Activity" OnClick="Button3_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button4" runat="server" Text="Search" OnClick="Button4_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button5" runat="server" Text="Log out" OnClick="Button5_Click" />

                        </td>
                    </tr>
                </table>
            </div>
            <div class="content">
                <asp:Label ID="userConLbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="userConLbl2" runat="server" Text=""></asp:Label>
            </div>
            <div class="footer">Developed by Brett Thornton</div>
        </div>
    </form>
</body>
</html>
