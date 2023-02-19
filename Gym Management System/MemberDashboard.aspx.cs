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
    public partial class MemberDashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        SqlDataAdapter da = null;

        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Member")
            {
                Response.Redirect("LogIn.aspx");
            }

            LabelMemberName.Text = Session["MemberName"].ToString();

            if (!IsPostBack)
            {
                setData();
            }
        }

        public void setData()
        {
           

                con.Open();

                cmd = new SqlCommand("select name from TblTrainers where trainerid = (select trainerid from TblTrainerAllocation where memberid=@id)", con);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Session["MemberId"]));

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        LabelTrainer.Text = dr["name"].ToString();
                    }
                }

                cmd = new SqlCommand("select * from TblMembers where memberid = @id", con);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Session["MemberId"]));

                da = new SqlDataAdapter(cmd);

                dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtMon.Text = dr["mon"].ToString();
                        txtTues.Text = dr["tues"].ToString();
                        txtWed.Text = dr["wed"].ToString();
                        txtThu.Text = dr["thu"].ToString();
                        txtFri.Text = dr["fri"].ToString();
                        txtSatu.Text = dr["satu"].ToString();
                        txtSun.Text = dr["sun"].ToString();

                        LabelDOJ.Text = dr["doj"].ToString();
                        LabelExpireDate.Text = dr["expiredate"].ToString();
                        LabelFrom.Text = dr["fromtime"].ToString();
                        LabelTo.Text = dr["totime"].ToString();
                    }
                }

                con.Close();
            
        }
    }
}