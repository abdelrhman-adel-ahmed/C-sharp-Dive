<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Caching.aspx.cs" Inherits="WebFormFirst.Caching" %>
<%@ OutputCache Duration="30" VaryByParam="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="LoadData"  runat="server" OnClick="LoadData_Click" Text="LoadData" />
            <asp:Button ID="ClearCach" runat="server" OnClick="ClearCach_Click" Text="ClearCach" />
            <br/>
            <br/>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            Server Time : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br/>
            client Time :
            <script>
                document.write(Date());
            </script>
        </div>
    </form>
</body>
</html>
