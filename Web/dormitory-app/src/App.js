import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import './App.css';

const App = () => {
  const [svgContent, setSvgContent] = useState('');
  const [rooms, setRooms] = useState([]);
  const [isDrawing, setIsDrawing] = useState(false);
  const [newPolygonPoints, setNewPolygonPoints] = useState([]);
  const svgContainerRef = useRef(null);
  const snapThreshold = 10; // расстояние привязки в пикселях

  const handleFileUpload = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      setSvgContent(reader.result);
    };
    reader.readAsText(file);
  };

  const getMidpoint = (x1, y1, x2, y2) => ({
    x: (x1 + x2) / 2,
    y: (y1 + y2) / 2,
  });

  const getNearestMidpoint = (x, y) => {
    const svg = svgContainerRef.current.querySelector('svg');
    const midpoints = [];

    svg.querySelectorAll('rect').forEach(rect => {
      const bbox = rect.getBBox();
      const topMid = getMidpoint(bbox.x, bbox.y, bbox.x + bbox.width, bbox.y);
      const bottomMid = getMidpoint(bbox.x, bbox.y + bbox.height, bbox.x + bbox.width, bbox.y + bbox.height);
      const leftMid = getMidpoint(bbox.x, bbox.y, bbox.x, bbox.y + bbox.height);
      const rightMid = getMidpoint(bbox.x + bbox.width, bbox.y, bbox.x + bbox.width, bbox.y + bbox.height);
      
      midpoints.push(topMid, bottomMid, leftMid, rightMid);
    });

    let nearestMidpoint = { x, y };
    let minDist = Infinity;
    midpoints.forEach(midpoint => {
      const dist = Math.hypot(midpoint.x - x, midpoint.y - y);
      if (dist < minDist && dist < snapThreshold) {
        nearestMidpoint = midpoint;
        minDist = dist;
      }
    });

    return nearestMidpoint;
  };

  const handleSVGClick = (e) => {
    if (isDrawing) {
      const svg = svgContainerRef.current.querySelector('svg');
      const pt = svg.createSVGPoint();
      pt.x = e.clientX;
      pt.y = e.clientY;
      const svgPoint = pt.matrixTransform(svg.getScreenCTM().inverse());

      const nearestMidpoint = getNearestMidpoint(svgPoint.x, svgPoint.y);
      const points = [...newPolygonPoints];

      if (points.length > 0) {
        const lastPoint = points[points.length - 1];
        const dx = Math.abs(nearestMidpoint.x - lastPoint.x);
        const dy = Math.abs(nearestMidpoint.y - lastPoint.y);

        if (dx > dy) {
          nearestMidpoint.y = lastPoint.y;
        } else {
          nearestMidpoint.x = lastPoint.x;
        }
      }

      setNewPolygonPoints([...points, nearestMidpoint]);
    }
  };

  const handleStartDrawing = () => {
    setIsDrawing(true);
    setNewPolygonPoints([]);
  };

  const handleFinishDrawing = () => {
    if (newPolygonPoints.length < 3) {
      alert('A polygon must have at least 3 points.');
      return;
    }

    const pointsString = newPolygonPoints.map(point => `${point.x},${point.y}`).join(' ');
    const roomId = `room-${Math.random().toString(36).substr(2, 9)}`;
    const roomNumber = prompt('Enter room number:', '');

    if (roomNumber) {
      const newRoom = { id: roomId, number: roomNumber, points: pointsString };
      setRooms([...rooms, newRoom]);

      const svgDoc = svgContainerRef.current.querySelector('svg');
      const polygonElement = document.createElementNS("http://www.w3.org/2000/svg", "polygon");
      polygonElement.setAttribute('points', pointsString);
      polygonElement.setAttribute('id', roomId);
      polygonElement.classList.add('interactive', 'selected');
      polygonElement.dataset.roomNumber = roomNumber;

      const bbox = polygonElement.getBBox();
      const textElement = document.createElementNS("http://www.w3.org/2000/svg", "text");
      textElement.setAttribute('x', bbox.x + bbox.width / 2);
      textElement.setAttribute('y', bbox.y + bbox.height / 2);
      textElement.setAttribute('text-anchor', 'middle');
      textElement.setAttribute('alignment-baseline', 'middle');
      textElement.setAttribute('font-size', '14');
      textElement.setAttribute('fill', 'black');
      textElement.textContent = roomNumber;
      textElement.id = `text-${roomId}`;

      svgDoc.appendChild(polygonElement);
      svgDoc.appendChild(textElement);

      setIsDrawing(false);
      setNewPolygonPoints([]);
    }
  };

  const handleRoomClick = (e) => {
    const target = e.target.closest('polygon');
    if (!target) return;

    const roomId = target.id;
    const existingRoom = rooms.find(room => room.id === roomId);

    if (existingRoom) {
      alert(`Room Number: ${existingRoom.number}`);
    }
  };

  const handleSave = () => {
    axios.post('/api/rooms', rooms)
      .then(response => alert('Rooms saved successfully!'))
      .catch(error => alert('Error saving rooms.'));
  };

  useEffect(() => {
    if (svgContainerRef.current) {
      const svgElements = svgContainerRef.current.querySelectorAll('polygon');
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
  }, [svgContent, rooms]);

  useEffect(() => {
    if (svgContainerRef.current) {
      const svgDoc = svgContainerRef.current.querySelector('svg');
      if (svgDoc) {
        const previewPolygon = svgDoc.getElementById('preview-polygon');
        if (previewPolygon) {
          previewPolygon.setAttribute('points', newPolygonPoints.map(point => `${point.x},${point.y}`).join(' '));
        } else if (isDrawing) {
          const polygonElement = document.createElementNS("http://www.w3.org/2000/svg", "polygon");
          polygonElement.setAttribute('id', 'preview-polygon');
          polygonElement.setAttribute('points', newPolygonPoints.map(point => `${point.x},${point.y}`).join(' '));
          polygonElement.classList.add('preview');
          svgDoc.appendChild(polygonElement);
        }
      }
    }
  }, [newPolygonPoints, isDrawing]);

  return (
    <div className="App">
      <h1>Dormitory Room Planner</h1>
      <input type="file" accept=".svg" onChange={handleFileUpload} />
      <button onClick={handleStartDrawing} disabled={isDrawing}>Start Drawing</button>
      <button onClick={handleFinishDrawing} disabled={!isDrawing}>Finish Drawing</button>
      {svgContent && (
        <div 
          ref={svgContainerRef} 
          onClick={handleSVGClick} 
          dangerouslySetInnerHTML={{ __html: svgContent }} 
          className="svg-container" 
        />
      )}
      <button onClick={handleSave}>Save Room Data</button>
    </div>
  );
};

export default App;
