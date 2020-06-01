using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantDetails
{
    public partial class ChefDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int roleid = 1;
            //check if Session has expired or user has not logged in
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                int RestaurantID = Int32.Parse(Session["RestaurantID"].ToString());
                RestaurantUser user = new RestaurantUser();
                Cuisine cuisine = new Cuisine();
                cuisine.RestaurantId = RestaurantID;
                try
                {
                    //if request is NOT a post back
                    if (!Page.IsPostBack)
                    {
                        user.RestaurantId = RestaurantID;
                        user.RoleId = roleid;
                        DataTable dt2 = user.getWaiters();
                        //create instane of middle layer business object
                        Restaurant restaurant = new Restaurant();
                    // retrieve departments from middle layer into a DataTable
                        restaurant.RestaurantId = int.Parse(HttpContext.Current.Session["RestaurantID"].ToString());
                        DataTable dt = restaurant.getsingleRestaurant();

                   // DataTable dt2 = restaurant.getRestaurantUser();

               //         check if query was successful
                        if (dt.Rows.Count>0 && dt2!=null )
                        {
                       // bind data
                            txtRestaurant.Text = dt.Rows[0]["RestaurantName"].ToString();

                            lstWaiters.DataSource = dt2;

                            lstWaiters.DataTextField = "RealName";//bind data

                            lstWaiters.DataValueField = "UserID";

                            lstWaiters.DataBind();
                        }
                        else
                        {
                            lblError.Text = " No data fetched-- Database error";
                        }

                        //retrieve cuisines from middle layer into a DataTable
                        DataTable dt3 = cuisine.bindCuisine();

                        //check if query was successful
                        if (dt3 != null)
                        {
                            //set RepeaterControls's data source to the DataTable
                            rptCuisines.DataSource = dt3;

                            //bind data
                            rptCuisines.DataBind();

                        }
                        else
                        {
                            lblError.Text = "Database connection error - cannot display Cuisines.";
                        }
                    }
                }
                catch
                {
                    lblError.Text = "Database connection error - cannot display Restaurants.";
                }
            }
            
        }

        protected void btnRemoveWaiter_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstWaiters.SelectedItem.Text == null)
                {
                    lblError.Text = "Select Waiter to remove";
                }
                else
                {
                    RestaurantUser user = new RestaurantUser();
                    user.UserId = Int32.Parse(lstWaiters.SelectedValue);
                    //create instane of middle layer business object

                    DataTable dt = user.removeWaiter();
                    if (dt != null)
                    {

                        lblSuccess.Text = "Waiter Successfully Removed";
                        lstWaiters.Items.RemoveAt(lstWaiters.SelectedIndex);
                    }

                    else
                    {
                        lblError.Text = "Datebase Connection Error!!";
                    }
                }
            }
            catch
            {
                lblError.Text = "Database connection error - cannot display Restaurants.";
            }
        }
    }
}