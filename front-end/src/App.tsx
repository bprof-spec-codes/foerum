/* Our main component */
import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import { Header } from "./components";
import AppRoutes from "./routes";

function App() {
  return (
    <Router>
      <div className="app">
        <Header />
        <AppRoutes />
      </div>
    </Router>
  );
}

export default App;
