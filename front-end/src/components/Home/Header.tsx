import { IconButton } from "@mui/material";
import React, { FC, useEffect, useState } from "react";
import { connect } from "react-redux";
import { useHistory } from "react-router";
import { IRootState } from "src/store/reducers";
import minilogo from "../../assets/images/minilogo.png";
import { SignInButton } from "../shared/MicrosoftSignIn";
import { SignOutButton } from "../shared/MicrosoftSignOut";
import "./home.scss";

export interface IHeaderProps extends StateProps {}

const Header: FC<IHeaderProps> = (props) => {
  const history = useHistory();

  const [isAuth, setIsAuth] = useState<boolean>(false);

  useEffect(() => {
    setIsAuth(!!sessionStorage.getItem("token"));
    console.log(isAuth);
  }, [props]);

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
          <p
            className="font-bold cursor-pointer mt-2 mr-4"
            onClick={() => history.push("/Admin")}
          >
            Admin felület
          </p>

          {isAuth && <SignOutButton />}
        </div>
      </div>
    </div>
  );
};

const mapStateToProps = ({ authentication }: IRootState) => ({
  authenticated: authentication.isAuthenticated,
});

type StateProps = ReturnType<typeof mapStateToProps>;

export default connect(mapStateToProps)(Header);
