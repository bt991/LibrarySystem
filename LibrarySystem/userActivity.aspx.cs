using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class userActivity : System.Web.UI.Page
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
                    userActivityLbl.Text = "Welcome to activity, " + Session["username"].ToString() + ".";
                    userActivityLbl2.Text = "Check lend or return history here or submit a return form.";
                    userReturnLbl.Text = "If you would like to return a book, fill our the form below.";
                    getUserInfo();
                    getUserActivity();
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

        //allows a user to delete a request
        protected void userActivityGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //open connection to DB
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteUserRequest", sqlCon); //run SP with activityID as parameter
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@activityID", Convert.ToInt32(userActivityGV.DataKeys[e.RowIndex].Value.ToString().Trim()));
                    sqlCmd.ExecuteNonQuery();
                    //execute query and reload activity
                    getUserActivity();
                }
            }
            catch (Exception ex)
            {
                userActivityLbl2.Text = ex.Message;
            }
        }

        //allows user to submit a request to return a book
        protected void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //checks if textboxes are empty
                if (usernameTB.Text == "" || userFirstTB.Text == "" ||
                    userLastTB.Text == "" || typeDDL.Text == "" ||
                    bookCodeTB.Text == "" || titleTB.Text == "")
                {
                    requiredText.Text = "Missing fields. Make sure all are filled out.";
                }
                else
                {
                    //get activity id from method
                    getActivityID();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //open connection
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("RequestAddOrEdit", sqlCon); //run SP and pass parameters
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@activityID", Convert.ToInt32(activityID.Text.Trim()));
                        sqlCmd.Parameters.AddWithValue("@type", typeDDL.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@username", usernameTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userFirst", userFirstTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userLast", userLastTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@bookCode", bookCodeTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@title", titleTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@accountID", accountID.Text.Trim());
                        //execute query
                        sqlCmd.ExecuteNonQuery();
                        Clear();
                        requiredText.Text = "Submitted successfully.";
                        //reload user activity and information
                        getUserActivity();
                        getUserInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                requiredText.Text = ex.Message;
            }
        }

        //clears text boxes
        void Clear()
        {
            usernameTB.Text = userFirstTB.Text = userLastTB.Text = typeDDL.Text = bookCodeTB.Text = titleTB.Text = "";
            hfReturnForm.Value = "";
        }

        //method to get user personal information
        void getUserInfo()
        {
            if (Session["username"] == null)
            {
                userActivityLbl2.Text = "Could not display information for " + Session["username"].ToString();
            }
            else
            {
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
                usernameTB.Text = dt.Rows[0][2].ToString().Trim();
                userFirstTB.Text = dt.Rows[0][4].ToString().Trim();
                userLastTB.Text = dt.Rows[0][5].ToString().Trim();
                accountID.Text = dt.Rows[0][0].ToString().Trim();
            }
        }

        //method to get activityID
        void getActivityID()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //opened the database connection
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ActivityIDByTitle", sqlCon); //uses stored procedure "ActivityIDByTitle"
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@title", titleTB.Text.Trim()); //parameter passed to SP
                sqlDa.Fill(dt); //fills object dt with data
            }
            activityID.Text = dt.Rows[0][0].ToString().Trim();
        }

        //method to display all activity
        void getUserActivity()
        {
            try
            {
                if (Session["username"] == null)
                {
                    userActivityLbl2.Text = "Could not display information for " + Session["username"].ToString() + ".";
                }
                else
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opened the database connection
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("ActivityByUsername", sqlCon); //uses stored procedure "ActivityByUsername"
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@username", Session["username"]); //parameter passed to SP
                        sqlDa.Fill(dt); //fills object dt with data
                    }
                    userActivityGV.DataSource = dt;
                    userActivityGV.DataBind();
                }
            }
            catch (Exception ex)
            {
                userActivityLbl2.Text = ex.Message;
            }
        }
    }
}