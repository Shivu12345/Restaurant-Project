<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="RestaurantDetails.UserAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Account</title>
</head>
<body>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cute-background-for-pictures-hd-wallpaper.png" Height="950px" Width="1895px" />
       <form id="form1" runat="server">
    
    <asp:Button ID="btnLogout" runat="server" PostBackUrl="~/Logout.aspx"        
        style="z-index: 1; left: 27px; top: 29px; position: absolute;" 
        Text="Logout" OnClick="btnLogout_Click" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
    
    <div>
    
        <asp:Label ID="lblUserAccount" runat="server" Font-Bold="True" 
            Font-Size="Larger" Font-Underline="True" 
            style="z-index: 1; left: 119px; top: 69px; position: absolute" 
            Text="User Account" BackColor="White" ForeColor="#CC0099"></asp:Label>
    
    </div>
    <asp:Label ID="lblWelcome" runat="server" 
        style="z-index: 1; left: 119px; top: 107px; position: absolute"></asp:Label>
        
    <asp:Label ID="lblChangePassword" runat="server" 
        style="z-index: 1; left: 118px; top: 144px; position: absolute" 
        Text="If this is the first time you have logged in, please change your password." 
        Visible="true"></asp:Label>
        
    <asp:Button ID="btnUpdatePassword" runat="server" 
        style="z-index: 1; top: 29px; position: absolute; left: 280px" 
        Text="Update Password" PostBackUrl="~/UpdatePassword.aspx" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
        
    <asp:Button ID="btnUserDetails" runat="server" 
        PostBackUrl="~/WaiterDetails.aspx" 
        style="z-index: 1; left: 120px; top: 29px; position: absolute" 
        Text="Waiter Details" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid"/>
        
    <asp:Button ID="btnUpdateChefRestaurant" runat="server" 
        style="z-index: 1; left: 457px; top: 30px; position: absolute" 
        Text="Update Chef Restaurant" Visible="False" 
        PostBackUrl="~/UpdateChefRestaurant.aspx" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
        
    
    <asp:Label ID="lblUpdateSuccess" runat="server" ForeColor="#009900" 
        style="z-index: 1; left: 121px; top: 189px; position: absolute"></asp:Label>
        
    
    </form>
</body>
</html>
