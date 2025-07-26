
# ReactJS Cohort Dashboard Styling - Hands-on Lab

## 🎯 Objective

Style a React component as per the following requirements:

- Use **CSS Modules** and **inline styling**
- Display ongoing and completed cohort details
- Use conditional styling based on cohort status

---

## 📦 Prerequisites

- Node.js
- NPM
- Visual Studio Code

---

## 🛠️ Setup Instructions

1. **Download & Unzip the React App**

2. **Install dependencies**:
```bash
npm install
```

3. **Open the app in VS Code**:
```bash
code .
```

---

## 🎨 Styling Instructions

1. **Create CSS Module**  
Create a file:  
```txt
src/Components/CohortDetails.module.css
```

Add the following styles:

```css
.box {
  width: 300px;
  display: inline-block;
  margin: 10px;
  padding: 10px 20px;
  border: 1px solid black;
  border-radius: 10px;
}

dt {
  font-weight: 500;
}
```

---

2. **Update the Component**  
Open the `CohortDetails.js` file and import the CSS module:

```jsx
import styles from './CohortDetails.module.css';
```

Apply `box` class to the container `div`:

```jsx
<div className={styles.box}>
```

---

3. **Apply Inline Style for <h3> Element**

In the `render` or `return` section:

```jsx
<h3 style={{ color: status === 'ongoing' ? 'green' : 'blue' }}>
  {status} Cohort
</h3>
```

Replace `status` with the actual variable holding the cohort status.

---

## ✅ Expected Output

- Cohort card styled with CSS module
- `<h3>` appears green for "ongoing", blue for others
- `dt` elements have bold font (500 weight)

---

## ⌛ Estimated Time

30 minutes

---

## 📁 File Overview

```
student-app/
├── src/
│   ├── Components/
│   │   ├── CohortDetails.js
│   │   └── CohortDetails.module.css
│   ├── App.js
│   └── ...
```

---

## 🧾 License

This project is part of a hands-on module for Cognizant MyAcademy ReactJS training.
