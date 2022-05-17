/* eslint-disable @typescript-eslint/no-unused-vars */
import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../ms-auth-config";
import { connect } from "react-redux";
import { IRootState } from "src/store/reducers";
import { logout } from "../../store/reducers/ms-authentication";
import { Button, IconButton } from "@mui/material";
import LogoutIcon from "@mui/icons-material/Logout";
import { useHistory } from "react-router";

/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignOutButton = () => {
  const { instance } = useMsal();

  const history = useHistory();

  return (
    <div onClick={() => logout(instance)}>
      <br /> <p>Kijelentkezés</p>
      <IconButton>
        <LogoutIcon sx={{ color: "black" }} onClick={() => history.push("/")} />
      </IconButton>
    </div>
  );
};

const mapStateToProps = ({ msAuthentication }: IRootState) => ({
  isAuthenticated: msAuthentication.isAuthenticated,
  loginError: msAuthentication.loginError,
});

const mapDispatchToProps = { logout };

type StateProps = ReturnType<typeof mapStateToProps>;
type DispatchProps = typeof mapDispatchToProps;

export default connect(mapStateToProps, mapDispatchToProps)(SignOutButton);
