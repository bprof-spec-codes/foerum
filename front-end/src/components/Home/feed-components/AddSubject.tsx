import { Button, Input } from "@mui/material";
import React, { useState } from "react";
import { ISubject } from "src/models/subject.model";
import axios from "../../../axios";


const AddSubject = (topic: ISubject) => {
  const [subjectName, setSubjectName] = useState("");


  const createSubject = ()=> {

    const data = {
      SubjectName: subjectName,
      IsPrivate: false,
    };

    axios.post("/Subject", data)
    .then((res) => {
      console.log(res.data)
    })
    
    .catch((err) => {
      console.log(err);
    })};


  return (
    <div>
      <Input
        className="w-full ml-1 mb-4"
        placeholder="Mi lesz a téma neve?"
        type="text"
        onChange={(e) => setSubjectName(e.target.value)}
      />

      <Button
        onClick={createSubject}
        style={{
          backgroundColor: "#182A4E",
          color: "white",
          marginBottom: "10px",
          outline: "none",
          border: "none",
        }}>
        Hozzáadás
      </Button>
    </div>
  );
};

export default AddSubject;
