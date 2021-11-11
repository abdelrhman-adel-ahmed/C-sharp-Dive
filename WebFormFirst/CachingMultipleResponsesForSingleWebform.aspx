<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CachingMultipleResponsesForSingleWebform.aspx.cs" Inherits="WebFormFirst.CachingMultipleResponsesForSingleWebform" %>
<%@ OutputCache Duration="30" VaryByParam="DropDownList1" Location="Any"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>hello entity</asp:ListItem>
                <asp:ListItem>second title</asp:ListItem>
                <asp:ListItem>hello entity 2</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            Server Time: 
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            Client Time:
            <script>
                document.write(Date());
            </script>
        </div>
    </form>
</body>
</html>
