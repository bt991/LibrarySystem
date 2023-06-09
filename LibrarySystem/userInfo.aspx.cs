using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class userInfo : System.Web.UI.Page
    {
        //set connectionString for DB connection
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //displays welcome if username is set, else redirect to login
                if (Session["username"] != null)
                {
                    userInfoLbl.Text = "Welcome to your user information, " + Session["username"].ToString() + ".";
                    userInfoLbl2.Text = "Here you can edit your details or delete your account.";
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
                    sqlDa.Fill(dt);
                }
                //fill and bind the information from the SP to the gridview
                userInfoGV.DataSource = dt;
                userInfoGV.DataBind();
            }
        }

        //allows for editing user info, changing labels to textboxes
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            userInfoGV.EditIndex = e.NewEditIndex;
            getUserInfo();
        }

        //changes edit index back to normal text
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            userInfoGV.EditIndex = -1;
            getUserInfo();
        }
        //allows user to update account information
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //checks if these text fields are blank/not filled in
                if (((userInfoGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim() == "" ||
                    (userInfoGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "user") ||
                    (userInfoGV.Rows[e.RowIndex].FindControl("editUser") as TextBox).Text.Trim() == "" ||
                    (userInfoGV.Rows[e.RowIndex].FindControl("editPass") as TextBox).Text.Trim() == "" ||
                    (userInfoGV.Rows[e.RowIndex].FindControl("editUserFirst") as TextBox).Text.Trim() == "" ||
                    (userInfoGV.Rows[e.RowIndex].FindControl("editUserLast") as TextBox).Text.Trim() == "" ||
                    (userInfoGV.Rows[e.RowIndex].FindControl("editEmail") as TextBox).Text.Trim() == "")
                {
                    errorMessage.Text = "Missing or incorrect fields.";
                    if ((userInfoGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "user")
                    {
                        errMessage2.Text = "Account type must be 'user'.";
                    }
                }
                else
                {
                    //creates the connection and stored procedure to update the database with user information
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon); //uses SP to update account information
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@type", (userInfoGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@username", (userInfoGV.Rows[e.RowIndex].FindControl("editUser") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@password", (userInfoGV.Rows[e.RowIndex].FindControl("editPass") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userFirst", (userInfoGV.Rows[e.RowIndex].FindControl("editUserFirst") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userLast", (userInfoGV.Rows[e.RowIndex].FindControl("editUserLast") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@email", (userInfoGV.Rows[e.RowIndex].FindControl("editEmail") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@accountID", Convert.ToInt32(userInfoGV.DataKeys[e.RowIndex].Value.ToString()));
                        //passes parameters into SP and executes query
                        sqlCmd.ExecuteNonQuery();
                        //reset the session username from given information
                        Session["username"] = (userInfoGV.Rows[e.RowIndex].FindControl("editUser") as TextBox).Text.Trim();
                        userInfoGV.EditIndex = -1;
                        //reobtain user's information and return textBoxes into labels
                        getUserInfo();
                        errorMessage.Text = "Updated successfully.";
                        errMessage2.Text = "";
                        userInfoLbl.Text = "Welcome to your user information, " + Session["username"].ToString() + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //allows user to delete account information
        protected void userInfoGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //connect to DB with connection string
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteUserFromDB", sqlCon); //use stored procedure to delete user from DB
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@accountID", Convert.ToInt32(userInfoGV.DataKeys[e.RowIndex].Value.ToString().Trim()));
                    //passes accountID as a parameter and deletes row with that index
                    sqlCmd.ExecuteNonQuery();
                    getUserInfo();
                    //make system wait 5 seconds before returning user to login
                    System.Threading.Thread.Sleep(5000);
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }
    }
}