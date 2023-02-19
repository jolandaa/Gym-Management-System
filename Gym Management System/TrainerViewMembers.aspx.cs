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

namespace Gym_Management_System
{
    public partial class TrrainerViewMembers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null || Session["User"] != "Trainer")
            {
                Response.Redirect("LogIn.aspx");
            }

            getUser("");
        }

        public void getUser(string SearchMember)
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select *,CONVERT(VARCHAR(10), dob, 105) as d from TblMembers where memberid in (select memberid from TblTrainerAllocation where trainerid = "+Convert.ToInt32(Session["TrainerId"])+")", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            RepeaterDB.DataSource = dt;

            RepeaterDB.DataBind();

            con.Close();
        }
    }
}