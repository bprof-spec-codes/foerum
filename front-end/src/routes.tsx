import React from "react";
import { Switch, Route } from "react-router-dom";
import { Home, LogIn, Admin } from "./components";

const Routes = () => {
  return (
    <div className="view-routes">
      <Switch>
        <Route path="/" component={LogIn}></Route>
        <Route path="/home" component={Home}></Route>
        <Route path="/admin" component={Admin}></Route>
      </Switch>
    </div>
  );
};

export default Routes;
