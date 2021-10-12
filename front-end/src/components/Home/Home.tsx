import React from "react";
import Feed from "./Feed";
import ProfileActions from "./ProfileActions";
import Sidebar from "./Sidebar";

const Home = () => {
  return (
    <div className="flex m-5">
      <div className="flex justify-between w-full">
        <div className="w-1/3 mr-5">
          <Sidebar />
        </div>

        <div className="w-1/3 mr-5">
          <Feed />
        </div>

        <div className="w-1/3">
          <ProfileActions />
        </div>
      </div>
    </div>
  );
};

export default Home;
