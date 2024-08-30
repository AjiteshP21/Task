using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tsk_Login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Clear();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string gender = RbMale.Checked ? "Male" : (RbFemale.Checked ? "Female" : "Not Specified");
            string place = ddlPlace.SelectedValue;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txt_Password.Text.Trim();

            if (!IsValidPassword(password))
            {
                errorMessage.Text = "Password must contain 8 Character along with at least one uppercase letter[A - Z], one digit[0 - 10], and one special character[@!$%^&*()_+].";
                return;
            }
            if(password != confirmPassword)
            {
                errorMessage.Text = "Password does not match";
                return;
            }

            string hashedPassword = HashPassword(password);

            // Store user data in session state
            Session["Name"] = name;
            Session["Gender"] = gender;
            Session["Place"] = place;
            Session["UserName"] = username;
            //Session["Password"] = password;
            //Session["ConfirmPassword"] = confirmPassword;

            string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
            string query = "INSERT INTO Register(Name, Gender, Place, UserName, UserPassword, ConfirmPassword) VALUES(@Name, @Gender, @Place, @UserName, @UserPassword, @ConfirmPassword)";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Register WHERE Name = @Name And Username = @UserName";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", name);
                        checkCmd.Parameters.AddWithValue("@UserName", username);
                        int userExists = (int)checkCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            errorMessage.Text = "User already exists.";
                            return;
                        }
                    }
                    
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Place", place);
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@UserPassword", password);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", confirmPassword);

                        cmd.ExecuteNonQuery();
                    }
                }
                successMessage.Text = "Registration Successful";
            }
            catch(Exception ex)
            {
                errorMessage.Text = ("error" + ex.Message);
            }
        }
        protected void Btn_Back(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;
            bool hasUpper = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if (!char.IsLetterOrDigit(c))
                    hasSpecial = true;
            }
            return hasUpper && hasDigit && hasSpecial;
        }
        private string HashPassword(string password)
        {
            //256 bytes Secure Hash Algorithm 256-bit 
            //Cryptography 
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}















