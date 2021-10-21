/* eslint-disable @typescript-eslint/no-unused-vars */
import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../ms-auth-config";
import { connect } from "react-redux";
import { IRootState } from "src/store/reducers";
import { login } from "../../store/reducers/ms-authentication";

/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignInButton = () => {
  const { instance } = useMsal();

  return (
    <button onClick={() => login(instance)}>
      Sign in using Redirect
    </button>
  );
};

const mapStateToProps = ({ msAuthentication }: IRootState) => ({
  isAuthenticated: msAuthentication.isAuthenticated,
  loginError: msAuthentication.loginError,
});

const mapDispatchToProps = { login };

type StateProps = ReturnType<typeof mapStateToProps>;
type DispatchProps = typeof mapDispatchToProps;

export default connect(mapStateToProps, mapDispatchToProps)(SignInButton);
