import React from 'react';
import './App.css';
import Posts from './Posts';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1 style={{ 
          color: '#2c3e50', 
          marginBottom: '20px',
          textShadow: '2px 2px 4px rgba(0,0,0,0.1)' 
        }}>
          React Blog Application
        </h1>
        <p style={{ 
          color: 'black', 
          marginBottom: '30px',
          fontSize: '18px' 
        }}>
          Demonstrating Component Lifecycle Methods
        </p>
      </header>
      
      <main>
        <Posts />
      </main>
    </div>
  );
}

export default App;