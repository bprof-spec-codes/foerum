import { AnyAction, CombinedState, combineReducers } from "redux";
import { AuthenticationState } from "./authentication";

export interface IRootState {
    readonly authentication: AuthenticationState;
}

const appReducer = combineReducers<IRootState>({
    authentication,
});

/*  eslint no-console:off */
const rootReducer = (state: CombinedState<IRootState> | undefined, action: AnyAction) => {
  if (action.type === "authentication/LOGOUT") {
    state = undefined;
  }
  return appReducer(state, action);
};

export default rootReducer;
