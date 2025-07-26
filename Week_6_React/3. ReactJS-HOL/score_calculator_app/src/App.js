import React from 'react';
import './App.css';
import { CalculateScore } from './Components/CalculateScore';

function App() {
  return (
    <div className="App">
      <div className="App-header">
        <h1>Student Score Management Portal</h1>
        <CalculateScore 
          Name="Shashank Yadav" 
          School="City Montessori School" 
          total={478} 
          goal={500} 
        />
        
        <CalculateScore 
          Name="Vibhav" 
          School="St. Joseph's Convent" 
          total={371} 
          goal={420} 
        />
        
      </div>
    </div>
  );
}

export default App;