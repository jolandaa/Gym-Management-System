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
using System.Security.Cryptography;
using System.Text;

namespace Gym_Management_System
{
    public partial class LogIn : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        SqlDataAdapter da = null;

        DataTable dt = null;

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] encrypt;

            UTF8Encoding encode = new UTF8Encoding();

            encrypt = md5.ComputeHash(encode.GetBytes(password));

            StringBuilder encryptdate = new StringBuilder();

            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdate.Append(encrypt[i].ToString());
            }

            return encryptdate.ToString();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {

                if (Session["User"].ToString() == "Admin")
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
                else if (Session["User"].ToString() == "Trainer")
                {
                    Response.Redirect("TrainerDashboard.aspx");
                }
                else if (Session["User"].ToString() == "Member")
                {
                    Response.Redirect("MemberDashboard.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("select * from TblMembers where email = @email and password = @pass", con);

            cmd.Parameters.AddWithValue("@email", txtEmail.Text);

            cmd.Parameters.AddWithValue("@pass",encryption(txtPass.Text));

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                Session["User"] = "Member";

                foreach (DataRow dr in dt.Rows)
                {
                    Session["MemberId"] = dr["memberid"].ToString();

                    Session["MemberName"] = dr["name"].ToString();

                }
                Session["Email"] = txtEmail.Text;

                Response.Redirect("MemberDashboard.aspx");
            }
            else
            {
                cmd = new SqlCommand("select * from TblTrainers where email = @email and password = @pass", con);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                cmd.Parameters.AddWithValue("@pass",encryption(txtPass.Text));

                SqlDataAdapter da2 = new SqlDataAdapter(cmd);

                DataTable dt2 = new DataTable();

                da2.Fill(dt2);

                if (dt2.Rows.Count == 1)
                {


                    Session["User"] = "Trainer";

                    Session["Email"] = txtEmail.Text;

                    foreach (DataRow dr in dt2.Rows)
                    {
                        Session["TrainerId"] = dr["trainerid"].ToString();

                        Session["TrainerName"] = dr["name"].ToString();
                    }

                    Response.Redirect("TrainerDashboard.aspx");
                }
                else
                {
                    cmd = new SqlCommand("select * from TblAdmin where email = @email and password = @pass", con);

                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                    SqlDataAdapter da3 = new SqlDataAdapter(cmd);

                    DataTable dt3 = new DataTable();

                    da3.Fill(dt3);

                    if (dt3.Rows.Count == 1)
                    {

                        Session["User"] = "Admin";

                        Session["Email"] = txtEmail.Text;

                        Response.Redirect("AdminDashboard.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Username Or Password')</script>");
                    }
                }

            }

            con.Close();
 
        }
    }
}