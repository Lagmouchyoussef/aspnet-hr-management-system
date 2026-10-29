# ASP.NET HR Management System

A lightweight **Human Resources management web application** built with **ASP.NET Web Forms** and **Entity Framework 6 (Code First)**. It allows an organization to manage **departments** and **employees**, with full CRUD operations backed by a SQL Server LocalDB database that is generated automatically from the domain model.

This project was built as an academic exercise (EMSI – 4IIR, ASP.NET module) demonstrating the **Code First** approach to data access in classic ASP.NET Web Forms applications.

## Overview

- Manage **departments**: create, edit, delete, and list departments with their location.
- Manage **employees**: assign employees to a department, record their job title and salary.
- The database schema (`MaBaseSalarie`) is generated and kept in sync automatically by Entity Framework Code First — no manual SQL scripts required.

## Technology Stack

| Layer              | Technology                                  |
|--------------------|----------------------------------------------|
| UI                 | ASP.NET Web Forms (`.aspx` / code-behind)     |
| Language           | C#                                            |
| Runtime            | .NET Framework 4.8.1                          |
| Data Access        | Entity Framework 6.5.2 (Code First)           |
| Database           | SQL Server LocalDB (`MSSQLLocalDB`)           |
| Web Server         | IIS Express                                   |
| IDE                | Visual Studio Enterprise 2026 Insiders        |

## Domain Model

```text
Departement                     Salarie
------------------               ------------------
DepartementId  (int, PK)         SalarieId      (int, PK)
Description    (string)          Nom            (string)
Location       (string)          Prenom         (string)
SalraieListe   (IList<Salarie>)  Fonction       (string)
                                  Salaire        (double)
                                  DepartementId  (int, FK)
```

- `DbSalarieContext` (`Models/EmployeeDatabaseContext.cs`) exposes `DbSet<Departement>` and `DbSet<Salarie>` and uses the `MyDbConnection` connection string defined in `Web.config`.

## Project Structure

```text
WebAppCodeFirst/
├── DepartmentManagement.aspx            # Departments & employees UI (markup)
├── DepartmentManagement.aspx.cs         # Code-behind: CRUD logic
├── DepartmentManagement.aspx.designer.cs
├── Global.asax / Global.asax.cs         # Application lifecycle events
├── Models/
│   ├── Department.cs                    # Departement entity
│   ├── Employee.cs                      # Salarie entity
│   └── EmployeeDatabaseContext.cs       # EF Code First DbContext
├── Properties/
│   └── AssemblyInfo.cs
├── App_Data/                            # LocalDB data files (generated at runtime)
├── Web.config / Web.Debug.config / Web.Release.config
├── packages.config                      # NuGet packages (EF6, CodeDom providers)
├── WebAppCodeFirst.csproj
└── WebAppCodeFirst.slnx
```

---

## Getting Started — Run the Existing Project

### Prerequisites

- **Visual Studio Enterprise 2026 Insiders** (or any recent Visual Studio) with the **ASP.NET and web development** workload installed.
- **.NET Framework 4.8.1 Developer Pack**.
- **SQL Server Express LocalDB** (installed by default with the ASP.NET and web development workload).
- **Git** for cloning the repository.

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/Lagmouchyoussef/aspnet-hr-management-system.git
   ```
2. Open `WebAppCodeFirst.slnx` in Visual Studio.
3. Right-click the solution in **Solution Explorer** → **Restore NuGet Packages** (this restores `EntityFramework 6.5.2` and `Microsoft.CodeDom.Providers.DotNetCompilerPlatform`).
4. Confirm that SQL Server LocalDB is installed and that the `MyDbConnection` connection string in `Web.config` matches your local instance:
   ```xml
   <add name="MyDbConnection"
        connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MaBaseSalarie;Integrated Security=True;MultipleActiveResultSets=True"
        providerName="System.Data.SqlClient" />
   ```
5. Press **F5** (or **Ctrl+F5**) to build and run the application with IIS Express.
6. If `DepartmentManagement.aspx` doesn't open automatically, right-click it in **Solution Explorer** and choose **Set As Start Page**, then run again.

On first run, Entity Framework Code First creates the `MaBaseSalarie` database on your LocalDB instance automatically — no manual setup is required.

---

## Building the Project From Scratch in Visual Studio Enterprise 2026 Insiders

The steps below reproduce this project from an empty solution, in case you want to recreate it manually or use it as a learning walkthrough.

### 1. Create the Web Forms project

1. Open **Visual Studio Enterprise 2026 Insiders**.
2. On the Start Window, click **Create a new project**.
3. In the project template search box, type `ASP.NET Web Application` and select **ASP.NET Web Application (.NET Framework)** — make sure **C#** is selected as the language.
4. Click **Next**.
5. Configure the project:
   - **Project name**: `WebAppCodeFirst`
   - **Location**: choose your working folder
   - **Solution name**: `WebAppCodeFirst`
6. Click **Create**.
7. On the **New ASP.NET Web Application** screen, select the **Web Forms** template, leave **Authentication** as **No Authentication** (or configure as needed), and click **Create**.

### 2. Install Entity Framework 6 via NuGet

1. Right-click the project in **Solution Explorer** → **Manage NuGet Packages…**
2. Search for `EntityFramework` and install the latest **6.x** version (this project uses `6.5.2`).
3. This adds the `EntityFramework` / `EntityFramework.SqlServer` references and the `packages.config` entry, and updates `Web.config` with the EF configuration section.

### 3. Create the domain model

Add a `Models` folder to the project (**right-click project → Add → New Folder**), then add the entity classes:

**`Models/Department.cs`**
```csharp
using System;
using System.Collections.Generic;

public class Departement
{
    public Int32 DepartementId { get; set; }
    public string Description { get; set; }
    public String Location { get; set; }
    public IList<Salarie> SalraieListe { get; set; }
}
```

**`Models/Employee.cs`**
```csharp
using System;

public class Salarie
{
    public Int32 SalarieId { get; set; }
    public String Nom { get; set; }
    public String Prenom { get; set; }
    public String Fonction { get; set; }
    public Double Salaire { get; set; }
    public Int32 DepartementId { get; set; }
}
```

### 4. Create the Code First `DbContext`

**`Models/EmployeeDatabaseContext.cs`**
```csharp
using System.Data.Entity;

public class DbSalarieContext : DbContext
{
    public DbSalarieContext() : base("name=MyDbConnection")
    {
    }

    public DbSet<Departement> Departement { get; set; }
    public DbSet<Salarie> Salarie { get; set; }
}
```

### 5. Configure the LocalDB connection string

Open `Web.config` and add the connection string used by the `DbContext` inside `<connectionStrings>`:

```xml
<connectionStrings>
  <add name="MyDbConnection"
       connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MaBaseSalarie;Integrated Security=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Entity Framework Code First will create the `MaBaseSalarie` database automatically the first time the application runs — no migration or manual script is needed for this simple scenario.

### 6. Build the Web Forms page

1. Right-click the project → **Add → Web Form**, name it `DepartmentManagement.aspx`.
2. Design the markup with the server controls needed for the CRUD screens (e.g. `GridView`, `DetailsView`/`FormView`, `DropDownList` for the department picker, `TextBox`/`Button` controls for input).
3. In `DepartmentManagement.aspx.cs`, use the `DbSalarieContext` to query and persist `Departement` and `Salarie` entities (standard EF CRUD: `Add`, `Find`, `Remove`, `SaveChanges`).
4. Set `DepartmentManagement.aspx` as the **Start Page** (right-click → **Set As Start Page**).

### 7. Run the application

1. Press **F5** to build and launch the project with **IIS Express**.
2. Visual Studio Enterprise 2026 Insiders will build the project, start IIS Express, and open the start page in your default browser.
3. Verify that the department and employee lists load correctly and that create/update/delete actions work as expected.

---

## Database Notes

- Database name: `MaBaseSalarie`
- Server: `(LocalDB)\MSSQLLocalDB`
- The database and its schema are generated automatically by EF Code First based on the `Departement` and `Salarie` classes — delete the `.mdf`/`.ldf` files under `App_Data` (or drop the database via SQL Server Object Explorer) to force a clean regeneration if the model changes.

## Contributing

This is a personal academic project. Issues and suggestions are welcome via GitHub Issues.

## License

No license has been specified yet. All rights reserved by the author unless stated otherwise.

## Author

**Youssef Lagmouch** — EMSI, 4IIR G9/G92, ASP.NET module.
