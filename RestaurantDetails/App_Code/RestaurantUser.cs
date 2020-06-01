using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;



namespace RestaurantDetails
{
    public class RestaurantUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string RealName { get; set; }
        public string EmailAddress { get; set; }
        public int RoleId { get; set; }
        public int RestaurantId { get; set; }

        private DatabaseConnection dataConnection;

        public RestaurantUser()
        {
            dataConnection = new DatabaseConnection();
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
        public bool userNameExists()
        {
            dataConnection.addParameter("@user_name", UserName);

            string command = "Select COUNT(UserName) FROM RestaurantUser WHERE UserName=@user_name";

            int result = dataConnection.executeScalar(command); //result of count

            return result > 0 || result == -1; //if record found or exception caught
        }

        public bool emailaddressExists()
        {
            dataConnection.addParameter("@email_address", EmailAddress);

            string command = "Select COUNT(EmailAddress) FROM RestaurantUser WHERE EmailAddress=@email_address";

            int result = dataConnection.executeScalar(command); //result of count

            return result > 0 || result == -1; //if record found or exception caught
        }

        public bool adduser()
        {
            string userPassword = CalculateMD5Hash(UserPassword);
            dataConnection.addParameter("@user_name", UserName);
            dataConnection.addParameter("@User_Password", userPassword);
            dataConnection.addParameter("@Real_Name", RealName);
            dataConnection.addParameter("@Email_Address", EmailAddress);
            dataConnection.addParameter("@RoleID", RoleId);
            dataConnection.addParameter("@RestaurantId", RestaurantId);

            string command = "INSERT INTO RestaurantUser (UserName, UserPassword, RealName, EmailAddress, RoleID, RestaurantId) " +
                            "VALUES (@user_name, @user_Password, @Real_Name, @Email_Address, @RoleID, @RestaurantId)";

            return dataConnection.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
        }

        public bool authenticateUser()
        {
            string userPassword = CalculateMD5Hash(UserPassword);
            dataConnection.addParameter("@User_name", UserName);
            dataConnection.addParameter("@User_Password", userPassword);

            string command = "Select UserID, RealName, RoleID, RestaurantID FROM RestaurantUser " +
                            "WHERE UserName=@User_name AND UserPassword=@User_Password";

            DataTable table = dataConnection.executeReader(command);

            if (table.Rows.Count > 0)
            {
                HttpContext.Current.Session["UserID"] = table.Rows[0]["UserID"].ToString();
                HttpContext.Current.Session["RealName"] = table.Rows[0]["RealName"].ToString();
                HttpContext.Current.Session["RoleID"] = table.Rows[0]["RoleID"].ToString();
                HttpContext.Current.Session["RestaurantID"] = table.Rows[0]["RestaurantID"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }

        public string getPasswordUsingID()
        {
            dataConnection.addParameter("@UserID", UserId);

            string command = "Select UserPassword FROM RestaurantUser WHERE UserID=@userID";

            DataTable table = dataConnection.executeReader(command);

            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["UserPassword"].ToString();
            }
            else
            {
                return "";
            }
        }

        public bool updatePasswordByUserId()
        {
            string userPassword = CalculateMD5Hash(UserPassword);
            dataConnection.addParameter("@User_Password", userPassword);
            dataConnection.addParameter("@UserID", UserId);

            string command = "Update RestaurantUser Set UserPassword=@User_Password WHERE UserID=@UserID";

            return dataConnection.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
        }


        public DataTable getchefName(int RoleId)
        {
            string command = "Select UserID,RealName FROM RestaurantUser Where RoleID = @role_id AND RestaurantId = @RestaurantId";
            dataConnection.addParameter("@role_id", RoleId);
            dataConnection.addParameter("@RestaurantId", RestaurantId);
            return dataConnection.executeReader(command);
        }
        
        public DataTable getChefEmail()
        {
            dataConnection.addParameter("@UserId", UserId);         
            string command = "SELECT EmailAddress from RestaurantUser where UserID = @UserId";
   //         DataTable dt_chef_email= dataConnection.executeReader(command);
            return dataConnection.executeReader(command);
        }

        //public string getChefEmail()
        //{
        //    dataConnection.addParameter("@UserID", UserId);
        //    using (DataTable dt = dataConnection.executeReader("SELECT EmailAddress from RestaurantUser where UserID = @UserID"))
        //    {
        //        DataTable dt_table = dt;
        //        return dt.Rows[0].ItemArray[0].ToString();
        //    }
        //}

        public string getRestaurantUsingRestaurantID()
        {
            dataConnection.addParameter("@RestaurantId", RestaurantId);
            // sql command to get the Restaurant name
            string command = "Select RestaurantName FROM Restaurant WHERE RestaurantId=@RestaurantId";
            // execute the sql command
            DataTable table = dataConnection.executeReader(command);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["RestaurantName"].ToString();
            }
            else
            {
                return "";
            }

        }

        public bool updateRestaurantByUserId()
        {
            // set the parametere values
            dataConnection.addParameter("@RestaurantId", RestaurantId);
            dataConnection.addParameter("@UserID", UserId);
            //sql command to update the Restaurant name
            string command = "UPDATE RestaurantUser Set RestaurantId=@RestaurantId WHERE UserID=@UserID";
            //execute the sql command
            return dataConnection.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
        }

        public DataTable removeWaiter()
        {
            // set the parameter value
            dataConnection.addParameter("@UserID", UserId);
            //sql command to delete the selected Waiter
            string command = "DELETE FROM RestaurantUser WHERE UserID=@UserID";
            return dataConnection.executeReader(command);
        }

        public DataTable getWaiters()
        {
            // set the parameter value
            dataConnection.addParameter("@RestaurantId", RestaurantId);
            dataConnection.addParameter("@RoleID", RoleId);
            //sql command to delete the selected Waiter
            string command = "select RealName,UserID from RestaurantUser WHERE RestaurantId=@RestaurantId and RoleID=@RoleID";
            return dataConnection.executeReader(command);
        }
        public DataTable getUserDetails()
        {
            // set the parameter value
            dataConnection.addParameter("@RealName", RealName);
            //sql command to delete the selected Waiter
            string command = "select * FROM RestaurantUser WHERE RealName=@RealName";
            return dataConnection.executeReader(command);
        }
    }
}