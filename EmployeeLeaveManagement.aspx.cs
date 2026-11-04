using System;
using System.Linq;
using System.Data.Entity;

namespace WebAppCodeFirst
{
    public partial class EmployeeLeaveManagement : System.Web.UI.Page
    {
        private readonly DbSalarieContext DbContext = new DbSalarieContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindEmployees();
                BindLeaveEmployees();
                DdlLeaveStatus.SelectedValue = "Pending";
                BindLeaveRequests();
            }
        }

        private void BindEmployees()
        {
            GvEmployees.DataSource = DbContext.Salarie
                .Join(DbContext.Departement,
                    employee => employee.DepartementId,
                    department => department.DepartementId,
                    (employee, department) => new
                    {
                        employee.SalarieId,
                        employee.Nom,
                        employee.Prenom,
                        employee.Fonction,
                        employee.Salaire,
                        DepartmentName = department.Description
                    })
                .OrderBy(employee => employee.Nom)
                .ThenBy(employee => employee.Prenom)
                .ToList();
            GvEmployees.DataBind();
        }

        private void BindLeaveEmployees()
        {
            DdlLeaveEmployee.DataSource = DbContext.Salarie
                .OrderBy(employee => employee.Nom)
                .ThenBy(employee => employee.Prenom)
                .ToList()
                .Select(employee => new
                {
                    employee.SalarieId,
                    FullName = employee.Nom + " " + employee.Prenom
                })
                .ToList();
            DdlLeaveEmployee.DataTextField = "FullName";
            DdlLeaveEmployee.DataValueField = "SalarieId";
            DdlLeaveEmployee.DataBind();
            DdlLeaveEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select an employee", ""));
        }

        private void BindLeaveRequests()
        {
            GvLeaveRequests.DataSource = DbContext.LeaveRequests
                .Include(request => request.Salarie)
                .OrderBy(request => request.StartDate)
                .ToList()
                .Select(request => new
                {
                    request.LeaveRequestId,
                    EmployeeName = request.Salarie.Nom + " " + request.Salarie.Prenom,
                    request.StartDate,
                    request.EndDate,
                    request.Reason,
                    request.Status
                })
                .ToList();
            GvLeaveRequests.DataBind();
        }

        protected void BtSaveLeaveRequest_Click(object sender, EventArgs e)
        {
            bool isUpdate = sender == BtUpdateLeaveRequest;
            int employeeId;
            DateTime startDate;
            DateTime endDate;

            if (isUpdate && GvLeaveRequests.SelectedIndex < 0)
            {
                ShowMessage("Select a leave request before updating it.");
                return;
            }

            if (!int.TryParse(DdlLeaveEmployee.SelectedValue, out employeeId)
                || !DateTime.TryParse(TbLeaveStartDate.Text, out startDate)
                || !DateTime.TryParse(TbLeaveEndDate.Text, out endDate)
                || startDate.Date > endDate.Date
                || String.IsNullOrWhiteSpace(TbLeaveReason.Text))
            {
                ShowMessage("Choose an employee, enter valid dates, and provide a reason. The end date must not be before the start date.");
                return;
            }

            LeaveRequest leaveRequest;
            if (isUpdate)
            {
                int requestId = Convert.ToInt32(GvLeaveRequests.SelectedValue);
                leaveRequest = DbContext.LeaveRequests.Find(requestId);
                if (leaveRequest == null)
                {
                    ShowMessage("The selected leave request could not be found.");
                    return;
                }
            }
            else
            {
                leaveRequest = new LeaveRequest();
                DbContext.LeaveRequests.Add(leaveRequest);
            }

            leaveRequest.SalarieId = employeeId;
            leaveRequest.StartDate = startDate.Date;
            leaveRequest.EndDate = endDate.Date;
            leaveRequest.Reason = TbLeaveReason.Text.Trim();
            leaveRequest.Status = DdlLeaveStatus.SelectedValue;
            DbContext.SaveChanges();

            GvLeaveRequests.SelectedIndex = -1;
            BindLeaveRequests();
            ClearLeaveRequestForm();
            ShowMessage(isUpdate ? "Leave request updated successfully." : "Leave request added successfully.");
        }

        protected void GvLeaveRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            int requestId = Convert.ToInt32(GvLeaveRequests.SelectedValue);
            LeaveRequest leaveRequest = DbContext.LeaveRequests.Find(requestId);
            if (leaveRequest == null)
            {
                ShowMessage("The selected leave request could not be found.");
                return;
            }

            DdlLeaveEmployee.SelectedValue = leaveRequest.SalarieId.ToString();
            TbLeaveStartDate.Text = leaveRequest.StartDate.ToString("yyyy-MM-dd");
            TbLeaveEndDate.Text = leaveRequest.EndDate.ToString("yyyy-MM-dd");
            TbLeaveReason.Text = leaveRequest.Reason;
            DdlLeaveStatus.SelectedValue = leaveRequest.Status;
            LblMessage.Text = String.Empty;
        }

        protected void BtDeleteLeaveRequest_Click(object sender, EventArgs e)
        {
            if (GvLeaveRequests.SelectedIndex < 0)
            {
                ShowMessage("Select a leave request before deleting it.");
                return;
            }

            int requestId = Convert.ToInt32(GvLeaveRequests.SelectedValue);
            LeaveRequest leaveRequest = DbContext.LeaveRequests.Find(requestId);
            if (leaveRequest == null)
            {
                ShowMessage("The selected leave request could not be found.");
                return;
            }

            DbContext.LeaveRequests.Remove(leaveRequest);
            DbContext.SaveChanges();
            GvLeaveRequests.SelectedIndex = -1;
            BindLeaveRequests();
            ClearLeaveRequestForm();
            ShowMessage("Leave request deleted successfully.");
        }

        protected void BtClearLeaveRequest_Click(object sender, EventArgs e)
        {
            GvLeaveRequests.SelectedIndex = -1;
            ClearLeaveRequestForm();
            LblMessage.Text = String.Empty;
        }

        private void ClearLeaveRequestForm()
        {
            if (DdlLeaveEmployee.Items.Count > 0)
            {
                DdlLeaveEmployee.SelectedIndex = 0;
            }

            TbLeaveStartDate.Text = String.Empty;
            TbLeaveEndDate.Text = String.Empty;
            TbLeaveReason.Text = String.Empty;
            DdlLeaveStatus.SelectedValue = "Pending";
        }

        private void ShowMessage(string message)
        {
            LblMessage.Text = message;
        }
    }
}
