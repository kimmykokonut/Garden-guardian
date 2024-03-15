interface GardenProps {
  GardenId: number;
  Name: string;
  //Size: string;
  //Row: number;
  //Column: number;
  whenGardenClicked: (id: number) => void;
}

const Garden: React.FC<GardenProps> = (props) => {
  return(
    <>
    <div onClick={() => props.whenGardenClicked(props.GardenId)}>
    <h3>{props.Name}</h3>
    </div>
    </>
  );
}
export default Garden;