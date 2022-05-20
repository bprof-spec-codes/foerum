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
import { Button, ButtonProps, TextField } from "@mui/material";
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
  const [users, setUsers] = useState<IUser[]>([]);
  const [showAddComment, setShowAddComment] = useState(false);

  const [yearSearchKeyword, setYearSearchKeyword] = useState<string>("");
  const [subjetSearchKeyword, setSubjectSearchKeyword] = useState<string>("");
  const [topicSearchKeyword, setTopicSearchKeyword] = useState<string>("");

  const [selectedYear, setSelectedYear] = useState<IYear | null>(null);
  const [selectedSubject, setSelectedSubject] = useState<ISubject | null>(null);

  

  useEffect(() => {
    const getDatas = async () => {
      getTopics();
      getUsers();
      await getYears();
      await getSubjects();
    };
    getDatas();

    
  }, []);

  useEffect(() => {
    if (years && years.length > 0) {
      console.log(years[0]);
      setSelectedYear(years[0]);
    }
    if (subjects && subjects.length > 0) {
      const sb = subjects.find((s) => s.yearID === selectedYear?.yearID);
      console.log(sb);
      if (sb) {
        setSelectedSubject(sb);
      }
    }
  }, [years, subjects]);

  useEffect(() => {
    getTopics();
  }, [selectedYear, selectedSubject]);

  useEffect(() => {
    if (subjects && subjects.length > 0) {
      const sb = subjects.find((s) => s.yearID === selectedYear?.yearID);
      console.log(sb);
      if (sb) {
        setSelectedSubject(sb);
      }
    }
  }, [selectedYear]);

  useEffect(() => {
    renderTopics();
  }, [years, subjects, selectedSubject, selectedYear]);

  const getSubjects = async () => {
    const token = sessionStorage.getItem("foerumtoken");

    if (token) {
      axios
        .get<ISubject[]>("/Subject", { headers: { Authorization: token } })
        .then((res) => {
          setSubjects(res.data);
        })
        .catch((err) => {
          console.log(err);
        });
    }
  };

  const getYears = async () => {
    const token = sessionStorage.getItem("foerumtoken");

    if (token) {
      axios
        .get<IYear[]>("/Year", { headers: { Authorization: token } })
        .then((res) => {
          setYears(res.data);
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

  

  const renderTopics = () => {
    return (
      <>
        {topics && selectedSubject
          ? topicSearchKeyword
            ? topics
                .filter(
                  (t) =>
                    t.subjectID === selectedSubject?.subjectID &&
                    t.topicName?.toLowerCase().includes(topicSearchKeyword)
                )
                .sort((a, b) => new Date(b.creationDate).getTime() - new Date(a.creationDate).getTime())
                .map((topic, i) => (
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
            : topics.map((topic, i) => (
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
          : null}
      </>
    );
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
              <TextField
                variant="outlined"
                label="Keress évfolyamot..."
                value={yearSearchKeyword}
                onChange={(e) => setYearSearchKeyword(e.target.value)}
                style={{ padding: 10, width: "100%" }}
              />
              <div className="">
                {years && selectedYear
                  ? yearSearchKeyword
                    ? years
                        .filter((y) =>
                          y.yearName?.toLowerCase().includes(yearSearchKeyword)
                        )
                        .map((year, i) => (
                          <div
                            key={i}
                            className={`cursor-pointer ${
                              year.yearID === selectedYear?.yearID &&
                              "bg-gray-400 rounded-md"
                            }`}
                            onClick={() => setSelectedYear(year)}
                          >
                            <Year
                              yearName={
                                year.yearName
                              } /*onClick={filterByYear}*/
                            />
                          </div>
                        ))
                    : years.map((year, i) => (
                        <div
                          key={i}
                          className={`cursor-pointer ${
                            year.yearID === selectedYear?.yearID &&
                            "bg-gray-400 rounded-md"
                          }`}
                          onClick={() => setSelectedYear(year)}
                        >
                          <Year
                            yearName={year.yearName} /*onClick={filterByYear}*/
                          />
                        </div>
                      ))
                  : null}
                <div>
                  <h4 className="text-normal tracking-wider p-2 pt-6 text-gray-400">
                    Tantárgyak
                  </h4>
                  <TextField
                    variant="outlined"
                    label="Keress tárgyat..."
                    value={subjetSearchKeyword}
                    onChange={(e) => setSubjectSearchKeyword(e.target.value)}
                    style={{ padding: 10, width: "100%" }}
                  />
                  {subjects && selectedSubject
                    ? subjetSearchKeyword
                      ? subjects
                          .filter(
                            (s) =>
                              s.yearID === selectedYear?.yearID &&
                              s.subjectName
                                ?.toLowerCase()
                                .includes(subjetSearchKeyword)
                          )
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
                            <div
                              key={i}
                              className={`cursor-pointer ${
                                subject.subjectID ===
                                  selectedSubject?.subjectID &&
                                "bg-gray-400 rounded-md"
                              }`}
                              onClick={() => setSelectedSubject(subject)}
                            >
                              <Subject
                                {...subject} /*onClick={filterBySubject}*/
                              />
                            </div>
                          ))
                      : subjects
                          .sort(function (a, b) {
                            if (a.subjectName! < b.subjectName!) {
                              return -1;
                            }
                            if (a.subjectName! > b.subjectName!) {
                              return 1;
                            }
                            return 0;
                          })
                          .filter((s) => s.yearID === selectedYear?.yearID)
                          .map((subject, i) => (
                            <div
                              key={i}
                              style={{ cursor: "pointer" }}
                              className={`cursor-pointer ${
                                subject.subjectID ===
                                  selectedSubject?.subjectID &&
                                "bg-gray-400 rounded-md"
                              }`}
                              onClick={() => setSelectedSubject(subject)}
                            >
                              <Subject
                                {...subject} /*onClick={filterBySubject}*/
                              />
                            </div>
                          ))
                    : null}
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
              <TextField
                variant="outlined"
                label="Keress témát..."
                value={topicSearchKeyword}
                onChange={(e) => setTopicSearchKeyword(e.target.value)}
                style={{ padding: 10, width: "100%" }}
              />
              {renderTopics()}
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
