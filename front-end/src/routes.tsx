import React from "react";
import { Switch, Route } from "react-router-dom";
import { LogIn } from "./components";

const Routes = () => {
  return (
    <div className="view-routes">
      <Switch>
        <Route path="/" component={LogIn}></Route>
      </Switch>
    </div>
  );
};

export default Routes;
