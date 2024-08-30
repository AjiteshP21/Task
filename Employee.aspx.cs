using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tsk_Login
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_EmployeeData();
            }
        }
        protected void Load_EmployeeData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
            string query = ("select EmpID, EmpName, EmpDesignation, EmpPlace, EmpState, EmpCountry from Employee");
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    using(SqlCommand cmd = new SqlCommand(query,con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //EmployeeGridView.DataSource = dt;
                        //EmployeeGridView.DataBind();

                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage.Text = ("Error loading data : " + ex.Message);
                errorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnClick_Submit(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtDesig.Text) && !string.IsNullOrWhiteSpace(txtPlace.Text) && !string.IsNullOrWhiteSpace(txtState.Text) && !string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                string name = txtName.Text.Trim();
                string designation = txtDesig.Text.Trim();
                string place = txtPlace.Text.Trim();
                string state = txtState.Text.Trim();
                string country = txtCountry.Text.Trim();

                string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
                string query = "INSERT INTO Employee (EmpName, EmpDesignation, EmpPlace, EmpState, EmpCountry) VALUES (@EmpName, @EmpDesignation, @EmpPlace, @EmpState, @EmpCountry)";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@EmpName", name);
                            cmd.Parameters.AddWithValue("@EmpDesignation", designation);
                            cmd.Parameters.AddWithValue("@EmpPlace", place);
                            cmd.Parameters.AddWithValue("@EmpState", state);
                            cmd.Parameters.AddWithValue("@EmpCountry", country);

                            cmd.ExecuteNonQuery();
                        }
                        con.Close();

                        errorMessage.Text = "Registration successful!";
                        errorMessage.ForeColor = System.Drawing.Color.Green;

                        Load_EmployeeData();
                    }
                }
                catch (Exception ex)
                {
                    errorMessage.Text = "Error: " + ex.Message;
                    errorMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                errorMessage.Text = "Please fill all the details.";
                errorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnClick_Edit(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
        protected void btnClick_Delete(object sender, EventArgs e)
        {
            //Make a table and give there emp Id and give two button for Edit and Delete
            //string empID = txtId.Text.Trim(); // Ensure you have a control for this

            string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
            string query = "DELETE FROM Employee WHERE EmpID = @EmpID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        //cmd.Parameters.AddWithValue("@EmpID", empID); 

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        errorMessage.Text = "Record deleted successfully!";
                        errorMessage.ForeColor = System.Drawing.Color.Green;

                        Load_EmployeeData();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = "Error: " + ex.Message;
                errorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnLogOut_click(object sender, EventArgs e)
        {
            Session.Clear(); 
            Response.Redirect("Login.aspx");
        }
    }
}








//protected void btnClick_Submit(object sender, EventArgs e)
//{
//    if (!string.IsNullOrWhiteSpace(txtName.Text) &&
//        !string.IsNullOrWhiteSpace(txtDesig.Text) &&
//        !string.IsNullOrWhiteSpace(txtPlace.Text) &&
//        !string.IsNullOrWhiteSpace(txtState.Text) &&
//        !string.IsNullOrWhiteSpace(txtCountry.Text))
//    {
//        string name = txtName.Text.Trim();
//        string designation = txtDesig.Text.Trim();
//        string place = txtPlace.Text.Trim();
//        string state = txtState.Text.Trim();
//        string country = txtCountry.Text.Trim();

//        // Store data in session if needed
//        Session["EmpName"] = name;
//        Session["EmpDesignation"] = designation;
//        Session["EmpPlace"] = place;
//        Session["EmpState"] = state;
//        Session["EmpCountry"] = country;

//        string connectionString = ConfigurationManager.ConnectionStrings["Dbcontext"].ConnectionString;
//        string query = "INSERT INTO Employee (EmpName, EmpDesignation, EmpPlace, EmpState, EmpCountry) VALUES (@EmpName, @EmpDesignation, @EmpPlace, @EmpState, @EmpCountry)";

//        try
//        {
//            using (SqlConnection con = new SqlConnection(connectionString))
//            {
//                con.Open();
//                using (SqlCommand cmd = new SqlCommand(query, con))
//                {
//                    cmd.Parameters.AddWithValue("@EmpName", name);
//                    cmd.Parameters.AddWithValue("@EmpDesignation", designation);
//                    cmd.Parameters.AddWithValue("@EmpPlace", place);
//                    cmd.Parameters.AddWithValue("@EmpState", state);
//                    cmd.Parameters.AddWithValue("@EmpCountry", country);

//                    cmd.ExecuteNonQuery();
//                }
//                con.Close();

//                errorMessage.Text = "Registration successful!";
//                errorMessage.ForeColor = System.Drawing.Color.Green;

//                Load_EmployeeData();
//            }
//        }
//        catch (Exception ex)
//        {
//            errorMessage.Text = "Error: " + ex.Message;
//            errorMessage.ForeColor = System.Drawing.Color.Red;
//        }
//    }
//    else
//    {
//        errorMessage.Text = "Please fill all the details.";
//        errorMessage.ForeColor = System.Drawing.Color.Red;
//    }
//}
