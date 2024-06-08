// src/App.js

import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import './App.css';

const App = () => {
  const [svgContent, setSvgContent] = useState('');
  const [rooms, setRooms] = useState([]);
  const svgContainerRef = useRef(null);

  const handleFileUpload = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      setSvgContent(reader.result);
    };
    reader.readAsText(file);
  };

  const handleRoomClick = (e) => {
    const target = e.target.closest('rect, path');
    if (!target) return;

    const roomId = target.id || `room-${Math.random().toString(36).substr(2, 9)}`;
    target.id = roomId;
    const existingRoom = rooms.find(room => room.id === roomId);

    if (existingRoom) {
      alert(`Room Number: ${existingRoom.number}`);
    } else {
      const roomNumber = prompt('Enter room number:', '');
      if (roomNumber) {
        target.dataset.roomNumber = roomNumber;
        target.classList.add('selected');
        const newRoom = { id: roomId, number: roomNumber, element: target.outerHTML };
        setRooms([...rooms, newRoom]);
      }
    }
  };

  const handleSave = () => {
    axios.post('/api/rooms', rooms)
      .then(response => alert('Rooms saved successfully!'))
      .catch(error => alert('Error saving rooms.'));
  };

  useEffect(() => {
    if (svgContainerRef.current) {
      const svgElements = svgContainerRef.current.querySelectorAll('rect, path');
      svgElements.forEach(elem => {
        elem.style.cursor = 'pointer';
        elem.addEventListener('click', handleRoomClick);
      });
      return () => {
        svgElements.forEach(elem => {
          elem.removeEventListener('click', handleRoomClick);
        });
      };
    }
  }, [svgContent]);

  return (
    <div className="App">
      <h1>Dormitory Room Planner</h1>
      <input type="file" accept=".svg" onChange={handleFileUpload} />
      {svgContent && (
        <div ref={svgContainerRef} dangerouslySetInnerHTML={{ __html: svgContent }} className="svg-container" />
      )}
      <button onClick={handleSave}>Save Room Data</button>
    </div>
  );
};

export default App;
