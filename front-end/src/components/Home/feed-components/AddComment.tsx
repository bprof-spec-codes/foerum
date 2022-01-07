import { IconButton, TextField } from "@mui/material";
import React, { FC, useState } from "react";
import { ITopic } from "src/models/topic.model";
import SendOutlinedIcon from "@mui/icons-material/SendOutlined";

const AddComment: FC<ITopic> = (props) => {
  const [commentBody, setCommentBody] = useState("");

  return (
    <div className="flex justify-between align-center h-12 w-full mt-4 p-2 pl-6 bg-gray-100 rounded-full">
      <TextField
        className="w-full"
        placeholder="Mi a kérdés tárgya?"
        type="text"
        onChange={(e) => setCommentBody(e.target.value)}
        variant="standard"
        InputProps={{ disableUnderline: true }}
      />
      <IconButton>
        <SendOutlinedIcon
          className="text-gray-400"
          sx={{ height: "20px", width: "20px" }}
        />
      </IconButton>
    </div>
  );
};

export default AddComment;
