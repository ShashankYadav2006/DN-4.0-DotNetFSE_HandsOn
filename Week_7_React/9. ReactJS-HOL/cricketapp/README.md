# ES6 Features - Theoretical Overview

## Objectives Covered

This document covers the theoretical aspects of ES6 features as required for the ReactJS hands-on lab.

## ES6 Features

### 1. JavaScript `let`

- `let` is a block-scoped variable declaration introduced in ES6
- Variables declared with `let` are only accessible within the block they are defined
- Unlike `var`, `let` does not allow re-declaration in the same scope
- `let` variables are not hoisted (cannot be used before declaration)

**Example:**
```javascript
if (true) {
    let x = 10;
    console.log(x);
}

```

### 2. Differences between `var` and `let`

| Feature | `var` | `let` |
|---------|-------|-------|
| Scope | Function-scoped | Block-scoped |
| Hoisting | Hoisted (undefined before declaration) | Not hoisted |
| Re-declaration | Allowed | Not allowed in same scope |
| Temporal Dead Zone | No | Yes |

**Example:**
```javascript
// var example
function varExample() {
    if (true) {
        var x = 1;
    }
    console.log(x); 
}

// let example
function letExample() {
    if (true) {
        let y = 1;
    }
}
```

### 3. JavaScript `const`

- `const` creates a constant (read-only) reference to a value
- Must be initialized at the time of declaration
- Block-scoped like `let`
- Cannot be reassigned, but objects/arrays can be mutated
- Convention: Use UPPER_CASE for primitive constants

**Example:**
```javascript
const PI = 3.14159;


const person = { name: "John" };
person.name = "Jane"; 
```

### 4. ES6 Class Fundamentals

- Classes provide a cleaner syntax for creating constructor functions
- Use `class` keyword followed by class name
- Constructor method is called when creating new instances
- Methods are defined without the `function` keyword

**Example:**
```javascript
class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }
    
    greet() {
        return `Hello, I'm ${this.name}`;
    }
}

const person1 = new Person("Alice", 30);
console.log(person1.greet());
```

### 5. ES6 Class Inheritance

- Use `extends` keyword to create inheritance
- `super()` calls the parent constructor
- Child classes can override parent methods
- Access parent methods using `super.methodName()`

**Example:**
```javascript
class Animal {
    constructor(name) {
        this.name = name;
    }
    
    speak() {
        return `${this.name} makes a sound`;
    }
}

class Dog extends Animal {
    constructor(name, breed) {
        super(name); 
        this.breed = breed;
    }
    
    speak() {
        return `${this.name} barks`;
    }
}

const dog = new Dog("Rex", "Labrador");
console.log(dog.speak()); 
```

### 6. ES6 Arrow Functions

- Shorter syntax for writing functions
- Lexical `this` binding (inherits `this` from enclosing scope)
- Implicit return for single expressions
- Cannot be used as constructors

**Syntax:**
```javascript
// Traditional function
function add(a, b) {
    return a + b;
}

// Arrow function
const add = (a, b) => a + b;
const square = x => x * x;
const greet = () => "Hello World";

const multiply = (a, b) => {
    const result = a * b;
    return result;
};
```

### 7. `set()` Method

- `Set` is a collection of unique values
- No duplicate values are allowed
- Has methods like `add()`, `delete()`, `has()`, `clear()`
- Iterable with `forEach()` or `for...of`

**Example:**
```javascript
const mySet = new Set();
mySet.add(1);
mySet.add(2);
mySet.add(2); // Duplicate, won't be added

console.log(mySet.size); // 2
console.log(mySet.has(1)); // true

// From array
const uniqueNumbers = new Set([1, 2, 2, 3, 3, 4]);
console.log([...uniqueNumbers]); // [1, 2, 3, 4]
```

### 8. `map()` Method

- Creates a new array by calling a function on every array element
- Does not modify the original array
- Returns an array of the same length
- Commonly used for data transformation

**Example:**
```javascript
const numbers = [1, 2, 3, 4, 5];

// Double each number
const doubled = numbers.map(x => x * 2);
console.log(doubled); // [2, 4, 6, 8, 10]

// Transform objects
const users = [
    { name: "John", age: 30 },
    { name: "Jane", age: 25 }
];

const userNames = users.map(user => user.name);
console.log(userNames); // ["John", "Jane"]
```

## Additional ES6 Features Used in the Lab

### Destructuring Assignment
- Extract values from arrays or objects into variables
- Provides a clean way to unpack values

**Example:**
```javascript
// Array destructuring
const [first, second, ...rest] = [1, 2, 3, 4, 5];

// Object destructuring
const { name, age } = { name: "John", age: 30 };
```

### Spread Operator (...)
- Expands arrays or objects
- Used for merging arrays, copying arrays, function parameters

**Example:**
```javascript
const arr1 = [1, 2, 3];
const arr2 = [4, 5, 6];
const merged = [...arr1, ...arr2]; // [1, 2, 3, 4, 5, 6]
```

### Filter Method
- Creates a new array with elements that pass a test
- Returns elements where callback returns `true`

**Example:**
```javascript
const numbers = [1, 2, 3, 4, 5];
const evenNumbers = numbers.filter(x => x % 2 === 0);
console.log(evenNumbers); // [2, 4]
```

---