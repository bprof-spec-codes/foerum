import axios from "../../axios";
import React, { useEffect, useState } from "react";
import s from "./Admin.module.scss";
import { IUser } from "src/models/user.model";
import Header from "../Home/Header";

import PermIdentityOutlinedIcon from "@mui/icons-material/PermIdentityOutlined";
import PaidOutlinedIcon from "@mui/icons-material/PaidOutlined";
import GridViewOutlinedIcon from "@mui/icons-material/GridViewOutlined";
import LocalFireDepartmentOutlinedIcon from "@mui/icons-material/LocalFireDepartmentOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";
import { IComment } from "src/models/comment.model";
import { ICommentReacters } from "src/models/commentReacters.model";
import { ITopic } from "src/models/topic.model";
import { ISubject } from "src/models/subject.model";
import { Box, Skeleton } from "@mui/material";
import { boxSizing } from "@mui/system";
import moment from "moment";
import Timer from "./Timer";

const Admin = () => {
  const [users, setUsers] = useState<IUser[] | null>(null);
  const [comments, setComments] = useState<IComment[] | null>(null);
  const [reactions, setReactions] = useState<ICommentReacters[] | null>(null);
  const [topics, setTopics] = useState<ITopic[] | null>(null);
  const [subjects, setSubjects] = useState<ISubject[] | null>(null);
  const [actualPage, setActualPage] = useState<number>(1);

  useEffect(() => {
    const getData = async () => {
      await getUsers();
      await getComments();
      // getReacters();
      await getTopics();
      await getSubjects();
    };
    getData();
  }, []);


  const getUsers = async () => {
    const { data } = await axios.get<IUser[]>("/MyUser");
    setUsers(data);
  };

  const getComments = async () => {
    const { data } = await axios.get<IComment[]>("/Comment");

    setComments(data);
  };

  /*   const getReacters = async () => {
    const { data } = await axios.get<ICommentReacters[]>("/CommentReacters");
    console.log(data);
    setReactions(data);
  }; */

  const getTopics = async () => {
    axios
      .get("/Topic")
      .then((res) => {
        setTopics(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const getSubjects = async () => {
    axios
      .get("/Subject")
      .then((res) => {
        setSubjects(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const findSubject = (tid: any) => {
    const subject = subjects?.find((s) => s.subjectID === tid);
    return subject?.subjectName;
  };

  // TODO: rerender problem
  const createActivityList = () => {
    if (comments && topics) {
      const arr = comments.concat(topics);
      console.log(arr);

      return arr.map((q, i) => (
        <li key={i}>
          <p>igen</p>
        </li>
      ));
    }
    return <></>;
  };

  const renderMain = (): JSX.Element => {
    switch (actualPage) {
      case 2:
      case 3:
      case 4:
      default:
        return (
          <>
            <div className={s.hotTopics}>
              <div className={s.topicContainer}>
                {topics
                  ? topics.map((t, i) => (
                      <div key={i} className={s.topicItem}>
                        <h4>{t.topicName}</h4>

                        {subjects && <p>{findSubject(t.subjectID)}</p>}
                        <span>
                          {t.offeredCoins}{" "}
                          <MonetizationOnOutlinedIcon className="text-yellow-400" />
                        </span>
                      </div>
                    ))
                  : Array.from(new Array(3)).map((item, index) => (
                      <Box key={index} className={s.topicItem}>
                        <Skeleton
                          variant="rectangular"
                          width={210}
                          height={118}
                        />
                        <Skeleton />
                        <Skeleton width="60%" />
                      </Box>
                    ))}
              </div>
            </div>

            <div className={s.latestActivity}>
              <h3>Latest Activity</h3>
              <Timer />
              {comments || reactions || topics || subjects ? (
                <ul>{createActivityList()}</ul>
              ) : (
                Array.from(new Array(3)).map((item, index) => (
                  <Box key={index} className={s.topicItem}>
                    <Skeleton variant="rectangular" width={210} height={118} />
                    <Skeleton />
                    <Skeleton width="60%" />
                  </Box>
                ))
              )}
            </div>
          </>
        );
    }
  };

  return (
    <>
      <Header />
      <div className={s.root}>
        <div className={s.sidebar}>
          <ul className={s.sidebarList}>
            <li className={s.sidebarListItem} onClick={() => setActualPage(1)}>
              <div className={actualPage === 1 ? s.active : s.listIcon}>
                <GridViewOutlinedIcon />
              </div>
              <p>Áttekintés</p>
            </li>
            <li className={s.sidebarListItem} onClick={() => setActualPage(2)}>
              <div className={actualPage === 2 ? s.active : s.listIcon}>
                <PermIdentityOutlinedIcon />
              </div>
              <p>Felhasználók</p>
            </li>
            <li className={s.sidebarListItem} onClick={() => setActualPage(3)}>
              <div className={actualPage === 3 ? s.active : s.listIcon}>
                <PaidOutlinedIcon />
              </div>
              <p>Jóváírások</p>
            </li>
            <li className={s.sidebarListItem} onClick={() => setActualPage(4)}>
              <div className={actualPage === 4 ? s.active : s.listIcon}>
                <LocalFireDepartmentOutlinedIcon />
              </div>
              <p>Népszerű</p>
            </li>
          </ul>
        </div>

        <div className={s.main}>{renderMain()}</div>

        <div>bval</div>
      </div>
    </>
  );
};

export default Admin;
