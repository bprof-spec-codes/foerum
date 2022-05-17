import React, { FC, useState } from "react";
import { IComment } from "src/models/comment.model";
import "../Home/home.scss";
import { IUser } from "src/models/user.model";

import KeyboardArrowUpOutlinedIcon from "@mui/icons-material/KeyboardArrowUpOutlined";
import KeyboardArrowDownOutlinedIcon from "@mui/icons-material/KeyboardArrowDownOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";

import { Avatar, Button, IconButton, Snackbar } from "@mui/material";
import moment from "moment";

interface ICommentProps {
  comment: IComment;
  allUsers: IUser[];
}

const Comment: FC<ICommentProps> = ({ comment, allUsers }) => {
  const [snackBarOpen, setSnackBarOpen] = useState<boolean>(false);

  // const user = allUsers.find((u) => u.id === comment.userID);
  const getCommenter = (): string => {
    const user = allUsers.find((u) => u.id === comment.userID);
    return user && user.fullName ? user.fullName : "";
  };

  const normalizeUserName = (name: string) => {
    return name.toLowerCase().replace(/\s/g, "");
  };

  const handleClose = (
    event: React.SyntheticEvent | Event,
    reason?: string
  ) => {
    if (reason === "clickaway") {
      return;
    }

    setSnackBarOpen(false);
  };

  const action = (
    <React.Fragment>
      <IconButton
        size="small"
        aria-label="close"
        color="inherit"
        onClick={handleClose}
      >
        <CloseOutlinedIcon fontSize="small" />
      </IconButton>
    </React.Fragment>
  );

  return (
    <div className="flex border-l-2 border-gray-100">
      <div className="px-2 pt-1">
        <Avatar sx={{ height: "30px", width: "30px" }} />
      </div>
      <div className="flex justify-between w-full">
        <div>
          <div className="flex h-10 pt-2">
            <h2 className="font-bold tracking-wide">{getCommenter()}&nbsp;</h2>
            <p className="text-gray-400 space-x-6">
              @{normalizeUserName(getCommenter())} ·{" "}
              {+moment(comment.creationDate).format("d") > 0
                ? `${moment(comment.creationDate).format("d")} napja`
                : +moment(comment.creationDate).format("h") > 1
                ? `${moment(comment.creationDate).format("h")} órája`
                : `${moment(comment.creationDate).format("m")} perce`}
            </p>
          </div>
          <p>{comment.content}</p>
          {comment.attachmentUrl}
        </div>
        <div className="flex flex-col ml-2">
          <IconButton onClick={() => setSnackBarOpen(true)}>
            <KeyboardArrowUpOutlinedIcon />
          </IconButton>
          <IconButton onClick={() => setSnackBarOpen(true)}>
            <KeyboardArrowDownOutlinedIcon />
          </IconButton>

          <Snackbar
            open={snackBarOpen}
            autoHideDuration={6000}
            onClose={handleClose}
            message="Értékelésed rögzítettük"
            action={action}
            sx={{ backgroundColor: "white" }}
          />
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
