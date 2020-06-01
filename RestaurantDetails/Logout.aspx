<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="RestaurantDetails.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/cute-background-for-pictures-hd-wallpaper.png" Height="950px" Width="1895px" />
   <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblLogout" runat="server" Font-Bold="True" Font-Size="Larger" 
            style="z-index: 1; left: 72px; top: 28px; position: absolute" 
            Text="Logout" Font-Strikeout="False" Font-Underline="True" ForeColor="#CC0099"></asp:Label>
    
    </div>
    <asp:Label ID="lblConfirmation" runat="server" 
        style="z-index: 1; left: 74px; top: 64px; position: absolute" 
        Text="Are you sure you want to logout?"></asp:Label>
    <asp:Button ID="btnYes" runat="server"  
        style="z-index: 1; left: 75px; top: 98px; position: absolute; " 
        Text="Yes" OnClick="btnYes_Click" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
    <asp:Button ID="btnNo" runat="server" PostBackUrl="~/UserAccount.aspx" 
        style="z-index: 1; left: 138px; top: 98px; position: absolute" Text="No" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
    </form>
</body>
</html>
