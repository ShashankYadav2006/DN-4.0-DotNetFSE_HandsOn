EF Core 8.0 – Hands-On Labs
===========================

Project: Retail Inventory Management System  
Technology: .NET 8 Console App + Entity Framework Core 8  
Database: SQL Server

This project demonstrates how to use EF Core 8.0 in a real-world scenario. It consists of 5 labs that walk through setting up models, configuring DbContext, creating a database, inserting data, and retrieving data.

--------------------------------------------------------------------------------
Lab 1: Understanding ORM
--------------------------------------------------------------------------------

Objective:
----------
- Understand what ORM (Object-Relational Mapping) is and how EF Core bridges C# objects and relational tables.

Key Concepts:
-------------
- ORM maps C# classes (like `Product`, `Category`) to database tables.
- EF Core allows developers to work with databases using C# without writing SQL.
- Benefits:
  • Productivity
  • Maintainability
  • Strongly typed access to data

EF Core 8.0 Features:
---------------------
- JSON column mapping
- Compiled models for faster startup
- Interceptors and better bulk operations

No code files for Lab 1 — it's theory only.

--------------------------------------------------------------------------------
Lab 2: Setting Up the Database Context
--------------------------------------------------------------------------------

Objective:
----------
- Create model classes and configure `AppDbContext` to connect to SQL Server.

Files:
------
1. Models/Category.cs  
2. Models/Product.cs  
3. Data/AppDbContext.cs

Description:
------------
- `Category` and `Product` are POCO (Plain Old CLR Object) classes.
- `AppDbContext` inherits from `DbContext`, and defines `DbSet<Product>` and `DbSet<Category>`.
- The connection string is passed via `OnConfiguring()` method in `AppDbContext`.

Note: You must update the connection string to match your SQL Server setup.

--------------------------------------------------------------------------------
Lab 3: Creating and Applying Migrations
--------------------------------------------------------------------------------

Objective:
----------
- Use EF Core CLI to create migrations and apply schema changes to SQL Server.

Steps:
------
1. Install EF CLI (if not already):
   > dotnet tool install --global dotnet-ef

2. Create Migration:
   > dotnet ef migrations add InitialCreate

3. Apply Migration:
   > dotnet ef database update

Output:
-------
- Creates a `Migrations/` folder with schema definition.
- SQL Server database will have `Products` and `Categories` tables.

Tools Used:
-----------
- SQL Server Management Studio (SSMS) or Azure Data Studio for verification

--------------------------------------------------------------------------------
Lab 4: Inserting Initial Data into the Database
--------------------------------------------------------------------------------

Objective:
----------
- Use EF Core to insert categories and products using async methods.

Code File:
----------
Program.cs (Lab 4 version)

Code Summary:
-------------
- Creates two categories: "Electronics" and "Groceries"
- Creates two products: "Laptop" (₹75,000) and "Rice Bag" (₹1,200)
- Uses `AddRangeAsync()` and `SaveChangesAsync()` to save data to the database

Command:
--------
> dotnet run

Expected Output:
----------------
Inserted data successfully.

--------------------------------------------------------------------------------
Lab 5: Retrieving Data from the Database
--------------------------------------------------------------------------------

Objective:
----------
- Use EF Core to retrieve and query data from the database.

Code File:
----------
Program.cs (Lab 5 version)

Operations Performed:
---------------------
1. Retrieve all products using `ToListAsync()`
2. Find a product by ID using `FindAsync()`
3. Get the first expensive product using `FirstOrDefaultAsync()` with condition

Sample Output:
--------------
📦 All Products:
Laptop - ₹75000  
Rice Bag - ₹1200  

🔍 Found by ID 1: Laptop  

💰 First Expensive Product (> ₹50,000): Laptop  

Note:
-----
- Ensure data from Lab 4 is already inserted.
- If empty output, re-run Lab 4 insert logic first.

--------------------------------------------------------------------------------
Folder Structure
--------------------------------------------------------------------------------

RetailInventory/
├── Models/
│   ├── Category.cs
│   └── Product.cs
├── Data/
│   └── AppDbContext.cs
├── Migrations/
│   └── (Auto-generated after running migrations)
├── Program.cs      ← This is updated for each Lab 4 or 5
├── Lab4_InsertData.cs (optional backup)
├── Lab5_RetrieveData.cs (optional backup)
├── RetailInventory.csproj
└── README.txt

--------------------------------------------------------------------------------
Important Notes
--------------------------------------------------------------------------------

- Keep only one `Program.cs` with a `Main()` method active at a time.
- You can switch between Lab 4 and Lab 5 by copying their logic into `Program.cs`.
- Make sure your connection string in `AppDbContext` is valid for your machine.
- Run `dotnet clean` and `dotnet build` if errors persist.

--------------------------------------------------------------------------------
END OF README
--------------------------------------------------------------------------------
