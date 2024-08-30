using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tsk_Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Clear();
            }
        }
        protected void Loadbtn_submit(object sender, EventArgs e)
        {
            
            // Check if controls are not null before accessing them
            if (txtUsername != null && txtPassword != null && loginMessage != null)
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                bool IsValidUser = ValidateUser(username, password);
                {
                    if(IsValidUser)
                    {
                        Session["UserName"] = username;
                        Response.Redirect("Employee.aspx");
                    }
                    else
                    {
                        errorMessage.Text = ("Invalid Useer or Password");
                        errorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }

                //string hashedPassword = HashPassword(password);

                string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
                string query = "SELECT COUNT(*) FROM Register WHERE UserName = @UserName AND UserPassword = @UserPassword";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@UserName", username);
                            cmd.Parameters.AddWithValue("@UserPassword", password);
                            
                            int userCount = (int)cmd.ExecuteScalar();
                            if (userCount > 0)
                            {
                                // User is authenticated
                                loginMessage.Text = "Login successful!";
                                Session.Timeout = 21600; 
                                Response.Redirect("Employee.aspx");
                            }
                            else
                            {
                                // User is not authenticated invalid user
                                loginMessage.Text = "Invalid username or password.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (errorMessage != null)
                    {
                        errorMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
            else
            {
                errorMessage.Text = "error";
            }
       
        }
        protected void btn_register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        private bool ValidateUser(string username, string password)
        {
            return username == "username" && password == "password";
        }
    }
}


