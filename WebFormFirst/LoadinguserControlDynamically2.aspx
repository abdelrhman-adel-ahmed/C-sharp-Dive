<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadinguserControlDynamically2.aspx.cs" Inherits="WebFormFirst.LoadinguserControlDynamically2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="58px" Width="146px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="-1">please select</asp:ListItem>
            <asp:ListItem value="DDL">Select city</asp:ListItem>
            <asp:ListItem Value="TB">Enter post code</asp:ListItem>

        </asp:DropDownList>
        <br />
        <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
