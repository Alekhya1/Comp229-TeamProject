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
            SqlConnection connection = new SqlConnection("Server=DESKTOP-BN12BDD;Initial Catalog=Comp229Assign03;Integrated Security=True");
            SqlCommand command = new SqlCommand("select * from Students", connection);
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
    }
}