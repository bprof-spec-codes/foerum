import React, { useEffect, useState } from "react";
import axios from "src/axios";
import { ITopic } from "src/models/topic.model";
import { IUser } from "src/models/user.model";
import Topic from "../Misc/Topic";

const Feed = () => {
  const [topics, setTopics] = useState<ITopic[]>([]);
  const [users, setUsers] = useState<IUser[]>([]);
  const [showAddComment, setShowAddComment] = useState(false);

  useEffect(() => {
    const getTopics = async () => {
      const data = await axios.get<ITopic[]>("http://localhost:8585/Topic");
      setTopics(data);
    };

    const getUsers = async () => {
      const data = await axios.get<IUser[]>("http://localhost:8585/User");
      setUsers(data);
    };
  }, []);

  return (
    <div>
      <div>
        <div>
          {topics &&
            topics.map((topic, i) => (
              <div key={i}>
                <Topic {...topic} showAdd={showAddComment} user={users.find(u=>u.id===topic.userID)} />
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Feed;
