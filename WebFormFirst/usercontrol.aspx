<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usercontrol.aspx.cs" Inherits="WebFormFirst.usercontrol" %>

<%--<%@ Register Src="usercontrols/calenderControl.ascx" TagPrefix="uc1" TagName="calenderControl" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Date of Birth: <uc1:calenderControl runat="server" id="calenderControl" />
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
        </div>
    </form>
</body>
</html>
