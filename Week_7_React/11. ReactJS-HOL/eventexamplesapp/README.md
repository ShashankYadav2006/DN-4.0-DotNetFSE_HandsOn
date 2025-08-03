# React Events and Event Handling - Theoretical Overview

## Objectives Covered

This document covers the theoretical aspects of React events and event handling as required for the Event Examples App lab.

## 1. React Events

**Definition:** React events are actions that can be triggered as a result of user actions or system-generated events, such as mouse clicks, key presses, form submissions, etc.

**Key Characteristics:**
- React events are based on the W3C standard for events
- They provide a consistent API across different browsers
- React uses its own event system called SyntheticEvent
- Events are handled through event handlers (functions)

**Common React Events:**
- **Mouse Events**: `onClick`, `onDoubleClick`, `onMouseOver`, `onMouseOut`
- **Keyboard Events**: `onKeyDown`, `onKeyUp`, `onKeyPress`
- **Form Events**: `onChange`, `onSubmit`, `onFocus`, `onBlur`
- **Window Events**: `onLoad`, `onResize`, `onScroll`

**Example:**
```jsx
function Button() {
  const handleClick = () => {
    console.log('Button clicked!');
  };

  return <button onClick={handleClick}>Click Me</button>;
}
```

## 2. Event Handlers

**Definition:** Event handlers are functions that are called when a specific event occurs. They contain the logic that should execute in response to the event.

**Key Points:**
- Event handlers are regular JavaScript functions
- They can be defined inline or as separate functions
- They receive an event object as their first parameter
- Can access component state and props
- Can call other functions or update state

**Types of Event Handler Definitions:**

### Inline Event Handlers:
```jsx
<button onClick={() => console.log('Clicked!')}>
  Click Me
</button>
```

### Function Reference:
```jsx
function MyComponent() {
  const handleClick = () => {
    console.log('Button clicked!');
  };

  return <button onClick={handleClick}>Click Me</button>;
}
```

### Class Component Method:
```jsx
class MyComponent extends React.Component {
  handleClick = () => {
    console.log('Button clicked!');
  }

  render() {
    return <button onClick={this.handleClick}>Click Me</button>;
  }
}
```

### Event Handler with Parameters:
```jsx
function MyComponent() {
  const handleClick = (message) => {
    console.log(message);
  };

  return (
    <button onClick={() => handleClick('Hello World!')}>
      Click Me
    </button>
  );
}
```

## 3. Synthetic Event

**Definition:** SyntheticEvent is React's wrapper around native DOM events. It provides a consistent interface for handling events across different browsers.

**Key Features:**
- **Cross-browser Compatibility**: Works the same way in all browsers
- **Same Interface**: Has the same interface as native events
- **Event Pooling**: React reuses event objects for performance (legacy feature)
- **Prevents Default**: Can call `preventDefault()` and `stopPropagation()`

**SyntheticEvent Properties:**
- `event.target`: The element that triggered the event
- `event.currentTarget`: The element that the event handler is attached to
- `event.type`: The type of event (click, submit, etc.)
- `event.preventDefault()`: Prevents default browser behavior
- `event.stopPropagation()`: Stops event from bubbling up

**Example:**
```jsx
function Form() {
  const handleSubmit = (event) => {
    event.preventDefault(); // Prevent form submission
    console.log('Form submitted');
    console.log('Event type:', event.type); // "submit"
    console.log('Target:', event.target); // form element
  };

  return (
    <form onSubmit={handleSubmit}>
      <button type="submit">Submit</button>
    </form>
  );
}
```

**Accessing Native Event:**
```jsx
const handleClick = (event) => {
  console.log('Synthetic event:', event);
  console.log('Native event:', event.nativeEvent);
};
```

## 4. React Event Naming Convention

**Definition:** React follows a specific naming convention for events that differs from standard HTML events.

**Key Rules:**
- **camelCase**: All event names use camelCase instead of lowercase
- **"on" Prefix**: All event handlers start with "on"
- **No Hyphens**: No hyphens or underscores in event names

**HTML vs React Event Names:**

| HTML Event | React Event |
|------------|-------------|
| `onclick` | `onClick` |
| `onchange` | `onChange` |
| `onsubmit` | `onSubmit` |
| `onmouseover` | `onMouseOver` |
| `onkeydown` | `onKeyDown` |
| `onfocus` | `onFocus` |
| `onblur` | `onBlur` |
| `ondoubleclick` | `onDoubleClick` |

**Examples:**
```jsx
// Correct React event naming
<button onClick={handleClick}>Click</button>
<input onChange={handleChange} />
<form onSubmit={handleSubmit}>
<div onMouseOver={handleMouseOver}>

// Incorrect (HTML style)
<button onclick={handleClick}>Click</button>
<input onchange={handleChange} />
```

## Additional Concepts for the Lab

### 1. The `this` Keyword in Class Components

In class components, `this` refers to the component instance. Event handlers need to be bound to maintain the correct context.

**Problem with `this`:**
```jsx
class MyComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = { count: 0 };
  }

  handleClick() {
    // 'this' will be undefined without proper binding
    this.setState({ count: this.state.count + 1 });
  }

  render() {
    return <button onClick={this.handleClick}>Click</button>;
  }
}
```

**Solutions:**

### Bind in Constructor:
```jsx
constructor(props) {
  super(props);
  this.state = { count: 0 };
  this.handleClick = this.handleClick.bind(this);
}
```

### Arrow Function (Recommended):
```jsx
handleClick = () => {
  this.setState({ count: this.state.count + 1 });
}
```

### Inline Arrow Function:
```jsx
<button onClick={() => this.handleClick()}>Click</button>
```

### 2. Multiple Event Handlers

You can call multiple functions from a single event:

```jsx
const handleIncrement = () => {
  incrementCounter();
  sayHello();
  logAction();
};

<button onClick={handleIncrement}>Increment</button>
```

### 3. Event Handler with Arguments

**Using Arrow Functions:**
```jsx
const handleWelcome = (message) => {
  console.log(message);
};

<button onClick={() => handleWelcome('Welcome!')}>
  Say Welcome
</button>
```

**Using Bind:**
```jsx
<button onClick={handleWelcome.bind(this, 'Welcome!')}>
  Say Welcome
</button>
```

### 4. Form Events and State Management

```jsx
function CurrencyConverter() {
  const [rupees, setRupees] = useState('');
  const [euros, setEuros] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    const euroValue = parseFloat(rupees) * 0.012; // conversion rate
    setEuros(euroValue.toFixed(2));
  };

  const handleInputChange = (event) => {
    setRupees(event.target.value);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input 
        type="number" 
        value={rupees}
        onChange={handleInputChange}
        placeholder="Enter rupees"
      />
      <button type="submit">Convert</button>
      <p>Euros: {euros}</p>
    </form>
  );
}
```

### 5. Common Event Patterns

**Button Click Counter:**
```jsx
const [count, setCount] = useState(0);

const increment = () => setCount(count + 1);
const decrement = () => setCount(count - 1);

<button onClick={increment}>+</button>
<span>{count}</span>
<button onClick={decrement}>-</button>
```

**Input Handling:**
```jsx
const [text, setText] = useState('');

const handleChange = (event) => {
  setText(event.target.value);
};

<input value={text} onChange={handleChange} />
```

