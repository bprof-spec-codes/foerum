import React, { FC } from "react";
import { IYear } from "src/models/year.model";
import SchoolOutlinedIcon from "@mui/icons-material/SchoolOutlined";

const Year: FC<IYear> = (props) => {
  const { yearName } = props;

  return (
    <div className="flex w-full justify-start text-center items-center mb-2 hover:bg-gray-100 rounded-lg">
      <div className="flex justify-center items-center h-6 w-6 ml-4 bg-pink-200 rounded-md mr-4 text-pink-400">
        {" "}
        <SchoolOutlinedIcon sx={{ height: "15px", width: "15px" }} />
      </div>
      <p className="pl-1 py-2">{yearName}</p>
      <br />
    </div>
  );
};

export default Year;
