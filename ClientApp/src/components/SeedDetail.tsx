// import { useEffect, useState } from "react";
// import { useParams } from "react-router-dom";
// import { getSeedById } from "../api-helper";

interface Seed {
  Name: string;
  PhotoUrl: string;
  Type: string;
  Quantity: number;
  Information: string;
  PlantingDates: string;
  DaysToGerminate: string;
  DepthToSow: string;
  SeedSpacing: string;
  RowSpacing: string;
  DaysToHarvest: number;
  Status: string;
  DatePlanted: string;
  Results: string;
  Yield: number;
}
interface Props {
  seed?: Seed;
}

const SeedDetail: React.FC<Props> = () => {
//   const { seedId: number } useParams<{ seedId: number }>();
//   const [seed, setSeed] = useState<Seed | null>(null);

//   useEffect(() => {
//     const fetchSeedDetails = async () => {
//       try {
//         const seedDetails = await getSeedById(parseInt(seedId));
//         setSeed(seedDetails);
//       } catch (error) {
//         console.error("fail", error);
//       }
//     };
//     fetchSeedDetails();
//   }, [seedId]);


//   if (!seed) {
//     return <div>...loading...</div>;
//   }

   return(
    <h2>seed detail page in progress</h2>
//     <div id="seed-deets">
//       <h1>{seed.Name}</h1>
//       <img src={seed.PhotoUrl} alt="seed image" />
//       <p>{seed.Type}</p>
//       <p>{seed.Quantity}</p>
//       <p>{seed.Information}</p>
//       <p>{seed.PlantingDates}</p>
//       <p>{seed.DaysToGerminate}</p>
//       <p>{seed.DepthToSow}</p>
//       <p>{seed.SeedSpacing}</p>
//       <p>{seed.RowSpacing}</p>
//       <p>{seed.DaysToHarvest}</p>
//       <p>{seed.Status}</p>
//       <p>{seed.DatePlanted}</p>
//       <p>{seed.Results}</p>
//       <p>{seed.Yield}</p>
//     </div>
  );
}
export default SeedDetail;