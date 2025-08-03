# ReactJS Hands-on Lab: Theme Switching using Context API

##  Objective

Convert a prop-based theming solution into a **React Context API**-based one for an Employee Management App. This lab demonstrates the benefit of **avoiding prop drilling** by using `createContext`, `useContext`, and a context `Provider`.

---

##  Folder Structure

```
src/
├── App.js
├── Employee.js
├── EmployeesList.js
├── EmployeeCard.js
├── ThemeContext.js
├── EmployeeCard.module.css
├── App.css
```

---

##  Requirements

- Node.js and npm installed
- Visual Studio Code
- Internet connection to install dependencies

---

##  Steps to Run

1. Clone or unzip the project into your local machine.
2. Open the project in VS Code.
3. Run the following command to install dependencies:

```bash
npm install
```

4. Then start the application:

```bash
npm start
```

---

##  Implementation Summary

### 1. **Create Theme Context**

A new file `ThemeContext.js` is created:
```js
import { createContext } from 'react';
const ThemeContext = createContext('light');
export default ThemeContext;
```

### 2. **Update App.js**

- Added `<ThemeContext.Provider>` wrapping all JSX.
- Removed `theme` from props.
- Controlled theme value using a state hook.

### 3. **Update EmployeesList.js**

- Removed `theme` prop.
- Just renders employee cards.

### 4. **Update EmployeeCard.js**

- Imported `useContext` and `ThemeContext`.
- Retrieved theme using `useContext(ThemeContext)`.
- Used theme value in the class names of buttons (`Edit`, `Delete`).

---

## Styling

CSS classes (`light`, `dark`) are defined in `App.css`:
```css
.light {
  color: black;
  background-color: white;
}

.dark {
  color: white;
  background-color: black;
}
```

---

##  Outcome
✅ The app now supports dynamic theme switching without passing theme via props to each component.  
✅ Uses React Context to cleanly share global theme across deeply nested components.



