# ScoreCalculatorApp - Student Score Calculator

## 📘 Introduction to React Function Components

### ⚛️ What are Function Components?
**Function Components** are JavaScript functions that return JSX. They are a simpler way to write components compared to class components.

### 🔹 Function Components vs Class Components
| Feature | Function Components | Class Components |
|---------|-------------------|------------------|
| Syntax | Simple function syntax | ES6 class syntax |
| State Management | Use React Hooks (useState) | Use this.state |
| Lifecycle Methods | Use useEffect Hook | Built-in lifecycle methods |
| Performance | Generally faster | Slightly more overhead |
| Code Length | More concise | More verbose |

### 📋 Function Component Structure
```javascript
function ComponentName(props) {
  return (
    // JSX to be rendered
  );
}

const ComponentName = (props) => {
  return (
    // JSX to be rendered
  );
};
```

### 🎨 Styling Components
There are several ways to apply styles to React components:

**1. External CSS Files:**
- Create separate .css files
- Import them in your component
- Use className attribute instead of class

**2. Inline Styles:**
- Use style attribute with JavaScript objects
- camelCase property names
- String values for CSS properties

**3. CSS Modules:**
- Scoped CSS for components
- Prevents style conflicts

### 🧮 Score Calculator Features
This application demonstrates:
- **Function Components**: Modern React component syntax
- **Props**: Passing data to components
- **CSS Styling**: External stylesheet integration
- **Calculations**: JavaScript logic within components
- **Conditional Rendering**: Display results based on calculations

### 📌 Summary
Function components are the modern way to write React components. They are simpler, more readable, and perform better than class components in most cases.

---

## Prerequisites
- Node.js
- NPM
- Visual Studio Code

## Installation Steps

### Step 1: Create React Project
```bash
npx create-react-app scorecalculatorapp
```

### Step 2: Navigate to Project Directory
```bash
cd scorecalculatorapp
```

### Step 3: Create Project Structure
Create the following folders and files:
- `src/Components/` folder
- `src/Components/CalculateScore.js`
- `src/StyleSheets/` folder
- `src/StyleSheets/mystyle.css`

### Step 4: Implement Components
Copy the provided component code into respective files

### Step 5: Update App.js
Import and use the CalculateScore component in App.js

### Step 6: Run the Application
```bash
npm start
```

### Step 7: View in Browser
Open browser and type "localhost:3000" in the address bar

## Project Structure
```
scorecalculatorapp/
├── src/
│   ├── Components/
│   │   └── CalculateScore.js
│   ├── Stylesheets/
│   │   └── mystyle.css
│   ├── App.js
│   ├── App.css
│   └── index.js
├── public/
└── package.json
```

## Features
- **Function Component**: Modern React component approach
- **Score Calculation**: Calculates average score from total and goal
- **Styled Interface**: Custom CSS styling for better presentation
- **Props Usage**: Demonstrates data passing to components

## Estimated Completion Time
**30 minutes**