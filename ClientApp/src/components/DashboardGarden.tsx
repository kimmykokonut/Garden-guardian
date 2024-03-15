import { useEffect, useState } from "react";
import Garden from "./Garden";
import { getGardens } from "../api-helper";
import { Link, useNavigate } from "react-router-dom";

interface DashGarden {
  name: string;
  gardenId: number;
}

const DashboardGarden = () => {
  const [gardenList, setGardenList] = useState<DashGarden[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchGardens = async () => {
      try {
        const response = await getGardens();
        setGardenList(response);
      } catch (error) {
        console.error(error);
      }
    };
    fetchGardens();
  }, []);

  const handleClick = (gardenId: number) => {
    //define click to show detail page
    console.log(`garden ${gardenId} clicked`);
    //api call? redirect to detail page.
    navigate(`/garden-detail/${gardenId}`);
  };

  return (
    <>
      {gardenList === null && ( 
      <div><h3>No gardens have been created yet...</h3>
          <p>create one here: <Link to="/create">new garden</Link></p>
      </div>
      )}
      {gardenList != null && (
        <div>
      <h2>Your created gardens</h2>
      <hr />
      <div>
        {gardenList.map((garden) => (
          <div key={garden.gardenId} onClick={() => handleClick(garden.gardenId)}>
          <Garden
            key={garden.gardenId}
            whenGardenClicked={handleClick}
            Name={garden.name}
            //grids
            GardenId={garden.gardenId} />
          </div>
        ))}
      </div>
        </div>
)}

    </>
  );
};

export default DashboardGarden;