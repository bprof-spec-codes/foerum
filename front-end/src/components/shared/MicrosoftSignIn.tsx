/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { FC, useEffect } from "react";
import { useMsal } from "@azure/msal-react";
import { connect, useDispatch } from "react-redux";
import { IRootState } from "src/store/reducers";
import { login } from "../../store/reducers/ms-authentication";
import { useHistory } from "react-router";
import mslogo from "../../assets/images/micro.png";
import { Button } from "@mui/material";
import LockOpenOutlinedIcon from "@mui/icons-material/LockOpenOutlined";

export interface ILoginProps extends StateProps, DispatchProps {}

export const SignInButton: FC<ILoginProps> = (props) => {
  const { isAuthenticated } = props;
  const dispatch = useDispatch();
  const history = useHistory();
  const { instance } = useMsal();

  useEffect(() => {
    if (isAuthenticated) {
      history.push("/home");
    }
  }, [isAuthenticated]);

  return (
    <Button
      variant="contained"
      onClick={() => login(instance, dispatch)}
      style={{
        backgroundColor: "#182A4E",
        color: "white",
        outline: "none",
        border: "none",
      }}
    >
      <LockOpenOutlinedIcon />
      Bejelentkezés
    </Button>
  );
};

const mapStateToProps = ({ msAuthentication }: IRootState) => ({
  isAuthenticated: msAuthentication.isAuthenticated,
});

const mapDispatchToProps = { login };

type StateProps = ReturnType<typeof mapStateToProps>;
type DispatchProps = typeof mapDispatchToProps;

export default connect(mapStateToProps, mapDispatchToProps)(SignInButton);
