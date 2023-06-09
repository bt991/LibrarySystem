<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminOrder.aspx.cs" Inherits="LibrarySystem.adminOrder" %>

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
                <div class="sendRequest">
                    <asp:HiddenField ID="hfOrderForm" runat="server" />
                    <asp:Label ID="adminOrderLbl" runat="server" Text="" />
                    <br />
                    <br />
                    <table class="tableFormat">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="requiredText" Text="Enter information about a book to order." runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Order type: " runat="server" Width="150px" />
                            </td>
                            <td>
                                <asp:TextBox ID="orderTB" runat="server" Width="175px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Book code: " runat="server" Width="150px" />
                            </td>
                            <td>
                                <asp:TextBox ID="bookCodeTB" runat="server" Width="175px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Title: " runat="server" Width="150px" />
                            </td>
                            <td>
                                <asp:TextBox ID="titleTB" runat="server" Width="175px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Amount: " runat="server" Width="150px" />
                            </td>
                            <td>
                                <asp:TextBox ID="amountTB" runat="server" Width="175px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Author number: " runat="server" Width="150px" />
                            </td>
                            <td>
                                <asp:TextBox ID="authorNumTB" runat="server" Width="175px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <asp:Label ID="errorMessage" runat="server" Text="" />
                <br />
                <br />
                <asp:Label ID="errMessage2" runat="server" Text="" />
                <br />
                <br />
                <div class="adminContentGV">
                    <asp:GridView ID="adminOrderGV" runat="server" AutoGenerateColumns="False" DataKeyNames="orderID"
                        OnRowEditing="adminOrderGV_RowEditing" OnRowCancelingEdit="adminOrderGV_RowCancelingEdit"
                        OnRowUpdating="adminOrderGV_RowUpdating" OnRowDeleting="adminOrderGV_RowDeleting"

                        BackColor="LightGoldenrodYellow" BorderColor="Black" BorderWidth="1px"
                        CellPadding="2" ForeColor="Black" >

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
                            <asp:TemplateField HeaderText="Order type">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("orderType") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="editType" Text='<%# Eval("orderType") %>' runat="server" />
                                </EditItemTemplate>
                                <ControlStyle Width="75px" />
                                <HeaderStyle Width="75px" HorizontalAlign="Center" />
                                <ItemStyle Width="75px" HorizontalAlign="Left" />
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
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("amount") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="editAmount" Text='<%# Eval("amount") %>' runat="server" />
                                </EditItemTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Left" />
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
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Author first name">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("authorFirst") %>' runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Left" />
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
            <div class="footer">Developed by Brett Thornton</div>
        </div>
    </form>
</body>
</html>
