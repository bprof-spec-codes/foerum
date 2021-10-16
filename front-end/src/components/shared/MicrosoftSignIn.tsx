import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../ms-auth-config";

function handleLogin(instance: any) {
  instance.loginPopup(loginRequest).catch((e: any) => {
    console.error(e);
  });
}

/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignInButton = () => {
  const { instance } = useMsal();

  return (
    <button
      onClick={() => handleLogin(instance)}
    >
      Sign in using Redirect
    </button>
  );
};
