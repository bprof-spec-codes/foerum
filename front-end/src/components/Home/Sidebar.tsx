import axios from "../../axios";
import React, { useEffect, useState } from "react";
import { ISubject } from "src/models/subject.model";
import Subject from "./sidebar-components/Subject";
import { IYear } from "src/models/year.model";
import Year from "./sidebar-components/Year";
import AddSubject from "./feed-components/AddSubject";
import { Button, ButtonProps } from "@mui/material";

import { styled, createTheme } from "@mui/material/styles";
import { blue } from "@mui/material/colors";

const Sidebar = () => {
  const [showAdd, setShowAdd] = useState(false);

  const [subjects, setSubjects] = useState<ISubject[]>([]);
  const [years, setYears] = useState<IYear[]>([]);

  useEffect(() => {
    axios
      .get<ISubject[]>("/Subject")
      .then((res) => {
        setSubjects(res.data);
        //console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
      });

    axios
      .get<IYear[]>("/Year")
      .then((res) => {
        setYears(res.data);
        //console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <div className="mx-5">
      <h4 className="text-normal tracking-wider p-2 pt-6 text-gray-400">
        Évfolyamok
      </h4>
      <div className="">
        {years &&
          years.map((year, i) => (
            <div key={i} style={{ cursor: "pointer" }}>
              <Year yearName={year.yearName} />
            </div>
          ))}
      </div>
      <h4 className="text-normal tracking-wider p-2 pt-6 text-gray-400">
        Tantárgyak
      </h4>
      <div>
        {subjects &&
          subjects.map((subject, i) => (
            <div key={i} style={{ cursor: "pointer" }}>
              <Subject subjectName={subject.subjectName} />
            </div>
          ))}
      </div>
      <div>
        {showAdd && <AddSubject />}
        <Button
          className="w-full"
          variant="outlined"
          onClick={() => setShowAdd(!showAdd)}
          style={{
            backgroundColor: `${showAdd ? "#FAB001" : "#182A4E"}`,
            color: "white",
            outline: "none",
            border: "none",
          }}
        >
          {showAdd ? "Mégse" : "Új téma hozzáadása"}
        </Button>
      </div>
    </div>
  );
};

export default Sidebar;
