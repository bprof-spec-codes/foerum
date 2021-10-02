/* This is where we store our main urls(etc: baseUrl/home) */
import React from "react";
import { Switch, Route } from "react-router-dom";
import Admin from "./components/Admin/Admin";
import Home from "./components/Home/Home";
import LogIn from "./components/LogIn/LogIn";

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
