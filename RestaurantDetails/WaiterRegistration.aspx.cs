using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantDetails
{
    public partial class WaiterRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if request is NOT a post back
                if (!Page.IsPostBack)
                {
                    //create instane of middle layer business object
                    Restaurant restaurant = new Restaurant();
                    //retrieve departments from middle layer into a DataTable
                    DataTable dt = restaurant.getAllRestaurants();

                    //check if query was successful
                    if (dt != null)
                    {
                        //set DropDownList's data source to the DataTable
                        ddlRestaurants.DataSource = dt;
                        //assign DepartmentID database field to the value property
                        ddlRestaurants.DataValueField = "RestaurantID";
                        //assign DepartmentName database field to the text property
                        ddlRestaurants.DataTextField = "RestaurantName";
                        //bind data
                        ddlRestaurants.DataBind();
                    }
                }
            }
            catch
            {
                lblError.Text = "Database connection error - cannot display Restaurants.";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //validate input
                if (txtUsername.Text.Length < 5 || txtUsername.Text.Length > 20)
                {
                    lblError.Text = "Entered username length is not less than 5 or greater than 20 characters";
                }
                else if (txtPassword.Text.Length < 6)
                {
                    lblError.Text = "Password must be at least 6 characters long.";
                }
                else if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
                {
                    lblError.Text = "Please confirm password.";
                }
                else if (txtRealName.Text.Equals(""))
                {
                    lblError.Text = "Please enter your full name.";
                }
                else
                {
                    try
                    {
                        //create instane of middle layer business object
                        RestaurantUser user = new RestaurantUser();

                        //set username property, so it  can be used as a parameter for the query
                        user.UserName = txtUsername.Text;
                        user.EmailAddress = txtEmailAddress.Text;

                        //check if the username exists
                        if (user.userNameExists())
                        {
                            //already exists so output error
                            lblError.Text = "Username already exists, please select another";
                        }
                        else if (user.emailaddressExists())
                        {
                            //already exists so output error
                            lblError.Text = "EmailAddress already exists, please enter another one";
                        }
                        else
                        {
                            //INSERT NEW USER...   

                            //set properties, so it can be used as a parameter for the query
                            user.UserName = txtUsername.Text;
                            user.UserPassword = txtPassword.Text;
                            user.RealName = txtRealName.Text;
                            user.EmailAddress = txtEmailAddress.Text;
                            string selectedvalue = rblist1.SelectedValue;
                            user.RoleId = Int32.Parse(selectedvalue); ;
                            user.RestaurantId = Int32.Parse(ddlRestaurants.SelectedValue);

                            //attempt to add a User and test if it is successful
                            if (user.adduser())
                            {
                                //redirect user to login page
                                System.Threading.Thread.Sleep(3000);
                                Response.Redirect("~/UserLogin.aspx");
                            }
                        }
                    }
                    catch
                    {
                        //exception thrown so display error
                        lblError.Text = "Database connection error - failed to insert record.";
                    }

                }
            }
            catch
            {
                //exception thrown so display error
                lblError.Text = "Database connection error - failed to insert record.";
            }
        }
    }
}