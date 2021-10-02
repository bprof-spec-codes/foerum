/* This is where we store our main urls(etc: baseUrl/home) */
import React from "react";
import { Switch, Route } from "react-router-dom";
import { Home, Admin, LogIn } from "./components";

const Routes = () => {
  return (
    <div className="view-routes">
      <Switch>
        <Route path="/home" component={Home}></Route>
        <Route path="/admin" component={Admin}></Route>
        <Route path="/" component={LogIn}></Route>
      </Switch>
    </div>
  );
};

export default Routes;
