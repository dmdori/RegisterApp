using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebApplication1
{

    public partial class ViewPage : System.Web.UI.Page
    {
        //string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RegisterDatabase.mdf;Integrated Security=True";
        string connStr = ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewbind();
            }
        }
        protected void GridViewbind()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("SelectUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    sqlAdapter.Fill(dataTable);
                    con.Close();

                    if (dataTable.Rows.Count > 0)
                    {
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                    else
                    {
                        dataTable.Rows.Add(dataTable.NewRow());
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                        int columncount = GridView1.Rows[0].Cells.Count;
                        GridView1.Rows[0].Cells.Clear();
                        GridView1.Rows[0].Cells.Add(new TableCell());
                        GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                        GridView1.Rows[0].Cells[0].Text = "No Records Found";
                    }
                } 
            }
        }
            protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

                using (SqlConnection con = new SqlConnection(connStr)) 
                    {
                    using (SqlCommand cmd = new SqlCommand("DeleteUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", userid);
                    
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close(); 
                    }     
                } 
                this.GridViewbind(); 
            }
            protected void RowEditing(object sender, GridViewEditEventArgs e)
            {
                GridView1.EditIndex = e.NewEditIndex;
                GridViewbind();
            }
            protected void RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                try {
                    int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                    string firstName = Convert.ToString(e.NewValues["FirstName"]);
                    string lastName = Convert.ToString(e.NewValues["LastName"]);
                    string email = Convert.ToString(e.NewValues["Email"]);
                    string passw = Convert.ToString(e.NewValues["PasswordVal"]);
                    int phone = Convert.ToInt32(e.NewValues["Phone"]);

                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("UpdateUser", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", userId);
                            cmd.Parameters.AddWithValue("@FirstName", firstName);
                            cmd.Parameters.AddWithValue("@LastName", lastName);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@PasswordVal", passw);
                            cmd.Parameters.AddWithValue("@Phone", phone);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        
                    }
                    GridView1.EditIndex = -1;
                    GridViewbind();
                }
                catch (Exception ex) {
                    if (ex.Message.Contains("UNIQUE KEY"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The Email is aleady registered!')", true);
                        return;
                    }
            }     
            }
            protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridViewbind();
            }
            protected void RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
                GridView1.EditIndex = -1;
                GridViewbind();
            }

            protected void BtnRegister_click(object sender, EventArgs e)
            {
                Server.Transfer("RegisterPage.aspx");
            }
    }
}