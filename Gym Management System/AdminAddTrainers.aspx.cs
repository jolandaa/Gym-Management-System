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
    public partial class AdminAddTrainer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Admin")
            {
                Response.Redirect("LogIn.aspx");
            }
        }

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


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("select * from TblMembers where email = @email", con);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmd = new SqlCommand("select * from TblTrainers where email = @email", con);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                SqlDataAdapter da2 = new SqlDataAdapter(cmd);

                DataTable dt2 = new DataTable();

                da2.Fill(dt2);

                cmd = new SqlCommand("select * from TblAdmin where email = @email", con);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                SqlDataAdapter da3 = new SqlDataAdapter(cmd);

                DataTable dt3 = new DataTable();

                da3.Fill(dt3);

                if (dt.Rows.Count >= 1 || dt2.Rows.Count >= 1 || dt3.Rows.Count >= 1)
                {
                    Response.Write("<script>alert('Email Id Already Used..')</script>");
                }
                else
                {

                    cmd = new SqlCommand("insert into TblTrainers (name, address, contactno, gender, dob, email, city, state, salary,password,doj) VALUES (@name, @address, @contactno, @gender, @dob, @email, @city, @state, @salary, @password, @doj)", con);

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtContact.Text);
                    cmd.Parameters.AddWithValue("@gender", rbtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(txtDob.Text));
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@state", txtState.Text);
                    cmd.Parameters.AddWithValue("@doj", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@salary", Convert.ToInt32(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@password",encryption(txtPass.Text));
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script>alert('Trainer Inserted Successfully..')</script>");

                    Server.Transfer("AdminViewTrainers.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please Enter Right Information..)</script>");
            }
        }
    }
}