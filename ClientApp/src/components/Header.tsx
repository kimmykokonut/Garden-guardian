import { Link } from "react-router-dom";
import './../Header.css';
import logo from '../assets/logo.png';
import { useState } from "react";

const Header = () => {
  const [isNavOpen, setIsNavOpen] = useState(false);

  return (
    <div className="header bg-white flex items-center justify-between">
      <img src={logo} alt="Garden logo with shovel and plant" className="h-20"/>
      
      <nav>
        <section className="MOBILE-MENU flex lg:hidden md:hidden">
          <div
            className="HAMBURGER-ICON space-y-2"
            onClick={() => setIsNavOpen((prev) => !prev)}
          >
            <span className="block h-0.5 w-8 animate-pulse bg-gray-600"></span>
            <span className="block h-0.5 w-8 animate-pulse bg-gray-600"></span>
            <span className="block h-0.5 w-8 animate-pulse bg-gray-600"></span>
          </div>

          <div className={isNavOpen ? "showMenuNav" : "hideMenuNav"}>
            <div
              className="CROSS-ICON absolute top-0 right-0 px-8 py-8"
              onClick={() => setIsNavOpen(false)}
            >
              <svg
                className="h-8 w-8 text-gray-600"
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth="2"
                strokeLinecap="round"
                strokeLinejoin="round"
              >
                <line x1="18" y1="6" x2="6" y2="18" />
                <line x1="6" y1="6" x2="18" y2="18" />
              </svg>
            </div>
            <ul className="MENU-LINK-MOBILE-OPEN flex flex-col items-center justify-between min-h-[250px]">
              <li className="border-b border-gray-400 my-2 uppercase">
                <Link to="/">home</Link>
              </li>
              <li className="border-b border-gray-400 my-2 uppercase">
                <Link to="/create">create new bed</Link>
              </li>
              <li className="border-b border-gray-400 my-2 uppercase">
                <Link to="/dashboard">see your beds</Link>
              </li>
              <li className="border-b border-gray-400 my-2 uppercase">
                <Link to="/add-seed">add new seed</Link>
              </li>
            </ul>
          </div>
        </section>

        <ul className="DESKTOP-MENU hidden space-x-8 md:flex">
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/create">New garden</Link>
          </li>
          <li>
            <Link to="/dashboard">See all gardens</Link>
          </li>
          <li>
            <Link to="/add-seed">New seed</Link>
          </li>
        </ul>
      </nav>
      <style>{`
      .hideMenuNav {
        display: none;
      }
      .showMenuNav {
        display: block;
        position: absolute;
        width: 66%;
        height: 50vh;
        top: 0;
        right: 0;
        background: white;
        z-index: 10;
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;
        align-items: center;
      }
    `}</style>
    </div>
  );
}
export default Header;