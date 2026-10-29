using System;
using System.Collections.Generic;

public class Departement
{
    public Int32 DepartementId { get; set;}
    public string Description { get; set; }
    public String Location { get; set; }
    public IList<Salarie> SalraieListe { get; set; }
}
