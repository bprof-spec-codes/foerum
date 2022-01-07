import { Button, IconButton, Input, TextField } from "@mui/material";
import React, { FC, useState } from "react";
import AttachFileOutlinedIcon from "@mui/icons-material/AttachFileOutlined";
import SendOutlinedIcon from "@mui/icons-material/SendOutlined";
import PanoramaOutlinedIcon from "@mui/icons-material/PanoramaOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";

const AddTopic: FC = () => {
  const [topicName, setTopicName] = useState("");
  const [nikCoin, setNikCoin] = useState("");
  const [attachment, setAttachment] = useState("");

  return (
    <>
      <div className="flex justify-between w-full p-4 pb-0">
        <TextField
          className="w-3/4"
          placeholder="Mi a kérdés tárgya?"
          type="text"
          onChange={(e) => setTopicName(e.target.value)}
          variant="standard"
          InputProps={{ disableUnderline: true }}
        />
        <div>
          <TextField
            placeholder="0"
            type="number"
            onChange={(e) => setNikCoin(e.target.value)}
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
            <AttachFileOutlinedIcon className="text-gray-400" />
          </IconButton>

          <IconButton>
            <PanoramaOutlinedIcon className="text-gray-400" />
          </IconButton>
        </div>
        <IconButton>
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
