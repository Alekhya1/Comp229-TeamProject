using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Comp229TeamProject;Integrated Security=True");
            SqlCommand command = new SqlCommand("select * from Books", connection);
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                //repeaterstudent.DataSource = reader;
                //repeaterstudent.DataBind();
            }


            finally
            {
                connection.Close();
            }
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {

        }
    }
}