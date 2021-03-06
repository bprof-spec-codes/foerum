import React, { FC, useState } from "react";
import s from "./Login.module.scss";
import logo from "../../assets/images/logo.png";
import micro from "../../assets/images/micro.png";

import { connect } from "react-redux";
import { RouteComponentProps } from "react-router-dom";
import { IRootState } from "src/store/reducers";
import { login } from "../../store/reducers/authentication";
import { SignInButton, SignOutButton } from "../shared";
import { LoginSVG } from "./login-components";
import { Button } from "@mui/material";


export interface ILoginProps
  extends StateProps,
    DispatchProps,
    RouteComponentProps<{}> {}

const LogIn: FC<ILoginProps> = (props) => {
  return (
    <div className={s.root}>
      <div className={s.form}>
        <div className={s.svg}>
          <LoginSVG />
        </div>
        <div className={s.button}>
          <SignInButton />
        </div>
      </div>

      {/*       <div className="login__colored-container">
        <img
          className="login__colored-container__logo-container--image"
          src={logo}
          alt="alt"
        />
      </div>
      <div
        className={`login__login-container ${
          true
            ? "login__login-container--active"
            : "login__login-container--inactive"
        }`}
      >
        <div className="login__login-container__main-container">
          <img
            //className="login__colored-container__logo-container--image"
            src={micro}
            alt="alt"
          />
          <SignInButton />
        </div>
      </div> */}
    </div>
  );
};
const mapStateToProps = ({ authentication }: IRootState) => ({
  isAuthenticated: authentication.isAuthenticated,
  loginError: authentication.loginError,
});

const mapDispatchToProps = { login };

type StateProps = ReturnType<typeof mapStateToProps>;
type DispatchProps = typeof mapDispatchToProps;

export default connect(mapStateToProps, mapDispatchToProps)(LogIn);
