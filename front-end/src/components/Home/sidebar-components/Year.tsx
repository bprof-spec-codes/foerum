import React from "react";
import { IYear } from "src/models/year.model";

const Year = (year: IYear) => {
  return(
  <div>
    <p className="text-center"> {year.yearName}</p><br/>
  </div>)
};

export default Year;