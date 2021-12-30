import React from "react";
import Feed from "./Feed";
import ProfileActions from "./ProfileActions";
import Sidebar from "./Sidebar";
import Header from "./Header";
import { SignOutButton } from "../shared";

const Home = () => {
  return (
    <div>
      <Header/>
        <div className="flex justify-between w-full mr-5">

          <div className="w-1/5 m-5">
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
