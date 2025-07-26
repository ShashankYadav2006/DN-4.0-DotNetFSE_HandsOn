import React from 'react';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Welcome to the first session of React</h1>
        <p>
          This is my first React application created using create-react-app.
        </p>
        <div className="info-section">
          <h2>What you'll learn:</h2>
          <ul>
            <li>Single Page Applications (SPA)</li>
            <li>React fundamentals</li>
            <li>Virtual DOM concepts</li>
            <li>Component-based architecture</li>
          </ul>
        </div>
      </header>
    </div>
  );
}

export default App;