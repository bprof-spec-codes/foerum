import React, { useEffect, useState } from "react";
import Feed from "./Feed";
import ProfileActions from "./ProfileActions";
import Sidebar from "./Sidebar";
import Header from "./Header";
import axios from "../../axios";
import { IUser } from "src/models/user.model";
import { ITopic } from "src/models/topic.model";

const Home = () => {
  const [topics, setTopics] = useState<ITopic[] | null>(null);

  useEffect(() => {
    getTopics();
  }, []);

  const getTopics = async () => {
    const topics = await axios.get<ITopic[]>("/Topic");
    setTopics(topics.data);
  };

  return (
    <>
      <Header />
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
          </div>
        </div>
      </div>
    </>
  );
};

export default Home;
