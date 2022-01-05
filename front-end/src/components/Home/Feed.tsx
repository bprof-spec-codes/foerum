import React, { useEffect, useState } from "react";
import axios from "src/axios";
import { ITopic } from "src/models/topic.model";
import { IUser } from "src/models/user.model";
import Topic from "../Misc/Topic";
import AddTopic from "./feed-components/AddTopic";
import Button from "./feed-components/Button";

const Feed = () => {
  const [topics, setTopics] = useState<ITopic[]>([]);
  const [users, setUsers] = useState<IUser[]>([]);
  const [showAddComment, setShowAddComment] = useState(false);
  const [showAddTopic, setShowAddTopic] = useState(false);


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
          <header>
            {showAddTopic && <AddTopic />}
              <Button
                onClicked={() => setShowAddTopic(!showAddTopic)}
                color={showAddTopic ? "#FAB001" : "#182A4E"}
                text={showAddTopic ? "Mégse" : "Új téma hozzáadása"}
              />
        </header>
        </div>
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
