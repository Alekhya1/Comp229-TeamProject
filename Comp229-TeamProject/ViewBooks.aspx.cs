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
    public partial class ViewBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int itemvalue = Convert.ToInt32(Request.QueryString["id2"]);
            int item = Convert.ToInt32(Request.QueryString["id2"]);
            string itemname = Request.QueryString["id"];
            string connectionString = ConfigurationManager.ConnectionStrings["anithasystem"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("null");
            SqlCommand command1 = new SqlCommand("null");

            if (itemvalue == 1)
            {
                command = new SqlCommand("select * from Movies where ItemName=@ItemName", connection);
                command.Parameters.Add("@ItemName", System.Data.SqlDbType.VarChar);
                command.Parameters["@ItemName"].Value = itemname;
            }
            else if (itemvalue == 2)
            {
                command = new SqlCommand("select * from Games where ItemName=@ItemName", connection);
                command.Parameters.Add("@ItemName", System.Data.SqlDbType.VarChar);
                command.Parameters["@ItemName"].Value = itemname;
            }

            else if (itemvalue == 3)
            {
                command = new SqlCommand("select * from EBooks books,SAuthor authors,ISBN isbn where books.BookID = authors.BookID and books.BookID = isbn.BookID and ItemName = @ItemName", connection);
                command.Parameters.Add("@ItemName", System.Data.SqlDbType.VarChar);
                command.Parameters["@ItemName"].Value = itemname;
            }

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (itemvalue == 1)
                    {

                        command1 = new SqlCommand("select users.FirstName,users.LastName,Review.Rating,Review.Comments from SUsers users,SReview Review where users.UserID=Review.UserID and Review.ItemId=@ItemId", connection);
                        command1.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command1.Parameters["@ItemId"].Value = Convert.ToInt32(reader["MovieId"]);

                        nameofitem.Text = "<b>Movie Name  </b>:" + reader["ItemName"].ToString();
                        UniqueNo.Text = "<b> ASINno </b>     :" + reader["ASINno"].ToString();
                        RDate.Text = "<b> Release Date: </b>" + reader["ReleaseDate"].ToString();
                        Description.Text = "<b> Description : </b>" + reader["ShortDescription"].ToString();
                        Others.Text = "";
                    }

                    if (itemvalue == 2)
                    {

                        command1 = new SqlCommand("select users.FirstName,users.LastName,Review.Rating,Review.Comments from SUsers users,SReview Review where users.UserID=Review.UserID and Review.ItemId=@ItemId", connection);
                        command1.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command1.Parameters["@ItemId"].Value = Convert.ToInt32(reader["GameID"]);
                    }

                    if (itemvalue == 3)
                    {

                        command1 = new SqlCommand("select users.FirstName,users.LastName,Review.Rating,Review.Comments from SUsers users,SReview Review where users.UserID=Review.UserID and Review.ItemId=@ItemId", connection);
                        command1.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command1.Parameters["@ItemId"].Value = Convert.ToInt32(reader["BookId"]);

                    }

                }
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter(command1);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Reviewdetails.DataSource = dt;
                Reviewdetails.DataBind();
            }

           
            finally
            {
                connection.Close();
            }


        }
    }
}
