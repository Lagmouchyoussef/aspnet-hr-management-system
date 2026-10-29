<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentManagement.aspx.cs" Inherits="WebAppCodeFirst.DepartmentManagement" Culture="en-US" UICulture="en-US" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Department Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Department Management</h1>
            <asp:GridView ID="GvDepartement" runat="server" AutoGenerateColumns="False" DataKeyNames="DepartementId" OnSelectedIndexChanged="GvDepartement_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                    <asp:BoundField DataField="DepartementId" HeaderText="Department ID" />
                    <asp:BoundField DataField="Description" HeaderText="Department" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                </Columns>
            </asp:GridView>
            <br />
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
            <br />
            <br />
            <asp:Button ID="BtAdd" runat="server" OnClick="BtAdd_Click" Text="Add Department" />
            <asp:Button ID="BtUpdate" runat="server" OnClick="BtUpdate_Click" Text="Update Department" />
            <asp:Button ID="BtDelette" runat="server" OnClick="BtDelette_Click" Text="Delete Department" />
            <br />
            <br />
            <h2>Add Employee</h2><br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="TbNom" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="TbPrenom" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Job Title:"></asp:Label>
            <asp:TextBox ID="TbFonction" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Salary:"></asp:Label>
            <asp:TextBox ID="TbSalaire" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Department"></asp:Label>
            &nbsp;:
            <asp:DropDownList ID="DDLDepartement" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="BtAddSalarie" runat="server" OnClick="BtAddSalarie_Click" Text="Add Employee" />
            <asp:Button ID="BtMAJSalarie" runat="server" Text="Update Employee" />
            <asp:Button ID="BtDeletteSalarie" runat="server" Text="Delete Employee" />
            <br />
            <br />
            <h2>Employee List</h2>
            <asp:GridView ID="GvSalarie" runat="server" AutoGenerateColumns="False" DataKeyNames="SalarieId" OnSelectedIndexChanged="GvSalarie_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                    <asp:BoundField DataField="SalarieId" HeaderText="Employee ID" />
                    <asp:BoundField DataField="Nom" HeaderText="Last Name" />
                    <asp:BoundField DataField="Prenom" HeaderText="First Name" />
                    <asp:BoundField DataField="Fonction" HeaderText="Job Title" />
                    <asp:BoundField DataField="Salaire" HeaderText="Salary" DataFormatString="{0:N2}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
