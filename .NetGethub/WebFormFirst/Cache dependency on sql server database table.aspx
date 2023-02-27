<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cache dependency on sql server database table.aspx.cs" Inherits="WebFormFirst.Cache_dependency_on_sql_server_database_table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Get Data" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
