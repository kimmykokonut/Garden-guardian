import { useState, FormEvent } from "react";
import { createSeed } from './../api-helper';

const SeedForm = () => {
  const [type, setType] = useState('');
  const [name, setName] = useState('');
  const [qty, setQty] = useState(0);
  const [info, setInfo] = useState('');
  const [plantDates, setPlantDates] = useState('');
  const [germinate, setGerminate] = useState('');
  const [depth, setDepth] = useState('');
  const [seedSpace, setSeedSpace] = useState('');
  const [rowSpace, setRowSpace] = useState('');
  const [harvest, setHarvest] = useState(0);
  const [photo, setPhoto] = useState('');
  const [status, setStatus] = useState('');
  const [datePlanted, setDatePlanted] = useState('');
  const [results, setResults] = useState('');
  const [finalYield, setFinalYield] = useState(0);

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const formData = {
      Type: type, Name: name, Quantity: qty, Information: info, PlantingDates: plantDates, DaysToGerminate: germinate, DepthToSow: depth, SeedSpacing: seedSpace, RowSpacing: rowSpace, DaysToHarvest: harvest, PhotoUrl: photo, Status: status, DatePlanted: datePlanted, Results: results, Yield: finalYield
    };

    try {
      const newSeed = await createSeed(formData);
      console.log("new seed:", newSeed);
      window.location.href = (`/seed-detail/${newSeed.seedId}`);
    } catch (error) {
      console.error("fail", error);
    }
  };

  return (
    <div className="mx-auto max-w-md px-6 py-12 bg-white border-0 shadow-lg sm:rounded-3xl">
          <h1 className="text-2xl font-bold mb-8 text-slate-600">Build your bed</h1>
            <form onSubmit={handleSubmit}>
            <div className="relative z-0 w-full mb-5">
              <input
                  onChange={(e) => setGName(e.target.value)}
                type="text"
                  value={gName}
                placeholder=" "
                className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200"/>
              <label
                className="absolute duration-300 top-3 -z-1 origin-0 text-gray-500"
              >Name your garden</label>
            </div>
            <div className="relative z-0 w-full mb-5">
              <input
                  onChange={(e) => setSize(e.target.value)}
                type="text"
                  value={size} 
                placeholder=" "
                className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200"/>
              <label
                className="absolute duration-300 top-3 -z-1 origin-0 text-gray-500"
              >Size in square feet</label>
            </div>
            <div className="relative z-0 w-full mb-5">
              <input
                  onChange={(e: ChangeEvent<HTMLInputElement>) => {
                    const value = parseInt(e.target.value);
                    setRow(isNaN(value) ? 0 : value); }}
                type="number"
                  value={row}
                placeholder=" "
                className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200"
              />
              <label
                className="absolute duration-300 top-3 -z-1 origin-0 text-gray-500"
              >How many rows?</label>
            </div>
            <div className="flex flex-row space-x-4">
              <div className="relative z-0 w-full mb-5">
                <input
                    onChange={(e: ChangeEvent<HTMLInputElement>) => { const value = parseInt(e.target.value); setColumn(isNaN(value) ? 0 : value); }}
                  type="number"
                    value={column}
                  placeholder=" "
                  className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200"
                />
                <label
                  className="absolute duration-300 top-3 -z-1 origin-0 text-gray-500"
                >How many columns?</label>
              </div>
            </div>
            <button
              id="button"
              type="submit"
              className="w-full px-6 py-3 mt-3 text-lg text-white transition-all duration-150 ease-linear rounded-lg shadow outline-none bg-indigo-500 hover:bg-indigo-600 hover:shadow-lg focus:outline-none"
            >Create Garden</button>
          </form>
        </div>
    // <div className="seedForm">
    //   <h3>Complete this form to add a seed to the database</h3>
    //   <form onSubmit={handleSubmit}>
    //     <div>
    //       <label>Name:</label>
    //       <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Type:</label>
    //       <input type="text" value={type} onChange={(e) => setType(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Quantity:</label>
    //       <input type="number" value={qty} onChange={(e) => setQty(parseInt(e.target.value))} />
    //     </div>
    //     <div>
    //       <label>Information:</label>
    //       <input type="text" value={info} onChange={(e) => setInfo(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Planting Dates:</label>
    //       <input type="text" value={plantDates} onChange={(e) => setPlantDates(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Days To Germinate:</label>
    //       <input type="text" value={germinate} onChange={(e) => setGerminate(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Depth To Sow:</label>
    //       <input type="text" value={depth} onChange={(e) => setDepth(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Seed Spacing:</label>
    //       <input type="text" value={seedSpace} onChange={(e) => setSeedSpace(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Row Spacing:</label>
    //       <input type="text" value={rowSpace} onChange={(e) => setRowSpace(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Days To Harvest:</label>
    //       <input type="text" value={harvest} onChange={(e) => setHarvest(parseInt(e.target.value))} />
    //     </div>
    //     <div>
    //       <label>Photo Url:</label>
    //       <input type="text" value={photo} onChange={(e) => setPhoto(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Status:</label>
    //       <input type="text" value={status} onChange={(e) => setStatus(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Date Planted:</label>
    //       <input type="text" value={datePlanted} onChange={(e) => setDatePlanted(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Results:</label>
    //       <input type="text" value={results} onChange={(e) => setResults(e.target.value)} />
    //     </div>
    //     <div>
    //       <label>Yield:</label>
    //       <input type="number" value={finalYield} onChange={(e) => setFinalYield(parseInt(e.target.value))} />
    //     </div>
    //     <button type="submit">Create Seed</button>
    //   </form>
    // </div>
  );
}
export default SeedForm;