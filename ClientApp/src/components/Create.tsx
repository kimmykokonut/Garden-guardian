import { useState } from "react";
import { CreateForm } from "./CreateForm";
import { createGarden, fetchSeeds, addSeed } from './../api-helper';
import { Link } from "react-router-dom";

interface GardenData {
  gardenId: number;
  name: string;
  size: string;
  row: number;
  column: number;
  grids: {
    $values: Grid[];
  };
}

interface Grid {
  gridId: number;
  locationCode: string;
  gardenId: number;
  garden: {
    $ref: string;
  };
}

interface Seed {
  seedId: number;
  name: string;
}

const Create = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [gardenData, setGardenData] = useState<GardenData | null>(null);
  const [seeds, setSeeds] = useState<Seed[]>([]);
  const [selectedSeeds, setSelectedSeeds] = useState<{ [key: number]: number }>({});

  const handleCreate = async (formData: object) => {
    setIsLoading(true);
    try {
      const newGarden = await createGarden(formData);
      setGardenData(newGarden);
      const seedList = await fetchSeeds();
      setSeeds(seedList);
      console.log("success", newGarden);
    } catch (error) {
      console.error('fail:', error);
    }
    setIsLoading(false);
  };

  const handleAddSeed = async (seedId: number, gridId: number, locationCode: string) => {
    setIsLoading(true);
    console.log(seedId, gridId, locationCode);
    try {
      if (!seedId) {
        if (!seedId) {
          alert("Please select a seed to plant");
          setIsLoading(false);
          return;
        }
      }
      await addSeed(seedId, gridId, locationCode);
      console.log(`add seed to grid with id ${gridId}`);
    } catch (error) {
      console.error('fail to add seed', error);
    }
    setIsLoading(false);
  }
  const handleSeedChange = (gridId: number, seedId: number) => {
    setSelectedSeeds(prevState => ({
      ...prevState,
      [gridId]: seedId 
    }));
  };

return (
  <div className="create">
    {gardenData === null && (
      <div>
        <CreateForm onSubmit={handleCreate} />
      </div>
    )}
    {isLoading && <p>submitting form...</p>}

    {gardenData != null && (
      <div>
        <p>Garden Info</p>
        <hr />
        <p>Name: {gardenData.name}</p>
        <p>Size: {gardenData.size}</p>
        <p>Grids: {gardenData.row} * {gardenData.column}</p>
        <div>
          <hr />
          <p>Plant a seed in the grid</p>
          <p>Don't see a seed you want? Add a seed to the database <Link to="/add-seed">here...</Link></p>
          {gardenData.grids.$values.map((grid: Grid) => (
            <div key={grid.gridId}>
              <p>Grid Location: {grid.locationCode}</p>
              <label>Available Seeds:</label>
              <select 
              value={selectedSeeds[grid.gridId] || ''} onChange={(e) => handleSeedChange(grid.gridId, parseInt(e.target.value))}>
                <option value="">Plant seed</option>
                {seeds.map(seed => (
                  <option key={seed.seedId} value={seed.seedId}>{seed.name}</option>
                ))}
              </select>
              <button onClick={() => handleAddSeed(selectedSeeds[grid.gridId], grid.gridId, grid.locationCode)}>Plant</button>
            </div>
          ))}
        </div>
      </div>
    )}
  </div>
);
}
export default Create;