# DN4.0 Deep Skilling - Week 1

## Week-1: Design Patterns and Principles (C# Version)

### Exercise 1: Singleton Pattern

**Description:**  
Implements a thread-safe Singleton using double-checked locking in a `Logger` class.

**Files:**
- `Logger.cs` – Singleton class  
- `TestLogger.cs` – Demonstrates usage  
- `Output/Output.png` – Screenshot of output  

**Run:**
```bash
dotnet new console -n SingletonPatternExample
dotnet run
```

---

### Exercise 2: Factory Method Pattern

**Description:**  
Implements Factory Method Pattern to create various document types like Word, PDF, Excel using C#.

**Files:**
- `Document.cs` (abstract base class)  
- `WordDocument.cs`, `PdfDocument.cs`, `ExcelDocument.cs`  
- `DocumentFactory.cs`, `WordDocumentFactory.cs`, `PdfDocumentFactory.cs`, `ExcelDocumentFactory.cs`  
- `Program.cs` – Demonstrates usage  
- `Output/OUTPUT.png` – Screenshot of output  

**Run:**
```bash
dotnet new console -n FactoryMethodPatternExample
dotnet run
```

---

## Week-1: Data Structures and Algorithm

### Exercise 1: E-commerce Platform Search Function

**Description:**  
Demonstrates linear and binary search logic and explains Big O notation using C#.

**Files:**
- `EcommerceSearchMain.cs` – Includes all functionality in a single file  
- `Output/Output.png` – Screenshot of output  

**Run:**
```bash
dotnet new console -n EcommerceSearch
dotnet run
```

---

### Exercise 2: Financial Forecasting with Recursion

**Description:**  
Recursive forecasting tool to compute future values based on a fixed or variable growth rate. Also demonstrates memoization to optimize performance.

**Files:**
- `ForecastDemo.cs` – Includes all recursive logic and memoization  
- `Output/Output.png` – Screenshot of output  

**Run:**
```bash
dotnet new console -n FinancialForecast
dotnet run
```

---

## Technologies Used

- C# (.NET 6 or above)  
- OOP and Design Patterns (Singleton, Factory Method)  
- Data Structures and Algorithms (Search, Recursion, Memoization)

---

## Folder Structure

```
DN-4.0-HANDSON-TASK/
├── Week-1_Data Structures and Algorithm/
│   ├── 1_Ecommerce Platform search Function/
│   │   ├── Code/
│   │   │   └── EcommerceSearchMain.cs
│   │   └── Output/
│   │       └── Output.png
│   └── 2_Financial Forecasting/
│       ├── Code/
│       │   └── ForecastDemo.cs
│       └── Output/
│           └── Output.png
├── Week-1_Design Patterns and Principles/
│   ├── 1_SingletonPatternExample/
│   │   ├── Code/
│   │   │   ├── Logger.cs
│   │   │   └── TestLogger.cs
│   │   └── Output/
│   │       └── Output.png
│   └── 2_FactoryMethodPatternExample/
│       ├── Code/
│       │   ├── Document.cs
│       │   ├── DocumentFactory.cs
│       │   ├── WordDocument.cs
│       │   ├── PdfDocument.cs
│       │   ├── ExcelDocument.cs
│       │   ├── WordDocumentFactory.cs
│       │   ├── PdfDocumentFactory.cs
│       │   ├── ExcelDocumentFactory.cs
│       │   └── Program.cs
│       └── Output/
│           └── OUTPUT.png
```
