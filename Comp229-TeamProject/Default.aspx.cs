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

            int items_added =Added_items();
            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Comp229TeamProject;Integrated Security=True");
            SqlCommand command = new SqlCommand("select count(*) from items where ItemStatus='owned'", connection);
            SqlCommand command1 = new SqlCommand("select count(*) from items where ItemStatus='wanted'", connection);
            SqlCommand command2 = new SqlCommand("select count(*) from items where ItemStatus='loaned'", connection);
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                OwnedItems.Text = reader["count(*)"].ToString();
                reader.Close();
                WantedItems.Text = reader["count(*)"].ToString();
                reader.Close();
                LoanedItems.Text= reader["count(*)"].ToString();
                reader.Close();
            }


            finally
            {
                connection.Close();
            }
            recentitems.Text = items_added.ToString();

        }

        protected int Added_items()
        {

            int sum = 0;
            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Comp229TeamProject;Integrated Security=True");
            SqlCommand command = new SqlCommand("select count(*) from Books where date in(select max(date) from books)", connection);
            SqlCommand command1 = new SqlCommand("select count(*) from Books where date in(select max(date) from books)", connection);
            SqlCommand command2 = new SqlCommand("select count(*) from Books where date in(select max(date) from books)", connection);
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                sum = sum + Convert.ToInt32(reader["count(*)"]);
                reader.Close();
                reader = command1.ExecuteReader();
                sum = sum + Convert.ToInt32(reader["count(*)"]);
                reader.Close();
                reader = command2.ExecuteReader();
                sum = sum + Convert.ToInt32(reader["count(*)"]);
                reader.Close();
            }


            finally
            {
                connection.Close();
            }
            return sum;
        }


        protected void LogIn_Click(object sender, EventArgs e)
        { 

        }
    }
}