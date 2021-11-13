<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reloading or refreshing cache automatically when cached data is removed.aspx.cs" Inherits="WebFormFirst.Reloading_or_refreshing_cache_automatically_when_cached_data_is_removed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Load Countires & Cach" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Countries from cach" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Remove Cached Item" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Get Cache Status" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
