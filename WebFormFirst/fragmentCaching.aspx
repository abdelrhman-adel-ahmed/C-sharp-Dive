<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fragmentCaching.aspx.cs" Inherits="WebFormFirst.fragmentCaching" %>
<%@ OutputCache VaryByParam="none" Duration="30" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc2:fragmentcach runat="server" ID="FragmentCach" />
       </div>
       ServerTime: 
    </form>
</body>
</html>
