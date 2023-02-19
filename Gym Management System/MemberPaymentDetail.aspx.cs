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
    public partial class MemberPaymentDetail : System.Web.UI.Page
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


            if (!IsPostBack)
            {
                setData();
            }
        }

        public void setData()
        {


            con.Open();

        

            cmd = new SqlCommand("select * from TblMembers where memberid = @id", con);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Session["MemberId"]));

            da = new SqlDataAdapter(cmd);

            dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtMonth.Text = dr["month"].ToString();
                    txtOneMonthFee.Text = dr["onemonthfee"].ToString();
                    txtPaidFee.Text = dr["receivedfee"].ToString();
                    txtRemainingFee.Text = (Convert.ToInt32(dr["totalfee"].ToString()) - Convert.ToInt32(dr["receivedfee"].ToString())).ToString();
                    txtTotalFee.Text = dr["totalfee"].ToString();
                  
                }
            }

            con.Close();

        }
    }
}