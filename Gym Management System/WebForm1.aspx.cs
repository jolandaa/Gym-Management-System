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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        SqlDataAdapter da = null;

        DataTable dt, dt2 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
               getTrainer();
           }
        }

        public void getTrainer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select email from TblTrainers", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownTrainer.DataSource = dt;
            DropDownTrainer.DataBind();
            con.Close();
        }

        protected void DropDownTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownMember.Items.Clear();
            DropDownMember.Items.Add("--Select Member Email--");

            if (DropDownTrainer.SelectedItem.Text != "--Select Trainer Email--")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from TblMembers where memberid in (select memberid from TblTrainerAllocation where trainerid = (select trainerid from TblTrainers where email = '" + DropDownTrainer.SelectedItem.Text + "'))", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownMember.DataSource = dt;
                DropDownMember.DataBind();

                con.Close();
            }
        }

      
    }
}