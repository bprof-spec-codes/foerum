import React, { FC, useEffect, useState } from "react";
import { IRootState } from "src/store/reducers";
import { connect } from "react-redux";
import { Avatar } from "@mui/material";
import { SignOutButton } from "../../shared/MicrosoftSignOut";
import axios from "../../../axios";
import Web3 from "web3";

export interface IProfileCardProps extends StateProps {}

const ProfileCard: FC<IProfileCardProps> = (props) => {
  const [userName, setUserName] = useState<string | null>(null);
  const [userEmail, setUserEmail] = useState<string | null>(null);
  const [userid, setUserId] = useState<string | null>(null);
  const [userBalance, setUserBalance] = useState<string | null>(null);
  useEffect(() => {
    const userName = sessionStorage.getItem("username");
    const userEmail = sessionStorage.getItem("useremail");
    const userid = sessionStorage.getItem("userid");
    const userBalance = "0";

    setUserName(userName);
    setUserEmail(userEmail);
    setUserId(userid);
    setUserBalance(userBalance);
  }, []);

  useEffect(() => {
    if (userid) {
      getBalance();
    }
  }, [userid]);

  const normalizeUserName = (name: string) => {
    return name.toLowerCase().replace(/\s/g, "");
  };

  const getBalance = () => {
    const token = sessionStorage.getItem("foerumtoken");
    const web3 = new Web3("https://data-seed-prebsc-1-s1.binance.org:8545");
    const abi = require("human-standard-token-abi");
    const contractAddress = "0xA0e11Ca7c99655C6ca16336F1AF69b6A7683FDfC";
    const contract = new web3.eth.Contract(abi, contractAddress);
    if (token) {
      axios
        .get("/MyUser/GetOneWallet/" + userid, {
          headers: { Authorization: token },
        })
        .then((res) => {
          contract.methods
            .balanceOf(res.data)
            .call()
            .then(function (result: any) {
              var myTokenResult = result;
              setUserBalance(
                (parseInt(myTokenResult) / 100).toFixed(1).toString()
              );
            })
            .catch((err: any) => {
              console.log(err);
            });
        })
        .catch((err) => console.log(err));
    }
  };

  return (
    <div className="relative h-1/3 shadow-md rounded-lg">
      <div className="h-16 bg-basebg text-white rounded-t-2xl"></div>

      {userName && userEmail && (
        <div>
          <div className="w-full absolute top-4 items-center text-center">
            <div
              className="flex justify-center items-center mt-1 ml-auto mr-auto bg-white rounded-full"
              style={{ height: "80px", width: "80px" }}
            >
              <Avatar
                sx={{
                  height: "70px",
                  width: "70px",
                }}
              />
            </div>
            <span className="text-sm text-gray-400">
              @{normalizeUserName(userName)}
            </span>
            <p className="text-xl">{userName}</p>
          </div>
          <div className="flex flex-col justify-between mt-20 p-4 align-center text-center">
            <p>{userEmail}</p>
            <SignOutButton />
          </div>
          <div className="flex flex-col pb-4 align-center text-center">
            NikCoin egyenleg: {userBalance}
          </div>
        </div>
      )}
    </div>
  );
};

const mapStateToProps = ({ authentication }: IRootState) => ({
  account: authentication.account,
});

type StateProps = ReturnType<typeof mapStateToProps>;

export default connect(mapStateToProps)(ProfileCard);
