using System.Data.Entity;

public class LeaveRequestDatabaseInitializer : IDatabaseInitializer<DbSalarieContext>
{
    public void InitializeDatabase(DbSalarieContext context)
    {
        if (!context.Database.Exists())
        {
            new CreateDatabaseIfNotExists<DbSalarieContext>().InitializeDatabase(context);
            return;
        }

        context.Database.ExecuteSqlCommand(@"
IF OBJECT_ID(N'dbo.LeaveRequests', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LeaveRequests
    (
        LeaveRequestId int IDENTITY(1,1) NOT NULL,
        SalarieId int NOT NULL,
        StartDate datetime NOT NULL,
        EndDate datetime NOT NULL,
        Reason nvarchar(max) NOT NULL,
        Status nvarchar(max) NOT NULL,
        CONSTRAINT PK_LeaveRequests PRIMARY KEY CLUSTERED (LeaveRequestId ASC),
        CONSTRAINT FK_LeaveRequests_Salaries_SalarieId
            FOREIGN KEY (SalarieId) REFERENCES dbo.Salaries (SalarieId) ON DELETE CASCADE
    );
    CREATE NONCLUSTERED INDEX IX_SalarieId ON dbo.LeaveRequests (SalarieId);
END");
    }
}
