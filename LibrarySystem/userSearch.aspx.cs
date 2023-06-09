using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class userSearch : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //displays welcome if username is set, else redirect to login
                if (Session["username"] != null)
                {
                    userSearchLbl.Text = "Welcome to the search page, " + Session["username"].ToString() + ".";
                    userSearchLbl2.Text = "Use this page to search for a book and request a book.";
                    errorMessage.Text = "Apply one of the filters to update the table.";
                    filterTitleText.Text = "Filter by Title: ";
                    filterGenreText.Text = "Filter by Genre: ";
                    filterStockText.Text = "Filter by Stock: ";
                    userRequestLbl.Text = "If you would like to request for a book, fill our the form below.";
                    getBookInfo();
                    getUserInfo();
                }
                else
                {
                    Session.Remove("username");
                    Response.Redirect("Default.aspx");
                }
            }
        }
        //redirects to userConsole if username is set, else redirect to login
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("userConsole.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }
        //redirects to userInfo if username is set, else redirect to login
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("userInfo.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }
        //redirects to userActivity if username is set, else redirect to login
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("userActivity.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }
        //redirects to userSearch if username is set, else redirect to login
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("userSearch.aspx");
            }
            else
            {
                Session.Remove("username");
                Response.Redirect("Default.aspx");
            }
        }
        //removes username and returns user to login
        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
            Response.Redirect("Default.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                //check if first filter isn't empty
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
                        //bind datasource if rows are more than  0
                        bookInfoGV.DataSource = dt;
                        bookInfoGV.DataBind();
                    }
                    else
                    {
                        //add new cell to gridview to display filter information was false
                        dt.Rows.Add(dt.NewRow());
                        bookInfoGV.DataSource = dt;
                        bookInfoGV.DataBind();
                        bookInfoGV.Rows[0].Cells.Clear();
                        bookInfoGV.Rows[0].Cells.Add(new TableCell());
                        bookInfoGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        bookInfoGV.Rows[0].Cells[0].Text = "No such book with title '" + filterTitle.Text + "' exists.";
                        bookInfoGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
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
                        //bind datasource if rows are more than  0
                        bookInfoGV.DataSource = dt;
                        bookInfoGV.DataBind();
                    }
                    else
                    {
                        //add new cell to gridview to display filter information was false
                        dt.Rows.Add(dt.NewRow());
                        bookInfoGV.DataSource = dt;
                        bookInfoGV.DataBind();
                        bookInfoGV.Rows[0].Cells.Clear();
                        bookInfoGV.Rows[0].Cells.Add(new TableCell());
                        bookInfoGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        bookInfoGV.Rows[0].Cells[0].Text = "No such book with genre '" + filterGenre.Text + "' exists.";
                        bookInfoGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                else if ((filterTitle.Text.Trim() == "" && filterGenre.Text.Trim() == "") && filterStock.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetSearchStock", sqlCon); //uses stored procedure "GetSearchGenre"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@inStock", filterStock.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        //bind datasource if rows are more than  0
                        bookInfoGV.DataSource = dt;
                        bookInfoGV.DataBind();
                    }
                    else
                    {
                        //add new cell to gridview to display filter information was false
                        dt.Rows.Add(dt.NewRow());
                        bookInfoGV.DataSource = dt;
                        bookInfoGV.DataBind();
                        bookInfoGV.Rows[0].Cells.Clear();
                        bookInfoGV.Rows[0].Cells.Add(new TableCell());
                        bookInfoGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        bookInfoGV.Rows[0].Cells[0].Text = "No such book with stock '" + filterStock.Text + "' exists.";
                        bookInfoGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
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

        //clears filter
        protected void clearButton_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //check if these textboxes are empty
                if (usernameTB.Text == "" || userFirstTB.Text == "" ||
                    userLastTB.Text == "" || typeDDL.Text == "" ||
                    bookCodeTB.Text == "" || titleTB.Text == "")
                {
                    requiredText.Text = "Missing fields. Make sure all are filled out.";
                }
                else
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("CheckValidBook", sqlCon); //uses stored procedure "GetSearchTitle"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@bookCode", bookCodeTB.Text.Trim());
                        sqlDa.SelectCommand.Parameters.AddWithValue("@title", titleTB.Text.Trim());
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if ((dt.Rows.Count > 0) && (dt.Rows[0][2].ToString().Trim() != "0"))
                    {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            //open DB connection
                            sqlCon.Open();
                            SqlCommand sqlCmd = new SqlCommand("RequestAddOrEdit", sqlCon); //run SP, pass parameters and check if activityID is new or not
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@activityID", Convert.ToInt32(hfRequestForm.Value == "" ? "0" : hfRequestForm.Value));
                            sqlCmd.Parameters.AddWithValue("@username", usernameTB.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@userFirst", userFirstTB.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@userLast", userLastTB.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@type", typeDDL.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@bookCode", bookCodeTB.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@title", titleTB.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@accountID", accountID.Text.Trim());
                            //execute query
                            sqlCmd.ExecuteNonQuery();
                            Clear();
                            requiredText.Text = "Submitted successfully.";
                            getUserInfo(); //reobtain user info
                        }
                    }
                    else
                    {
                        requiredText.Text = "Invalid book code, title or no stock available.";
                    }
                }
            }
            catch (Exception ex)
            {
                requiredText.Text = ex.Message;
            }
        }

        //gets account information for the user
        void getUserInfo()
        {
            if (Session["username"] == null)
            {
                errorMessage.Text = "Could not display information for " + Session["username"].ToString();
            }
            else
            {
                //creates DataTable and database connection
                DataTable dt = new DataTable();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //opened the database connection
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByUsername", sqlCon); //uses stored procedure "UserViewByUsername"
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.SelectCommand.Parameters.AddWithValue("@username", Session["username"]); //parameter passed to SP
                    sqlDa.Fill(dt); //fills object dt with data
                }
                //fill and bind the information from the SP to the textboxes

                usernameTB.Text = dt.Rows[0][2].ToString().Trim();
                userFirstTB.Text = dt.Rows[0][4].ToString().Trim();
                userLastTB.Text = dt.Rows[0][5].ToString().Trim();
                accountID.Text = dt.Rows[0][0].ToString().Trim();
            }
        }

        void getBookInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //opened the database connection
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetSearchItems", sqlCon); //uses stored procedure "GetSearchItems"
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dt); //fills gridview with information
            }
            //fill and bind the information from the SP to the gridview
            bookInfoGV.DataSource = dt;
            bookInfoGV.DataBind();
        }

        //clears textboxes
        void clearFilter()
        {
            filterTitle.Text = "";
            filterGenre.Text = "";
            filterStock.Text = "";
            getBookInfo();
        }

        //clears textboxes
        void Clear()
        {
            usernameTB.Text = userFirstTB.Text = userLastTB.Text = typeDDL.Text = bookCodeTB.Text = titleTB.Text = "";
            hfRequestForm.Value = "";
        }
    }
}