using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class adminActivity : System.Web.UI.Page
    {
        //set connectionString for DB Access
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    adminConLbl.Text = "Welcome to the activity manager, " + Session["username"].ToString() + ".";
                    adminConLbl2.Text = "Manage activity information of the users.";
                    errorMessage.Text = "Apply one of the filters to update the table.";
                    filterAccountIDText.Text = "Filter by Account ID: ";
                    filterUsernameText.Text = "Filter by Username: ";
                    filterTypeText.Text = "Filter by Activity Type: ";
                    getActivityInfo();
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

        //allow user to set filter to search
        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (filterAccountID.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetUserID", sqlCon); //uses stored procedure "GetUserID"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@accountID", filterAccountID.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminActivityGV.DataSource = dt;
                        adminActivityGV.DataBind();
                    }
                    else
                    {
                        //display bad filter if wrong information
                        dt.Rows.Add(dt.NewRow());
                        adminActivityGV.DataSource = dt;
                        adminActivityGV.DataBind();
                        adminActivityGV.Rows[0].Cells.Clear();
                        adminActivityGV.Rows[0].Cells.Add(new TableCell());
                        adminActivityGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminActivityGV.Rows[0].Cells[0].Text = "No account found with ID '" + filterAccountID.Text + "'.";
                        adminActivityGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                else if (filterAccountID.Text.Trim() == "" && filterUsername.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetUsername", sqlCon); //uses stored procedure "GetUsername"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@username", filterUsername.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminActivityGV.DataSource = dt;
                        adminActivityGV.DataBind();
                    }
                    else
                    {
                        //display bad filter if wrong information
                        dt.Rows.Add(dt.NewRow());
                        adminActivityGV.DataSource = dt;
                        adminActivityGV.DataBind();
                        adminActivityGV.Rows[0].Cells.Clear();
                        adminActivityGV.Rows[0].Cells.Add(new TableCell());
                        adminActivityGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminActivityGV.Rows[0].Cells[0].Text = "No account with username '" + filterUsername.Text + "' exists.";
                        adminActivityGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    }
                }
                else if ((filterAccountID.Text.Trim() == "" && filterUsername.Text.Trim() == "") && filterType.Text.Trim() != "")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetActivityType", sqlCon); //uses stored procedure "GetActivityType"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@type", filterType.Text);
                        sqlDa.Fill(dt); //fills gridview with information
                    }
                    if (dt.Rows.Count > 0)
                    {
                        adminActivityGV.DataSource = dt;
                        adminActivityGV.DataBind();
                    }
                    else
                    {
                        //display bad filter if wrong information
                        dt.Rows.Add(dt.NewRow());
                        adminActivityGV.DataSource = dt;
                        adminActivityGV.DataBind();
                        adminActivityGV.Rows[0].Cells.Clear();
                        adminActivityGV.Rows[0].Cells.Add(new TableCell());
                        adminActivityGV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                        adminActivityGV.Rows[0].Cells[0].Text = "No data with type '" + filterType.Text + "' exists.";
                        adminActivityGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
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

        //clears search filters
        protected void clearButton_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        //set text fields to editable and reload activity information
        protected void adminActivityGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            adminActivityGV.EditIndex = e.NewEditIndex;
            getActivityInfo();
        }

        //revert text fields back to normal and reload activity information
        protected void adminActivityGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            adminActivityGV.EditIndex = -1;
            getActivityInfo();
        }

        //updates activity
        protected void adminActivityGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //check if text fields are empty, if so then make sure user changes them to have a value
                if (((adminActivityGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim() == "" ||
                    ((adminActivityGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "lend" &&
                    (adminActivityGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "return")) ||
                    (adminActivityGV.Rows[e.RowIndex].FindControl("editUsername") as TextBox).Text.Trim() == "" ||
                    (adminActivityGV.Rows[e.RowIndex].FindControl("editUserFirst") as TextBox).Text.Trim() == "" ||
                    (adminActivityGV.Rows[e.RowIndex].FindControl("editUserLast") as TextBox).Text.Trim() == "" ||
                    (adminActivityGV.Rows[e.RowIndex].FindControl("editBookCode") as TextBox).Text.Trim() == "" ||
                    (adminActivityGV.Rows[e.RowIndex].FindControl("editTitle") as TextBox).Text.Trim() == "")
                {
                    errorMessage.Text = "Please fill out all fields.";

                    if ((adminActivityGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "lend" &&
                        (adminActivityGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "return")
                    {
                        errMessage2.Text = "Activity type must be 'return' or 'lend'.";
                    }
                }
                else
                {
                    //creates the connection and stored procedure to update the database with user information
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("RequestAddOrEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@activityID", Convert.ToInt32(adminActivityGV.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.Parameters.AddWithValue("@type", (adminActivityGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@accountID", Convert.ToInt32(adminActivityGV.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.Parameters.AddWithValue("@username", (adminActivityGV.Rows[e.RowIndex].FindControl("editUsername") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userFirst", (adminActivityGV.Rows[e.RowIndex].FindControl("editUserFirst") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userLast", (adminActivityGV.Rows[e.RowIndex].FindControl("editUserLast") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@bookCode", (adminActivityGV.Rows[e.RowIndex].FindControl("editBookCode") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@title", (adminActivityGV.Rows[e.RowIndex].FindControl("editTitle") as TextBox).Text.Trim());
                        //passes parameters into SP and runs execute query
                        sqlCmd.ExecuteNonQuery();
                        adminActivityGV.EditIndex = -1;
                        //reverts edit index back to normal, reload activity information
                        getActivityInfo();
                        errorMessage.Text = "Updated successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //deletes activity
        protected void adminActivityGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //opens connection
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteUserRequest", sqlCon); //uses SP to delete request with activityID
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@activityID", Convert.ToInt32(adminActivityGV.DataKeys[e.RowIndex].Value.ToString().Trim()));
                    //execute query and reload activity information
                    sqlCmd.ExecuteNonQuery();
                    getActivityInfo();
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //gets activity information
        void getActivityInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //opened the database connection
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ViewUserActivity", sqlCon); //uses stored procedure "ViewUserActivity"
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dt);
            }
            //fills adminActivityGV with data and binds source
            adminActivityGV.DataSource = dt;
            adminActivityGV.DataBind();
        }

        //clears text fields and reloads activity info
        void clearFilter()
        {
            filterAccountID.Text = "";
            filterUsername.Text = "";
            filterType.Text = "";
            getActivityInfo();
        }
    }
}