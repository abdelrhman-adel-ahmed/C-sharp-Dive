<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FragmentCach.ascx.cs" Inherits="WebFormFirst.usercontrols.FragmentCach" %>
<%@ OutputCache Shared="true" Duration="30" VaryByParam="none" %>

<asp:GridView ID="GridView1" runat="server">
</asp:GridView>

Server Time :<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br />
Client Time :<script>
                 document.write(Date());
             </script>

