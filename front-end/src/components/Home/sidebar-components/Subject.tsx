import React, { FC } from "react";
import { ISubject } from "src/models/subject.model";
import MenuBookOutlinedIcon from "@mui/icons-material/MenuBookOutlined";

const Subject: FC<ISubject> = (props) => {
  const { subjectName } = props;
  return (
    <div className="flex w-full justify-start text-center items-center mb-2 hover:bg-gray-100 rounded-lg">
      <div className="flex justify-center items-center h-6 w-6 ml-4 bg-blue-200 rounded-md mr-4 text-blue-400"><MenuBookOutlinedIcon sx={{ height:"15px", width:"15px"}} /></div><p className="pl-1 py-2"> {subjectName}</p>
    </div>
  );
};

export default Subject;
