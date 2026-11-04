<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentManagement.aspx.cs" Inherits="WebAppCodeFirst.DepartmentManagement" Culture="en-US" UICulture="en-US" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>HR Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>HR Management</h1>
            <a href="EmployeeLeaveManagement.aspx">Employee List and Leave Requests</a>

            <h2>Department Management</h2>
            <asp:GridView ID="GvDepartement" runat="server" AutoGenerateColumns="False" DataKeyNames="DepartementId" OnSelectedIndexChanged="GvDepartement_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                    <asp:BoundField DataField="DepartementId" HeaderText="Department ID" />
                    <asp:BoundField DataField="Description" HeaderText="Department" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Department ID:"></asp:Label>
            <asp:TextBox ID="TbId" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Department:"></asp:Label>
            <asp:TextBox ID="TbDescription" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Location:"></asp:Label>
            <asp:TextBox ID="TbLocalisation" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtAdd" runat="server" OnClick="BtAdd_Click" Text="Add Department" />
            <asp:Button ID="BtUpdate" runat="server" OnClick="BtUpdate_Click" Text="Update Department" />
            <asp:Button ID="BtDelette" runat="server" OnClick="BtDelette_Click" Text="Delete Department" />

            <h2>Add Employee</h2>
            <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="TbNom" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="TbPrenom" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Job Title:"></asp:Label>
            <asp:TextBox ID="TbFonction" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Salary:"></asp:Label>
            <asp:TextBox ID="TbSalaire" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Department:"></asp:Label>
            <asp:DropDownList ID="DDLDepartement" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="BtAddSalarie" runat="server" OnClick="BtAddSalarie_Click" Text="Add Employee" />
            <asp:Button ID="BtMAJSalarie" runat="server" Text="Update Employee" />
            <asp:Button ID="BtDeletteSalarie" runat="server" Text="Delete Employee" />


        </div>
    </form>
</body>
</html>
