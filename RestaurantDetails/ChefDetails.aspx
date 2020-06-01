<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChefDetails.aspx.cs" Inherits="RestaurantDetails.ChefDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cute-background-for-pictures-hd-wallpaper.png" Height="950px" Width="1895px" />
    <form id="form1" runat="server">
    
    <asp:Button ID="btnUserAccount" runat="server" PostBackUrl="~/UserAccount.aspx" 
        style="z-index: 1; left: 104px; top: 15px; position: absolute" 
        Text="User Account" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
    
    <div> 
        <asp:Label ID="lblChefDetails" runat="server" Font-Bold="True" 
            Font-Size="Larger" 
            style="z-index: 1; left: 100px; top: 48px; position: absolute" 
            Text="Chef Details" Font-Underline="True" ForeColor="#CC0099"></asp:Label>
    </div>
    <asp:Label ID="lblRestaurant" runat="server" 
        
        style="z-index: 1; left: 90px; top: 90px; position: absolute; height: 19px;" 
        Text="Restaurant:"></asp:Label>
    <asp:TextBox ID="txtRestaurant" runat="server" ReadOnly="True" 
        style="z-index: 1; left: 165px; top: 87px; position: absolute"></asp:TextBox>
        
    <asp:Label ID="lblError" runat="server" ForeColor="Red" 
        style="z-index: 1; left: 321px; top: 89px; position: absolute"></asp:Label>
        
    <asp:Label ID="lblWaiters" runat="server" 
        style="z-index: 1; left: 102px; top: 125px; position: absolute" 
        Text="Waiters(s) at your restaurant:"></asp:Label>
    <asp:ListBox ID="lstWaiters" runat="server" 
        
        
        style="z-index: 1; left: 102px; top: 159px; position: absolute; height: 72px; width: 180px">
    </asp:ListBox>
    
    <asp:Button ID="btnRemoveWaiter" runat="server" 
        style="z-index: 1; left: 102px; top: 250px; position: absolute" 
        Text="Remove Waiter" OnClick="btnRemoveWaiter_Click" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
        
    <asp:Label ID="lblSuccess" runat="server" ForeColor="#009900" 
        style="z-index: 1; left: 278px; top: 252px; position: absolute"></asp:Label>
    
    <p>
        
    <asp:Label ID="lblCuisines" runat="server" 
        style="z-index: 1; left: 100px; top: 305px; position: absolute" 
        Text="Cuisines at your restaurant:"></asp:Label>
    
    </p>
    
     <div style="z-index: 1; left: 110px; top: 340px; position: absolute;">
    <asp:Repeater ID="rptCuisines" runat="server">
        <ItemTemplate>
        Cuisine Region:
        <strong><asp:Label ID="lblcuisineregion" runat="server" Text='<%#Eval("CuisineRegion") %>'></asp:Label></strong><br />
        Cuisine Name:
           <strong><asp:Label ID="lblcuisinename" runat="server" Text='<%#Eval("CuisineName") %>'></asp:Label></strong><br />        
        </ItemTemplate>
        <SeparatorTemplate>
            <div style="width:300px;"><hr /></div>
        </SeparatorTemplate>
    </asp:Repeater>
    </div>
    
    </form>
</body>
</html>
