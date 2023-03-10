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
    public partial class AdminViewTrainers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Admin")
            {
                Response.Redirect("LogIn.aspx");
            }

            getUser("");
        }

        public void getUser(string SearchOffer)
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select *,CONVERT(VARCHAR(10), dob, 105) as d from TblTrainers", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            RepeaterDB.DataSource = dt;

            RepeaterDB.DataBind();

            con.Close();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "FindTrainer";
            cmd.CommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                SqlParameter parameter = new SqlParameter("@trainerName", txtName.Text);
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                RepeaterDB.DataSource = rdr;

                RepeaterDB.DataBind();

                con.Close();
            }






        }
    }
}