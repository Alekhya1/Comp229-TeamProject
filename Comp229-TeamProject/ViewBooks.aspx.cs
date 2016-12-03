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
            SqlCommand command2 = new SqlCommand("null");

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
                command = new SqlCommand("select * from EBooks where ItemName = @ItemName", connection);
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
                        command2 = new SqlCommand("select * from BStatus where ItemID=@ItemID",connection);
                        command2.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command2.Parameters["@ItemId"].Value = Convert.ToInt32(reader["MovieId"]);

                        category.Text = itemvalue.ToString();
                        ItemId.Text = reader["MovieId"].ToString();
                        nameofitem.Text = "<b>Movie Name  </b>:" + reader["ItemName"].ToString();
                        UniqueNo.Text = "<b> ASINno </b>     :" + reader["ASINno"].ToString();
                        RDate.Text = "<b> Release Date: </b>" + reader["ReleaseDate"].ToString();
                        Description.Text = "<b> Description : </b>" + reader["ShortDescription"].ToString();

                    }

                    if (itemvalue == 2)
                    {

                        command1 = new SqlCommand("select users.FirstName,users.LastName,Review.Rating,Review.Comments from SUsers users,SReview Review where users.UserID=Review.UserID and Review.ItemId=@ItemId", connection);
                        command1.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command1.Parameters["@ItemId"].Value = Convert.ToInt32(reader["GameID"]);
                        command2 = new SqlCommand("select * from BStatus where ItemID=@ItemID", connection);
                        command2.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command2.Parameters["@ItemId"].Value = Convert.ToInt32(reader["GameID"]);

                        category.Text = itemvalue.ToString();
                        ItemId.Text = reader["GameID"].ToString();
                        nameofitem.Text = "<b>Movie Name  </b>:" + reader["ItemName"].ToString();
                        UniqueNo.Text = "<b> UPC </b>     :" + reader["UPC"].ToString();
                        RDate.Text = "<b> Release Date: </b>" + reader["ReleaseDate"].ToString();
                        Description.Text = "<b> Platform : </b>" + reader["OnPlatform"].ToString();
                    }

                    if (itemvalue == 3)
                    {
                        
                        
                        int bookid = Convert.ToInt32(reader["BookID"]);
                        command1 = new SqlCommand("select users.FirstName,users.LastName,Review.Rating,Review.Comments from SUsers users,SReview Review where users.UserID=Review.UserID and Review.ItemId=@ItemId", connection);
                        command1.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command1.Parameters["@ItemId"].Value = bookid;
                        command2 = new SqlCommand("select * from BStatus where ItemID=@ItemID", connection);
                        command2.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                        command2.Parameters["@ItemId"].Value = bookid;


                        category.Text = itemvalue.ToString();
                        ItemId.Text = reader["bookid"].ToString();
                        nameofitem.Text = "<b>Movie Name  </b>:" + reader["ItemName"].ToString();
                        pages.Text = "<b> No Of Pages </b>     :" + reader["NoofPages"].ToString();
                        RDate.Text = "<b> Edition Date: </b>" + reader["EditionDate"].ToString();
                        Description.Text = "<b> Description : </b>" + reader["ShortDescription"].ToString();

                        other_details(bookid);
                        

                    }

                }
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter(command1);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    reviewdata.Text = "No Reviews found for this item";
                }
                else
                {
                    Reviewdetails.DataSource = dt;
                    Reviewdetails.DataBind();

                }
                SqlDataReader reader1 = command2.ExecuteReader();
                if (reader1.Read())
                {
                    Cstatus.Text =  "<b>Current Status :</b>"+reader1["CStatus"].ToString();
                    ItemStatus.Text = "<b>Item  Status :</b>"+ reader1["ItemStatus"].ToString();
                }
                else
                {
                    Cstatus.Text = "<b>Current Status :</b>" + " No data Available";
                    ItemStatus.Text = "<b>Item Status :</b>" + " No data Available";

                }
            }

                                    
            finally
            {
                connection.Close();
            }


        }

        protected void other_details(int bookid)
            {


            isbns.Visible = true;
            authors.Visible = true;
             string connectionString = ConfigurationManager.ConnectionStrings["anithasystem"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command1 = new SqlCommand("select * from SAuthor where BookID=@BookID", connection);
            SqlCommand command2 = new SqlCommand("select * from ISBN where BookID=@BookID", connection);
            
            command1.Parameters.Add("@BookID", System.Data.SqlDbType.Int);
            command1.Parameters["@BookID"].Value = bookid;

            command2.Parameters.Add("@BookID", System.Data.SqlDbType.Int);
            command2.Parameters["@BookID"].Value = bookid;

            try
            {
                connection.Open();
                SqlDataReader reader1 = command1.ExecuteReader();
                if (!reader1.Read())
                {
                    authordata.Text = "No data found";
                }
                else
                {
                    authordetails.DataSource = reader1;
                    authordetails.DataBind();
                }
                              reader1.Close();
                reader1 = command2.ExecuteReader();
                if (!reader1.Read())
                {
                    isbndata.Text = "No data Found";   
                }

                else
                {
                    isbndetails.DataSource = reader1;
                    isbndetails.DataBind();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string name = ItemId.Text;
            Response.Redirect("~/Update.aspx?id="+name);
        }
    }
}
