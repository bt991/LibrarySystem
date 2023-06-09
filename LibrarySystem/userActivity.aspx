<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userActivity.aspx.cs" Inherits="LibrarySystem.userActivity" %>

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
                <asp:Label ID="userActivityLbl" runat="server" Text="" />
                <br />
                <br />
                <asp:Label ID="userActivityLbl2" runat="server" Text="" />
                <br />
                <br />
                <div class="activityContent">
                    <div class="activityContentGV">
                        <asp:GridView ID="userActivityGV" runat="server" DataKeyNames="activityID, accountID"
                            OnRowDeleting="userActivityGV_RowDeleting"
                            BackColor="LightGoldenrodYellow" BorderColor="Black" BorderWidth="1px"
                            CellPadding="2" ForeColor="Black" AutoGenerateColumns="False" >
                            
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
                                <asp:TemplateField HeaderText="Activity Type">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("type") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Username during event">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("username") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("userFirst") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("userLast") %>' runat="server" Width="100px" />
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Book Code">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("bookCode") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("title") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you sure you want to delete?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="sendReturn">
                    <asp:HiddenField ID="hfReturnForm" runat="server" />
                    <asp:Label ID="userReturnLbl" runat="server" Text="" />
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
                                    <asp:ListItem>Return</asp:ListItem>
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
                                <asp:Label Text="" runat="server" Width="100px" Visible="false" />
                            </td>
                            <td>
                                <asp:TextBox ID="accountID" runat="server" Visible="false" />
                                <asp:TextBox ID="activityID" runat="server" Visible="false" />
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
