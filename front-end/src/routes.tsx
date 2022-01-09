/* This is where we store our main urls(etc: baseUrl/home) */
import React from "react";
import { Switch, Route } from "react-router-dom";
import { Home, Admin, LogIn, Header } from "./components";
import PrivateRoute from "./shared/auth/PrivateRoute";

const Routes = () => {
  return (
    <div className="view-routes">
      <Header />
      <Switch>
        <PrivateRoute path="/home" component={Home}></PrivateRoute>
        <PrivateRoute path="/admin" component={Admin}></PrivateRoute>
        <Route path="/" component={LogIn}></Route>
      </Switch>
    </div>
  );
};

export default Routes;
