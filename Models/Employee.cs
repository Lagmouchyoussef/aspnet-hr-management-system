using System;
using System.Collections.Generic;

public class Salarie
{
    public Int32 SalarieId { get; set;}
    public String Nom { get; set; }
    public String Prenom { get; set; }
    public String Fonction { get; set; }
    public Double Salaire { get; set; }
    public Int32 DepartementId { get; set; }

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
}
