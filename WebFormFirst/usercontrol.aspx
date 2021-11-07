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
            Date of Birth: <uc1:calenderControl runat="server" id="calenderControl" />
        </div>
    </form>
</body>
</html>
