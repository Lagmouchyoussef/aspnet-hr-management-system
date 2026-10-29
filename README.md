# Employee and Department Management

An ASP.NET Web Forms application for managing company departments and employees. The application uses Entity Framework 6 Code First with SQL Server LocalDB.

## Features

- View departments and their locations
- Add, update, and delete departments
- Assign employees to departments
- View employees by department
- Add employees with job title and salary

## Technology Stack

- ASP.NET Web Forms
- C# and .NET Framework 4.8.1
- Entity Framework 6 (Code First)
- SQL Server LocalDB

## Getting Started

### Prerequisites

- Visual Studio with ASP.NET and web development support
- .NET Framework 4.8.1 Developer Pack
- SQL Server Express LocalDB

### Run the application

1. Clone this repository and open `WebAppCodeFirst.slnx` in Visual Studio.
2. Restore the NuGet packages listed in `packages.config`.
3. Ensure SQL Server LocalDB is installed and available.
4. Review the `MyDbConnection` connection string in `Web.config` if your LocalDB instance uses a different configuration.
5. Build the solution and run the web project with IIS Express.
6. Open `DepartmentManagement.aspx` if it is not selected as the start page.

Entity Framework Code First creates or uses the `MaBaseSalarie` database through the configured LocalDB connection.

## Project Structure

```text
WebAppCodeFirst/
├── DepartmentManagement.aspx
├── DepartmentManagement.aspx.cs
├── DepartmentManagement.aspx.designer.cs
├── Global.asax
├── Models/
│   ├── Department.cs
│   ├── Employee.cs
│   └── EmployeeDatabaseContext.cs
├── Properties/
├── Web.config
├── WebAppCodeFirst.csproj
└── WebAppCodeFirst.slnx
```

## License

No license has been specified yet.
