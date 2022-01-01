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
      const topics = await axios.get<ITopic[]>("http://localhost:8585/Topic");
      setTopics(topics.data);
    };

    const getUsers = async () => {
      const users = await axios.get<IUser[]>("http://localhost:8585/MyUser");
      setUsers(users.data);
    };

    getTopics();
    getUsers();
  }, []);

  const selectUser = (tid: any) => {
    const user = users.find((u) => u.id === tid);
    console.log(user)
    return user ? user : ({} as IUser);
  };

  return (
    <div>
      <div>
        <div>
          {topics &&
            topics.map((topic, i) => (
              <div key={i}>
                {users && (
                  <Topic
                    topic={topic}
                    onAdd={showAddComment}
                    allUsers={users}
                    user={selectUser(topic.userID)}
                  />
                )}
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Feed;
