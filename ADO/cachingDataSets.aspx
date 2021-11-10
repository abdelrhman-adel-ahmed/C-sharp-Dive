<%@ Page Language="C#" AutoEventWireup="true" Trace="true" CodeBehind="cachingDataSets.aspx.cs" Inherits="ADO.cachingDataSets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="LoadData" runat="server" OnClick="LoadData_Click" Text="LoadData" />
            <asp:Button ID="ClearCach" runat="server" OnClick="ClearCach_Click" Text="ClearCach" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="Data"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
