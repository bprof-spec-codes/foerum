import React, { FC, useEffect, useState } from "react";
import { IRootState } from "src/store/reducers";
import { connect } from "react-redux";
import { Avatar } from "@mui/material";
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

    console.log(userid);
    getBalance();
  }, []);

  const normalizeUserName = (name: string) => {
    return name.toLowerCase().replace(/\s/g, "");
  };

  const getBalance = () => {
    // const web3 = new Web3('https://data-seed-prebsc-1-s1.binance.org:8545');
    // const abi = require('human-standard-token-abi');
    // const contractAddress = '0xA0e11Ca7c99655C6ca16336F1AF69b6A7683FDfC';
    // const contract = new web3.eth.Contract(abi, contractAddress);
    // console.log("userid: "+userid);
    /*
    axios.get("/MyUser/GetOneWallet/" + userid).then((res) => {
      console.log(res.data);
      contract.methods.balanceOf(res.data).call().then(function(result : any) {
        var myTokenResult = result;
        console.log(myTokenResult);
        setUserBalance(myTokenResult);
      });
    });
    */
    /*
    axios.get("/MyUser/GetOneWallet/" + userid).then((res) => {
      web3.eth.getBalance(res.data).then((balance) => {
        setUserBalance(
          (parseFloat(balance)/1000000000000000000).toFixed(2)
          .toString());
      });
    });*/
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
