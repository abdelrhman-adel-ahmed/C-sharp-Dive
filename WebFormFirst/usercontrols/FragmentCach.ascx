<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FragmentCach.ascx.cs" Inherits="WebFormFirst.usercontrols.FragmentCach" %>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>

Server Time :<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
Client Time :<script>
                 document.write(Date());
             </script>

