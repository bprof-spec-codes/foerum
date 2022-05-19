import React, { useEffect, useState } from "react";
import Feed from "./Feed";
import ProfileActions from "./ProfileActions";
import Sidebar from "./Sidebar";
import Header from "./Header";
import axios from "../../axios";
import { IUser } from "src/models/user.model";
import { ITopic } from "src/models/topic.model";
import { ISubject } from "src/models/subject.model";
import Subject from "./sidebar-components/Subject";
import { IYear } from "src/models/year.model";
import Year from "./sidebar-components/Year";
import { Button, ButtonProps } from "@mui/material";
import { styled, createTheme } from "@mui/material/styles";
import { blue } from "@mui/material/colors";
import AddSubject from "./feed-components/AddSubject";
import { connect } from "react-redux";
import { useHistory } from "react-router";
import { IRootState } from "src/store/reducers";
import minilogo from "../../assets/images/minilogo.png";
import { SignOutButton } from "../shared/MicrosoftSignOut";
import "./home.scss";
import jwt_decode from "jwt-decode";
import AddTopic from "./feed-components/AddTopic";
import Topic from "../../components/Misc/Topic";
import ChatOutlinedIcon from "@mui/icons-material/ChatOutlined";
import { Box, Skeleton } from "@mui/material";
import { Notifications, ProfileCard } from "./profile-actions-components";

const Home = () => {
  const [topics, setTopics] = useState<ITopic[] | null>(null);
  const [showAdd, setShowAdd] = useState(false);
  const [subjects, setSubjects] = useState<ISubject[]>([]);
  const [years, setYears] = useState<IYear[]>([]);
  const [selectedSubject, setSelectedSubject] = useState<ISubject>();
  const [selectedYear, setSelectedYear] = useState<IYear>();
  const [subjectName, setSubjectName] = useState("");
  const [filteredTopics, setFilteredTopics] = useState<ITopic[] | null>(null);
  const [users, setUsers] = useState<IUser[]>([]);
  const [showAddComment, setShowAddComment] = useState(false);
  const [showAddTopic, setShowAddTopic] = useState(false);

  useEffect(() => {
    getTopics();
    getUsers();

    getSubjects();
  }, []);

  const getSubjects = () => {
    const token = sessionStorage.getItem("foerumtoken");

    if (token) {
      axios
        .get<ISubject[]>("/Subject", { headers: { Authorization: token } })
        .then((res) => {
          setSubjects(res.data);

          const subj = res.data[0];

          console.log(subj.subjectName);

          setSelectedSubject(subj);
          //console.log(res.data);
        })
        .catch((err) => {
          console.log(err);
        });
    }
  };

  const getYears = () => {
    const token = sessionStorage.getItem("foerumtoken");

    if (token) {
      axios
        .get<IYear[]>("/Year", { headers: { Authorization: token } })
        .then((res) => {
          setYears(res.data);

          const yr = res.data[0];

          console.log(yr);

          setSelectedYear(yr);
          // console.log(res.data);
        })
        .catch((err) => {
          console.log(err);
        });
    }
  };

  const getTopics = async () => {
    const token = sessionStorage.getItem("foerumtoken");

    if (token) {
      const topics = await axios.get<ITopic[]>("/Topic", {
        headers: { Authorization: token },
      });
      setTopics(topics.data);
    }
  };

  const getUsers = async () => {
    const token = sessionStorage.getItem("foerumtoken");

    if (token) {
      const users = await axios.get<IUser[]>("/MyUser", {
        headers: { Authorization: token },
      });
      setUsers(users.data);
    }
  };

  const selectUser = (tid: any) => {
    const user = users.find((u) => u.id === tid);
    return user ? user : ({} as IUser);
  };

  return (
    <>
      <Header />
      <div className="flex justify-between pt-14">
        <div className="flex justify-between w-full">
          <div className="w-1/5 mr-5 shadow-sm">
            <div className="mx-5">
              <h4 className="text-normal tracking-wider p-2 pt-6 text-gray-400">
                Évfolyamok
              </h4>
              <div className="">
                {years &&
                  years.map((year, i) => (
                    <div key={i} style={{ cursor: "pointer" }}>
                      <Year
                        yearName={year.yearName} /*onClick={filterByYear}*/
                      />
                    </div>
                  ))}
                <div>
                  <h4 className="text-normal tracking-wider p-2 pt-6 text-gray-400">
                    Tantárgyak
                  </h4>
                  {subjects &&
                    subjects
                      .sort(function (a, b) {
                        if (a.subjectName! < b.subjectName!) {
                          return -1;
                        }
                        if (a.subjectName! > b.subjectName!) {
                          return 1;
                        }
                        return 0;
                      })
                      .map((subject, i) => (
                        <div key={i} style={{ cursor: "pointer" }}>
                          <Subject {...subject} /*onClick={filterBySubject}*/ />
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
            </div>
          </div>

          <div className="w-2/4 m-5">
            <>
              <div className="flex flex-col w-full bg-gray-100 rounded-lg shadow-md">
                <AddTopic getTopics={getTopics} />
              </div>

              {topics ? (
                topics.length > 0 ? (
                  topics.map((topic, i) => (
                    <div key={i}>
                      {users && (
                        <Topic
                          topic={topic}
                          onAdd={showAddComment}
                          allUsers={users}
                          user={selectUser(topic.userID)}
                        />
                      )}
                    </div>
                  ))
                ) : (
                  <div className="flex flex-col justify-center items-center mt-16 p-4 text-gray-400">
                    <span className="flex justify-center items-center h-16 w-16 mb-4 border-2 border-gray-400 border-dashed rounded-full">
                      <ChatOutlinedIcon />
                    </span>
                    <p>Nem találtunk egyetlen témát sem.</p>
                  </div>
                )
              ) : (
                Array.from(new Array(15)).map((item, index) => (
                  <Box key={index} className="mt-4">
                    <Skeleton animation="wave" width="30%" />
                    <Skeleton animation="wave" width="70%" />
                    <Skeleton animation="wave" width="50%" />
                    <Skeleton animation="wave" width="50%" />
                    <Skeleton animation="wave" width="50%" />
                  </Box>
                ))
              )}
            </>
          </div>

          <div className="w-1/5 m-5">
            <div>
              <div>
                <div>
                  <ProfileCard />
                </div>

                <div>
                  <Notifications />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Home;
