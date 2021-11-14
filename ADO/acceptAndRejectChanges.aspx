<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceptAndRejectChanges.aspx.cs" Inherits="ADO.acceptAndRejectChanges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGetDataFromDb" runat="server" Text="btnGetDataFromDb" OnClick="btnGetDataFromDb_Click" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Button ID="Button2" runat="server" Text="RejectChangesIfAny" OnClick="Button2_Click" />
            <br />
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="gvStudents_RowCancelingEdit" OnRowEditing="gvStudents_RowEditing" OnRowUpdating="gvStudents_RowUpdating" OnRowDeleting="gvStudents_RowDeleting">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnUpdateTable" runat="server" Text="btnUpdateTable" OnClick="btnUpdateTable_Click" />
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            <br />
           
        </div>
    </form>
  
</body>
</html>
