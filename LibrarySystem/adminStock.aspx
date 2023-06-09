<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminStock.aspx.cs" Inherits="LibrarySystem.adminStock" %>

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
                <div class="adminContent">
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
                    <div class="adminContentGV">
                        <asp:GridView ID="adminStockGV" runat="server" AutoGenerateColumns="False" DataKeyNames="bookCode"
                            OnRowEditing="adminStockGV_RowEditing" OnRowCancelingEdit="adminStockGV_RowCancelingEdit"
                            OnRowUpdating="adminStockGV_RowUpdating" OnRowDeleting="adminStockGV_RowDeleting"
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
                                <asp:TemplateField HeaderText="Book code">
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
                                <asp:TemplateField HeaderText="Genre">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("genre") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editGenre" Text='<%# Eval("genre") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="50px" />
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author number">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("authorNum") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editAuthorNum" Text='<%# Eval("authorNum") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="50px" />
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author last name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("authorLast") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author first name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("authorFirst") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="In Stock">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("inStock") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="50px" />
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("amount") %>' runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="50px" />
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Publisher Code">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("publisherCode") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editPC" Text='<%# Eval("publisherCode") %>' runat="server" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="50px" />
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" HorizontalAlign="Left" />
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
