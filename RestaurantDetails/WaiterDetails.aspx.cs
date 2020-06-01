using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantDetails
{
    public partial class WaiterDetails : System.Web.UI.Page
    {
        //Declare Instance of Middle Class
        Restaurant restaurant = new Restaurant();
        RestaurantUser user = new RestaurantUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    //retrieve Restaurant from middle layer into a DataTable
                    restaurant.RestaurantId = Int32.Parse(HttpContext.Current.Session["RestaurantID"].ToString());
                    DataTable dt = restaurant.getsingleRestaurant();

                    user.RestaurantId = Int32.Parse(HttpContext.Current.Session["RestaurantID"].ToString());
                    user.RoleId = Int32.Parse(HttpContext.Current.Session["RoleID"].ToString());
                    DataTable dt2 = user.getchefName(2);


                    //check if query was successful
                    if (dt != null)
                    {
                        //set textbox's data source to the DataTable
                        //bind data
                        txtRestaurant.Text = dt.Rows[0]["RestaurantName"].ToString();
                    }
                    else
                    {
                        lblError.Text = "Table is null - cannot display Restaurants.";
                    }

                    if (dt2 != null)
                    {
                        //bind data
                        lstChefs.DataSource = dt2;
                        lstChefs.DataTextField = "RealName";
                        lstChefs.DataValueField = "UserID";
                        lstChefs.DataBind();

                    }
                    else
                    {
                        lblError.Text = "null table cannot display Restaurants.";
                    }
                }
                catch
                {
                    lblError.Text = "Database connection error - cannot display .";
                }
            }

        }

        protected void btnShowEmail_Click(object sender, EventArgs e)
        {
            if (lstChefs.SelectedIndex == -1)
            {
                lblEmail.Text = "No Chef selected";
            }
            else
            {

                int selectedIndex1 = Int32.Parse(lstChefs.SelectedValue);
                user.UserId = selectedIndex1;
                DataTable chef_email = user.getChefEmail();
                if (chef_email.Rows.Count > 0)
                {
                    lblEmail.Text = chef_email.Rows[0]["EmailAddress"].ToString();

                }
                else
                {
                    lblError.Text = "DB returned null datatable";
                }
            }

        }
    }
}