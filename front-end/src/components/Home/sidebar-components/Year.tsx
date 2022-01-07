import React, { FC } from "react";
import { IYear } from "src/models/year.model";

const Year: FC<IYear> = (props) => {
  const { yearName } = props;

  return (
    <div className="flex w-full justify-start text-center items-center mb-2 hover:bg-gray-100 rounded-lg">
      <p className="pl-4 py-2">{yearName}</p>
      <br />
    </div>
  );
};

export default Year;
