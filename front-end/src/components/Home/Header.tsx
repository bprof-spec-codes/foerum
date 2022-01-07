import React from "react";
import { useHistory } from "react-router";
import minilogo from "../../assets/images/minilogo.png";
import "./home.scss";

const Header = () => {
  const history = useHistory();

  return (
    <div className="fixed w-full h-14 bg-basebg shadow-lg z-50">
      <div className="flex justify-between h-full content-center text-center text-white">
        <img
          className="cursor-pointer"
          src={minilogo}
          alt="Logo"
          loading="lazy"
          onClick={() => history.push("/home")}
        />

        <div className="flex content-center p-2 self-center">
          <p className="font-bold cursor-pointer" onClick={() => history.push("/Admin")}>
            Admin felület
          </p>
        </div>
      </div>
    </div>
  );
};

export default Header;
