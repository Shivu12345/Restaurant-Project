using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Modules
/// </summary>
public class Cuisine
{
    public int CuisineId { get; set; }
    public int RestaurantId { get; set; }
    public int CuisineRegion { get; set; }
    public string CuisineName { get; set; }

    private DatabaseConnection dataConn;

    public DataTable getAllCuisine()
    {
        string command = "Select * FROM Cuisine";
        return dataConn.executeReader(command);
    }

    public Cuisine()
    {
        dataConn = new DatabaseConnection();
    }

    public DataTable bindCuisine()
    {
        // set the parameter values
        dataConn.addParameter("@RestaurantID", RestaurantId);
        // sql command to get the cuisines from the databse         
        string cmd = "select * from Cuisine where CuisineID in (select CuisineID from RestaurantCuisine where RestaurantID=@RestaurantID)";
        DataTable dt3 = dataConn.executeReader(cmd);
        //    return dataConn.executeReader(cmd);
        return dt3;
    }
}