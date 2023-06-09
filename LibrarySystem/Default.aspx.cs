using System;
using System.Data;
using System.Data.SqlClient;

namespace LibrarySystem
{
    public partial class Default : System.Web.UI.Page
    {
        //variable declaration, set connectionString for DB access
        string a = "admin";
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

        //redirects to the account creation page
        protected void newUserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("createAccount.aspx");
        }

        protected void logInButton_Click(object sender, EventArgs e)
        {
            //if one or more fields are empty, clear the fields and tell user to restart.
            if (userText.Text == "" || passText.Text == "")
            {
                errorMessage.Text = "Please fill out both fields.";
                Clear();
            }
            else
            {
                //create database connection with connectionString
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //opened the database connection
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand("GetTypeOfUser", sqlCon); //uses stored procedure "GetTypeOfUser"
                    sqlDa.CommandType = CommandType.StoredProcedure;
                    sqlDa.Parameters.AddWithValue("@username", userText.Text); //parameter passed to SP
                    sqlDa.Parameters.AddWithValue("@password", passText.Text); //parameter passed to SP

                    try
                    {
                        //if the result is null, clear all the fields
                        if (sqlDa.ExecuteScalar() == null)
                        {
                            errorMessage.Text = "Invalid credentials.";
                            Clear();
                        }
                        //if the result is "admin", redirect to admin page
                        else if (sqlDa.ExecuteScalar().ToString().ToLower() == a)
                        {
                            Session["username"] = userText.Text;
                            Response.Redirect("adminConsole.aspx");
                        }
                        //if both of those conditions fail, redirect the user to the user page
                        else
                        {
                            Session["username"] = userText.Text;
                            Response.Redirect("userConsole.aspx");
                        }
                    }
                    catch (Exception err)
                    {
                        errorMessage.Text = err.Message;
                        sqlCon.Close();
                    }
                }
            }
        }

        //clears username and password fields
        void Clear()
        {
            userText.Text = "";
            passText.Text = "";
        }
    }
}