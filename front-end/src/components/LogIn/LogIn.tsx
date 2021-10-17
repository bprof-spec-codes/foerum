import React, { FC, useState } from "react";
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
    <div>
      <div>
        {/* this div is the left sido of the login page(figma) */}
        <div></div>

        <div>
          <SignInButton />
        </div>

        <div>
          <SignOutButton />
        </div>

        {/* this div is the left sido of the login page(figma) */}
        {/*
        <div>
          <form onSubmit={handleSubmit}>
            <input
              type="text"
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
            />
            <button type="submit">button</button>
          </form>
        </div>
        */}
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
