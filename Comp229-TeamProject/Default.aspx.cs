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
    public partial class Default : Page
    {
        public int value = 0;

        protected void Page_Load(object sender, EventArgs e)
            {
             
            int items_added =Added_items();
            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Comp229TeamProject;Integrated Security=True");
            SqlCommand command = new SqlCommand("select count(*) as bstat from Bstatus where ItemStatus='Owned'", connection);
            SqlCommand command1 = new SqlCommand("select count(*) as ostat from Bstatus where ItemStatus='Wanted'", connection);
            SqlCommand command2 = new SqlCommand("select count(*) as lstat from Bstatus where ItemStatus='Loaned'", connection);
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                { OwnedItems.Text = reader["bstat"].ToString(); }
                reader.Close();
                reader = command1.ExecuteReader();
                if (reader.Read())
                { WantedItems.Text = reader["ostat"].ToString(); }
                reader.Close();
                reader = command2.ExecuteReader();

                if (reader.Read())
                { LoanedItems.Text = reader["lstat"].ToString(); }
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
            SqlCommand command = new SqlCommand("select count(*) as bookscount from EBooks where EditionDate in(select max(EditionDate) from Ebooks)", connection);
            SqlCommand command1 = new SqlCommand("select count(*) as moviescount from Movies where ReleaseDate in(select max(ReleaseDate) from Movies)", connection);
            SqlCommand command2 = new SqlCommand("select count(*) as gamescount from Games where ReleaseDate in(select max(ReleaseDate) from Games)", connection);
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read()) { sum = sum + Convert.ToInt32(reader["bookscount"]); } 
                        
                reader.Close();
                reader = command1.ExecuteReader();
                if (reader.Read())
                { sum = sum + Convert.ToInt32(reader["moviescount"]); }
                reader.Close();
                reader = command2.ExecuteReader();
                if (reader.Read())
                { sum = sum + Convert.ToInt32(reader["gamescount"]); }
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

        protected void CollectionItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            value = Convert.ToInt32(CollectionItem.SelectedValue);
           SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Comp229TeamProject;Integrated Security=True");
            SqlCommand command = new SqlCommand("null");
            
            if(value==1)
                {
                    command= new SqlCommand("select * from Movies", connection);
                }
            else if(value==2)
            {
                command = new SqlCommand("select * from Games", connection);
            }

            else if(value==3)
            {
                command = new SqlCommand("select * from EBooks", connection);
            }
                
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                displayitemlist.DataSource = reader;
                displayitemlist.DataBind();
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}