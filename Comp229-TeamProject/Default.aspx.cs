using System;
using System.Collections.Generic;
using System.Data;
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
            SqlDataAdapter command = new SqlDataAdapter("select * from Books where TypeofBook='Novel'", connection);
            SqlDataAdapter command1 = new SqlDataAdapter("select * from Books where TypeofBook='AudioBook'", connection);
            SqlDataAdapter command2 = new SqlDataAdapter("select * from Books where TypeofBook='ebook'", connection);
            try
            {

                connection.Open();
                DataTable dt = new DataTable();
                command.Fill(dt);
                novels.DataSource = dt;
                novels.DataBind();

                DataTable dt1 = new DataTable();
                command.Fill(dt1);
                audiobooks.DataSource = dt1;
                audiobooks.DataBind();

                DataTable dt2 = new DataTable();
                command.Fill(dt2);
                ebooks.DataSource = dt2;
                ebooks.DataBind();


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