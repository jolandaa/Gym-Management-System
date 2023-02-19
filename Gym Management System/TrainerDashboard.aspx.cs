using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration.Install;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Gym_Management_System
{
    public partial class TrainerDashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        SqlDataAdapter da = null;

        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Trainer")
            {
                Response.Redirect("LogIn.aspx");
            }

            getCounting();

            LabelTrainerName.Text = Session["TrainerName"].ToString();
        }

        public void getCounting()
        {
            con.Open();

            da = new SqlDataAdapter("select * from TblTrainerAllocation where trainerid = "+Convert.ToInt32(Session["TrainerId"])+"", con);

            dt = new DataTable();

            da.Fill(dt);

            LabelTotalMembers.Text = dt.Rows.Count.ToString();

            con.Close();
        }
    }
}