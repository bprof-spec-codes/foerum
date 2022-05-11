import React, { FC, useEffect, useState } from "react";
import { connect } from "react-redux";
import { useHistory } from "react-router";
import { IRootState } from "src/store/reducers";
import minilogo from "../../assets/images/minilogo.png";
import { SignOutButton } from "../shared/MicrosoftSignOut";
import "./home.scss";
import jwt_decode from "jwt-decode";
import { Button, IconButton } from "@mui/material";
import AddCircleOutlinedIcon from '@mui/icons-material/AddCircleOutlined';
import { ethers } from "ethers";
import axios from "../../axios";

export interface IHeaderProps extends StateProps, DispatchProps {}

interface IAuth {}

const Header: FC<IHeaderProps> = (props) => {
  const { isAuthenticated } = props;
  const history = useHistory();

  const [auth, setAuth] = useState<IAuth | null>(null);

  useEffect(() => {
    const authToken = sessionStorage.getItem("foerumtoken");
    if (authToken) {
      const decodedToken = jwt_decode(authToken);
      setAuth(decodedToken as IAuth);
    }
  }, [isAuthenticated, props]);

  function walletLogin(){
    if(window.ethereum){
      window.ethereum.request({method:'eth_requestAccounts'})
      .then((res: any) => {
        console.log(typeof res[0])
        console.log(res[0])
        const userid = sessionStorage.getItem("userid");
        const data = {address: res[0]};
        axios.post("/MyUser/SetWallet/" + userid, data)
      })
    }
    else {
      alert("Please install MetaMask");
    }
  }

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
              className="font-bold cursor-pointer mt-2 mr-4"
              onClick={() => history.push("/Admin")}
            >
              Admin felület
            </p>
          )}
          <IconButton onClick={walletLogin}><div className="border-2 px-2 py-2 rounded-full text-sm text-white"><AddCircleOutlinedIcon className="text-sm" />&nbsp;pénztárca csatlakozás</div></IconButton>
          {auth && <SignOutButton />}
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
