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
    public partial class AdminDelete : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        SqlDataAdapter da = null;

        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Admin")
            {
                Response.Redirect("LogIn.aspx");
            }

            if (!IsPostBack)
            {
                con.Open();

                if (Request.QueryString["tid"] != null && Request.QueryString["mid"] != null)
                {
                    cmd = new SqlCommand("delete from TblTrainerAllocation where trainerid = @tid and memberid = @mid", con);

                    cmd.Parameters.AddWithValue("@tid", Convert.ToInt32(Request.QueryString["tid"]));

                    cmd.Parameters.AddWithValue("@mid", Convert.ToInt32(Request.QueryString["mid"]));

                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Allocation Deleted Successfully..')</script>");

                    Server.Transfer("AdminViewAllocation.aspx");
                }

                if (Request.QueryString["type"].ToString() == "Member" && Request.QueryString["id"] != null)
                {

                    cmd = new SqlCommand("delete from TblTrainerAllocation where memberid = @id", con);


                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["id"]));

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from TblMeasurements where memberid = @id", con);


                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["id"]));

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from TblMembers where memberid = @id",con);
                    
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["id"]));

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from TblTrainerAllocation where memberid = @mid", con);

                    cmd.Parameters.AddWithValue("@mid", Convert.ToInt32(Request.QueryString["id"]));

                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Member Deleted Successfully..')</script>");

                    Server.Transfer("AdminViewMembers.aspx");
                 
                }
                else if (Request.QueryString["type"].ToString() == "Trainer" && Request.QueryString["id"] != null)
                {
                  
                    cmd = new SqlCommand("delete from TblTrainers where trainerid = @id",con);
                    
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["id"]));

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from TblTrainerAllocation where trainer = @tid", con);

                    cmd.Parameters.AddWithValue("@tid", Convert.ToInt32(Request.QueryString["id"]));

                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Trainer Deleted Successfully..')</script>");

                    Server.Transfer("AdminViewTrainers.aspx");
                    
                }

                con.Close();
            }
        }
    }
}