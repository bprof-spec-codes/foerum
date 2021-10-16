/* This file stores the startingpoint of our app and the basic configs */
import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import { createStore } from "redux";
import rootReducer from "./store/reducers";
import { Provider } from "react-redux";

import { PublicClientApplication } from "@azure/msal-browser";
import { MsalProvider } from "@azure/msal-react";
import { msalConfig } from "./ms-auth-config";

const store = createStore(rootReducer);

const msalInstance = new PublicClientApplication(msalConfig);

ReactDOM.render(
  <React.StrictMode>
    <MsalProvider instance={msalInstance}>
      <Provider store={store}>
        <App />
      </Provider>
    </MsalProvider>
  </React.StrictMode>,
  document.getElementById("root")
);
