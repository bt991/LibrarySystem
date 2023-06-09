<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userSearch.aspx.cs" Inherits="LibrarySystem.userSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library</title>
    <link href="Style/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <p>Welcome to the library system</p>
            </div>
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
                <asp:Label ID="userSearchLbl" runat="server" Text="" />
                <br />
                <asp:Label ID="userSearchLbl2" runat="server" Text="" />
                <br />
                <br />
                <asp:Label ID="errorMessage" runat="server" Text="" />
                <br />
                <br />
                <div class="searchContent">
                    <asp:Label ID="filterTitleText" runat="server" Text="" />
                    <asp:TextBox ID="filterTitle" runat="server" Text="" Width="100px" />
                    &nbsp;&nbsp;
                    <asp:Label ID="filterGenreText" runat="server" />
                    <asp:TextBox ID="filterGenre" runat="server" Text="" Width="50px" />
                    &nbsp;&nbsp;
                    <asp:Label ID="filterStockText" runat="server" Text="" />
                    <asp:TextBox ID="filterStock" runat="server" Text="" Width="50px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                    &nbsp;
                    <asp:Button ID="clearButton" runat="server" Text="Clear filter" OnClick="clearButton_Click" />
                    <br />
                    <br />
                    <div class="searchContentGV">
                        <asp:GridView ID="bookInfoGV" runat="server" AutoGenerateColumns="False"
                            BackColor="LightGoldenrodYellow" BorderColor="Black" BorderWidth="1px"
                            CellPadding="2" ForeColor="Black">

                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />

                            <Columns>
                                <asp:TemplateField HeaderText="Book Code">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("bookCode") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("title") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Genre">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("genre") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="40px" />
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                    <ItemStyle Width="40px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author Number">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("authorNum") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author Last Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("authorLast") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author First Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("authorFirst") %>' runat="server" Width="100px" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="In Stock">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("inStock") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Copies">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("amount") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="sendRequest">
                    <asp:HiddenField ID="hfRequestForm" runat="server" />
                    <asp:Label ID="userRequestLbl" runat="server" Text="" />
                    <br />
                    <br />
                    <table class="tableFormat">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="requiredText" Text="All fields required, some will auto-fill." runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Username: " runat="server" Width="100px"/>
                            </td>
                            <td>
                                <asp:TextBox ID="usernameTB" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="First Name: " runat="server" Width="100px"/>
                            </td>
                            <td>
                                <asp:TextBox ID="userFirstTB" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Last Name: " runat="server" Width="100px"/>
                            </td>
                            <td>
                                <asp:TextBox ID="userLastTB" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Request type: " runat="server" Width="100px"/>
                            </td>
                            <td>
                                <asp:DropDownList ID="typeDDL" runat="server" Width="175px" >
                                    <asp:ListItem>Lend</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Book Code: " runat="server" Width="100px"/>
                            </td>
                            <td>
                                <asp:TextBox ID="bookCodeTB" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Title: " runat="server" Width="100px" />
                            </td>
                            <td>
                                <asp:TextBox ID="titleTB" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="" runat="server" Width="100px" />
                            </td>
                            <td>
                                <asp:TextBox ID="accountID" runat="server" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="footer">Developed by Brett Thornton</div>
        </div>
    </form>
</body>
</html>
