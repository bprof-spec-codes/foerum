import React, { useEffect } from "react";
import Feed from "./Feed";
import ProfileActions from "./ProfileActions";
import Sidebar from "./Sidebar";
import Header from "./Header";
import { SignOutButton } from "../shared";
import axios from "../../axios";
import { IUser } from "src/models/user.model";

const Home = () => {
  return (
    <div className="flex justify-between pt-14">
        <div className="flex justify-between w-full">

          <div className="w-1/5 mr-5 shadow-sm">
            <Sidebar />
          </div>

          <div className="w-2/4 m-5">
            <Feed />
          </div>

          <div className="w-1/5 m-5">
            <ProfileActions />
            <SignOutButton />
          </div>
        </div>
      </div>
  )
};

export default Home;
