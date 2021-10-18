import React from "react";
import minilogo from "../../assets/images/minilogo.png"
import "./home.scss"

const Header = () => {
  return (
    <div className="h-14 bg-basebg">
      <div className="flex justify-between h-full content-center text-center text-white">
        <img src={minilogo} alt="Logo" loading="lazy" />

        <div className="flex w-14/10 p-1  px-20 self-center">
            <div className="flex w-full h-8 bg-white rounded-2xl">
            <input type="text" className="flex w-full my-2 mx-2 text-black outline-none bg-white" placeholder={`Keresés`} />
            </div>
        </div>

        <div className="flex content-center p-2 self-center">
          <a href="/Admin" className="font-bold">Admin felület</a>
        </div>
      </div>
    </div>
  );
};

export default Header;
