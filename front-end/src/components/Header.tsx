import React from "react";
import minilogo from '../assets/images/minilogo.png'
import "./Home/home.scss"

const Header = () => {
  return (
    <div className="h-16 bg-basebg">
      <div className="flex justify-between h-full content-center text-center text-white">
        <img src={minilogo} alt="Logo" loading="lazy" />

        <div className="flex w-10/12 p-4  px-20">
            <div className="flex w-full h-8 bg-white rounded-2xl">
            <input type="text" className="flex w-full my-2 mx-4 text-black outline-none bg-white" placeholder={`Keresés`} />
            </div>
        </div>

        <div className="flex content-center p-5">
          <h1>Admin</h1>
        </div>
      </div>
    </div>
  );
};

export default Header;
