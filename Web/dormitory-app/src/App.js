// src/App.js

import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './App.css';

const App = () => {
  const [svgContent, setSvgContent] = useState('');
  const [rooms, setRooms] = useState([]);
  const [selectedRoom, setSelectedRoom] = useState(null);

  const handleFileUpload = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      setSvgContent(reader.result);
    };
    reader.readAsText(file);
  };

  const handleSvgClick = (e) => {
    if (e.target.tagName === 'rect' || e.target.tagName === 'path') {
      const roomId = e.target.id;
      const roomNumber = prompt('Enter room number:', e.target.dataset.roomNumber || '');
      if (roomNumber) {
        e.target.dataset.roomNumber = roomNumber;
        setRooms((prevRooms) => [...prevRooms, { id: roomId, number: roomNumber }]);
      }
    }
  };

  const handleSave = () => {
    // Save the rooms data to the server
    axios.post('/api/rooms', rooms)
      .then(response => alert('Rooms saved successfully!'))
      .catch(error => alert('Error saving rooms.'));
  };

  useEffect(() => {
    if (svgContent) {
      const svgElement = document.getElementById('svg-element');
      svgElement.addEventListener('click', handleSvgClick);
      return () => {
        svgElement.removeEventListener('click', handleSvgClick);
      };
    }
  }, [svgContent]);

  return (
    <div className="App">
      <h1>Dormitory Room Planner</h1>
      <input type="file" accept=".svg" onChange={handleFileUpload} />
      {svgContent && <div dangerouslySetInnerHTML={{ __html: svgContent }} id="svg-element" />}
      <button onClick={handleSave}>Save Room Data</button>
      {selectedRoom && (
        <div>
          <h2>Room Information</h2>
          <p>Room ID: {selectedRoom.id}</p>
          <p>Room Number: {selectedRoom.number}</p>
        </div>
      )}
    </div>
  );
};

export default App;
