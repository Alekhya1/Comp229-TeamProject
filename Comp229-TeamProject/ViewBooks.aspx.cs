using System;
using System.Collections.Generic;
using System.Configuration;
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
                command = new SqlCommand("select * from EBooks where ItemName=@ItemName", connection);
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
                        nameofitem.Text = "Movie Name  :"+ reader["ItemName"].ToString();
                        UniqueNo.Text = "ASINno      :"+reader["ASINno"].ToString();
                        RDate.Text =    "Release Date:"+reader["ReleaseDate"].ToString();
                        Description.Text = "Description :"+reader["ShortDescription"].ToString();
                        discont.Attributes["style"] = "text-align: center;";
                    }
                    if (itemvalue == 2)
                    {
                       
                    }

                    if (itemvalue == 3)
                    {
                       
                    }
                }


            }
            finally
            {
                connection.Close();
            }


        }
    }
}
