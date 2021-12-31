import React from "react";
import { useHistory } from "react-router";
import minilogo from "../../assets/images/minilogo.png";
import "./home.scss";

const Header = () => {
  const history = useHistory();

  return (
    <div className="h-14 bg-basebg">
      <div className="flex justify-between h-full content-center text-center text-white">
        <img
          className="cursor-pointer"
          src={minilogo}
          alt="Logo"
          loading="lazy"
          onClick={() => history.push("/home")}
        />

        <div className="flex p-1 w-full px-56 self-center">
          <div className="flex w-full h-8 bg-white rounded-2xl">
            <input
              type="text"
              className="flex w-full my-1 mx-2 text-black outline-none text-center bg-white"
              placeholder={`Keress rá bármire!`}
            />
          </div>
        </div>

        <div className="flex content-center p-2 self-center">
          <a href="/Admin" className="font-bold">
            Admin felület
          </a>
        </div>
      </div>
    </div>
  );
};

export default Header;
