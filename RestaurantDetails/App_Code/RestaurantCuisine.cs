using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CourseModules
/// </summary>
public class RestaurantCuisine
{

    public int RestaurantId { get; set; }
    public int CuisineId { get; set; }

    private DatabaseConnection dataConn;

    public DataTable getAllRestaurantCuisine()
    {
        string command = "Select * FROM RestaurantCuisine";
        return dataConn.executeReader(command);
    }
    public RestaurantCuisine()
    {
        dataConn = new DatabaseConnection();
    }
}