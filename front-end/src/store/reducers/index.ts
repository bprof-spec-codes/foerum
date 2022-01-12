import { AnyAction, CombinedState, combineReducers } from "redux";
import authentication, { AuthenticationState } from "./authentication";
import msAuthentication, { MSAuthenticationState } from "./ms-authentication";

export interface IRootState {
  readonly authentication: AuthenticationState;
  readonly msAuthentication: MSAuthenticationState;
}

const appReducer = combineReducers<IRootState>({
  authentication,
  msAuthentication,
});

/*  eslint no-console:off */
const rootReducer = (
  state: CombinedState<IRootState> | undefined,
  action: AnyAction
) => {
  if (action.type === "authentication/LOGOUT") {
    state = undefined;
  }
  return appReducer(state, action);
};

export default rootReducer;
