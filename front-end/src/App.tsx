import axios from "./axios";
import React, { useEffect } from "react";

function App() {
  useEffect(() => {
    axios
      .get("/")
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }, []);

  return (
    <div>
      <h1 className="m-4 text-8xl font-light">Foerum</h1>
    </div>
  );
}

export default App;
