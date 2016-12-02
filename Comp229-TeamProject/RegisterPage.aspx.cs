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

            Response.Redirect("~/Default.aspx");
        }
    }
}