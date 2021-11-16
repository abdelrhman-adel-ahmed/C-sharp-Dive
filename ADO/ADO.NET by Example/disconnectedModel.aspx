<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="disconnectedModel.aspx.cs" Inherits="ADO.ADO.NET_by_Example.disconnectedModel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Gender"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="DepartmentId"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add Employee" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
