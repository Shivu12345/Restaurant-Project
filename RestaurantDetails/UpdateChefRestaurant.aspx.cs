using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantDetails
{
    public partial class UpdateChefRestaurant : System.Web.UI.Page
    {
        string RealName;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.Count == 0)
                {
                    Response.Redirect("~/UserLogin.aspx");
                }
                else
                {
                    RealName = (string)Session["RealName"];
                    //if request is NOT a post back
                    if (!Page.IsPostBack)
                    {
                        Restaurant restaurant = new Restaurant();
                        restaurant.RestaurantId = Int32.Parse(Session["RestaurantID"].ToString());

                        DataTable getAllRestaurants_dt = restaurant.getsingleRestaurant();
                        DataTable getRestaurants_dt = restaurant.getRestaurants();
                        if (getAllRestaurants_dt.Rows.Count > 0 && getRestaurants_dt.Rows.Count > 0)
                        {
                            txtRestaurant.Text = getAllRestaurants_dt.Rows[0]["RestaurantName"].ToString();
                            // set DropDownList's data source to the DataTable
                            lstRestaurants.DataSource = getRestaurants_dt;
                            //assign CoursetID database field to the value property
                            lstRestaurants.DataValueField = "RestaurantID";
                            //assign CourseName database field to the text property
                            lstRestaurants.DataTextField = "RestaurantName";
                            //bind data
                            lstRestaurants.DataBind();
                        }
                    }
                }

            }
            catch
            {
                lblError.Text = "Database connection error - cannot display Restaurant.";
            }

            //try
            //{
            //    //if request is NOT a post back
            //    if (!Page.IsPostBack)
            //    {
            //        //create instane of middle layer business object
            //        Restaurant restaurant = new Restaurant();

            //        string RealName = (string)Session["RealName"];
            //        int RestaurantID = Int32.Parse(Session["RestaurantID"].ToString());
            //        restaurant.RestaurantId = RestaurantID;

            //        //retrieve departments from middle layer into a DataTable
            //        DataTable dt = restaurant.getAllRestaurants();

            //        //check if query was successful
            //        if (dt != null)
            //        {
            //            //set DropDownList's data source to the DataTable
            //            lstRestaurants.DataSource = dt;
            //            //assign CoursetID database field to the value property
            //            lstRestaurants.DataValueField = "RestaurantID";
            //            //assign CourseName database field to the text property
            //            lstRestaurants.DataTextField = "RestaurantName";
            //            //bind data
            //            lstRestaurants.DataBind();
            //        }
            //    }
            //}
            //catch
            //{
            //    lblError.Text = "Database connection error - cannot display Restaurants.";
            //}
        }

        private void UpdatedRestaurantList()
        {
            RestaurantUser user = new RestaurantUser();
            user.RealName = RealName; 

            // Fetch data from the restaurantUser table to load all the data 
            DataTable dt_chef_details = user.getUserDetails();
            if (dt_chef_details.Rows.Count > 0)
            {
                // assign session with the new updated data 
                Session["UserID"] = dt_chef_details.Rows[0]["UserID"].ToString();
                Session["UserName"] = dt_chef_details.Rows[0]["UserName"].ToString();
                Session["UserPassword"] = dt_chef_details.Rows[0]["UserPassword"].ToString();
                Session["RealName"] = dt_chef_details.Rows[0]["RealName"].ToString();
                Session["EmailAddress"] = dt_chef_details.Rows[0]["EmailAddress"].ToString();
                Session["RoleID"] = dt_chef_details.Rows[0]["RoleID"].ToString();         
                Session["RestaurantID"] = dt_chef_details.Rows[0]["RestaurantID"].ToString();
                
                int RestaurantID = Convert.ToInt32(Session["RestaurantID"].ToString());
                Restaurant restaurant = new Restaurant();
                restaurant.RestaurantId = RestaurantID;

                // Fetch chef restaurant and all the other restaurants present

                DataTable dt_restaurant = restaurant.getsingleRestaurant();

                DataTable dt_all_restaurant = restaurant.getRestaurants();

                if (dt_restaurant.Rows.Count > 0 &&  dt_all_restaurant.Rows.Count > 0)
                {
                    txtRestaurant.Text = dt_restaurant.Rows[0]["RestaurantName"].ToString();
                    lstRestaurants.DataSource = dt_all_restaurant;

                    //assign WorkerID database field to the value property

                    lstRestaurants.DataValueField = "RestaurantID";

                    //assign WorkerName database field to the text property
                    lstRestaurants.DataTextField = "RestaurantName";

                    //bind data
                    lstRestaurants.DataBind();
                    System.Threading.Thread.Sleep(3000);
                    lblError.Text = "Restaurants listbox Updated";
                    lblError.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("~/UserAccount.aspx?UpdateSuccess=Restaurant");

                }
                else
                {
                    lblError.Text = "Database connection error - cannot display RestaurantNames.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblError.Text = "Database connection error while updating.";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }





        protected void btnUpdateRestaurant_Click(object sender, EventArgs e)
        {
        
                if (lstRestaurants.SelectedIndex != -1)
                {
                    //create instane of middle layer business object
                    RestaurantUser user = new RestaurantUser();
                    //set property, so it can be used as a parameter for the query
                    user.UserId = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                    user.RestaurantId = int.Parse(lstRestaurants.SelectedValue);
                    if (user.updateRestaurantByUserId())
                    {
      //                  System.Threading.Thread.Sleep(4000);
                        lblError.Text = "Restaurant Updated Successfully";
                        lblError.ForeColor = System.Drawing.Color.Green;
                        UpdatedRestaurantList();

                        //string RestaurantID = (string)Session["RestaurantID"];
                        //System.Threading.Thread.Sleep(4000);

                        //txtRestaurant.Text = user.getRestaurantUsingRestaurantID();
                        //lblError.Text = "Restaurant Updated Successfully";
                        //lblError.ForeColor = System.Drawing.Color.Green;
                        //Response.Redirect("~/UserAccount.aspx?UpdateSuccess=Restaurant");
                    }
                    else
                    {
                        //exception thrown so display error
                        lblError.Text = "Database connection error - failed to update record.";
                    }
                }
                else
                {
                    lblError.Text = "Select a Restaurant to update";
                }
        
        }
    }
}