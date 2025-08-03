import React, { useState } from 'react';


const CurrencyConvertor = () => {
  const [rupees, setRupees] = useState('');
  const [euros, setEuros] = useState('');


  const handleSubmit = (event) => {
    event.preventDefault();
    if (rupees) {
      const euroValue = parseFloat(rupees) * 0.012; // 1 INR = 0.012 EUR
      setEuros(euroValue.toFixed(2));
    }
  };

  const handleInputChange = (event) => {
    setRupees(event.target.value);
  };

  return (
    <div style={{border: '1px solid #ccc', padding: '20px', margin: '20px', borderRadius: '5px'}}>
      <h3>Currency Converter</h3>
      <div>
        <div>
          <label>Indian Rupees: </label>
          <input 
            type="number" 
            value={rupees}
            onChange={handleInputChange}
            placeholder="Enter amount in INR"
          />
        </div>
        <br />
        <button onClick={handleSubmit}>Convert to Euro</button>
        <br /><br />
        {euros && <p><strong>Euros: €{euros}</strong></p>}
      </div>
    </div>
  );
};

const App = () => {

  const [counter, setCounter] = useState(0);
  const [message, setMessage] = useState('');

  const increment = () => {
    setCounter(counter + 1);
  };

  const sayHello = () => {
    setMessage('Hello! Counter has been incremented!');
  };
  const handleIncrement = () => {
    increment(); 
    sayHello(); 
  };

  const decrement = () => {
    setCounter(counter - 1);
    setMessage('');
  };

  const sayWelcome = (welcomeMsg) => {
    setMessage(welcomeMsg);
  };

  const onPress = (event) => {
    console.log('Synthetic event:', event);
    setMessage('I was clicked');
  };

  return (
    <div style={{textAlign: 'center', padding: '20px', fontFamily: 'Arial, sans-serif'}}>
      <h1>Event Examples App</h1>
      
      <div style={{margin: '30px 0', padding: '20px', border: '1px solid #ddd', borderRadius: '5px'}}>
        <h2>Counter: {counter}</h2>
        

        <button onClick={handleIncrement} style={{margin: '10px', padding: '10px 20px'}}>
          Increment
        </button>
        
        <button onClick={decrement} style={{margin: '10px', padding: '10px 20px'}}>
          Decrement
        </button>
        
        {message && <p style={{color: 'green', fontWeight: 'bold'}}>{message}</p>}
      </div>

      <div style={{margin: '30px 0', padding: '20px', border: '1px solid #ddd', borderRadius: '5px'}}>
        <h3>Welcome Button</h3>
        <button 
          onClick={() => sayWelcome('Welcome to React Event Handling!')} 
          style={{margin: '10px', padding: '10px 20px', backgroundColor: '#4CAF50', color: 'white'}}
        >
          Say Welcome
        </button>
      </div>

      <div style={{margin: '30px 0', padding: '20px', border: '1px solid #ddd', borderRadius: '5px'}}>
        <h3>Synthetic Event Demo</h3>
        <button 
          onClick={onPress} 
          style={{margin: '10px', padding: '10px 20px', backgroundColor: '#2196F3', color: 'white'}}
        >
          OnPress (Synthetic Event)
        </button>
      </div>

      <CurrencyConvertor />
    </div>
  );
};

export default App;