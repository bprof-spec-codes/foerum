import React, { FC } from "react";
import { IComment } from "src/models/comment.model";
import "../Home/home.scss";
import { FaTimes } from "react-icons/fa";
import { BiChevronsUp, BiChevronsDown } from "react-icons/bi";
import { RiCoinFill } from "react-icons/ri";
import { IUser } from "src/models/user.model";

import KeyboardArrowUpOutlinedIcon from "@mui/icons-material/KeyboardArrowUpOutlined";
import KeyboardArrowDownOutlinedIcon from "@mui/icons-material/KeyboardArrowDownOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";

import { Avatar, IconButton } from "@mui/material";
import moment from "moment";

interface ICommentProps {
  comment: IComment;
  allUsers: IUser[];
}

const Comment: FC<ICommentProps> = ({ comment, allUsers }) => {
  // const user = allUsers.find((u) => u.id === comment.userID);
  const getCommenter = (): string => {
    const user = allUsers.find((u) => u.id === comment.userID);
    console.log(user);
    return user && user.fullName ? user.fullName : "";
  };

  const normalizeUserName = (name: string) => {
    return name.toLowerCase().replace(/\s/g, "");
  };

  return (
    <div className="flex my-2 border-l-2 border-gray-100">
      <div className="px-2">
        <Avatar />
      </div>
      <div className="flex justify-between w-full">
        <div>
          <div className="flex h-10 pt-2">
            <h2 className="font-bold tracking-wide">{getCommenter()}&nbsp;</h2>
            <p className="text-gray-400 space-x-6">
              @{normalizeUserName(getCommenter())} ·{" "}
              {moment(comment.creationDate).format("d")} napja
            </p>
          </div>
          <p>{comment.content}</p>
          {comment.attachmentUrl}
        </div>
        <div className="flex flex-col ml-2">
          <IconButton>
            <KeyboardArrowUpOutlinedIcon />
          </IconButton>
          <IconButton>
            <KeyboardArrowDownOutlinedIcon />
          </IconButton>
{/*           <IconButton>
            <MonetizationOnOutlinedIcon />
          </IconButton>
          <IconButton>
            <CloseOutlinedIcon />
          </IconButton> */}
        </div>
      </div>
    </div>
  );
};

export default Comment;
