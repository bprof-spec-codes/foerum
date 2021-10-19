import axios from "../../axios";
import React, { useEffect, useState } from "react";
import { ITopic } from "src/models/topic.model";
import Topic from "./sidebar-components/Topic";

const Sidebar = () => {
  const [topics, setTopics] = useState<ITopic[]>([]);

  useEffect(() => {
    axios
      .get<ITopic[]>("/majdleszurl")
      .then((res) => {
        setTopics(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <div>
      <div className="flex-col bg-basewhitebg">
        <div className="h-16 bg-basebg text-white rounded-t-2xl">
          <h4 className="text-4xl font-thin tracking-wider p-2">Évfolyamok/témák</h4>
        </div>

        <div className="flex w-full p-3  px-5 self-center">
            <div className="flex w-full h-8 bg-white rounded-2xl">
            <input type="text" className="flex w-full my-1 mx-2 text-black outline-none bg-white" placeholder={`Keress rá egy témára!`} />
            </div>
        </div>

        <div>
          {topics &&
            topics.map((topic) => (
              <div>
                <Topic />
              </div>
            ))}
            <h2>SampleTopic#1</h2>
            <h2>SampleTopic#2</h2>
            <h2>SampleTopic#3</h2>

        </div>
      </div>
    </div>
  );
};

export default Sidebar;
