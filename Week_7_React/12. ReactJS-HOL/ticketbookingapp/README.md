# React Conditional Rendering - Theoretical Overview

## Objectives Covered

This document covers the theoretical aspects of conditional rendering in React as required for the Ticket Booking App lab.

## 1. Conditional Rendering in React

**Definition:** Conditional rendering in React allows you to render different UI elements or components based on certain conditions. It's similar to how conditions work in JavaScript.

**Key Concepts:**
- Render different components based on application state
- Show/hide elements dynamically
- Control what users see based on their status (logged in/out, permissions, etc.)
- Create interactive user interfaces that respond to user actions

**Why Use Conditional Rendering:**
- **User Experience**: Show relevant content based on user state
- **Security**: Hide sensitive content from unauthorized users
- **Performance**: Avoid rendering unnecessary components
- **Dynamic UI**: Create responsive interfaces that adapt to data

## 2. Methods of Conditional Rendering

### **2.1 If-Else Statements**
```jsx
function Welcome({ isLoggedIn }) {
  if (isLoggedIn) {
    return <h1>Welcome back!</h1>;
  } else {
    return <h1>Please sign up.</h1>;
  }
}
```

### **2.2 Ternary Operator (Most Common)**
```jsx
function Welcome({ isLoggedIn }) {
  return (
    <div>
      {isLoggedIn ? <h1>Welcome back!</h1> : <h1>Please sign up.</h1>}
    </div>
  );
}
```

### **2.3 Logical AND (&&) Operator**
```jsx
function Notification({ hasMessages }) {
  return (
    <div>
      {hasMessages && <p>You have new messages!</p>}
    </div>
  );
}
```

### **2.4 Switch Statements**
```jsx
function UserStatus({ status }) {
  switch (status) {
    case 'guest':
      return <GuestPage />;
    case 'user':
      return <UserPage />;
    case 'admin':
      return <AdminPage />;
    default:
      return <LoginPage />;
  }
}
```

## 3. Element Variables

**Definition:** Element variables are JavaScript variables that store JSX elements. They allow you to conditionally assign different UI elements to variables and then render them.

**Benefits:**
- **Cleaner Code**: Separate conditional logic from JSX
- **Reusability**: Store complex elements for multiple uses
- **Readability**: Make render methods more readable
- **Performance**: Pre-calculate elements before rendering

**Examples:**

### **Basic Element Variable:**
```jsx
function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  
  let button;
  if (isLoggedIn) {
    button = <button onClick={logout}>Logout</button>;
  } else {
    button = <button onClick={login}>Login</button>;
  }
  
  return (
    <div>
      <h1>My App</h1>
      {button}
    </div>
  );
}
```

### **Complex Element Variables:**
```jsx
function Dashboard({ user }) {
  let content;
  
  if (!user) {
    content = (
      <div>
        <h2>Welcome Guest</h2>
        <p>Please login to access more features</p>
        <button>Login</button>
      </div>
    );
  } else {
    content = (
      <div>
        <h2>Welcome, {user.name}!</h2>
        <p>Here's your dashboard</p>
        <button>Logout</button>
      </div>
    );
  }
  
  return (
    <div className="dashboard">
      {content}
    </div>
  );
}
```

### **Multiple Element Variables:**
```jsx
function TicketBooking({ isLoggedIn }) {
  const guestContent = (
    <div>
      <h2>Flight Information</h2>
      <p>Browse available flights</p>
      <FlightList />
    </div>
  );
  
  const userContent = (
    <div>
      <h2>Book Your Flight</h2>
      <p>Select and book your tickets</p>
      <BookingForm />
    </div>
  );
  
  return (
    <div>
      {isLoggedIn ? userContent : guestContent}
    </div>
  );
}
```

## 4. Preventing Components from Rendering

**Definition:** Sometimes you want to hide a component even though it was rendered by another component. You can return `null` instead of its render output to prevent rendering.

**Key Points:**
- **Return null**: Component doesn't render anything
- **Lifecycle Still Runs**: Component lifecycle methods still execute
- **Conditional Prevention**: Use with conditional statements
- **Performance**: Avoids unnecessary DOM updates

### **Using null to Prevent Rendering:**
```jsx
function WarningBanner({ warn }) {
  if (!warn) {
    return null; // Component doesn't render
  }
  
  return (
    <div className="warning">
      Warning: Something went wrong!
    </div>
  );
}

function App() {
  const [showWarning, setShowWarning] = useState(false);
  
  return (
    <div>
      <WarningBanner warn={showWarning} />
      <button onClick={() => setShowWarning(!showWarning)}>
        Toggle Warning
      </button>
    </div>
  );
}
```

### **Conditional Component Rendering:**
```jsx
function UserProfile({ user, isVisible }) {
  // Prevent rendering if not visible
  if (!isVisible) {
    return null;
  }
  
  // Prevent rendering if no user data
  if (!user) {
    return null;
  }
  
  return (
    <div>
      <h3>{user.name}</h3>
      <p>{user.email}</p>
    </div>
  );
}
```

### **Hiding Components Based on Permissions:**
```jsx
function AdminPanel({ user }) {
  // Only render for admin users
  if (user.role !== 'admin') {
    return null;
  }
  
  return (
    <div>
      <h2>Admin Controls</h2>
      <button>Manage Users</button>
      <button>View Reports</button>
    </div>
  );
}
```

## 5. Practical Patterns for Ticket Booking App

### **Login State Management:**
```jsx
function TicketApp() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  
  const handleLogin = () => {
    setIsLoggedIn(true);
  };
  
  const handleLogout = () => {
    setIsLoggedIn(false);
  };
  
  return (
    <div>
      {isLoggedIn ? (
        <UserView onLogout={handleLogout} />
      ) : (
        <GuestView onLogin={handleLogin} />
      )}
    </div>
  );
}
```

### **Guest vs User Pages:**
```jsx
function GuestPage({ onLogin }) {
  return (
    <div>
      <h1>Welcome Guest</h1>
      <p>Browse flight information</p>
      <FlightInfo />
      <button onClick={onLogin}>Login to Book</button>
    </div>
  );
}

function UserPage({ onLogout }) {
  return (
    <div>
      <h1>Welcome User</h1>
      <p>Book your tickets here</p>
      <BookingSystem />
      <button onClick={onLogout}>Logout</button>
    </div>
  );
}
```

### **Navigation Based on Auth Status:**
```jsx
function Navigation({ isLoggedIn, onLogin, onLogout }) {
  const authButton = isLoggedIn ? (
    <button onClick={onLogout}>Logout</button>
  ) : (
    <button onClick={onLogin}>Login</button>
  );
  
  return (
    <nav>
      <h1>Ticket Booking</h1>
      {authButton}
    </nav>
  );
}
```

## 6. Best Practices

### **Do's:**
- Use ternary operators for simple conditions
- Use element variables for complex conditional logic
- Return `null` to prevent component rendering
- Keep conditional logic readable and maintainable
- Use meaningful variable names for element variables

### **Don'ts:**
- Don't nest too many ternary operators
- Don't put complex logic directly in JSX
- Don't forget to handle edge cases (null, undefined)
- Don't render sensitive data for unauthorized users

### **Performance Tips:**
- Use React.memo() for components that re-render frequently
- Avoid creating new objects/functions in render methods
- Consider using useMemo() for expensive computations
- Return early from components when possible

