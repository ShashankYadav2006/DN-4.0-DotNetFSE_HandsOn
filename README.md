# DN4.0 Deep Skilling - Week 1: Design Patterns and Principles

## Exercise 1: Singleton Pattern

**Description:**  
Implements a thread-safe Singleton using double-checked locking in a `Logger` class.

**Files:**
- `Logger.java` – Singleton class  
- `TestLogger.java` – Demonstrates usage  

**Run:**
```bash
javac *.java
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

## Exercise 2: Factory Method Pattern

**Description:**  
Implements Factory Method to create various document types (Word, PDF, Excel).

**Files:**
- `Document.java` (abstract)  
- `WordDocument.java`, `PdfDocument.java`, `ExcelDocument.java`  
- `DocumentFactory.java` and its concrete implementations  
- `TestFactory.java` – Demonstrates factory usage  

**Run:**
```bash
javac *.java
java TestFactory
```

**Output:**
```
Opening Word document: MyDocument.docx
Saving docs MyDocument.docx
Opening PDF document: MyDocument.pdf
Saving PDF MyDocument.pdf
Launching Excel sheet: MyDocument.xlsx
Saving spreadsheet:  MyDocument.xlsx
```

---

## Tech Used

- Java 21  
- OOP & Design Patterns (Singleton, Factory Method)

---

## Structure
```
DN-4.0-HandsOn-Task/
└── Week1-DesignPatterns/
    ├── SingletonPatternExample/
    │   └── src/
    │       ├── Logger.java
    │       └── TestLogger.java
    └── FactoryMethodPatternExample/
        └── src/
            ├── Document.java
            ├── WordDocument.java
            ├── PdfDocument.java
            ├── ExcelDocument.java
            ├── DocumentFactory.java
            ├── WordDocumentFactory.java
            ├── PdfDocumentFactory.java
            ├── ExcelDocumentFactory.java
            └── TestFactory.java
```
