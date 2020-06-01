using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantDetails
{
    public partial class UserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if Session has expired or user has not logged in
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                string Restaurant_update = Request.QueryString["UpdateSuccess"];
                string password_update = Request.QueryString["change"];
                if (Restaurant_update != null)
                {
                    lblUpdateSuccess.Text = "Restaurant updated successfully";
                }
                else if (password_update != null)
                {
                    lblUpdateSuccess.Text = "Password updated successfully";
                }

                if (Page.IsPostBack)
                {
                    lblUpdateSuccess.Text = "";
                }

                //retrieve nesseccary session data, casting into variables
                string RealName = (string)Session["RealName"];
                int RoleID = Int32.Parse(Session["RoleID"].ToString());


                //assign the worker's real name to the welcome label
                lblWelcome.Text = "Welcome " + RealName + ".";

                if (RoleID == 1) //i.e. waiter
                {
                    //    //make Waiter only button visible
                    lblChangePassword.Visible = false;
                    lblUserAccount.Text = "Waiter Account";
                }

                if (RoleID == 2) //i.e. Tutor
                {
                    //make tutor only button visible
                    btnUpdateChefRestaurant.Visible = true;

                    //change Text and PostBack Url properties for tutor
                    btnUserDetails.Text = "Chef Details";
                    lblUserAccount.Text = "Chef Account";
                    btnUserDetails.PostBackUrl = "~/ChefDetails.aspx";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //redirect User to the logout page
            Response.Redirect("~/Logout.aspx");
        }
    }
}