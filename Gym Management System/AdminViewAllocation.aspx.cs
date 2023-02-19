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
    public partial class AdminViewAllocation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Admin")
            {
                Response.Redirect("LogIn.aspx");
            }

            getAllocation("");
        }

        public void getAllocation(string SearchOffer)
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select TblTrainers.email as temail,TblTrainers.trainerid, TblMembers.email as memail,TblMembers.memberid from TblTrainerAllocation left join TblTrainers on TblTrainers.trainerid = TblTrainerAllocation.trainerid left join TblMembers on TblMembers.memberid = TblTrainerAllocation.memberid", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            RepeaterDB.DataSource = dt;

            RepeaterDB.DataBind();

            con.Close();
        }
    }
}