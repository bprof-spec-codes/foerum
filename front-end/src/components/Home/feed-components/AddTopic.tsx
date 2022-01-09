import { Button, IconButton, Input, TextField } from "@mui/material";
import React, { FC, useEffect, useState } from "react";
import AttachFileOutlinedIcon from "@mui/icons-material/AttachFileOutlined";
import SendOutlinedIcon from "@mui/icons-material/SendOutlined";
import PanoramaOutlinedIcon from "@mui/icons-material/PanoramaOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";
import axios from "../../../axios";

interface IAddTopicProps {
  getTopics: () => void;
}

const AddTopic: FC<IAddTopicProps> = ({ getTopics }) => {
  const [userName, setUserName] = useState<string>("");
  const [topicName, setTopicName] = useState<string>("");
  const [nikCoin, setNikCoin] = useState<number>(0);

  useEffect(() => {
    const username = sessionStorage.getItem("username");
    if (username) setUserName(username);
  }, []);

  const createTopic = () => {
    const userId = sessionStorage.getItem("userid");
    const data = {
      TopicName: topicName,
      OfferedCoins: nikCoin,
      CreationDate: new Date(Date.now()),
      UserID: userId,
      User: {
        FullName: userName,
      },
    };

    axios
      .post("/Topic", data)
      .then((res) => {
        console.log(res);
        getTopics();
      })
      .catch((err) => {
        console.log(err);
      });
  };

  return (
    <>
      <div className="flex justify-between w-full p-4 pb-0">
        <TextField
          className="w-3/4"
          placeholder="Kérdezz valamit..."
          type="text"
          value={topicName}
          onChange={(e) => setTopicName(e.target.value)}
          variant="standard"
          InputProps={{ disableUnderline: true }}
        />
        <div>
          <TextField
            placeholder="0"
            type="number"
            value={nikCoin}
            onChange={(e) => setNikCoin(+e.target.value)}
            variant="standard"
            InputProps={{ disableUnderline: true }}
            style={{ width: "50px" }}
          />
          <MonetizationOnOutlinedIcon
            className="text-gray-400"
            style={{ marginTop: "2px" }}
          />
        </div>
      </div>

      <div className="flex justify-between w-full p-2">
        <div>
          <IconButton>
            <AttachFileOutlinedIcon className="text-pink-400" />
          </IconButton>

          <IconButton>
            <PanoramaOutlinedIcon className="text-green-400" />
          </IconButton>
        </div>
        <IconButton onClick={createTopic}>
          <SendOutlinedIcon className="text-gray-400" />
        </IconButton>
      </div>

      {/*  <Button style={{ backgroundColor: "#182A4E" }} className="btn">
        Hozzáadás
      </Button> */}
    </>
  );
};

export default AddTopic;
