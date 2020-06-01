<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="RestaurantDetails.UpdatePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cute-background-for-pictures-hd-wallpaper.png" Height="950px" Width="1895px" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdateProgress ID="updatep1" runat="server" AssociatedUpdatePanelID="up1">
            <ProgressTemplate>
                <div>
                    <div>
                        &nbsp;<img alt="progress" src="Images/loading.gif" style="height: 239px; width: 246px; margin-left: 523px" />  
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    
     <asp:Button ID="btnUserAccount" runat="server" PostBackUrl="~/UserAccount.aspx" 
        style="z-index: 1; left: 104px; top: 15px; position: absolute" 
        Text="User Account" BackColor="#33CC33" BorderColor="#33CC33" BorderStyle="Solid" />
     
     <asp:Label ID="lblUpdatePassword" runat="server" 
            style="z-index: 1; left: 102px; top: 56px; position: absolute" 
            Text="Update Password" Font-Bold="True" Font-Size="Larger" 
            Font-Underline="True" ForeColor="#CC0099"></asp:Label>
    
     <asp:Label ID="lblCurrentPassword" runat="server" 
        style="z-index: 1; left: 53px; top: 111px; position: absolute" 
        Text="Current Password:"></asp:Label>
    <asp:Label ID="lblNewPassword" runat="server" 
        style="z-index: 1; left: 72px; top: 148px; position: absolute" 
        Text="New Password"></asp:Label>
  
    <asp:TextBox ID="txtCurrentPassword" runat="server" 
        style="z-index: 1; left: 184px; top: 111px; position: absolute" 
        TextMode="Password"></asp:TextBox>
    <asp:TextBox ID="txtNewPassword" runat="server" 
        style="z-index: 1; left: 184px; top: 149px; position: absolute" 
        TextMode="Password"></asp:TextBox>
    
    
    <asp:Label ID="lblConfirmPassword" runat="server" 
        style="z-index: 1; left: 50px; top: 186px; position: absolute" 
            Text="Confirm Password:"></asp:Label>

    <asp:TextBox ID="txtConfirmPassword" runat="server" 
        style="z-index: 1; left: 184px; top: 188px; position: absolute" 
            TextMode="Password"></asp:TextBox>
        </div>

        <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>

    <asp:Button ID="btnUpdatePassword" runat="server" 
 style="z-index: 1; left: 183px; top: 230px; position: absolute" 
        Text="Update Password" OnClick="btnUpdatePassword_Click" BackColor="#33CC33" BorderColor="#33CC33" ForeColor="Black" BorderStyle="Solid" />
                    
    <asp:Label ID="lblError" runat="server" ForeColor="Red" 
        style="z-index: 1; left: 185px; top: 275px; position: absolute"></asp:Label>
         </ContentTemplate>
         </asp:UpdatePanel>

    </form>
</body>
</html>
