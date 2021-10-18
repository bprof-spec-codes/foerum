import React from "react";
import Feed from "./Feed";
import ProfileActions from "./ProfileActions";
import Sidebar from "./Sidebar";
import Header from "./Header";

const Home = () => {
  return (
    <div>
      <Header/>
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

    </div>
  )
};
/*
import Header from "./Header";
import "./home.scss"
import Topic from "../Misc/Topic";

const Home = () => {
  return (
    <div className="home">
      <Header/>
      <Topic/>
      <Topic/>
      <Topic/>
>>>>>>> Stashed changes
    </div>
    
  );
};
*/
export default Home;
