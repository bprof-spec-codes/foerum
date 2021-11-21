import React from "react";
import { ISubject } from "src/models/subject.model";

const Subject = (subj: ISubject) => {
  return(
  <div>
    <p className="text-center"> {subj.subjectName}</p><br/>
  </div>)
};

export default Subject;
