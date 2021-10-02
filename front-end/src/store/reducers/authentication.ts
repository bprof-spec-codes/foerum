/* eslint-disable import/no-anonymous-default-export */
import axios from "axios";
import { IUser } from "src/models/user.model";
import { FAILURE, REQUEST, SUCCESS } from "./action-type.util";

export const ACTION_TYPES = {
  LOGIN: "authentication/LOGIN",
  GET_SESSION: "authentication/GET_SESSION",
  LOGOUT: "authentication/LOGOUT",
  CLEAR_AUTH: "authentication/CLEAR_AUTH",
  ERROR_MESSAGE: "authentication/ERROR_MESSAGE",
};

const AUTH_TOKEN_KEY = "token";

const initialState = {
  loading: false,
  isAuthenticated: false,
  loginSuccess: false,
  loginError: false, // Errors returned from server side
  account: {} as IUser,
  errorMessage: null as unknown as string, // Errors returned from server side
  redirectMessage: null as unknown as string,
  idToken: null as unknown as string,
  logoutUrl: null as unknown as string,
};

export type AuthenticationState = Readonly<typeof initialState>;

export default (
  state: AuthenticationState = initialState,
  action: any
): AuthenticationState => {
  switch (action.type) {
    case REQUEST(ACTION_TYPES.LOGIN):
      return { ...state, loading: true };

    case FAILURE(ACTION_TYPES.LOGIN):
      return {
        ...initialState,
        errorMessage: action.payload,
        loginError: true,
      };

    case SUCCESS(ACTION_TYPES.LOGIN):
      return {
        ...state,
        loading: false,
        loginError: false,
        loginSuccess: true,
      };

    case ACTION_TYPES.LOGOUT:
      return {
        ...initialState,
      };
    default:
      return state;
  }
};

export const login: (
  username: string,
  password: string,
  rememberMe?: boolean
) => void =
  (username, password, rememberMe = true) =>
  async (dispatch: any) => {
    const result = await dispatch({
      type: ACTION_TYPES.LOGIN,
      payload: axios.post("api/auth", {
        username,
        password,
        /* rememberMe, */
      }),
    });
    const bearerToken = result.value.headers.authorization;
    if (bearerToken) {
      if (rememberMe) {
        localStorage.setItem(AUTH_TOKEN_KEY, bearerToken);
      } else {
        sessionStorage.setItem(AUTH_TOKEN_KEY, bearerToken);
      }
    }
  };

export const clearAuthToken = () => {
  if (localStorage.getItem(AUTH_TOKEN_KEY)) {
    localStorage.removeItem(AUTH_TOKEN_KEY);
  }
  if (sessionStorage.getItem(AUTH_TOKEN_KEY)) {
    sessionStorage.remove(AUTH_TOKEN_KEY);
  }
};

export const logout: () => void = () => (dispatch: any) => {
  clearAuthToken();
  dispatch({
    type: ACTION_TYPES.LOGOUT,
  });
};
