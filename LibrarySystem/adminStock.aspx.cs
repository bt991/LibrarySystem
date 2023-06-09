using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class adminStock : System.Web.UI.Page
    {
        //set connectionString for DB Access
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    //sets default text values and loads book info
                    adminConLbl.Text = "Welcome to the book stock, " + Session["username"].ToString() + ".";
                    adminConLbl2.Text = "Manage the books in stock for the library.";
                    errorMessage.Text = "Apply one of the filters to update the table.";
                    filterTitleText.Text = "Filter by Title: ";
                    filterGenreText.Text = "Filter by Genre: ";
                    filterStockText.Text = "Filter by Stock: ";
                    getBookInfo();
                }
                else
                {
                    Session.Remove("username");
                    Response.Redirect("Default.aspx");
                }
            }
        }

        //redirects admin to adminConsole unless username is not set
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("adminConsole.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }

        //redirects admin to adminOrder unless username is not set
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("adminOrder.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }

        //redirects admin to adminStock unless username is not set
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("adminStock.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }

        //redirects admin to adminClient unless username is not set
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("adminClient.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }

        //redirects admin to adminActivity unless username is not set
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("adminActivity.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }

        //redirects admin to login and resets username
        protected void Button6_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
            Response.Redirect("Default.aspx");
        }

        //searches book table with a filter
        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                //checks value of filter field
                if (filterTitle.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetSearchTitle", sqlCon); //uses stored procedure "GetSearchTitle"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@title", filterTitle.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminStockGV.DataSource = dt;
                        adminStockGV.DataBind();
                    }
                    else
                    {
                        //display message if filter text doesn't match
                        dt.Rows.Add(dt.NewRow());
                        adminStockGV.DataSource = dt;
                        adminStockGV.DataBind();
                        adminStockGV.Rows[0].Cells.Clear();
                        adminStockGV.Rows[0].Cells.Add(new TableCell());
                        adminStockGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminStockGV.Rows[0].Cells[0].Text = "No such book with title '" + filterTitle.Text + "' exists.";
                        adminStockGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                //checks value of filter fields
                else if (filterTitle.Text.Trim() == "" && filterGenre.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetSearchGenre", sqlCon); //uses stored procedure "GetSearchGenre"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@genre", filterGenre.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminStockGV.DataSource = dt;
                        adminStockGV.DataBind();
                    }
                    else
                    {
                        //display message if filter text doesn't match
                        dt.Rows.Add(dt.NewRow());
                        adminStockGV.DataSource = dt;
                        adminStockGV.DataBind();
                        adminStockGV.Rows[0].Cells.Clear();
                        adminStockGV.Rows[0].Cells.Add(new TableCell());
                        adminStockGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminStockGV.Rows[0].Cells[0].Text = "No such book with genre '" + filterGenre.Text + "' exists.";
                        adminStockGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                //checks value of filter fields
                else if ((filterTitle.Text.Trim() == "" && filterGenre.Text.Trim() == "") && filterStock.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetSearchStock", sqlCon); //uses stored procedure "GetSearchStock"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@inStock", filterStock.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminStockGV.DataSource = dt;
                        adminStockGV.DataBind();
                    }
                    else
                    {
                        //display message if filter text doesn't match
                        dt.Rows.Add(dt.NewRow());
                        adminStockGV.DataSource = dt;
                        adminStockGV.DataBind();
                        adminStockGV.Rows[0].Cells.Clear();
                        adminStockGV.Rows[0].Cells.Add(new TableCell());
                        adminStockGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminStockGV.Rows[0].Cells[0].Text = "No such book with stock '" + filterStock.Text + "' exists.";
                        adminStockGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                else
                {
                    clearFilter();
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //clears filter text
        protected void clearButton_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        //sets edit index to editable
        protected void adminStockGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            adminStockGV.EditIndex = e.NewEditIndex;
            getBookInfo();
        }

        //delete an item from the table
        protected void adminStockGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //opens connection
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteBook", sqlCon); //uses SP DeleteBook to remove book from all tables
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@bookCode", adminStockGV.DataKeys[e.RowIndex].Value.ToString().Trim());
                    //passes parameter bookCode to find all data associated with it, then executes query
                    sqlCmd.ExecuteNonQuery();
                    //reload book information
                    getBookInfo();
                    errorMessage.Text = "Successfully deleted.";
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //sets edit index back to noneditable
        protected void adminStockGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            adminStockGV.EditIndex = -1;
            getBookInfo();
        }

        //update an item in the table
        protected void adminStockGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //checks to make sure all text boxes aren't empty
                if ((adminStockGV.Rows[e.RowIndex].FindControl("editBookCode") as TextBox).Text.Trim() == "" ||
                    (adminStockGV.Rows[e.RowIndex].FindControl("editTitle") as TextBox).Text.Trim() == "" ||
                    (adminStockGV.Rows[e.RowIndex].FindControl("editPC") as TextBox).Text.Trim() == "" ||
                    (adminStockGV.Rows[e.RowIndex].FindControl("editGenre") as TextBox).Text.Trim() == "" ||
                    (adminStockGV.Rows[e.RowIndex].FindControl("editAuthorNum") as TextBox).Text.Trim() == "")
                {
                    //output if any box is empty
                    errorMessage.Text = "Please fill out all fields.";
                }
                else
                {
                    //creates the connection and stored procedure to update the database with user information
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //open connection and set stored procedure type
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("BookAddOrEdit", sqlCon); //uses SP BookAddOrEdit
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        //parameters to go into stored procedure
                        sqlCmd.Parameters.AddWithValue("@bookCode", (adminStockGV.Rows[e.RowIndex].FindControl("editBookCode") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@title", (adminStockGV.Rows[e.RowIndex].FindControl("editTitle") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@publisherCode", (adminStockGV.Rows[e.RowIndex].FindControl("editPC") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@genre", (adminStockGV.Rows[e.RowIndex].FindControl("editGenre") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@authorNum", (adminStockGV.Rows[e.RowIndex].FindControl("editAuthorNum") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery(); //executes SQL query
                        adminStockGV.EditIndex = -1; //sets table index back to normal
                        getBookInfo(); //reload information
                        errorMessage.Text = "Updated successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //gets book information
        void getBookInfo()
        {
            DataTable dt = new DataTable(); //create data table
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //opened the database connection
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetSearchItems", sqlCon); //uses stored procedure "GetSearchItems"
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dt); //fills gridview with information
            }
            adminStockGV.DataSource = dt; //binds gridview as datasource
            adminStockGV.DataBind();
        }

        //clear text box fields
        void clearFilter()
        {
            //clears text of fields and reloads gridview
            filterTitle.Text = "";
            filterGenre.Text = "";
            filterStock.Text = "";
            getBookInfo();
        }
    }
}