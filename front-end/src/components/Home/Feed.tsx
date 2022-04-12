import { Box, Skeleton } from "@mui/material";
import React, { useEffect, useState } from "react";
import axios from "src/axios";
import { ITopic } from "src/models/topic.model";
import { IUser } from "src/models/user.model";
import Topic from "../Misc/Topic";
import AddTopic from "./feed-components/AddTopic";
import Button from "./feed-components/Button";
import ChatOutlinedIcon from "@mui/icons-material/ChatOutlined";

const Feed = () => {
  const [topics, setTopics] = useState<ITopic[] | null>(null);
  const [filteredTopics, setFilteredTopics] = useState<ITopic[] | null>(null);
  const [users, setUsers] = useState<IUser[]>([]);
  const [showAddComment, setShowAddComment] = useState(false);
  const [showAddTopic, setShowAddTopic] = useState(false);

  useEffect(() => {
    const getUsers = async () => {
      const users = await axios.get<IUser[]>("/MyUser");
      setUsers(users.data);
    };

    getTopics();
    getUsers();
  }, []);

  const getTopics = async () => {
    const topics = await axios.get<ITopic[]>("/Topic");
    setTopics(topics.data);
  };

  /*const getWantedTopics = async () => {
    const topics = await axios.get<ITopic[]>("/Topic");

    let wantedTopics = [];

    wantedTopics = topics.filter((topic) => topic.subjectID === "valami");

    setTopics(wantedTopics.data);
  };*/

  const filterTopicsBySubject = async () => {
    const topics = await axios.get<ITopic[]>("/Topic");

    setFilteredTopics(topics.data.filter((topic) => topic.subjectID === "1"));
  };

  /*const filterTopicsByYear = async () => {
    const topics = await axios.get<ITopic[]>("/Topic");

    setFilteredTopics(topics.data.filter((topic) => topic.yearID === "1"));
  };
  //nem kell, mert a topicok nem is tárolnak adatot a yearről
  */

  const selectUser = (tid: any) => {
    const user = users.find((u) => u.id === tid);
    return user ? user : ({} as IUser);
  };

  return (
    <>
      <div className="flex flex-col w-full bg-gray-100 rounded-lg shadow-md">
        <AddTopic getTopics={getTopics} />
      </div>

      {topics ? (
        topics.length > 0 ? (
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
          ))
        ) : (
          <div className="flex flex-col justify-center items-center mt-16 p-4 text-gray-400">
            <span className="flex justify-center items-center h-16 w-16 mb-4 border-2 border-gray-400 border-dashed rounded-full">
              <ChatOutlinedIcon />
            </span>
            <p>Nem találtunk egyetlen témát sem.</p>
          </div>
        )
      ) : (
        Array.from(new Array(15)).map((item, index) => (
          <Box key={index} className="mt-4">
            <Skeleton animation="wave" width="30%" />
            <Skeleton animation="wave" width="70%" />
            <Skeleton animation="wave" width="50%" />
            <Skeleton animation="wave" width="50%" />
            <Skeleton animation="wave" width="50%" />
          </Box>
        ))
      )}
    </>
  );
};

export default Feed;
