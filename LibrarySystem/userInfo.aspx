<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userInfo.aspx.cs" Inherits="LibrarySystem.userInfo" %>

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
                <asp:Label ID="userInfoLbl" runat="server" Text="" />
                <br />
                <asp:Label ID="userInfoLbl2" runat="server" Text="" />
                <br />
                <br />
                <asp:Label ID="errorMessage" runat="server" Text="" />
                <br />
                <br />
                <asp:Label ID="errMessage2" runat="server" Text="" />
                <br />
                <br />
                <asp:GridView ID="userInfoGV" runat="server" AutoGenerateColumns="False" DataKeyNames="accountID"
                    OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="userInfoGV_RowDeleting"

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
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("type") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="editType" Text='<%# Eval("type") %>' runat="server" />
                            </EditItemTemplate>
                            <ControlStyle Width="100px" />
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Username">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("username") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="editUser" Text='<%# Eval("username") %>' runat="server" />
                            </EditItemTemplate>
                            <ControlStyle Width="100px" />
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("password") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="editPass" Text='<%# Eval("password") %>' runat="server" />
                            </EditItemTemplate>
                            <ControlStyle Width="100px" />
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("userFirst") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="editUserFirst" Text='<%# Eval("userFirst") %>' runat="server" />
                            </EditItemTemplate>
                            <ControlStyle Width="100px" />
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("userLast") %>' runat="server" Width="100px"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="editUserLast" Text='<%# Eval("userLast") %>' runat="server" />
                            </EditItemTemplate>
                            <ControlStyle Width="100px" />
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("email") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="editEmail" Text='<%# Eval("email") %>' runat="server" />
                            </EditItemTemplate>
                            <ControlStyle Width="150px" />
                            <HeaderStyle Width="150px" HorizontalAlign="Center" />
                            <ItemStyle Width="150px" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                                <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                                <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <br />
            </div>
            <div class="footer">Developed by Brett Thornton</div>
        </div>
    </form>
</body>
</html>
