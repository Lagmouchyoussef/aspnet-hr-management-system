using System.Data.Entity;

public class DbSalarieContext : DbContext
{
    public DbSalarieContext() : base("name=MyDbConnection")
    {
    }

    public DbSet<Departement> Departement { get; set; }
    public DbSet<Salarie> Salarie { get; set; }
}