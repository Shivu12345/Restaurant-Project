<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateChefRestaurant.aspx.cs" Inherits="RestaurantDetails.UpdateChefRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cute-background-for-pictures-hd-wallpaper.png" Height="950px" Width="1895px" />
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


            <asp:Button ID="btnUserAccount" runat="server" PostBackUrl="~/UserAccount.aspx"
                Style="z-index: 1; left: 104px; top: 15px; position: absolute"
                Text="User Account" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />

            <asp:Label ID="lblTitle" runat="server"
                Style="z-index: 1; left: 102px; top: 56px; position: absolute"
                Text="Update Chef Restaurant" Font-Bold="True" Font-Size="Larger"
                Font-Underline="True" ForeColor="#CC0099"></asp:Label>

            <asp:Label ID="lblRestaurant" runat="server"
                Style="z-index: 1; left: 97px; top: 103px; position: absolute"
                Text="Current Restaurant:"></asp:Label>


            <asp:Label ID="lblSwitchToRestaurant" runat="server"
                Style="z-index: 1; left: 106px; top: 136px; position: absolute"
                Text="Switch to Restaurant:"></asp:Label>


            <asp:ListBox ID="lstRestaurants" runat="server"
                Style="z-index: 1; left: 106px; top: 165px; position: absolute; height: 72px; width: 180px"></asp:ListBox>

            <asp:UpdatePanel ID="up1" runat="server">

                <ContentTemplate>
                    <asp:UpdateProgress ID="updatep1" runat="server" >
                        <ProgressTemplate>
                            <div>
                                <div>
                                    <asp:Image runat="server" ImageUrl="Images/CircularProgressAnimation.gif" Style="z-index: 1; left: 503px; top: 175px; position: absolute; height: 72px; width: 180px" />
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <asp:TextBox ID="txtRestaurant" runat="server" ReadOnly="True"
                        Style="z-index: 1; left: 224px; top: 102px; position: absolute"></asp:TextBox>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"
                        Style="z-index: 1; left: 106px; top: 294px; position: absolute"></asp:Label>
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger runat="server" ControlID="btnUpdateRestaurant" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>

            <asp:Button ID="btnUpdateRestaurant" runat="server"
                Style="z-index: 1; left: 106px; top: 254px; position: absolute"
                Text="Update Restaurant" OnClick="btnUpdateRestaurant_Click" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
        </div>
    </form>
</body>
</html>
