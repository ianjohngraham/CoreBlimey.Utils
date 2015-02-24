<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateContact.aspx.cs" Inherits="Coreblimey.Utils.CreateContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder runat="server" ID="phForm">
            <fieldset>
                <legend>Personal Details</legend>
                <asp:Label ID="lblFirstname" runat="server" Text="Firstname:" AssociatedControlID="txtFirstname"></asp:Label>
                <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblSurname" runat="server" Text="Surname:" AssociatedControlID="txtSurname"></asp:Label>
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblEmailAddress" runat="server" Text="Email:" AssociatedControlID="txtEmail"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblEngagmentPoints" runat="server" Text="Interaction Points:" AssociatedControlID="txtEngagementPoints"></asp:Label>
                <asp:TextBox ID="txtEngagementPoints" runat="server" Text="10"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnCreateContact" runat="server" Text="Create Contact" OnClick="btnCreateContact_Click" />
                <asp:Button ID="btnEndSession" runat="server" Text="End Session" OnClick="btnEndSession_Click" />
                <br />
            </fieldset>

        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phCreated" Visible="false">Contact identified and created!!
                <asp:Button ID="btnBackToForm" runat="server" Text="Back" OnClick="btnBack_Click" />
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="phSessionCleared" Visible="false">Session Cleared!! Check in MongoDB
              <asp:Button ID="Button1" runat="server" Text="Back" OnClick="btnBack_Click" />
        </asp:PlaceHolder>
    </form>
    <p>
        Quickly created by Ian Graham - <a href='http://coreblimey.azurewebsites.net/'>http://coreblimey.azurewebsites.net</a>
    </p>
</body>
</html>
