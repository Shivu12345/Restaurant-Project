using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Restaurants
/// </summary>
public class Restaurant
{
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; }

    private DatabaseConnection dataConn;

    public Restaurant()
    {
        dataConn = new DatabaseConnection();
    }

    public DataTable getAllRestaurants()
    {
        dataConn.addParameter("@Restaurant_id", RestaurantId);
        string command = "Select * FROM Restaurant where not RestaurantID = @Restaurant_id";
        return dataConn.executeReader(command);
    }

    public DataTable getsingleRestaurant()
    {
        string command = "Select RestaurantName FROM Restaurant Where RestaurantID = @Restaurant_id ";
        dataConn.addParameter("@Restaurant_id", RestaurantId);
        return dataConn.executeReader(command);
    }

    public DataTable getRestaurantUser(int RoleId)
    {
        string command = "Select UserID,RealName FROM RestaurantUser Where RoleID = @role_id AND RestaurantID = @Restaurant_id";
        dataConn.addParameter("@role_id", RoleId);
        dataConn.addParameter("@Restaurant_id", RestaurantId);
        return dataConn.executeReader(command);
    }

    public DataTable getRestaurantname()
    {
        string command = "SELECT RealName from RestaurantUser where RestaurantID = RoleID";
        return dataConn.executeReader(command);
    }

    public DataTable deleteRestaurant()
    {
        string command = "Delete from Restaurant WHERE RestaurantID = @Restaurant_id";
        return dataConn.executeReader(command);
    }

    public string getTutorRestaurantUsingID()
    {
        dataConn.addParameter("@RestaurantID", RestaurantId);

        string command = "Select RestaurantName FROM Restaurant WHERE RestaurantID=@RestaurantID";

        DataTable table = dataConn.executeReader(command);

        if (table.Rows.Count > 0)
        {
            return table.Rows[0]["RestaurantName"].ToString();
        }
        else
        {
            return "";
        }
    }
    public DataTable getRestaurants()
    {
        dataConn.addParameter("@RestaurantID", RestaurantId);
        string command = "SELECT * from Restaurant WHERE NOT RestaurantID=@RestaurantID";
        return dataConn.executeReader(command);
    }
    
}