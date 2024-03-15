import { useState, FormEvent, ChangeEvent } from "react";

interface MyFormProps {
  onSubmit: (data: { Name: string; Size: string; Row: number; Column: number }) => void;
}

export function CreateForm({ onSubmit }: MyFormProps) {
  const [gName, setGName] = useState('');
  const [size, setSize] = useState('');
  const [row, setRow] = useState(0);
  const [column, setColumn] = useState<number>(0);

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => { 
    e.preventDefault();
    onSubmit({ Name: gName, Size: size, Row: row, Column: column });
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
                placeholder="Name your garden"
                className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200 text-black"/>
            </div>
            <div className="relative z-0 w-full mb-5">
              <input
                  onChange={(e) => setSize(e.target.value)}
                type="text"
                  value={size} 
            placeholder="Size in square feet"
            className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200 text-black"/>
            </div>
            <div className="relative z-0 w-full mb-5">
              <input
                  onChange={(e: ChangeEvent<HTMLInputElement>) => {
                    const value = parseInt(e.target.value);
                    setRow(isNaN(value) ? 0 : value); }}
                type="number"
                  value={row}
            placeholder="How many rows?"
                className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200 text-black"
              />
            </div>
            <div className="flex flex-row space-x-4">
              <div className="relative z-0 w-full mb-5">
                <input
                    onChange={(e: ChangeEvent<HTMLInputElement>) => { const value = parseInt(e.target.value); setColumn(isNaN(value) ? 0 : value); }}
                  type="number"
                    value={column}
              placeholder="How many columns?"
                  className="pt-3 pb-2 block w-full px-0 mt-0 bg-transparent border-0 border-b-2 appearance-none focus:outline-none focus:ring-0 focus:border-black border-gray-200 text-black"
                />
              </div>
            </div>
            <button
              id="button"
              type="submit"
              className="w-full px-6 py-3 mt-3 text-lg text-white transition-all duration-150 ease-linear rounded-lg shadow outline-none bg-indigo-500 hover:bg-indigo-600 hover:shadow-lg focus:outline-none"
            >Create Garden</button>
          </form>
        </div>
  );
}