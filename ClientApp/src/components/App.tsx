//import { useState } from 'react'
import Home from "./Home";
import Header from "./Header";
import Create from "./Create";
import DashboardGarden from "./DashboardGarden";
import SeedForm from "./SeedForm";
import SeedDetail from "./SeedDetail";
import GardenDetail from "./GardenDetail";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

function App() {

  return (
    <Router>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/create" element={<Create />} />
        <Route path="/dashboard" element={<DashboardGarden />} />
        <Route path="/add-seed" element={<SeedForm />} />
        <Route path="/seed-detail/:seedId" element={<SeedDetail />} />
        <Route path="/garden-detail/:gardenId" element={<GardenDetail />} />
      </Routes>
    </Router>
  );
}

export default App