/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { FC, useEffect } from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../ms-auth-config";
import { connect } from "react-redux";
import { IRootState } from "src/store/reducers";
import { useHistory } from "react-router-dom";

export interface ILoginProps {
  isAuthenticated: boolean;
  login(instance: any): void;
}

export const SignInButton: FC<ILoginProps> = (props) => {
  const { isAuthenticated, login } = props;
  const history = useHistory();
  const { instance } = useMsal();

  useEffect(() => {
    if (isAuthenticated) {
      history.push("/home");
    }
  }, [isAuthenticated]);

  return (
    <button onClick={() => login(instance)}>Sign in using Redirect</button>
  );
};

export default SignInButton;
