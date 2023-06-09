using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class adminOrder : System.Web.UI.Page
    {
        //set connectionString for DB Access
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    adminConLbl.Text = "Welcome to the book order form, " + Session["username"].ToString() + ".";
                    adminConLbl2.Text = "Create or delete new book orders for the library.";
                    getOrderInfo();
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

        //submit a new order form
        protected void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //ensures that no fields are empty
                if (orderTB.Text == "" ||
                    bookCodeTB.Text == "" || titleTB.Text == "" ||
                    amountTB.Text == "" || authorNumTB.Text == "")
                {
                    requiredText.Text = "Missing or incorrect fields.";
                }
                else
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opens connection
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("OrderAddOrEdit", sqlCon); //uses SP OrderAddOrEdit to add new order
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@orderID", Convert.ToInt32(hfOrderForm.Value == "" ? "0" : hfOrderForm.Value));
                        sqlCmd.Parameters.AddWithValue("@orderType", orderTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@bookCode", bookCodeTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@title", titleTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@amount", amountTB.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@authorNum", authorNumTB.Text.Trim());
                        //passes parameters and increments orderID since it won't have existed previously
                        sqlCmd.ExecuteNonQuery();
                        //execute query, clear the text fields and then reload the order information table
                        Clear();
                        getOrderInfo();
                        requiredText.Text = "Submitted successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                requiredText.Text = ex.Message;
            }
        }

        //set text boxes to editable
        protected void adminOrderGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            adminOrderGV.EditIndex = e.NewEditIndex;
            getOrderInfo();
        }

        //delete an order form from the table
        protected void adminOrderGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    //open connection
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteOrder", sqlCon); //uses SP DeleteOrder to remove order from the table
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@orderID", Convert.ToInt32(adminOrderGV.DataKeys[e.RowIndex].Value.ToString().Trim()));
                    //passes orderID as a parameter and removes all associated items, then executes query
                    sqlCmd.ExecuteNonQuery();
                    //reload order information
                    getOrderInfo();
                    errorMessage.Text = "Successfully deleted.";
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //revert text boxes to noneditable
        protected void adminOrderGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            adminOrderGV.EditIndex = -1;
            getOrderInfo();
        }

        //update order information
        protected void adminOrderGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //ensures that no text value is empty and that type is buy/sell
                if (((adminOrderGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim() == "" ||
                    ((adminOrderGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "buy" &&
                    (adminOrderGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "sell")) ||
                    (adminOrderGV.Rows[e.RowIndex].FindControl("editBookCode") as TextBox).Text.Trim() == "" ||
                    (adminOrderGV.Rows[e.RowIndex].FindControl("editTitle") as TextBox).Text.Trim() == "" ||
                    (adminOrderGV.Rows[e.RowIndex].FindControl("editAmount") as TextBox).Text.Trim() == "" ||
                    (adminOrderGV.Rows[e.RowIndex].FindControl("editAuthorNum") as TextBox).Text.Trim() == "")
                {
                    errorMessage.Text = "Please fill out all fields.";

                    //forces user to pick buy or sell as an order type
                    if ((adminOrderGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "buy" &&
                        (adminOrderGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.ToLower().Trim() != "sell")
                    {
                        errMessage2.Text = "Order type must be 'buy' or 'sell'.";
                    }
                }
                else
                {
                    //creates the connection and stored procedure to update the database with user information
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        //opens connection
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("OrderAddOrEdit", sqlCon); //uses SP OrderAddOrEdit
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@orderType", (adminOrderGV.Rows[e.RowIndex].FindControl("editType") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@bookCode", (adminOrderGV.Rows[e.RowIndex].FindControl("editBookCode") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@title", (adminOrderGV.Rows[e.RowIndex].FindControl("editTitle") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@amount", (adminOrderGV.Rows[e.RowIndex].FindControl("editAmount") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@authorNum", (adminOrderGV.Rows[e.RowIndex].FindControl("editAuthorNum") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@orderID", Convert.ToInt32(adminOrderGV.DataKeys[e.RowIndex].Value.ToString()));
                        //passes parameters and executes query
                        sqlCmd.ExecuteNonQuery();
                        adminOrderGV.EditIndex = -1;
                        //set values to noneditable and reload the order table
                        getOrderInfo();
                        errorMessage.Text = "Updated successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        //gets order information
        void getOrderInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //opened the database connection
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetOrders", sqlCon); //uses stored procedure "GetOrders"
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dt); //fills gridview with information
            }
            //bind data to the adminOrderGV
            adminOrderGV.DataSource = dt;
            adminOrderGV.DataBind();
        }

        //clears text boxes
        void Clear()
        {
            orderTB.Text = bookCodeTB.Text = titleTB.Text = amountTB.Text = authorNumTB.Text = errorMessage.Text = "";
        }
    }
}