
# TrainersApp - React Router Hands-On Lab

This project is part of Cognizant Academy's ReactJS Hands-On Lab. The objective is to create a Single Page Application (SPA) using React and React Router that manages and displays trainer details.

## 🎯 Objectives

- Create a React application named **TrainersApp**
- Display a list of trainers using mock data
- Use **React Router DOM** to navigate between components:
  - Home
  - Trainers List
  - Trainer Details (via URL parameter)
- Use URL parameters to dynamically show trainer details

## 🛠️ Prerequisites

- Node.js and npm
- Visual Studio Code

## 📦 Setup Instructions

1. **Create React App**:
```bash
npx create-react-app TrainersApp
cd TrainersApp
code .
```

2. **Install React Router DOM**:
```bash
npm install react-router-dom
```

## 📁 Folder Structure Overview

```
TrainersApp/
├── src/
│   ├── App.js
│   ├── Home.js
│   ├── TrainerList.js
│   ├── TrainerDetails.js
│   ├── TrainersMock.js
│   └── trainer.js
```

## 📄 File Responsibilities

### `trainer.js`
Defines a `Trainer` class with:
- trainerId, name, email, phone, technology, skills

### `TrainersMock.js`
Contains mock trainer data using real human names like:
- Rohit Mehra, Sneha Kapoor, Arjun Verma, etc.

### `TrainerList.js`
Displays a list of trainers with clickable links using `<Link>` from `react-router-dom`.

### `TrainerDetails.js`
- Uses `useParams()` to read `id` from the URL
- Fetches the correct trainer and displays their details

### `Home.js`
Displays a basic home welcome message.

### `App.js`
- Sets up `BrowserRouter`
- Adds navigation with `<Link>`
- Defines routes for `/`, `/trainers`, `/trainer/:id`

## 🚀 How to Run

```bash
npm start
```

Then visit:
- [http://localhost:3000/](http://localhost:3000/) → Home
- [http://localhost:3000/trainers](http://localhost:3000/trainers) → Trainer List
- Click on a name → Trainer Details
