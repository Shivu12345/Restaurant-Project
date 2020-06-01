using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantDetails
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = CalculateMD5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCurrentPassword.Text.Length < 6)
                {
                    lblError.Text = "Current password is invalid length.";
                }
                else if (txtNewPassword.Text.Length < 6)
                {
                    lblError.Text = "New password is invalid length.";
                }
                else if (!txtConfirmPassword.Text.Equals(txtNewPassword.Text))
                {
                    lblError.Text = "Please confirm new password.";
                }
                else
                {
                    RestaurantUser user = new RestaurantUser();
                    user.UserId = Int32.Parse(Session["UserID"].ToString());

                    string password = user.getPasswordUsingID();
                    if (verifyMd5Hash(txtCurrentPassword.Text, password))
                    {
                        user.UserPassword = txtNewPassword.Text; //UserId already set

                        if (user.updatePasswordByUserId())
                        {
                            lblError.Text = "Password updated";
                            Response.Redirect("~/UserAccount.aspx?change=success");
                        }
                        else
                        {
                            lblError.Text = "Database connection error - could not update password";
                        }
                    }
                    else
                    {
                        lblError.Text = "Password is incorrect";
                    }
                }
            }
            catch
            {
                lblError.Text = "Current password is incorrect";
            }
        }
    }
}