import React, { FC, useEffect, useState } from "react";
import { IComment } from "src/models/comment.model";
import "../Home/home.scss";
import { IUser } from "src/models/user.model";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

import KeyboardArrowUpOutlinedIcon from "@mui/icons-material/KeyboardArrowUpOutlined";
import KeyboardArrowDownOutlinedIcon from "@mui/icons-material/KeyboardArrowDownOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";
import { ethers } from "ethers";
import { IEmailModel } from "src/models/email.model";

import { Avatar, Button, IconButton, Snackbar } from "@mui/material";
import moment from "moment";
import axios from "axios";

interface ICommentProps {
  comment: IComment;
  allUsers: IUser[];
}

const Comment: FC<ICommentProps> = ({ comment, allUsers }) => {
  const [snackBarOpen, setSnackBarOpen] = useState<boolean>(false);
  const [open, setOpen] = React.useState(false);
  const [amountOfNikCoin, setAmountOfNikCoin] = useState<number>(0);

  const [provider, setProvider] = useState<any | null>(null);
  const [signer, setSigner] = useState<any | null>(null);
  const [contract, setContract] = useState<any | null>(null);
  const contractAddress = "0xA0e11Ca7c99655C6ca16336F1AF69b6A7683FDfC";

  useEffect(() => {
    const updateEthers = () => {
      let tempProvider = new ethers.providers.Web3Provider(window.ethereum);
      setProvider(tempProvider);

      let tempSigner = tempProvider.getSigner();
      setSigner(tempSigner);

      const abi = require("human-standard-token-abi");
      let tempContract = new ethers.Contract(contractAddress, abi, tempSigner);
      setContract(tempContract);
    };
    if (window.ethereum) {
      updateEthers();
    }
  }, []);

  const awardNikcoin = async (e: any) => {
    e.preventDefault();
    const user = allUsers.find((u) => u.id === comment.userID);
    const amount = amountOfNikCoin * 100;
    const toAddress = user!.walletAddress;
    const toUsername = user!.fullName;
    const toEmail = user!.email!;

    console.log(user);

    const newEmail: IEmailModel = {
      destinationEmail: toEmail,
      destinationName: toUsername,
      amount: amount / 100,
      fromUser: sessionStorage.getItem("username") || "felhasználó",
      adminTransaction: false,
    };
    await contract.transfer(toAddress, amount).then(
      await axios.post("http://localhost:5000/Transaction", newEmail, {
        headers: { Authorization: sessionStorage.getItem("foerumtoken") },
      })
    );

    handleTranscationClose();
  };

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

  const handleTransactionClickOpen = () => {
    setOpen(true);
  };

  const handleTranscationClose = () => {
    setOpen(false);
  };

  const openTransactionModal = () => {
    return (
      <div>
        <Button variant="outlined" onClick={handleTransactionClickOpen}>
          Open form dialog
        </Button>
      </div>
    );
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
            {window.ethereum &&
              allUsers.find((u) => u.id === comment.userID)?.walletAddress && (
                <button onClick={() => handleTransactionClickOpen()}>
                  <MonetizationOnOutlinedIcon
                    className="text-green-600"
                    style={{ marginLeft: "5px", marginBottom: "4px" }}
                  />
                </button>
              )}
            <Dialog open={open} onClose={handleTranscationClose}>
              <DialogTitle>NikCoin utalás</DialogTitle>
              <DialogContent>
                <DialogContentText>
                  Mennyi NikCoin-t szeretnél utalni?
                </DialogContentText>
                <TextField
                  onChange={(e) => setAmountOfNikCoin(+e.target.value)}
                  value={amountOfNikCoin}
                  type="number"
                  inputProps={{ min: 0 }}
                />
              </DialogContent>
              <DialogActions>
                <Button onClick={handleTranscationClose}>Mégse</Button>
                <Button onClick={awardNikcoin}>Küldés</Button>
              </DialogActions>
            </Dialog>
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
