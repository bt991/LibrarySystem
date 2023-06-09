using System;

namespace LibrarySystem
{
    public partial class adminConsole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    //display welcome message to admin
                    adminConLbl.Text = "Welcome to the admin console, " + Session["username"].ToString() + ".";
                    adminConLbl2.Text = "Follow the buttons above to navigate the page.";
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
    }
}