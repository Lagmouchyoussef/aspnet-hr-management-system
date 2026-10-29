<div align="center">

# 🏢 ASP.NET HR Management System

### A clean, Code-First HR web app for managing departments & employees

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8.1-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6.5.2-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://learn.microsoft.com/ef/ef6/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb)
[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2026%20Insiders-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)](https://visualstudio.microsoft.com/insiders/)
[![Platform](https://img.shields.io/badge/platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)](#)
[![License](https://img.shields.io/badge/license-unlicensed-lightgrey?style=for-the-badge)](#-license)

<br/>

<img src="https://raw.githubusercontent.com/github/explore/main/topics/asp-net/asp-net.png" width="90" alt="ASP.NET" />
&nbsp;&nbsp;
<img src="https://raw.githubusercontent.com/github/explore/main/topics/csharp/csharp.png" width="90" alt="C#" />
&nbsp;&nbsp;
<img src="https://raw.githubusercontent.com/github/explore/main/topics/sql/sql.png" width="90" alt="SQL" />

</div>

---

## 📑 Table of Contents

- [📖 Overview](#-overview)
- [✨ Features](#-features)
- [🎥 Demo](#-demo)
- [🧱 Tech Stack](#-tech-stack)
- [🗺️ Domain Model](#️-domain-model)
- [📂 Project Structure](#-project-structure)
- [🚀 Getting Started](#-getting-started)
- [🛠️ Build It From Scratch in Visual Studio Enterprise 2026 Insiders](#️-build-it-from-scratch-in-visual-studio-enterprise-2026-insiders)
- [🗄️ Database Notes](#️-database-notes)
- [🧭 Roadmap](#-roadmap)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)
- [👤 Author](#-author)

---

## 📖 Overview

**ASP.NET HR Management System** is a lightweight web application for managing an organization's **departments** 🏬 and **employees** 👨‍💼👩‍💼.

It's built with classic **ASP.NET Web Forms** on top of **Entity Framework 6 (Code First)** — meaning the entire SQL Server database schema is generated automatically from plain C# classes. No hand-written SQL scripts, no manual migrations: define your model, hit **F5**, and the database appears. 🪄

> 💡 A great reference project if you want to see Code First EF6 wired into a Web Forms app from the ground up.

---

## ✨ Features

- 🏬 **Department management** — create, edit, delete and list departments, each with a location.
- 👥 **Employee management** — add employees, assign them to a department, and record their job title and salary.
- 🔗 **Relational data** — employees are linked to departments via a foreign key, fully modeled in C#.
- 🧬 **Code First database generation** — the `MaBaseSalarie` database and its schema are created and kept in sync automatically by Entity Framework.
- ⚡ **Zero manual setup** — no SQL scripts to run; just point it at LocalDB and go.
- 🪶 **Lightweight & dependency-light** — only EF6 and the Roslyn CodeDom provider as NuGet dependencies.

---

## 🎥 Demo

<div align="center">

> 🖼️ _Add a screenshot or screen recording of the app here!_
>
> `docs/demo.gif` — e.g. record the Departments/Employees CRUD flow with [ScreenToGif](https://www.screentogif.com/) or [ShareX](https://getsharex.com/) and drop it into a `docs/` folder, then reference it like this:
>
> ```md
> ![Demo](docs/demo.gif)
> ```

</div>

---

## 🧱 Tech Stack

| Layer           | Technology                                       |
|------------------|---------------------------------------------------|
| 🎨 UI            | ASP.NET Web Forms (`.aspx` + code-behind)          |
| 🧑‍💻 Language     | C#                                                  |
| ⚙️ Runtime       | .NET Framework 4.8.1                               |
| 🗃️ Data Access   | Entity Framework 6.5.2 (Code First)                |
| 🛢️ Database      | SQL Server LocalDB (`MSSQLLocalDB`)                |
| 🌐 Web Server    | IIS Express                                        |
| 🧰 IDE           | Visual Studio Enterprise 2026 Insiders             |

---

## 🗺️ Domain Model

```text
┌───────────────────────────┐        1      N      ┌───────────────────────────┐
│        Departement        │───────────────────────│          Salarie          │
├───────────────────────────┤                       ├───────────────────────────┤
│ DepartementId   (PK, int) │                       │ SalarieId      (PK, int)  │
│ Description     (string)  │                       │ Nom            (string)   │
│ Location        (string)  │                       │ Prenom         (string)   │
│ SalraieListe    (IList)   │                       │ Fonction       (string)   │
└───────────────────────────┘                       │ Salaire        (double)   │
                                                      │ DepartementId  (FK, int)  │
                                                      └───────────────────────────┘
```

🧠 `DbSalarieContext` (in [`Models/EmployeeDatabaseContext.cs`](Models/EmployeeDatabaseContext.cs)) exposes `DbSet<Departement>` and `DbSet<Salarie>`, and reads the `MyDbConnection` connection string from `Web.config`.

---

## 📂 Project Structure

```text
WebAppCodeFirst/
├── 📄 DepartmentManagement.aspx            # Departments & employees UI (markup)
├── 🧠 DepartmentManagement.aspx.cs         # Code-behind: CRUD logic
├── ⚙️ DepartmentManagement.aspx.designer.cs
├── 🧵 Global.asax / Global.asax.cs         # Application lifecycle events
├── 📁 Models/
│   ├── 🏬 Department.cs                    # Departement entity
│   ├── 👤 Employee.cs                      # Salarie entity
│   └── 🗃️ EmployeeDatabaseContext.cs       # EF Code First DbContext
├── 📁 Properties/
│   └── AssemblyInfo.cs
├── 📁 App_Data/                            # LocalDB data files (generated at runtime)
├── 🔧 Web.config / Web.Debug.config / Web.Release.config
├── 📦 packages.config                      # NuGet packages (EF6, CodeDom providers)
├── 🏗️ WebAppCodeFirst.csproj
└── 🧩 WebAppCodeFirst.slnx
```

---

## 🚀 Getting Started

### ✅ Prerequisites

| Requirement | Notes |
|---|---|
| 🧰 **Visual Studio** | Enterprise 2026 Insiders (or any recent VS) with the **ASP.NET and web development** workload |
| 📦 **.NET Framework 4.8.1 Developer Pack** | Required to build the target framework |
| 🛢️ **SQL Server Express LocalDB** | Installed by default with the web development workload |
| 🔧 **Git** | For cloning the repository |

### ⚡ Quick Start

```bash
# 1️⃣ Clone the repository
git clone https://github.com/Lagmouchyoussef/aspnet-hr-management-system.git
```

2️⃣ Open `WebAppCodeFirst.slnx` in Visual Studio.

3️⃣ Restore NuGet packages — right-click the solution in **Solution Explorer** → **Restore NuGet Packages** (pulls in `EntityFramework 6.5.2` and `Microsoft.CodeDom.Providers.DotNetCompilerPlatform`).

4️⃣ Double-check the `MyDbConnection` connection string in `Web.config` matches your local setup:

```xml
<add name="MyDbConnection"
     connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MaBaseSalarie;Integrated Security=True;MultipleActiveResultSets=True"
     providerName="System.Data.SqlClient" />
```

5️⃣ Press **F5** (or **Ctrl+F5**) to build & run with **IIS Express**. 🏁

6️⃣ If `DepartmentManagement.aspx` doesn't open automatically, right-click it → **Set As Start Page**, then run again.

> ✨ On first run, Entity Framework Code First creates the `MaBaseSalarie` database on your LocalDB instance automatically — nothing else to configure!

---

## 🛠️ Build It From Scratch in Visual Studio Enterprise 2026 Insiders

Want to recreate this project yourself, step by step? Follow along below. 👇

### 1️⃣ Create the Web Forms project

1. Open **Visual Studio Enterprise 2026 Insiders**.
2. On the Start Window, click **Create a new project**.
3. Search for `ASP.NET Web Application` and select **ASP.NET Web Application (.NET Framework)** — make sure **C#** is the selected language.
4. Click **Next**.
5. Configure the project:
   - **Project name**: `WebAppCodeFirst`
   - **Location**: your working folder
   - **Solution name**: `WebAppCodeFirst`
6. Click **Create**.
7. On the **New ASP.NET Web Application** screen, pick the **Web Forms** template, leave **Authentication** as **No Authentication** (or configure as needed), then click **Create**. ✅

### 2️⃣ Install Entity Framework 6 via NuGet

1. Right-click the project in **Solution Explorer** → **Manage NuGet Packages…** 📦
2. Search for `EntityFramework` and install the latest **6.x** version (this project uses `6.5.2`).
3. This adds the `EntityFramework` / `EntityFramework.SqlServer` references, a `packages.config` entry, and the EF configuration section in `Web.config`.

### 3️⃣ Create the domain model

Add a `Models` folder (**right-click project → Add → New Folder**), then add the entity classes:

**`Models/Department.cs`** 🏬
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

**`Models/Employee.cs`** 👤
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

### 4️⃣ Create the Code First `DbContext`

**`Models/EmployeeDatabaseContext.cs`** 🗃️
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

### 5️⃣ Configure the LocalDB connection string

Open `Web.config` and add the connection string inside `<connectionStrings>`:

```xml
<connectionStrings>
  <add name="MyDbConnection"
       connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MaBaseSalarie;Integrated Security=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

🪄 Entity Framework Code First creates the `MaBaseSalarie` database automatically the first time the app runs — no migration or manual script needed for this scenario.

### 6️⃣ Build the Web Forms page

1. Right-click the project → **Add → Web Form**, name it `DepartmentManagement.aspx`. 📄
2. Design the markup with the controls you need for CRUD (`GridView`, `DetailsView`/`FormView`, a `DropDownList` for the department picker, `TextBox`/`Button` controls for input).
3. In `DepartmentManagement.aspx.cs`, use `DbSalarieContext` to query and persist `Departement` and `Salarie` entities (`Add`, `Find`, `Remove`, `SaveChanges`).
4. Set `DepartmentManagement.aspx` as the **Start Page** (right-click → **Set As Start Page**). ⭐

### 7️⃣ Run the application

1. Press **F5** to build & launch with **IIS Express**. 🚀
2. Visual Studio builds the project, starts IIS Express, and opens the start page in your default browser.
3. Verify departments/employees load correctly, and that create/update/delete actions all work. ✅

---

## 🗄️ Database Notes

| Item | Value |
|---|---|
| 🏷️ Database name | `MaBaseSalarie` |
| 🖥️ Server | `(LocalDB)\MSSQLLocalDB` |
| 🧬 Schema source | Generated automatically by EF Code First from `Departement` and `Salarie` |

> 🔄 Need a clean rebuild? Delete the `.mdf` / `.ldf` files under `App_Data` (or drop the database via **SQL Server Object Explorer**) to force EF to regenerate the schema the next time the app runs.

---

## 🧭 Roadmap

Ideas for taking this further:

- [ ] 🔐 Add authentication & role-based access (HR vs. employee views)
- [ ] 🔍 Add search, filtering and pagination to the grids
- [ ] 🧪 Add unit tests for the data layer
- [ ] 🌐 Expose a Web API layer alongside the Web Forms UI
- [ ] 🎨 Modernize the UI with Bootstrap

---

## 🤝 Contributing

Contributions, issues and feature requests are welcome! 🙌
Feel free to check the [issues page](https://github.com/Lagmouchyoussef/aspnet-hr-management-system/issues) or open a pull request.

---

## 📄 License

No license has been specified yet — all rights reserved by the author unless stated otherwise.

---

## 👤 Author

**Youssef Lagmouch**

[![GitHub](https://img.shields.io/badge/GitHub-Lagmouchyoussef-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Lagmouchyoussef)

<div align="center">

⭐ **If you found this project useful, consider giving it a star!** ⭐

</div>
