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
    public partial class adminallocate : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        SqlDataAdapter da = null;

        DataTable dt, dt2 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Admin")
            {
                Response.Redirect("LogIn.aspx");
            }
        }
        protected void btnAllocate_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("select * from TblTrainerAllocation where trainerid = @traineremail", con);

            cmd.Parameters.AddWithValue("@trainerid", DropDownTrainer.SelectedValue);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);


            //SqlCommand cmd2 = new SqlCommand("select a.trainerid from TblTrainerAllocation a,TblTrainers t where t.email = '"+DropDownTrainer.SelectedValue+"' and t.trainerid=a.trainerid ", con);


            //cmd2.Parameters.AddWithValue("@trainerid", DropDownTrainer.SelectedValue);

            /*SqlDataAdapter dab = new SqlDataAdapter(cmd);

            DataTable dt3 = new DataTable();
            dab.Fill(dt3);*/


            SqlCommand cmd1 = new SqlCommand("select * from TblTrainerAllocation where trainerid = (select trainerid from TblTrainers where email= '" + DropDownTrainer.Text + "') ", con);
            cmd1.Parameters.AddWithValue("@membereid", DropDownMember.SelectedValue);


            SqlDataAdapter daa = new SqlDataAdapter(cmd1);

            DataTable dt2 = new DataTable();
            daa.Fill(dt2);


            if (dt.Rows.Count >= 1)
            {

            }
            else
            {
                //cmd = new SqlCommand("insert into TblTrainerAllocation (trainerid,memberid) values (@traineremail,@memberemail)", con);

                //cmd.Parameters.AddWithValue("@traineremail", DropDownTrainer.SelectedValue);

                //cmd.Parameters.AddWithValue("@memberemail", DropDownMember.SelectedValue);

                //cmd.ExecuteNonQuery();

                //Response.Write("<script>alert('Alert..')</script>");
            }

            con.Close();
        }
    }
}