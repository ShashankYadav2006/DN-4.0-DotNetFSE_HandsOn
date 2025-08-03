import React from 'react';

const App = () => {
  // heading element
  const heading = <h1>Office Space Rental App</h1>;

  // single office object
  const office = {
    name: "Tech Hub Office",
    rent: 75000,
    address: "123 Business Street, Mumbai"
  };

  // list of offices
  const offices = [
    {
      id: 1,
      name: "Creative Workspace", 
      rent: 45000,
      address: "456 Innovation Road, Bangalore"
    },
    {
      id: 2,
      name: "Executive Suite",
      rent: 85000, 
      address: "789 Corporate Ave, Delhi"
    },
    {
      id: 3,
      name: "Startup Hub",
      rent: 35000,
      address: "321 Startup Lane, Pune"  
    },
    {
      id: 4,
      name: "Premium Office",
      rent: 120000,
      address: "567 Business Park, Hyderabad"
    }
  ];

  return (
    <div style={{textAlign: 'center'}}>
      {/* render heading */}
      {heading}
      
      {/* featured office */}
      <div>
        <h2>Featured Office</h2>
        <img src="https://images.unsplash.com/photo-1497366216548-37526070297c?w=400&h=200&fit=crop" alt="office space" />
        <h3>{office.name}</h3>
        <p style={{color: office.rent < 60000 ? 'red' : 'green'}}>
          Rent: ₹{office.rent}
        </p>
        <p>{office.address}</p>
      </div>

      {/* all offices */}
      <div>
        <h2>Available Offices</h2>
        {offices.map(item => (
          <div key={item.id}>
            <img src="https://images.unsplash.com/photo-1497366811353-6870744d04b2?w=400&h=200&fit=crop" alt="office" />
            <h3>{item.name}</h3>
            <p style={{color: item.rent < 60000 ? 'red' : 'green'}}>
              Rent: ₹{item.rent}
            </p>
            <p>{item.address}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default App;