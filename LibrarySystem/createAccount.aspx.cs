using System;
using System.Data;
using System.Data.SqlClient;

namespace LibrarySystem
{
    public partial class createAccount : System.Web.UI.Page
    {
        //set connectionString for DB access
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx"); //redirects to login screen
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            //requires all of these fields to be filled in with information
            if (accountBox.Text == "" || userTextBox.Text == "" || passTextBox.Text == "" ||
                firstNameBox.Text == "" || lastNameBox.Text == "" || emailBox.Text == "")
            {
                labelMessage.Text = "Please fill out all fields.";
            }
            else
            {
                //creates the connection and stored procedure to update the database with user information
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //opens connection
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon); //opens stored procedure to add user
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    //passes these parameters and checks if accountID already exists
                    sqlCmd.Parameters.AddWithValue("@accountID", Convert.ToInt32(hfAccountID.Value == "" ? "0" : hfAccountID.Value));
                    sqlCmd.Parameters.AddWithValue("@type", accountBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@username", userTextBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", passTextBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@userFirst", firstNameBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@userLast", lastNameBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@email", emailBox.Text.Trim());
                    //executes the query
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    labelMessage.Text = "Submitted successfully.";
                }
            }
        }

        //clears the fields
        void Clear()
        {
            accountBox.Text = "";
            userTextBox.Text = "";
            passTextBox.Text = "";
            firstNameBox.Text = "";
            lastNameBox.Text = "";
            emailBox.Text = "";
            hfAccountID.Value = "";
            labelMessage.Text = "";
        }
    }
}