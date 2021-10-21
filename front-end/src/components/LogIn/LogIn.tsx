import React, { FC, useState } from "react";
import "./login.scss";
import logo from "../../assets/images/logo.png";
import { connect } from "react-redux";
import { RouteComponentProps } from "react-router-dom";
import { IRootState } from "src/store/reducers";
import { login } from "../../store/reducers/authentication";
import { SignInButton, SignOutButton } from "../shared";

export interface ILoginProps
  extends StateProps,
    DispatchProps,
    RouteComponentProps<{}> {}

const LogIn: FC<ILoginProps> = (props) => {
  return (
    <div className="login">
      <div className="login__colored-container">
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
          Kérlek jelentkezz be
          <div className="login__login-container__main-container__form-container">
            <form
              className="login__login-container__main-container__form-container__form"
              onSubmit={(e) => {
                e.preventDefault();
              }}
            >
              <input
                className="login__login-container__main-container__form-container__form--email"
                type="email"
                placeholder="E-mail cím"
                required
              />
              <input
                className="login__login-container__main-container__form-container__form--password"
                type="password"
                placeholder="Jelszó"
                required
              />
              <button className="login__login-container__main-container__form-container__form--submit">
                Bejelentkezés
              </button>
            </form>
            <div>
              <SignInButton />
            </div>
            <div>
              <SignOutButton />
            </div>
          </div>
        </div>
      </div>
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
