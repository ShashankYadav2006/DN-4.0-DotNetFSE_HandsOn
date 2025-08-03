import React, { useState } from 'react';

// ListofPlayers Component
const ListofPlayers = () => {
  const players = [
    { name: "Virat Kohli", score: 85 },
    { name: "Rohit Sharma", score: 92 },
    { name: "KL Rahul", score: 65 },
    { name: "Hardik Pandya", score: 78 },
    { name: "Rishabh Pant", score: 55 },
    { name: "Ravindra Jadeja", score: 45 },
    { name: "Bhuvneshwar Kumar", score: 35 },
    { name: "Jasprit Bumrah", score: 25 },
    { name: "Mohammed Shami", score: 40 },
    { name: "Yuzvendra Chahal", score: 30 },
    { name: "Shikhar Dhawan", score: 88 }
  ];

  const playersBelow70 = players.filter(player => player.score < 70);

  return (
    <div>
      <h2>List of Players</h2>
      
      <h3>All Players (using map()):</h3>
      <ul>
        {players.map((player, index) => (
          <li key={index}>{player.name}: {player.score} runs</li>
        ))}
      </ul>

      <h3>Players with Scores Below 70 (using arrow functions):</h3>
      <ul>
        {playersBelow70.map((player, index) => (
          <li key={index}>{player.name}: {player.score} runs</li>
        ))}
      </ul>
    </div>
  );
};

const IndianPlayers = () => {
  const allPlayers = [
    "Virat Kohli", "Rohit Sharma", "KL Rahul", "Hardik Pandya", 
    "Rishabh Pant", "Ravindra Jadeja", "Bhuvneshwar Kumar", "Jasprit Bumrah"
  ];

  const [first, second, third, fourth, fifth, sixth, seventh, eighth] = allPlayers;
  
  const oddTeamPlayers = [first, third, fifth, seventh];
  const evenTeamPlayers = [second, fourth, sixth, eighth];

  const T20players = ["Virat Kohli", "Rohit Sharma", "KL Rahul", "Hardik Pandya"];
  const RanjiTrophyPlayers = ["Prithvi Shaw", "Devdutt Padikkal", "Sarfaraz Khan", "Abhimanyu Easwaran"];

  const mergedPlayers = [...T20players, ...RanjiTrophyPlayers];

  return (
    <div>
      <h2>Indian Players</h2>
      
      <h3>Odd Team Players:</h3>
      <ul>
        {oddTeamPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>

      <h3>Even Team Players:</h3>
      <ul>
        {evenTeamPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>

      <h3>Merged Players (T20 + Ranji Trophy):</h3>
      <p><strong>T20 Players:</strong> {T20players.join(', ')}</p>
      <p><strong>Ranji Trophy Players:</strong> {RanjiTrophyPlayers.join(', ')}</p>
      <p><strong>Merged Array:</strong> {mergedPlayers.join(', ')}</p>
    </div>
  );
};
const App = () => {
  const [flag, setFlag] = useState(true);

  return (
    <div style={{ padding: '20px', fontFamily: 'Arial, sans-serif' }}>
      <h1>Cricket App</h1>
      
      <div>
        <button onClick={() => setFlag(true)}>
          Show List of Players (flag = true)
        </button>
        <button onClick={() => setFlag(false)} style={{ marginLeft: '10px' }}>
          Show Indian Players (flag = false)
        </button>
      </div>
      
      <p>Current flag: {flag.toString()}</p>
      
      <hr />
      {flag ? <ListofPlayers /> : <IndianPlayers />}
    </div>
  );
};

export default App;