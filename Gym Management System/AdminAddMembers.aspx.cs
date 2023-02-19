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
    public partial class AdminAddMembers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"] != "Admin")
            {
                Response.Redirect("LogIn.aspx");
            
            
            }

            if (!IsPostBack) { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
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
                   

                    cmd = new SqlCommand("insert into TblMembers(name, address, contactno, gender, dob, email, city, state, month, onemonthfee, totalfee, receivedfee, password, doj, expiredate) VALUES (@name, @address, @contactno, @gender, @dob, @email, @city, @state, @month, @onemonthfee, @totalfee, @receivedfee, @password, @doj, @expiredate)", con);
                    

                //   cmd = new SqlCommand("insert into TblMembers(name, address, contactno, gender, email, city, state, height, weight, month, onemonthfee, totalfee, receivedfee, password, fromtime, totime) VALUES (@name, @address, @contactno, @gender, @email, @city, @state, @height, @weight, @month, @onemonthfee, @totalfee, @receivedfee, @password, @fromtime, @totime)", con);


                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtContact.Text);
                    cmd.Parameters.AddWithValue("@gender", rbtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(txtDob.Text).ToShortDateString());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@state", txtState.Text);
                    //cmd.Parameters.AddWithValue("@height", Convert.ToDecimal(txtHeight.Text));
                    //cmd.Parameters.AddWithValue("@weight", Convert.ToDecimal(txtWeight.Text));
                    cmd.Parameters.AddWithValue("@month", Convert.ToInt32(txtMonth.Text));
                    cmd.Parameters.AddWithValue("@onemonthfee", Convert.ToInt32(txtOneMonthFee.Text));
                    cmd.Parameters.AddWithValue("@totalfee", Convert.ToInt32(txtTotalFee.Text));
                    cmd.Parameters.AddWithValue("@receivedfee", Convert.ToInt32(txtReceivedFee.Text));
                    //cmd.Parameters.AddWithValue("@fromtime", txtFrom.Text);
                    //cmd.Parameters.AddWithValue("@totime", txtTo.Text);
                    cmd.Parameters.AddWithValue("@doj", DateTime.Now.Date.ToShortDateString());
                    cmd.Parameters.AddWithValue("@expiredate", DateTime.Now.Date.AddMonths(Convert.ToInt32(txtMonth.Text)).ToShortDateString());
                    cmd.Parameters.AddWithValue("@password", encryption(txtPass.Text));

                    cmd.ExecuteNonQuery();


                cmd = new SqlCommand("SELECT * FROM TblMembers");


                SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM TblMembers ORDER BY memberid DESC", con);

                DataTable dt4 = new DataTable();

                da4.Fill(dt4);

                int lastId = Convert.ToInt32(dt4.Rows[0]["memberid"]);

                Console.WriteLine(lastId);


                cmd = new SqlCommand("insert into TblMeasurements(memberid, height, weight, BMI) VALUES (@memberid, @height, @weight, @BMI)", con);
                cmd.Parameters.AddWithValue("@memberid", lastId);
                cmd.Parameters.AddWithValue("@height", Convert.ToInt32(txtHeight.Text));
                cmd.Parameters.AddWithValue("@weight", Convert.ToInt32(txtWeight.Text));
                cmd.Parameters.AddWithValue("@BMI", Convert.ToInt32(txtBMI.Text));
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("insert into TblMemberPlan(memberid, fromtime, totime) VALUES (@memberid, @fromtime, @totime)", con);
                cmd.Parameters.AddWithValue("@memberid", lastId);
                cmd.Parameters.AddWithValue("@fromtime", txtFrom.Text);
                cmd.Parameters.AddWithValue("@totime", txtTo.Text);
                cmd.ExecuteNonQuery();

                con.Close();

                    Response.Write("<script>alert('Member Inserted Successfully..')</script>");

                    Server.Transfer("AdminViewMembers.aspx");
                }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('Please Enter Right Information..)</script>");
            //}
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

        protected void txtMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalFee.Text = (Convert.ToInt32(txtMonth.Text) * Convert.ToInt32(txtOneMonthFee.Text)).ToString();
            }
            catch (Exception ex)
            { 
                
            }
        }

        protected void txtOneMonthFee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalFee.Text = (Convert.ToInt32(txtMonth.Text) * Convert.ToInt32(txtOneMonthFee.Text)).ToString();
            }
            catch (Exception ex)
            {

            }
        }   
    }
}