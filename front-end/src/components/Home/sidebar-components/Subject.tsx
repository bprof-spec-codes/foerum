import React, { FC } from "react";
import { ISubject } from "src/models/subject.model";

const Subject: FC<ISubject> = (props) => {
  const { subjectName } = props;
  return (
    <div className="flex w-full justify-start text-center items-center mb-2 hover:bg-gray-100 rounded-lg">
      <p className="pl-4 py-2"> {subjectName}</p>
      <br />
    </div>
  );
};

export default Subject;
