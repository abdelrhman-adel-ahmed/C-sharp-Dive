<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="copyDataFromOnTableToAnotherUsingSqlbulkCopy.aspx.cs" Inherits="ADO.copyDataFromOnTableToAnotherUsingSqlbulkCopy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="CopyDataFromSourceToDestinationDb" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
