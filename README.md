
# DN4.0 Deep Skilling - Week 1

## Week-1: Design Patterns and Principles

### Exercise 1: Singleton Pattern

**Description:**  
Implements a thread-safe Singleton using double-checked locking in a `Logger` class.

**Files:**
- `Logger.java` – Singleton class  
- `TestLogger.java` – Demonstrates usage  
- `Output/Output.png` – Screenshot of output  

**Run:**
```bash
javac Logger.java TestLogger.java
java TestLogger
```

**Sample Output:**
```
[Logger Initialized]
[main] Logging message: "First message"
[main] Logging message: "Second message"
Logger instance comparison: logger1 and logger2 refer to the same object ? true
[Thread-1] Logging message: "Message from thread 1"
[Thread-2] Logging message: "Message from thread 2"
```

---

### Exercise 2: Factory Method Pattern

**Description:**  
Implements Factory Method Pattern to create various document types like Word, PDF, Excel.

**Files:**
- `Document.java` (abstract base class)  
- `WordDocument.java`, `PdfDocument.java`, `ExcelDocument.java`  
- `DocumentFactory.java`, `WordDocumentFactory.java`, `PdfDocumentFactory.java`, `ExcelDocumentFactory.java`  
- `TestFactory.java` – Demonstrates usage  
- `Output/OUTPUT.png` – Screenshot of output  

**Run:**
```bash
javac *.java
java TestFactory
```

**Sample Output:**
```
Opening Word document: MyDocument.docx
Saving docs MyDocument.docx
Opening PDF document: MyDocument.pdf
Saving PDF MyDocument.pdf
Launching Excel sheet: MyDocument.xlsx
Saving spreadsheet:  MyDocument.xlsx
```

---

## Week-1: Data Structures and Algorithm

### Exercise 1: E-commerce Platform Search Function

**Description:**  
Demonstrates linear and binary search logic and explains Big O notation.

**Files:**
- `EcommerceSearchMain.java` – Includes all functionality in a single file  
- `Output/Output.png` – Screenshot of output  

**Run:**
```bash
javac EcommerceSearchMain.java
java EcommerceSearchMain
```

---

### Exercise 2: Financial Forecasting with Recursion

**Description:**  
Recursive forecasting tool to compute future values based on a fixed or variable growth rate. Also demonstrates memoization to optimize performance.

**Files:**
- `ForecastDemo.java` – Includes all recursive logic and memoization  
- `Output/Output.png` – Screenshot of output  

**Run:**
```bash
javac ForecastDemo.java
java ForecastDemo
```

---

## Technologies Used

- Java 21  
- OOP and Design Patterns (Singleton, Factory Method)  
- Data Structures and Algorithms (Search, Recursion, Memoization)

---

## Folder Structure

```
DN-4.0-HANDSON-TASK/
├── Week-1_Data Structures and Algorithm/
│   ├── 1_Ecommerce Platform search Function/
│   │   ├── Code/
│   │   │   └── EcommerceSearchMain.java
│   │   └── Output/
│   │       └── Output.png
│   └── 2_Financial Forecasting/
│       ├── Code/
│       │   └── ForecastDemo.java
│       └── Output/
│           └── Output.png
├── Week-1_Design Patterns and Principles/
│   ├── 1_SingletonPatternExample/
│   │   ├── Code/
│   │   │   ├── Logger.java
│   │   │   └── TestLogger.java
│   │   └── Output/
│   │       └── Output.png
│   └── 2_FactoryMethodPatternExample/
│       ├── Code/
│       │   ├── Document.java
│       │   ├── DocumentFactory.java
│       │   ├── WordDocument.java
│       │   ├── PdfDocument.java
│       │   ├── ExcelDocument.java
│       │   ├── WordDocumentFactory.java
│       │   ├── PdfDocumentFactory.java
│       │   ├── ExcelDocumentFactory.java
│       │   └── TestFactory.java
│       └── Output/
│           └── OUTPUT.png
```
