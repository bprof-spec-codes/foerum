/* eslint-disable import/no-anonymous-default-export */
import axios from "../../axios";
import { IUser } from "src/models/user.model";
import { loginRequest } from "src/ms-auth-config";
import { FAILURE, REQUEST, SUCCESS } from "./action-type.util";
import { baseHeader } from "src/shared/types/headers";

export const ACTION_TYPES = {
  LOGIN: "msAuthentication/LOGIN",
  LOGOUT: "msAuthentication/LOGOUT",
};

const AUTH_TOKEN_KEY = "token";

const initialState = {
  loading: false,
  isAuthenticated: false,
  loginSuccess: false,
  loginError: false,
  account: {} as IUser,
  errorMessage: null as unknown as string,
  idToken: null as unknown as string,
};

export type MSAuthenticationState = Readonly<typeof initialState>;

export default (
  state: MSAuthenticationState = initialState,
  action: any
): MSAuthenticationState => {
  switch (action.type) {
    case ACTION_TYPES.LOGIN:
      return {
        ...state,
        loading: false,
        loginError: false,
        loginSuccess: true,
        isAuthenticated: true,
        account:action.payload,
      };
    default:
      return state;
  }
};

export const login = (instance: any, dispatch: any) => {
  instance
    .loginPopup(loginRequest)
    .then((res: any) => {
      sessionStorage.setItem("username", res.account.name);
      sessionStorage.setItem("useremail", res.account.username);

      const bearerToken = `Bearer ${res.idToken}`;
      sessionStorage.setItem(AUTH_TOKEN_KEY, bearerToken);
      dispatch(setLoginState(res));
    })
    .catch((e: any) => {
      console.error(e);
    });
};

export const setLoginState = (data: any) => {
  return {
    type: ACTION_TYPES.LOGIN,
    payload: axios
      .put(
        "/auth/microsoft",
        {
          Name: data.idTokenClaims.name,
          uniqueName: data.idTokenClaims.preferred_username,
        },
        baseHeader
      )
      .then((res) => {
        sessionStorage.setItem("foerumtoken", `Bearer ${res.data.token}`);
        sessionStorage.setItem("userid", res.data.userId);
      })
      .catch((err) => console.error(err)),
  };
};

export const logout = (instance: any) => {
  instance
    .logoutPopup()
    .then((res: any) => {
      sessionStorage.removeItem("token");
      sessionStorage.removeItem("foerumtoken");
      sessionStorage.removeItem("userid");
      sessionStorage.removeItem("username");
      sessionStorage.removeItem("useremail");
    })
    .catch((e: any) => {
      console.error(e);
    });
};
