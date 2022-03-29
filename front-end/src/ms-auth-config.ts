export const msalConfig = {
  auth: {
    clientId: "76c4c395-9623-465d-aa07-949e0f58c09e",
    authority: "https://login.microsoftonline.com/1d6a56fa-705a-4bbc-8004-67a21d5e9b97/", // This is a URL (e.g. https://login.microsoftonline.com/{your tenant ID})
    redirectUri: "pite4.duckdns.org",
  },
  cache: {
    cacheLocation: "sessionStorage", // This configures where your cache will be stored
    storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
  },
};

// Add scopes here for ID token to be used at Microsoft identity platform endpoints.
export const loginRequest = {
  scopes: ["User.Read"],
};

// Add the endpoints here for Microsoft Graph API services you'd like to use.
/*
export const graphConfig = {
  graphMeEndpoint: "Enter_the_Graph_Endpoint_Here/v1.0/me",
};
*/
