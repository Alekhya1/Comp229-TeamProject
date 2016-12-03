using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         }

        protected void Register_Click(object sender, EventArgs e)
        {
            string fname = FirstName.Text;
            string lname = LastName.Text;
            long phonenumber = Convert.ToInt64(Phone.Text);
            string email = emailid.Text;
            string uname = username.Text;
            string pwd = Password.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["anithasystem"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("insert into Susers(FirstName,LastName,Email,PhoneNo) values(@FirstName,@LastName,@Email,@PhoneNo)",connection);

            command.Parameters.Add("@LastName", SqlDbType.VarChar);
            command.Parameters["@LastName"].Value = lname;

            command.Parameters.Add("@FirstName", SqlDbType.VarChar);
            command.Parameters["@FirstName"].Value = fname;

            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters["@Email"].Value = email;

            command.Parameters.Add("@PhoneNo",SqlDbType.BigInt);
            command.Parameters["@PhoneNo"].Value = phonenumber;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            finally
            {
                connection.Close();
            }

            add_user(fname,lname,uname,pwd);
            Response.Redirect("~/Default.aspx");
        }

        protected void add_user(string fname,string lname,string uname,string pwd )
        {
            int userid = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["anithasystem"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select UserID from SUsers where FirstName=@FirstName and LastName=@LastName", connection);
            command.Parameters.Add("@LastName", SqlDbType.VarChar);
            command.Parameters["@LastName"].Value = lname;

            command.Parameters.Add("@FirstName", SqlDbType.VarChar);
            command.Parameters["@FirstName"].Value = fname;

            try
            {
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userid = Convert.ToInt32(reader["UserID"]);
                }

                reader.Close();
                command = new SqlCommand("insert into Login(UserName,Password,UserID) values(@UserName,@Password,@UserID)",connection);

                command.Parameters.Add("@UserName", SqlDbType.VarChar);
                command.Parameters["@UserName"].Value = uname;

                command.Parameters.Add("@Password", SqlDbType.VarChar);
                command.Parameters["@Password"].Value = pwd;

                command.Parameters.Add("@UserID", SqlDbType.Int);
                command.Parameters["@UserID"].Value = userid;
                command.ExecuteNonQuery();
            }

            finally
            {
                connection.Close();
            }
        }
    }
}