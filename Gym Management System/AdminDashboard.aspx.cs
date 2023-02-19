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
using System.Web.UI.DataVisualization.Charting;

namespace Gym_Management_System
{
    public partial class AdminDashboard : System.Web.UI.Page
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

            try
            {

                getCounting();
            }
            catch(Exception ex)
            { }
        }

        public void getCounting()
        {

            con.Open();

            da = new SqlDataAdapter("select * from TblMembers", con);

            dt = new DataTable();

            da.Fill(dt);

            LabelTotalMembers.Text = dt.Rows.Count.ToString();

            da = new SqlDataAdapter("select * from TblTrainers", con);

            dt = new DataTable();

            da.Fill(dt);

            LabelTotalTrainer.Text = dt.Rows.Count.ToString();

            da = new SqlDataAdapter("select isnull(sum(totalfee),0) as totalfee, isnull(sum(receivedfee),0) as receivedfee from TblMembers", con);

            Series series = Chart1.Series["Series1"];

            dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    series.Points.AddXY("Total Fee", dr["totalfee"].ToString());
                    series.Points.AddXY("Total Received Fee", dr["receivedfee"].ToString());
                    series.Points.AddXY("Total Remaing Fee", (Convert.ToInt32(dr["totalfee"].ToString()) - Convert.ToInt32(dr["receivedfee"].ToString())).ToString());
                    
                    LabelTotalFee.Text = dr["totalfee"].ToString();
                    LabelReceivedFee.Text = dr["receivedfee"].ToString();
                    LabelRamaingFee.Text = (Convert.ToInt32(dr["totalfee"].ToString()) - Convert.ToInt32(dr["receivedfee"].ToString())).ToString();
                }
            }

            da = new SqlDataAdapter("select isnull(count(*),0) as totalmembers from TblMembers", con);

            Series s2 = Chart2.Series["Series1"];

            dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    s2.Points.AddXY("Total Members", dr["totalmembers"].ToString());
                }
            }

            da = new SqlDataAdapter("select isnull(count(*),0) as totaltrainers from TblTrainers", con);

            dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    s2.Points.AddXY("Total Trainers", dr["totaltrainers"].ToString());
                }
            }


            da = new SqlDataAdapter("select * from TblMembers where DATEDIFF(day,CONVERT(date, CONVERT(VARCHAR(10), getdate(), 103), 103),CONVERT(date, expiredate, 103)) <= 0", con);

            dt = new DataTable();

            da.Fill(dt);

            LabelExpireMemberShip.Text = dt.Rows.Count.ToString();

            con.Close();


            da = new SqlDataAdapter("select count(*) as totalmembers from TblMembers where DATEDIFF(day,CONVERT(date, CONVERT(VARCHAR(10), getdate(), 103), 103),CONVERT(date, expiredate, 103)) <= 0", con);

            Series s3 = Chart3.Series["Series1"];

            dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    s3.Points.AddXY("Expired MemberShip", dr["totalmembers"].ToString());
                }
            }


            da = new SqlDataAdapter("select count(*) as totalmembers from TblMembers where DATEDIFF(day,CONVERT(date, CONVERT(VARCHAR(10), getdate(), 103), 103),CONVERT(date, expiredate, 103)) > 0", con);

            dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    s3.Points.AddXY("Continue MemberShip", dr["totalmembers"].ToString());
                }
            }


        }
    }
}