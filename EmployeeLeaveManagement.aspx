<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeLeaveManagement.aspx.cs" Inherits="WebAppCodeFirst.EmployeeLeaveManagement" Culture="en-US" UICulture="en-US" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Employee List and Leave Requests</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Employee Management</h1>
            <a href="DepartmentManagement.aspx">Department Management</a>

            <h2>Employee List</h2>
            <asp:GridView ID="GvEmployees" runat="server" AutoGenerateColumns="False" EmptyDataText="No employees have been added.">
                <Columns>
                    <asp:BoundField DataField="SalarieId" HeaderText="Employee ID" />
                    <asp:BoundField DataField="Nom" HeaderText="Last Name" />
                    <asp:BoundField DataField="Prenom" HeaderText="First Name" />
                    <asp:BoundField DataField="Fonction" HeaderText="Job Title" />
                    <asp:BoundField DataField="Salaire" HeaderText="Salary" DataFormatString="{0:N2}" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                </Columns>
            </asp:GridView>

            <h2>Leave Requests</h2>
            <asp:Label ID="LblMessage" runat="server" EnableViewState="false" />
            <br />
            <asp:Label ID="LblLeaveEmployee" runat="server" AssociatedControlID="DdlLeaveEmployee" Text="Employee:" />
            <asp:DropDownList ID="DdlLeaveEmployee" runat="server" />
            <br />
            <asp:Label ID="LblLeaveStartDate" runat="server" AssociatedControlID="TbLeaveStartDate" Text="Start Date:" />
            <asp:TextBox ID="TbLeaveStartDate" runat="server" TextMode="Date" />
            <br />
            <asp:Label ID="LblLeaveEndDate" runat="server" AssociatedControlID="TbLeaveEndDate" Text="End Date:" />
            <asp:TextBox ID="TbLeaveEndDate" runat="server" TextMode="Date" />
            <br />
            <asp:Label ID="LblLeaveStatus" runat="server" AssociatedControlID="DdlLeaveStatus" Text="Status:" />
            <asp:DropDownList ID="DdlLeaveStatus" runat="server">
                <asp:ListItem Text="Pending" Value="Pending" />
                <asp:ListItem Text="Approved" Value="Approved" />
                <asp:ListItem Text="Rejected" Value="Rejected" />
            </asp:DropDownList>
            <br />
            <asp:Label ID="LblLeaveReason" runat="server" AssociatedControlID="TbLeaveReason" Text="Reason:" />
            <asp:TextBox ID="TbLeaveReason" runat="server" TextMode="MultiLine" Rows="2" />
            <br />
            <asp:Button ID="BtAddLeaveRequest" runat="server" OnClick="BtSaveLeaveRequest_Click" Text="Add Leave Request" />
            <asp:Button ID="BtUpdateLeaveRequest" runat="server" OnClick="BtSaveLeaveRequest_Click" Text="Update Selected Request" />
            <asp:Button ID="BtDeleteLeaveRequest" runat="server" OnClick="BtDeleteLeaveRequest_Click" Text="Delete Selected Request" />
            <asp:Button ID="BtClearLeaveRequest" runat="server" OnClick="BtClearLeaveRequest_Click" Text="Clear Form" CausesValidation="false" />

            <h2>Leave Request List</h2>
            <asp:GridView ID="GvLeaveRequests" runat="server" AutoGenerateColumns="False" DataKeyNames="LeaveRequestId" OnSelectedIndexChanged="GvLeaveRequests_SelectedIndexChanged" EmptyDataText="No leave requests have been submitted.">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                    <asp:BoundField DataField="LeaveRequestId" HeaderText="Request ID" />
                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee" />
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
