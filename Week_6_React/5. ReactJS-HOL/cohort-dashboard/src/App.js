import React from 'react';
import CohortDetails from './Components/CohortDetails';
import './App.css';

const App = () => {
  const cohorts = [
    {
      id: 'REACT2024 - React FSD',
      startDate: '15-Jan-2024',
      status: 'Ongoing',
      coach: 'Shashank Yadav',
      trainer: 'Vibhav'
    },
    {
      id: 'PYTHON23 - Python DS',
      startDate: '05-Mar-2024',
      status: 'Scheduled',
      coach: 'Prakhar',
      trainer: 'Mayank'
    },
    {
      id: 'NODE2024 - Node.js Backend',
      startDate: '20-Feb-2024',
      status: 'Ongoing',
      coach: 'Shashank Yadav',
      trainer: 'Kapil Sharma'
    },
    {
      id: 'ANGULAR24 - Angular FSD',
      startDate: '10-Apr-2024',
      status: 'Completed',
      coach: 'Kapil Sharma',
      trainer: 'Ajit'
    }
  ];

  return (
    <div className="App">
      <header className="App-header">
        <h1>Cognizant Academy - Cohort Dashboard</h1>
        <div className="cohorts-container">
          {cohorts.map((cohort, index) => (
            <CohortDetails key={index} cohort={cohort} />
          ))}
        </div>
      </header>
    </div>
  );
};

export default App;