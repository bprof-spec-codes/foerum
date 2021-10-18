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
      <div className="flex-col">
        <div className="h-16 bg-basebg text-white rounded-t-2xl">
          <h4 className="text-4xl font-thin tracking-wider p-2">Topics</h4>
        </div>

        <div>
          {topics &&
            topics.map((topic) => (
              <div>
                <Topic />
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Sidebar;
