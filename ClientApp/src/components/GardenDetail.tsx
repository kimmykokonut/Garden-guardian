import { useEffect, useState } from "react";
import { getGardenById } from "../api-helper";
import { useParams } from "react-router-dom";

interface Garden {
  grids: any;
  name: string;
  size: string;
  row: number;
  column: number;
  gardenId: number;
}
interface GardenDetailParams {
  gardenId: string;
}


const GardenDetail = () => {
  const { gardenId } = useParams<GardenDetailParams>();
  const [garden, setGarden] = useState<Garden | null>(null);

  useEffect(() => {
    const fetchGardenDetails = async () => {
      try {
        if (!gardenId) return;
        const actualId = parseInt(gardenId, 10);
        const gardenDetails = await getGardenById(actualId);
        setGarden(gardenDetails);
        console.log(gardenDetails);
      } catch (error) {
        console.error('fail', error);
      }
    };
    fetchGardenDetails();
  }, [gardenId]);

  if (!garden) {
    console.log('no garden set', gardenId);
    return <div>...loading...</div>;
  }

  return (
    <>
      {garden && (
        <div id="garden-deets">

          <h1>{garden.name}</h1>
          <p>Size: {garden.size}</p>
          <p>Total Grids: {garden.row * garden.column}</p>
          <p>Grids:</p>
          <ul>
            {garden.grids.$values.map((grid) => (
              <li key={grid.gridId}>{grid.locationCode}</li>
            ))}
          </ul>
          <p>Seeds in each grid go here</p>
        </div>
      )
      }
    </>
  );
};
export default GardenDetail;