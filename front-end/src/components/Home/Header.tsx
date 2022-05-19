import React, { FC, useEffect, useState } from "react";
import { connect } from "react-redux";
import { useHistory } from "react-router";
import { IRootState } from "src/store/reducers";
import minilogo from "../../assets/images/minilogo.png";
import { SignOutButton } from "../shared/MicrosoftSignOut";
import "./home.scss";
import jwt_decode from "jwt-decode";
import { IconButton } from "@mui/material";
import AddCircleOutlinedIcon from "@mui/icons-material/AddCircleOutlined";
import axios from "../../axios";
import { ethers } from "ethers";

export interface IHeaderProps extends StateProps, DispatchProps {}

interface IAuth {}

const Header: FC<IHeaderProps> = (props) => {
  const { isAuthenticated } = props;
  const history = useHistory();

  const [auth, setAuth] = useState<IAuth | null>(null);

  const [defaultAccount, setDefaultAccount] = useState<String | null>(null);
  const [connStatus, setConnStatus] = useState<Boolean>(false);

  useEffect(() => {
    const authToken = sessionStorage.getItem("foerumtoken");
    if (authToken) {
      const decodedToken = jwt_decode(authToken);
      setAuth(decodedToken as IAuth);
    }

    const _connStatus = getConnStatus();
    setConnStatus(_connStatus);
  }, [isAuthenticated, props]);

  const connectWalletHandler = () => {
    if (window.ethereum && window.ethereum.isMetaMask) {
      window.ethereum
        .request({ method: "eth_requestAccounts" })
        .then((result: any) => {
          const userid = sessionStorage.getItem("userid");
          const data = { address: result[0] };
          axios.post("/MyUser/SetWallet/" + userid, data);
          setDefaultAccount(result[0]);
          setConnStatus(true);
          sessionStorage.setItem("walletaddress", result[0]);
        })
        .catch((error: any) => {
          console.log(error.message);
        });
    } else {
      alert("Telepítsd fel a MetaMask kiegészítőt.");
    }
  };

  const getConnStatus = () => {
    if (window.ethereum && window.ethereum.isMetaMask) {
      if (sessionStorage.getItem("walletaddress")) return true;
      else return false;
    } else {
      return false;
    }
  };
  return (
    <div className="fixed w-full h-14 bg-basebg shadow-lg z-50">
      <div className="flex justify-between h-full mx-5 content-center text-center text-white">
        <img
          className="cursor-pointer"
          src={minilogo}
          alt="Logo"
          loading="lazy"
          onClick={() => history.push("/home")}
        />

        <div className="flex content-center p-2 self-center">
          {auth && (
            <p
              className="font-bold cursor-pointer mt-4 mr-4"
              onClick={() => history.push("/Admin")}
            >
              Admin felület
            </p>
          )}
          {connStatus === false && (
            <IconButton onClick={connectWalletHandler}>
              <div className="border-2 px-2 py-2 rounded-full text-sm text-white">
                <AddCircleOutlinedIcon className="text-sm" />
                &nbsp;pénztárca csatlakoztatása&nbsp;
              </div>
            </IconButton>
          )}
          {connStatus === true && (
            <div className="border-2 px-2 py-2 rounded-full text-sm text-white">
              &nbsp;csatlakozva&nbsp;
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

const mapStateToProps = ({ msAuthentication }: IRootState) => ({
  isAuthenticated: msAuthentication.isAuthenticated,
});

const mapDispatchToProps = {};

type StateProps = ReturnType<typeof mapStateToProps>;
type DispatchProps = typeof mapDispatchToProps;

export default connect(mapStateToProps, mapDispatchToProps)(Header);
