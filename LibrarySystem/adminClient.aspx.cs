using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class adminClient : System.Web.UI.Page
    {
        //set connectionString for DB Access
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //set text for text boxes and load user information
                if (Session["username"] != null)
                {
                    adminConLbl.Text = "Welcome to the client manager, " + Session["username"].ToString() + ".";
                    adminConLbl2.Text = "Manage client details for all users.";
                    errorMessage.Text = "Apply one of the filters to update the table.";
                    filterUserText.Text = "Filter by Username: ";
                    filterFirstNameText.Text = "Filter by First Name: ";
                    filterLastNameText.Text = "Filter by Last Name: ";

                    getUserInfo();
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

        //search button click function
        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                //check if text box is not empty
                if (filterUser.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetUserItem", sqlCon); //uses stored procedure "GetUserItems"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@username", filterUser.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminClientGV.DataSource = dt;
                        adminClientGV.DataBind();
                    }
                    else
                    {
                        //print bad search filter to gridview
                        dt.Rows.Add(dt.NewRow());
                        adminClientGV.DataSource = dt;
                        adminClientGV.DataBind();
                        adminClientGV.Rows[0].Cells.Clear();
                        adminClientGV.Rows[0].Cells.Add(new TableCell());
                        adminClientGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminClientGV.Rows[0].Cells[0].Text = "No user with name '" + filterUser.Text + "' exists.";
                        adminClientGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                else if (filterUser.Text.Trim() == "" && filterFirstName.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetUserFirstName", sqlCon); //uses stored procedure "GetUserFirstName"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@userFirst", filterFirstName.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminClientGV.DataSource = dt;
                        adminClientGV.DataBind();
                    }
                    else
                    {
                        //print bad search filter to gridview
                        dt.Rows.Add(dt.NewRow());
                        adminClientGV.DataSource = dt;
                        adminClientGV.DataBind();
                        adminClientGV.Rows[0].Cells.Clear();
                        adminClientGV.Rows[0].Cells.Add(new TableCell());
                        adminClientGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminClientGV.Rows[0].Cells[0].Text = "No user with first name '" + filterFirstName.Text + "' exists.";
                        adminClientGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                else if ((filterUser.Text.Trim() == "" && filterFirstName.Text.Trim() == "") && filterLastName.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetUserLastName", sqlCon); //uses stored procedure "GetUserLastName"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@userLast", filterLastName.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminClientGV.DataSource = dt;
                        adminClientGV.DataBind();
                    }
                    else
                    {
                        //print bad search filter to gridview
                        dt.Rows.Add(dt.NewRow());
                        adminClientGV.DataSource = dt;
                        adminClientGV.DataBind();
                        adminClientGV.Rows[0].Cells.Clear();
                        adminClientGV.Rows[0].Cells.Add(new TableCell());
                        adminClientGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminClientGV.Rows[0].Cells[0].Text = "No user with last name '" + filterLastName.Text + "' exists.";
                        adminClientGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
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

        //clear data from filters
        protected void clearButton_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        //set edit index to editable
        protected void adminClientGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            adminClientGV.EditIndex = e.NewEditIndex;
            getUserInfo();
        }

        //revert edit index to noneditable
        protected void adminClientGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            adminClientGV.EditIndex = -1;
            getUserInfo();
        }

        //update user information
        protected void adminClientGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //strings to pass into if statement logic
                string u = "user";
                string a = "admin";

                //check if these rows contain empty values or values not allowed by data sets
                if (((adminClientGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim() == "" ||
                    ((adminClientGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != u &&
                    (adminClientGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != a)) ||
                    (adminClientGV.Rows[e.RowIndex].FindControl("editUser") as TextBox).Text.Trim() == "" ||
                    (adminClientGV.Rows[e.RowIndex].FindControl("editPass") as TextBox).Text.Trim() == "" ||
                    (adminClientGV.Rows[e.RowIndex].FindControl("editUserFirst") as TextBox).Text.Trim() == "" ||
                    (adminClientGV.Rows[e.RowIndex].FindControl("editUserLast") as TextBox).Text.Trim() == "" ||
                    (adminClientGV.Rows[e.RowIndex].FindControl("editEmail") as TextBox).Text.Trim() == "")
                {
                    errorMessage.Text = "Incorrect or missing fields.";

                    //force user type to be admin or user
                    if ((adminClientGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != u &&
                        (adminClientGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != a)
                    {
                        errMessage2.Text = "Account type must be 'admin' or 'user'.";
                    }
                }
                else
                {
                    //creates the connection and stored procedure to update the database with user information
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon); //uses SP UserAddOrEdit to update the user's informaton
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@type", (adminClientGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@username", (adminClientGV.Rows[e.RowIndex].FindControl("editUser") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@password", (adminClientGV.Rows[e.RowIndex].FindControl("editPass") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userFirst", (adminClientGV.Rows[e.RowIndex].FindControl("editUserFirst") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userLast", (adminClientGV.Rows[e.RowIndex].FindControl("editUserLast") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@email", (adminClientGV.Rows[e.RowIndex].FindControl("editEmail") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@accountID", Convert.ToInt32(adminClientGV.DataKeys[e.RowIndex].Value.ToString()));
                        //passes parameters and executes query
                        sqlCmd.ExecuteNonQuery();
                        adminClientGV.EditIndex = -1;
                        //sets textboxes to noneditable and gets user information
                        getUserInfo();
                        errorMessage.Text = "Updated successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //delete user at an index
        protected void adminClientGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //opens connection
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteUserFromDB", sqlCon); //uses SP DeleteUserFromDB to remove all information regarding that user from the DB
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@accountID", Convert.ToInt32(adminClientGV.DataKeys[e.RowIndex].Value.ToString().Trim()));
                    //execute query and reload user table
                    sqlCmd.ExecuteNonQuery();
                    getUserInfo();
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //display user information to the gridview
        void getUserInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //opened the database connection
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ViewUsers", sqlCon); //uses stored procedure "ViewUsers"
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dt);
            }
            //fill gridview with information
            adminClientGV.DataSource = dt;
            adminClientGV.DataBind();
        }

        //clear text boxes on call
        void clearFilter()
        {
            filterUser.Text = "";
            filterFirstName.Text = "";
            filterLastName.Text = "";
            getUserInfo();
        }
    }
}