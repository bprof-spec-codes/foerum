import { IconButton } from "@mui/material";
import React from "react";
import { useHistory } from "react-router";
import minilogo from "../../assets/images/minilogo.png";
import { SignInButton } from "../shared/MicrosoftSignIn";
import { SignOutButton } from "../shared/MicrosoftSignOut";
import "./home.scss";

const Header = () => {
  const history = useHistory();

  return (
    <div className="fixed w-full h-14 bg-basebg shadow-lg z-50">
      <div className="flex justify-between h-full mx-5 content-center text-center text-white">
        <img
          className="cursor-pointer"
          src={minilogo}
          alt="Logo"
          loading="lazy"
          onClick={() => history.push("/home")}
        />

        <div className="flex content-center p-2 self-center">
          <p
            className="font-bold cursor-pointer mt-2 mr-4"
            onClick={() => history.push("/Admin")}
          >
            Admin felület
          </p>

            <SignOutButton />
        </div>
      </div>
    </div>
  );
};

export default Header;
