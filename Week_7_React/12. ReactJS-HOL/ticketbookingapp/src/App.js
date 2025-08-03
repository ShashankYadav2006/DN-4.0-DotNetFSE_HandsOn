import React, { useState } from 'react';

const GuestPage = ({ onLogin }) => {
  const flights = [
    { id: 1, from: 'Mumbai', to: 'Delhi', time: '10:30 AM', price: '₹8,500' },
    { id: 2, from: 'Bangalore', to: 'Chennai', time: '2:15 PM', price: '₹6,200' },
    { id: 3, from: 'Delhi', to: 'Kolkata', time: '6:45 PM', price: '₹7,800' },
    { id: 4, from: 'Hyderabad', to: 'Mumbai', time: '9:20 AM', price: '₹9,100' }
  ];

  return (
    <div>
      <h2>Welcome Guest!</h2>
      <p>Browse available flights below. Login to book tickets.</p>
      
      <h3>Available Flights</h3>
      <div>
        {flights.map(flight => (
          <div key={flight.id} style={{
            border: '1px solid #ddd',
            padding: '15px',
            margin: '10px 0',
            borderRadius: '5px',
            backgroundColor: '#f9f9f9'
          }}>
            <h4>{flight.from} → {flight.to}</h4>
            <p>Departure: {flight.time}</p>
            <p>Price: {flight.price}</p>
            <button disabled style={{ backgroundColor: '#ccc', cursor: 'not-allowed' }}>
              Login to Book
            </button>
          </div>
        ))}
      </div>
      
      <div style={{ marginTop: '20px', textAlign: 'center' }}>
        <button onClick={onLogin} style={{
          backgroundColor: '#4CAF50',
          color: 'white',
          padding: '10px 20px',
          fontSize: '16px',
          border: 'none',
          borderRadius: '5px',
          cursor: 'pointer'
        }}>
          Login
        </button>
      </div>
    </div>
  );
};
const UserPage = ({ onLogout }) => {
  const [bookedFlights, setBookedFlights] = useState([]);
  
  const flights = [
    { id: 1, from: 'Mumbai', to: 'Delhi', time: '10:30 AM', price: '₹8,500' },
    { id: 2, from: 'Bangalore', to: 'Chennai', time: '2:15 PM', price: '₹6,200' },
    { id: 3, from: 'Delhi', to: 'Kolkata', time: '6:45 PM', price: '₹7,800' },
    { id: 4, from: 'Hyderabad', to: 'Mumbai', time: '9:20 AM', price: '₹9,100' }
  ];

  const bookTicket = (flightId) => {
    if (!bookedFlights.includes(flightId)) {
      setBookedFlights([...bookedFlights, flightId]);
      alert('Ticket booked successfully!');
    } else {
      alert('Already booked this flight!');
    }
  };

  return (
    <div>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <h2>Welcome User!</h2>
        <button onClick={onLogout} style={{
          backgroundColor: '#f44336',
          color: 'white',
          padding: '8px 16px',
          border: 'none',
          borderRadius: '5px',
          cursor: 'pointer'
        }}>
          Logout
        </button>
      </div>
      
      <p>You can now book tickets for your preferred flights.</p>
      
      <h3>Book Your Tickets</h3>
      <div>
        {flights.map(flight => (
          <div key={flight.id} style={{
            border: '1px solid #ddd',
            padding: '15px',
            margin: '10px 0',
            borderRadius: '5px',
            backgroundColor: bookedFlights.includes(flight.id) ? '#e8f5e8' : '#fff'
          }}>
            <h4>{flight.from} → {flight.to}</h4>
            <p>Departure: {flight.time}</p>
            <p>Price: {flight.price}</p>
            <button 
              onClick={() => bookTicket(flight.id)}
              style={{
                backgroundColor: bookedFlights.includes(flight.id) ? '#27ae60' : '#2196F3',
                color: 'white',
                padding: '8px 16px',
                border: 'none',
                borderRadius: '5px',
                cursor: 'pointer'
              }}
            >
              {bookedFlights.includes(flight.id) ? 'Booked ✓' : 'Book Ticket'}
            </button>
          </div>
        ))}
      </div>
      {bookedFlights.length > 0 && (
        <div style={{
          marginTop: '20px',
          padding: '15px',
          backgroundColor: '#e8f5e8',
          borderRadius: '5px',
          border: '1px solid #27ae60'
        }}>
          <h4>Your Bookings</h4>
          <p>You have booked {bookedFlights.length} ticket(s).</p>
        </div>
      )}
    </div>
  );
};

const App = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => {
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
  };

  let currentPage;
  if (isLoggedIn) {
    currentPage = <UserPage onLogout={handleLogout} />;
  } else {
    currentPage = <GuestPage onLogin={handleLogin} />;
  }

  return (
    <div style={{
      maxWidth: '800px',
      margin: '0 auto',
      padding: '20px',
      fontFamily: 'Arial, sans-serif'
    }}>
      <div style={{
        textAlign: 'center',
        marginBottom: '30px',
        padding: '20px',
        backgroundColor: '#2c3e50',
        color: 'white',
        borderRadius: '10px'
      }}>
        <h1>✈️ Ticket Booking App</h1>
        <p>Book your flights easily and securely</p>
        
        <div style={{ marginTop: '10px', fontSize: '14px' }}>
          Status: <strong>{isLoggedIn ? 'Logged In' : 'Guest User'}</strong>
        </div>
      </div>
      {currentPage}
      
    </div>
  );
};

export default App;