import { Link } from "react-router-dom";
import bg from "../assets/bg.jpg";

const Home = () => {
  return (
    <>
      <section className="min-h-screen flex items-stretch text-white">
        <div className="lg:flex w-1/2 hidden bg-gray-500 bg-no-repeat bg-cover relative items-center justify-center" style={{backgroundImage: `url(${bg})`}}>
          <div className="absolute bg-black opacity-60 inset-0 z-0"></div>
          <div className="w-full px-24 z-10">
            <h1 className="text-5xl font-bold text-left tracking-wide">Sow, harvest, repeat</h1>
            <p className="text-3xl my-4">Manage your garden and get results</p>
          </div>
          <div className="bottom-0 absolute p-4 text-center right-0 left-0 flex justify-center space-x-4">
          </div>
        </div>
        <div className="lg:w-1/2 w-screen flex items-center justify-center text-center md:px-16 px-0 z-0" style={{backgroundColor: '#161616'}}>
          <div className="absolute lg:hidden z-10 inset-0 bg-gray-500 bg-no-repeat bg-cover items-center" style={{ backgroundImage: `url(${bg})` }}>
            <div className="absolute bg-black opacity-60 inset-0 z-0"></div>
          </div>
          <div className="w-full py-6 z-20">
            <h1 className="my-6">
              garden guardian
            </h1>
            <hr />
            <div className="py-6 space-x-2">
              <span className="w-20 h-10 items-center justify-center inline-flex font-bold text-lg">  <Link to="/create">Let's get started..</Link></span>
            </div>
            <p className="text-gray-100">
              or sign in to make it personal
            </p>
            <form action="" className="sm:w-2/3 w-full px-4 lg:px-0 mx-auto">
              <div className="pb-2 pt-4">
                <input type="email" name="email" id="email" placeholder="Email" className="block w-full p-4 text-lg rounded-sm bg-black"/>
              </div>
              <div className="pb-2 pt-4">
                <input className="block w-full p-4 text-lg rounded-sm bg-black" type="password" name="password" id="password" placeholder="Password"/>
              </div>
              <div className="text-right text-gray-400 hover:underline hover:text-gray-100">
                <a href="#">Forgot your password?</a>
              </div>
              <div className="px-4 pb-2 pt-4">
                <button className="uppercase block w-full p-4 text-lg rounded-full bg-indigo-500 hover:bg-indigo-600 focus:outline-none">sign in</button>
              </div>
              <div className="p-4 text-center right-0 left-0 flex justify-center space-x-4 mt-16 lg:hidden ">
                <div className="sticky bottom-0">
                  Designed and built by <a href="https://github.com/kimmykokonut/Garden-guardian" >
                   kimmykokonut
                </a>
                </div>
              </div>
            </form>
          </div>
        </div>
      </section>
    </>
  );
}
export default Home;