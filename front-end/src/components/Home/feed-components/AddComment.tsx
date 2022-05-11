import { IconButton, TextField } from "@mui/material";
import React, { FC, useState } from "react";
import { ITopic } from "src/models/topic.model";
import SendOutlinedIcon from "@mui/icons-material/SendOutlined";
import axios from "../../../axios";

interface IAddCommentProps {
  topic: ITopic;
  refresh: () => void;
}

const AddComment: FC<IAddCommentProps> = (props) => {
  const { topic, refresh } = props;
  const [commentBody, setCommentBody] = useState("");

  const createComment = () => {
    const userId = sessionStorage.getItem("userid");
    const data = {
      TopicID: topic.topicID,
      UserID: userId,
      Content: commentBody,
      CreationDate: new Date(Date.now()),
    };

    setCommentBody("");

    const token = sessionStorage.getItem("foerumtoken");
    axios
      .post("/Comment", data, {headers: {"Authorization" : token}})
      .then((res) => {
        refresh();
      })
      .catch((err) => {
        console.log(err);
      });
  };

  return (
    <div className="flex justify-between align-center h-12 w-full mt-4 p-2 pl-6 bg-gray-100 rounded-full">
      <TextField
        className="w-full"
        placeholder="Válasz..."
        type="text"
        value={commentBody}
        onChange={(e) => setCommentBody(e.target.value)}
        variant="standard"
        InputProps={{ disableUnderline: true }}
      />
      <IconButton onClick={createComment}>
        <SendOutlinedIcon
          className="text-gray-400"
          sx={{ height: "20px", width: "20px" }}
        />
      </IconButton>
    </div>
  );
};

export default AddComment;
