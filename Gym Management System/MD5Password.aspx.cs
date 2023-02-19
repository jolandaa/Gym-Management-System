using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gym_Management_System
{
    public partial class MD5Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPassword.Text = encryption("temp");
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

    }
}