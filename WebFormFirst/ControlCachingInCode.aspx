<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlCachingInCode.aspx.cs" Inherits="WebFormFirst.ControlCachingInCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
