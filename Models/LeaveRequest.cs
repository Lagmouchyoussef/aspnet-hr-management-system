using System;

public class LeaveRequest
{
    public int LeaveRequestId { get; set; }
    public int SalarieId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }

    public virtual Salarie Salarie { get; set; }
}
