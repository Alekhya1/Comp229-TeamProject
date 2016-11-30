using System;
using System.Collections.Generic;
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
            SqlConnection connection = new SqlConnection("Server=localhost\\SqlExpress;Database=Comp229TeamProject;Integrated Security=True");
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
                        hi.Text = reader["ASICno"].ToString();
                        hii.Text = reader["ShortDescription"].ToString();
                    }
                    if (itemvalue == 2)
                    {
                        hi.Text = reader["UPC"].ToString();
                        hii.Text = reader["OnPlatform"].ToString();
                    }

                    if (itemvalue == 3)
                    {
                        hi.Text = reader["EditionDate"].ToString();
                        hii.Text = reader["NoofPages"].ToString();
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
