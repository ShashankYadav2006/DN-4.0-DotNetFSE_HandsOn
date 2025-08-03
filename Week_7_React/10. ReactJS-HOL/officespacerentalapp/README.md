# JSX and React Fundamentals - Theoretical Overview

## Objectives Covered

This document covers the theoretical aspects of JSX and React fundamentals as required for the Office Space Rental App lab.

## 1. JSX (JavaScript XML)

**Definition:** JSX is a syntax extension for JavaScript that allows you to write HTML-like code within JavaScript. It makes React components more readable and easier to write.

**Key Features:**
- Combines the power of JavaScript with the familiarity of HTML
- Gets transpiled to regular JavaScript by tools like Babel
- Makes component creation more intuitive
- Supports JavaScript expressions within curly braces `{}`

**Example:**
```jsx
// JSX
const element = <h1>Hello, World!</h1>;

// Equivalent JavaScript (what JSX compiles to)
const element = React.createElement('h1', null, 'Hello, World!');
```

## 2. ECMA Script (ES)

**Definition:** ECMAScript is a standard for scripting languages, and JavaScript is an implementation of ECMAScript.

**Key Points:**
- **ES5 (2009)**: Added strict mode, JSON support, array methods
- **ES6/ES2015 (2015)**: Major update with classes, arrow functions, let/const, modules
- **ES2016+**: Yearly releases with incremental improvements
- React heavily uses ES6+ features like classes, arrow functions, destructuring, and modules

**ES6 Features commonly used in React:**
```javascript
// Arrow functions
const component = () => <div>Hello</div>;

// Classes
class MyComponent extends React.Component { }

// Destructuring
const { name, age } = props;

// Template literals
const message = `Hello, ${name}!`;

// Modules
import React from 'react';
export default MyComponent;
```

## 3. React.createElement()

**Definition:** `React.createElement()` is the fundamental method that creates React elements. JSX is syntactic sugar for this method.

**Syntax:**
```javascript
React.createElement(type, props, ...children)
```

**Parameters:**
- **type**: HTML tag name (string) or React component
- **props**: Object containing properties/attributes (can be null)
- **children**: Child elements or text content

**Examples:**
```javascript
// Creating a simple element
React.createElement('h1', null, 'Hello World');

// With attributes
React.createElement('img', { src: 'image.jpg', alt: 'Photo' });

// With children
React.createElement('div', { className: 'container' }, 
  React.createElement('h1', null, 'Title'),
  React.createElement('p', null, 'Description')
);

// JSX equivalent
<div className="container">
  <h1>Title</h1>
  <p>Description</p>
</div>
```

## 4. Creating React Nodes with JSX

**React Node:** Any renderable content in React (elements, strings, numbers, arrays, fragments).

**Creating Elements:**
```jsx
// Simple element
const title = <h1>Office Space Rental</h1>;

// Element with attributes
const image = <img src="office.jpg" alt="Office Space" />;

// Element with children
const container = (
  <div className="office-card">
    <h2>Modern Office</h2>
    <p>Downtown location</p>
  </div>
);

// Self-closing tags must have closing slash
const input = <input type="text" />;
const hr = <hr />;
```

**JSX Rules:**
- Must return a single parent element (or React Fragment)
- Use `className` instead of `class`
- Use `htmlFor` instead of `for`
- All tags must be closed
- Use camelCase for event handlers (`onClick`, `onChange`)

## 5. Rendering JSX to DOM

**Definition:** The process of converting JSX elements into actual DOM elements and displaying them in the browser.

**Method:** `ReactDOM.render()` (React 17) or `createRoot().render()` (React 18+)

**React 17 Syntax:**
```javascript
import React from 'react';
import ReactDOM from 'react-dom';

const App = () => <h1>Hello World</h1>;

ReactDOM.render(<App />, document.getElementById('root'));
```

**React 18+ Syntax:**
```javascript
import React from 'react';
import { createRoot } from 'react-dom/client';

const App = () => <h1>Hello World</h1>;

const root = createRoot(document.getElementById('root'));
root.render(<App />);
```

**Process:**
1. JSX gets transpiled to `React.createElement()` calls
2. React creates a virtual DOM representation
3. ReactDOM renders the virtual DOM to actual DOM
4. Browser displays the rendered HTML

## 6. JavaScript Expressions in JSX

**Definition:** You can embed any JavaScript expression in JSX by wrapping it in curly braces `{}`.

**Examples:**
```jsx
const name = "John";
const age = 25;
const user = { name: "Alice", role: "Admin" };

// Variables
const greeting = <h1>Hello, {name}!</h1>;

// Expressions
const mathResult = <p>Sum: {2 + 3}</p>;

// Function calls
const timestamp = <p>Current time: {new Date().toLocaleString()}</p>;

// Object properties
const userInfo = <p>User: {user.name} ({user.role})</p>;

// Conditional rendering
const status = <p>{age >= 18 ? 'Adult' : 'Minor'}</p>;

// Array methods
const numbers = [1, 2, 3, 4, 5];
const listItems = (
  <ul>
    {numbers.map(num => <li key={num}>{num * 2}</li>)}
  </ul>
);

// Complex expressions
const office = { name: "Tech Hub", rent: 75000 };
const rentColor = office.rent > 60000 ? 'green' : 'red';
const display = (
  <div>
    <h3>{office.name}</h3>
    <p style={{ color: rentColor }}>Rent: ₹{office.rent}</p>
  </div>
);
```

**Important Notes:**
- Only expressions are allowed, not statements (no `if`, `for`, `while`)
- Use ternary operator for conditional rendering
- Use `map()` for rendering lists
- Use `&&` for conditional display
- Functions must return something renderable

## 7. Inline CSS in JSX

**Definition:** CSS styles can be applied directly to JSX elements using the `style` attribute with a JavaScript object.

**Syntax:**
```jsx
<element style={{ property: 'value', anotherProperty: 'value' }} />
```

**Key Points:**
- Style attribute expects a JavaScript object, not a string
- CSS property names use camelCase (`backgroundColor`, `fontSize`)
- Values can be strings or numbers
- Numbers are treated as pixels for applicable properties
- Use double curly braces: outer for JavaScript expression, inner for object


**CSS Property Conversions:**
- `background-color` → `backgroundColor`
- `font-size` → `fontSize`
- `font-weight` → `fontWeight`
- `margin-top` → `marginTop`
- `text-align` → `textAlign`
- `border-radius` → `borderRadius`

**Best Practices:**
- Use external CSS classes for complex styling
- Inline styles are good for dynamic/conditional styling
- Create style objects for reusability
- Consider performance for frequently changing styles

