import axios from "../../axios";
import React, { useEffect, useState } from "react";
import { ISubject } from "src/models/subject.model";
import Subject from "./sidebar-components/Subject";
import { IYear } from "src/models/year.model";
import Year from "./sidebar-components/Year";
import Button from "./feed-components/Button";
import AddSubject from "./feed-components/AddSubject";

const Sidebar = () => {
  const [showAdd, setShowAdd] = useState(false);

  const [subjects, setSubjects] = useState<ISubject[]>([]);
  const [years, setYears] = useState<IYear[]>([]);

  useEffect(() => {
    axios
      .get<ISubject[]>("http://localhost:8585/Subject")
      .then((res) => {
        setSubjects(res.data);
        //console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
      });

      axios
      .get<IYear[]>("http://localhost:8585/Year")
      .then((res) => {
        setYears(res.data);
        //console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
      });

  }, []);
  

  return (
    <div>
      <div className="flex-col bg-basewhitebg">
      <div className="h-16 bg-basebg text-white rounded-t-2xl">
          <h4 className="text-4xl font-thin tracking-wider p-2 text-center">Évfolyamok</h4>
        </div>
        <div>
          {years &&
            years.map((year,i) => (
              <div key={i} style={{cursor: 'pointer' }}>
                <Year {...year} />
              </div>
            ))}

        </div>
      
        <div className="h-16 bg-basebg text-white rounded-t-2xl">
          <h4 className="text-4xl font-thin tracking-wider p-2 text-center">Témák</h4>
        </div>
        <div className="flex w-full p-3  px-5 self-center">
            <div className="flex w-full h-8 bg-white rounded-2xl">
            <input type="text" className="flex w-full my-1 mx-2 text-black outline-none text-center bg-white" placeholder={`Keress rá egy témára!`} />
            </div>
        </div>
        <div>
          {subjects &&
            subjects.map((subject,i) => (
              <div key={i} style={{cursor: 'pointer' }}>
                <Subject {...subject}/>
              </div>
            ))}

        </div>
        <div>
        {showAdd && <AddSubject />}
          <Button
            onClicked={() => setShowAdd(!showAdd)}
            color={showAdd ? "#FAB001" : "#182A4E"}
            text={showAdd ? "Mégse" : "Új téma hozzáadása"}
          />
        </div>

      </div>
    </div>
  );
};

export default Sidebar;
