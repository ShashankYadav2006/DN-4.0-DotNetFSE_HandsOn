# ReactJS Hands-on Lab: Conditional Rendering & Lists

## Objectives Covered

### 1. Explain various ways of Conditional Rendering in React

Conditional rendering in React works the same way conditions work in JavaScript. Here are several ways:

- **Using if statements**
- **Using ternary operator (`condition ? true : false`)**
- **Using logical `&&` operator**
- **Using `switch` statements**
- **Conditional functions returning components**

---

### 2. Explain how to render multiple components

You can render multiple components by:
- Including them inside a parent component using fragments:
  ```jsx
  <>
    <ComponentOne />
    <ComponentTwo />
  </>
  ```
- Using arrays:
  ```jsx
  const components = [<Comp1 />, <Comp2 />];
  return <>{components}</>;
  ```

---

### 3. Define List Component

A List component is one that renders a list of data using `Array.map()` and returns multiple JSX elements, usually `<li>` or cards.

```jsx
const List = ({ items }) => (
  <ul>
    {items.map(item => <li key={item.id}>{item.name}</li>)}
  </ul>
);
```

---

### 4. Explain about Keys in React applications

**Keys** are used in lists to uniquely identify elements for efficient rendering. They help React identify which items have changed, are added, or are removed.

- Should be **unique and stable**.
- Avoid using array indices unless necessary.

---

### 5. Explain how to extract components with keys

When rendering a list, it's a best practice to **extract the list item as a separate component** and assign a key to it:

```jsx
const ListItem = ({ item }) => <li>{item.name}</li>;

const List = ({ items }) => (
  <ul>
    {items.map(item => <ListItem key={item.id} item={item} />)}
  </ul>
);
```

---

### 6. Explain React `map()` Function

React leverages JavaScript’s `map()` to render lists:
```jsx
const fruits = ['Apple', 'Banana'];
const fruitList = fruits.map(fruit => <li key={fruit}>{fruit}</li>);
```

It transforms each item into a React element.

---

