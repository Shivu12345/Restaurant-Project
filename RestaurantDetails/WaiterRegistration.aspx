<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaiterRegistration.aspx.cs" Inherits="RestaurantDetails.WaiterRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
        <asp:radiobuttonlist ID="rblist1" runat="server" style="z-index: 1; left: 169px; top: 306px; position: absolute">
            <asp:ListItem Text="waiter" Value="1"></asp:ListItem>
            <asp:ListItem Text="Chef" Value="2"></asp:ListItem>
        </asp:radiobuttonlist>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cute-background-for-pictures-hd-wallpaper.png" Height="950px" Width="1895px" />
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="lblRegister" runat="server" 
            style="z-index: 1; left: 98px; top: 40px; position: absolute" 
            Text="Waiter Registration Form" Font-Bold="True" Font-Size="Larger" 
            Font-Underline="True" ForeColor="#CC0099"></asp:Label>
    
    <asp:Label ID="lblUsername" runat="server" 
        style="z-index: 1; left: 102px; top: 77px; position: absolute; height: 19px" 
        Text="Username:"></asp:Label>
    <asp:Label ID="lblPassword" runat="server" 
        style="z-index: 1; left: 103px; top: 111px; position: absolute" 
        Text="Password:"></asp:Label>
    <asp:Label ID="lblConfirmPassword" runat="server" 
        style="z-index: 1; left: 50px; top: 148px; position: absolute" 
        Text="Confirm Password:"></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server" 
        style="z-index: 1; left: 184px; top: 76px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" 
        style="z-index: 1; left: 184px; top: 111px; position: absolute" 
        TextMode="Password"></asp:TextBox>
    <asp:TextBox ID="txtConfirmPassword" runat="server" 
        style="z-index: 1; left: 184px; top: 149px; position: absolute" 
        TextMode="Password"></asp:TextBox>
    <asp:DropDownList ID="ddlRestaurants" runat="server" 
        style="z-index: 1; left: 184px; top: 267px; position: absolute;">
    </asp:DropDownList>
        <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="updatep1" runat="server" >
                        <ProgressTemplate>
                            <div>
                                <div>
                                    <asp:Image runat="server" ImageUrl="~/Images/loading.gif" Style="z-index: 1; left: 503px; top: 175px; position: absolute; height: 72px; width: 180px" />
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>                 
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger runat="server" ControlID="btnRegister" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
    <asp:Button ID="btnRegister" runat="server" 
        style="z-index: 1; left: 166px; top: -602px; position: relative; bottom: 576px; margin-top: 0px;" 
        Text="Register" OnClick="btnRegister_Click" BackColor="#33CC33" BorderColor="#33CC33" ForeColor="Black" BorderStyle="Solid" />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" 
        style="z-index: 1; left: 185px; top: 373px; position: absolute"></asp:Label>
     </div>
    <asp:Label ID="lblRealName" runat="server" 
        style="z-index: 1; left: 100px; top: 186px; position: absolute" 
        Text="Full Name:"></asp:Label>
    <asp:TextBox ID="txtRealName" runat="server" 
        style="z-index: 1; left: 184px; top: 184px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="txtEmailAddress" runat="server" 
        style="z-index: 1; left: 184px; top: 225px; position: absolute"></asp:TextBox>
    <asp:Label ID="lblEmailAddress" runat="server" 
        style="z-index: 1; left: 75px; top: 226px; position: absolute" 
        Text="Email Address:"></asp:Label>
    <p>
    <asp:Label ID="lblRestaurant" runat="server" 
        style="z-index: 1; left: 100px; top: 267px; position: absolute" 
        Text="Restaurant:"></asp:Label>
    </p>
    </form>
</body>
</html>

