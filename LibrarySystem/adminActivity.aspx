<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminActivity.aspx.cs" Inherits="LibrarySystem.adminActivity" %>

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
                <table class="adminTable">
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Order" OnClick="Button2_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button3" runat="server" Text="Manage stock" OnClick="Button3_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button4" runat="server" Text="Manage clients" OnClick="Button4_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button5" runat="server" Text="Manage activity" OnClick="Button5_Click" />

                        </td> 
                        <td>
                            <asp:Button ID="Button6" runat="server" Text="Log out" OnClick="Button6_Click" />

                        </td>
                    </tr>
                </table>
            </div>
            <div class="content">
                <asp:Label ID="adminConLbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="adminConLbl2" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="errorMessage" runat="server" Text="" />
                <br />
                <br />
                <asp:Label ID="errMessage2" runat="server" Text="" />
                <br />
                <br />
                <div class="adminContent">
                    <asp:Label ID="filterAccountIDText" runat="server" Text="" />
                    <asp:TextBox ID="filterAccountID" runat="server" Text="" Width="50px" />
                    &nbsp;&nbsp;
                    <asp:Label ID="filterUsernameText" runat="server" />
                    <asp:TextBox ID="filterUsername" runat="server" Text="" Width="80px" />
                    &nbsp;&nbsp;
                    <asp:Label ID="filterTypeText" runat="server" Text="" />
                    <asp:TextBox ID="filterType" runat="server" Text="" Width="80px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                    &nbsp;
                    <asp:Button ID="clearButton" runat="server" Text="Clear filter" OnClick="clearButton_Click" />
                    <br />
                    <br />
                    <div class="adminContentGV">
                        <asp:GridView ID="adminActivityGV" runat="server" AutoGenerateColumns="False" DataKeyNames="activityID, accountID"
                            
                            OnRowEditing="adminActivityGV_RowEditing" OnRowCancelingEdit="adminActivityGV_RowCancelingEdit"
                            OnRowUpdating="adminActivityGV_RowUpdating" OnRowDeleting="adminActivityGV_RowDeleting"

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
                                <asp:TemplateField HeaderText="Activity Type">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("type") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editType" Text='<%# Eval("type") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account ID">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("accountID") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Username during event">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("username") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editUsername" Text='<%# Eval("username") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("userFirst") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editUserFirst" Text='<%# Eval("userFirst") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("userLast") %>' runat="server" Width="100px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editUserLast" Text='<%# Eval("userLast") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Book Code">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("bookCode") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editBookCode" Text='<%# Eval("bookCode") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("title") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editTitle" Text='<%# Eval("title") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                        <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you sure you want to delete?');" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                        <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="footer">Developed by Brett Thornton</div>
        </div>
    </form>
</body>
</html>
