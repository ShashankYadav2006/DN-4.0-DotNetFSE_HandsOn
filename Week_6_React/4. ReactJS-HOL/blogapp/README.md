# BlogApp - React Component Lifecycle

## **React Component Lifecycle**

### **1. Need and Benefits of Component Lifecycle**
React component lifecycle provides methods that allow developers to control the behavior of components during their creation, update, and destruction phases. Understanding the lifecycle helps in:
* Managing side effects (like API calls, timers)
* Improving performance through controlled rendering
* Cleaning up resources before component removal
* Executing code at specific points during a component's life

### **2. Lifecycle Hook Methods in Class Components**

**Mounting Phase (when the component is being inserted into the DOM):**
* `constructor()` – Initializes state and bindings
* `static getDerivedStateFromProps()` – Syncs state with props
* `render()` – Returns JSX to render UI
* `componentDidMount()` – Called once after initial render; ideal for API calls

**Updating Phase (when props or state changes):**
* `static getDerivedStateFromProps()` – Called before every re-render
* `shouldComponentUpdate()` – Allows skipping re-render if not needed
* `render()` – Renders updated JSX
* `getSnapshotBeforeUpdate()` – Captures info (e.g., scroll position) before DOM changes
* `componentDidUpdate()` – Runs after DOM updates; useful for reacting to prop/state changes

**Unmounting Phase (when component is being removed from DOM):**
* `componentWillUnmount()` – Cleanup tasks like clearing timers or canceling subscriptions

**Error Handling Phase:**
* `static getDerivedStateFromError()` – Updates state to display fallback UI
* `componentDidCatch()` – Logs error info for debugging

### **3. Sequence of Steps in Rendering a Component**

**Initial Mount:**
1. `constructor()`
2. `getDerivedStateFromProps()`
3. `render()`
4. `componentDidMount()`

**Update:**
1. `getDerivedStateFromProps()`
2. `shouldComponentUpdate()`
3. `render()`
4. `getSnapshotBeforeUpdate()`
5. `componentDidUpdate()`

**Unmount:**
* `componentWillUnmount()`

---

## Prerequisites
- Node.js
- NPM
- Visual Studio Code

## Installation Steps

### Step 1: Create React Application
```bash
npx create-react-app blogapp
```

### Step 2: Navigate to Project Directory
```bash
cd blogapp
```

### Step 3: Open in VS Code
```bash
code .
```

### Step 4: Create Component Files
Create the following files in src folder:
- Post.js (Post class/model)
- Posts.js (Posts component)

### Step 5: Implement Components
Copy the provided code into respective files

### Step 6: Update App.js
Add Posts component to App.js

### Step 7: Run Application
```bash
npm start
```

## Project Structure
```
blogapp/
├── src/
│   ├── Post.js (Post model)
│   ├── Posts.js (Posts component)
│   ├── App.js
│   ├── App.css
│   └── index.js
├── public/
└── package.json
```

## Features
- **API Integration**: Fetches posts from JSONPlaceholder API
- **Lifecycle Methods**: Demonstrates componentDidMount and componentDidCatch
- **Error Handling**: Graceful error management with componentDidCatch
- **State Management**: Uses constructor to initialize state

## API Endpoint
- **URL**: https://jsonplaceholder.typicode.com/posts
- **Method**: GET
- **Returns**: Array of post objects with id, title, body, userId

## Estimated Completion Time
**60 minutes**