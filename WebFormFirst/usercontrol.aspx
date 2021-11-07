<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usercontrol.aspx.cs" Inherits="WebFormFirst.usercontrol" %>

<%@ Register Src="~/calenderControl.ascx" TagPrefix="uc1" TagName="calenderControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:calenderControl runat="server" id="calenderControl" />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
