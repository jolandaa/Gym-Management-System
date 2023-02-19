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
    public partial class AdminAllocateTrainer : System.Web.UI.Page
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

            cmd = new SqlCommand("select * from TblTrainerAllocation where trainerid = @traineremail and memberid = @memberemail", con);

            cmd.Parameters.AddWithValue("@traineremail", DropDownTrainer.SelectedValue);

            cmd.Parameters.AddWithValue("@memberemail", DropDownMember.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                Response.Write("<script>alert('Already Allocated..')</script>");
            }
            else
            {
                cmd = new SqlCommand("insert into TblTrainerAllocation (trainerid,memberid) values (@traineremail,@memberemail)", con);

                cmd.Parameters.AddWithValue("@traineremail", DropDownTrainer.SelectedValue);

                cmd.Parameters.AddWithValue("@memberemail", DropDownMember.SelectedValue);

                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Allocation Successfully..')</script>");
            }

            con.Close();
        }

      
    }
}