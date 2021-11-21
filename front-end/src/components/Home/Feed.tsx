import React, { useEffect, useState } from "react";
import axios from "src/axios";
import { ITopic } from "src/models/topic.model";
import Topic from "../Misc/Topic";

const Feed = () => {
  const [topics, setTopics] = useState<ITopic[]>([]);
  const [showAddComment, setShowAddComment] = useState(false)

  useEffect(() => {
    axios
      .get<ITopic[]>("http://localhost:8585/Topic")
      .then((res) => {
        setTopics(res.data);
        console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <div>
      <div>
        <div>
        {topics &&
            topics.map((topic,i) => (
              <div key={i}>
                <Topic 
                  {...topic} 
                  showAdd={showAddComment}
                />

              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Feed;