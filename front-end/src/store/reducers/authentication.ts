/* eslint-disable import/no-anonymous-default-export */
import { IUser } from "src/models/user.model";
import { REQUEST } from "./action-type.util";

export const ACTION_TYPES = {
  LOGIN: "authentication/LOGIN",
  GET_SESSION: "authentication/GET_SESSION",
  LOGOUT: "authentication/LOGOUT",
  CLEAR_AUTH: "authentication/CLEAR_AUTH",
  ERROR_MESSAGE: "authentication/ERROR_MESSAGE",
};

const initialState = {
  loading: false,
  isAuthenticated: false,
  loginSuccess: false,
  loginError: false, // Errors returned from server side
  showModalLogin: false,
  account: {} as IUser,
  errorMessage: null as unknown as string, // Errors returned from server side
  redirectMessage: null as unknown as string,
  sessionHasBeenFetched: false,
  idToken: null as unknown as string,
  logoutUrl: null as unknown as string,
};

export type AuthenticationState = Readonly<typeof initialState>;

export default (
  state: AuthenticationState = initialState,
  action: { type: any }
): AuthenticationState => {
  switch (action.type) {
    case REQUEST(ACTION_TYPES.LOGIN):
      return state;
    default:
      return state;
  }
};
