import { Button, Input } from "@mui/material";
import React, { useState } from "react";
import { ISubject } from "src/models/subject.model";

const AddSubject = (topic: ISubject) => {
  const [subjectName, setSubjectName] = useState("");

  return (
    <div>
      <Input
        className="w-full ml-1 mb-4"
        placeholder="Mi lesz a téma neve?"
        type="text"
        onChange={(e) => setSubjectName(e.target.value)}
      />

      <Button
        style={{
          backgroundColor: "#182A4E",
          color: "white",
          marginBottom: "10px",
          outline: "none",
          border: "none",
        }}
        className="btn"
      >
        Hozzáadás
      </Button>
    </div>
  );
};

export default AddSubject;
