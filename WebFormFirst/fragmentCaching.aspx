<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fragmentCaching.aspx.cs" Inherits="WebFormFirst.fragmentCaching" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     
    
        <table style="width:100%;">
            <tr>
                <td> <b>Page Content That Changes</b></td>
            </tr>
            <tr>
                <td> Server Time:
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Client Time: <script>document.write(Date());</script></td>
            </tr>
              <tr>
                  <td></td>
            </tr>
             <tr>
                <td> 
                    <b>User Custom Control That Fragmently Cached:</b>
              </td>
            </tr>
              <tr>
                <td>
                    <uc2:fragmentcach runat="server" ID="FragmentCach" />
                </td>
            </tr>
        </table>
     
    
    </form>
</body>
</html>
