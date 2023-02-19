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
    public partial class AdminViewMembers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Admin")
            {
                Response.Redirect("LogIn.aspx");
            }

        

           if (Request.QueryString["type"] == "remaining")
           {
                // user RemainingMembership VIEW
                getUser("select * from RemainingMembership");
            }
            else if(Request.QueryString["type"] == "expired")
           {
               getUser("select *,CONVERT(VARCHAR(10), dob, 105) as d,(totalfee - receivedfee) as remainingfee from TblMembers INNER JOIN TblMeasurements ON TblMembers.memberid = TblMeasurements.memberid AND DATEDIFF(day,CONVERT(date, CONVERT(VARCHAR(10), getdate(), 103), 103),CONVERT(date, expiredate, 103)) <= 0 INNER JOIN TblMemberPlan ON TblMembers.memberid = TblMemberPlan.memberid");
           }
           else
           {
                getUser("select *,CONVERT(VARCHAR(10), dob, 105) as d,(totalfee - receivedfee) as remainingfee from TblMembers INNER JOIN TblMeasurements ON TblMembers.memberid = TblMeasurements.memberid INNER JOIN TblMemberPlan ON TblMembers.memberid = TblMemberPlan.memberid");
           }


          
        }

        public void getUser(string query)
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, con);

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
                cmd.CommandText = "FindMember";
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    SqlParameter parameter = new SqlParameter("@memberName", txtName.Text);
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