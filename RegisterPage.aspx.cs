using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;


namespace WebApplication1
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnView_click(object sender, EventArgs e)
        {
            Server.Transfer("ViewPage.aspx");
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RegisterDatabase.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("FirstName", FirstText.Text);
                cmd.Parameters.AddWithValue("LastName", LastText.Text);
                cmd.Parameters.AddWithValue("Email", EmailText.Text);
                cmd.Parameters.AddWithValue("PasswordVal", PasswText.Text);
                cmd.Parameters.AddWithValue("Phone", PhoneText.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);          

                FirstText.Text = "";
                LastText.Text = "";
                EmailText.Text = "";
                PasswText.Text = "";
                PhoneText.Text = "";

            }
            
            catch (Exception ex)
            {

                if (FirstText.Text == "" || LastText.Text == "" || PasswText.Text == "" || EmailText.Text == "" || PhoneText.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter All Fields')", true);
                    FirstText.Focus();
                    return;
                }

                if (FirstText.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter First Name')", true);
                    FirstText.Focus();
                    return;
                }
                else if (FirstText.Text.Length > 20)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Too Long First Name')", true);
                    FirstText.Focus();
                    return;
                }

                if (LastText.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Last Name')", true);
                    LastText.Focus();
                    return;
                }
                else if (LastText.Text.Length > 20)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Too Long Last Name')", true);
                    LastText.Focus();
                    return;
                }

                if (EmailText.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Email')", true);
                    EmailText.Focus();
                    return;
                }
                else if (!Regex.Match(EmailText.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").Success)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong email format')", true);
                    EmailText.Focus();
                    return;
                }

                if (PasswText.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Password')", true);
                    PasswText.Focus();
                    return;
                }
                else if (PasswText.Text.Length > 10)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Too Long Password')", true);
                    PasswText.Focus();
                    return;
                }

                if (PhoneText.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Phone')", true);
                    PhoneText.Focus();
                    return;
                }
                else if (PhoneText.Text.Length > 10)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Too Long Phone')", true);
                    PhoneText.Focus();
                    return;
                }
                else if (!Regex.Match(PhoneText.Text, @"^([0-9]{10})$").Success)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Phone Number')", true);
                    PhoneText.Focus();
                    return;
                }

                if (ex.Message.Contains("UNIQUE KEY constraint"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The Email is aleady registered!')", true);
                    EmailText.Focus();
                    return;
                }

                Response.AddHeader("REFRESH", "1;URL=RegisterPage.aspx");
            }
            
            
        }

    }
}