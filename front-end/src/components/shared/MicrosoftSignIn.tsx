/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { FC, useEffect } from "react";
import { useMsal } from "@azure/msal-react";
import { connect, useDispatch } from "react-redux";
import { IRootState } from "src/store/reducers";
import { login } from "../../store/reducers/ms-authentication";
import { useHistory } from "react-router";

export interface ILoginProps extends StateProps, DispatchProps {}

export const SignInButton: FC<ILoginProps> = (props) => {
  const { isAuthenticated } = props;
  const dispatch = useDispatch();
  const history = useHistory();
  const { instance } = useMsal();

  useEffect(() => {
    console.log(isAuthenticated);
    if (isAuthenticated) {
      history.push("/home");
    }
  }, [isAuthenticated]);

  return (
    <button onClick={() => login(instance, dispatch)}>
      Sign in using Redirect
    </button>
  );
};

const mapStateToProps = ({ msAuthentication }: IRootState) => ({
  isAuthenticated: msAuthentication.isAuthenticated,
});

const mapDispatchToProps = { login };

type StateProps = ReturnType<typeof mapStateToProps>;
type DispatchProps = typeof mapDispatchToProps;

export default connect(mapStateToProps, mapDispatchToProps)(SignInButton);
