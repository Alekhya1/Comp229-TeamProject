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
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["id"];
            
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

           int cvalue = Convert.ToInt32(CurrentStatus.SelectedValue);
            int ivalue = Convert.ToInt32(ItemStatus.SelectedValue);
            string cname, iname;

            if(cvalue==1) { cname = "Completed"; }
            if (cvalue == 2) { cname = "Yet To Begin"; }
            if (cvalue == 3) { cname = "In Progree"; }

            if (ivalue == 1) { cname = "Loaned"; }
            if (ivalue == 2) { cname = "Wanted"; }
            if (ivalue == 3) { cname = "Owned"; }

            int itemvalue = Convert.ToInt32(Request.QueryString["id"]);
            string connectionString = ConfigurationManager.ConnectionStrings["anithasystem"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("Update BStatus set Cstatus=@Cstatus,ItemStatus=@ItemStatus",connection);
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