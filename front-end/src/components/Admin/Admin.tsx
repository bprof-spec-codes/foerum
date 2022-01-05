import axios from "../../axios";
import React, { FC, useEffect, useState } from "react";
import s from "./Admin.module.scss";
import { IUser } from "src/models/user.model";
import Header from "../Home/Header";

import PermIdentityOutlinedIcon from "@mui/icons-material/PermIdentityOutlined";
import PaidOutlinedIcon from "@mui/icons-material/PaidOutlined";
import GridViewOutlinedIcon from "@mui/icons-material/GridViewOutlined";
import LocalFireDepartmentOutlinedIcon from "@mui/icons-material/LocalFireDepartmentOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";
import ChatOutlinedIcon from "@mui/icons-material/ChatOutlined";
import LightbulbOutlinedIcon from "@mui/icons-material/LightbulbOutlined";
import UpdateOutlinedIcon from "@mui/icons-material/UpdateOutlined";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import KeyboardArrowDownOutlinedIcon from "@mui/icons-material/KeyboardArrowDownOutlined";
import AlternateEmailIcon from "@mui/icons-material/AlternateEmail";
import Zoom from "@mui/material/Zoom";

import { IComment } from "src/models/comment.model";
import { ICommentReacters } from "src/models/commentReacters.model";
import { ITopic } from "src/models/topic.model";
import { ISubject } from "src/models/subject.model";
import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Box,
  Button,
  Skeleton,
  Tooltip,
  Typography,
} from "@mui/material";
import { boxSizing } from "@mui/system";
import moment from "moment";
import { Timer } from "./admin-components";
import { ITransaction } from "src/models/transaction.model";

type concatArray = IComment & ITopic;

const Admin: FC = () => {
  const [users, setUsers] = useState<IUser[] | null>(null);
  const [transactions, setTransactions] = useState<ITransaction[] | null>(null);

  const [comments, setComments] = useState<IComment[] | null>(null);
  const [reactions, setReactions] = useState<ICommentReacters[] | null>(null);
  const [topics, setTopics] = useState<ITopic[] | null>(null);
  const [subjects, setSubjects] = useState<ISubject[] | null>(null);
  const [actualPage, setActualPage] = useState<number>(1);

  useEffect(() => {
    const getData = async () => {
      await getUsers();
      await getTransactions();
      await getComments();
      // getReacters();
      await getTopics();
      await getSubjects();
    };
    getData();
  }, []);

  useEffect(() => {
    console.log(transactions);
  }, [transactions]);

  const getUsers = async () => {
    const { data } = await axios.get<IUser[]>("/MyUser");
    setUsers(data);
  };

  const getTransactions = async () => {
    const { data } = await axios.get<ITransaction[]>("/Transaction");
    setTransactions(data);
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

  const updateLatest = async () => {
    await getUsers();
    await getTransactions();
    await getComments();
    // getReacters();
    await getTopics();
    await getSubjects();

    createActivityList();
  };

  const createActivityList = () => {
    if (comments && topics && /* reactions&& */ subjects) {
      const arr: concatArray[] = comments.concat(topics);
      console.log(arr);

      return arr.map((q, i) => (
        <li key={i} className={s.activityListItem}>
          {q.content && (
            <div className={s.listItemContent}>
              <div className={s.contentChat}>
                <ChatOutlinedIcon />
              </div>
              <div>
                <h5>{q.content}</h5>
                <p>{moment(q.creationDate).format("yyyy-mm-dd, hh:mm:ss")}</p>
              </div>
            </div>
          )}
          {q.topicName && (
            <div className={s.listItemContent}>
              <div className={s.contentLamp}>
                <LightbulbOutlinedIcon />
              </div>
              <div>
                <h5>{q.topicName}</h5>
                <p>{moment(q.creationDate).format("yyyy-mm-dd, hh:mm:ss")}</p>
              </div>
            </div>
          )}
        </li>
      ));
    }
    return <></>;
  };

  const renderMain = (): JSX.Element => {
    switch (actualPage) {
      case 2:
        return (
          <>
            <div className={s.userManagement}>
              <h3>Felhasználók kezelése</h3>
              <div className={s.manageList}>
                {users &&
                  users.map((u, i) => (
                    <Accordion key={i} className={s.manageItem}>
                      <AccordionSummary
                        className={s.itemSummary}
                        expandIcon={<KeyboardArrowDownOutlinedIcon />}
                        aria-controls="panel1a-content"
                        id="panel1a-header"
                      >
                        <div className={s.manageUser}>
                          <PersonOutlineOutlinedIcon />
                        </div>

                        <Typography className={s.itemTitle}>
                          {u.id} - {u.fullName}
                        </Typography>
                      </AccordionSummary>

                      <AccordionDetails className={s.itemDetails}>
                        <Typography className={s.detailItem}>
                          emial: {u.email}
                        </Typography>
                        <Typography className={s.detailItem}>
                          coinok: {u.nikCoin} coin
                        </Typography>
                        <Typography className={s.detailItem}>
                          kezdés éve: {u.startYear}
                        </Typography>
                        <Typography className={s.detailItem}>
                          státusz: {u.isActive ? "Aktív" : "Nem Aktív"}
                        </Typography>
                        <Typography className={s.detailItem}>
                          {u.role && u.role.map((r, i) => <p>{r}</p>)}
                        </Typography>
                      </AccordionDetails>
                    </Accordion>
                  ))}
              </div>
            </div>
          </>
        );
      case 3:
        return (
          <>
            <div className={s.transactionManagement}>
              <h3>Jóváírások</h3>
              <div className={s.manageList}>
                {transactions &&
                  transactions.map((u, i) => (
                    <Accordion key={i} className={s.manageItem}>
                      <AccordionSummary
                        className={s.itemSummary}
                        expandIcon={<KeyboardArrowDownOutlinedIcon />}
                        aria-controls="panel1a-content"
                        id="panel1a-header"
                      >
                        <div className={s.manageCash}>
                          <MonetizationOnOutlinedIcon />
                        </div>

                        <Typography className={s.itemTitle}>
                          {u.reason}
                        </Typography>
                      </AccordionSummary>

                      <AccordionDetails className={s.itemDetails}>
                        <Typography className={s.detailItem}>
                          osszeg: {u.quantity}
                        </Typography>
                        <Typography className={s.detailItem}>
                          feladó: {u.source}
                        </Typography>
                        <Typography className={s.detailItem}>
                          címzett: {u.recipient}
                        </Typography>
                        <Typography className={s.detailItem}>
                          {moment(u.transactionDate).format(
                            "hh:mm:ss, d-mm-yyyy"
                          )}
                        </Typography>
                        <Typography className={s.detailItem}>
                          {u.transactionID}
                        </Typography>
                        <Button className={s.itemButton}>
                          elfogadás
                        </Button>
                      </AccordionDetails>
                    </Accordion>
                  ))}
              </div>
            </div>
          </>
        );
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
                          animation="wave"
                        />
                        <Skeleton animation="wave" />
                        <Skeleton animation="wave" width="60%" />
                      </Box>
                    ))}
              </div>
            </div>

            <div className={s.latestActivity}>
              <div className={s.latestActivityHead}>
                <h3>Legutóbbi aktivitások</h3>
                <Tooltip
                  title="Frissítés"
                  placement="top"
                  TransitionComponent={Zoom}
                  enterDelay={500}
                  disableInteractive
                >
                  <Button
                    className={s.updateButton}
                    onClick={() => updateLatest()}
                  >
                    <UpdateOutlinedIcon />
                  </Button>
                </Tooltip>
              </div>
              <Timer />
              {comments || reactions || topics || subjects ? (
                <ul className={s.activityList}>{createActivityList()}</ul>
              ) : (
                Array.from(new Array(10)).map((item, index) => (
                  <Box key={index} className={s.topicItem}>
                    <Skeleton animation="wave" />
                    <Skeleton animation="wave" width="60%" />
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
      <div className="fixed w-full z-50">
        <Header />
      </div>
      <div className={s.root}>
        <div className={s.sidebar}>
          <ul className={s.sidebarList}>
            <li className={s.sidebarListItem} onClick={() => setActualPage(1)}>
              <Button className={actualPage === 1 ? s.active : s.listIcon}>
                <GridViewOutlinedIcon />
              </Button>
              <p>Áttekintés</p>
            </li>
            <li className={s.sidebarListItem} onClick={() => setActualPage(2)}>
              <Button className={actualPage === 2 ? s.active : s.listIcon}>
                <PermIdentityOutlinedIcon />
              </Button>
              <p>Felhasználók</p>
            </li>
            <li className={s.sidebarListItem} onClick={() => setActualPage(3)}>
              <Button className={actualPage === 3 ? s.active : s.listIcon}>
                <PaidOutlinedIcon />
              </Button>
              <p>Jóváírások</p>
            </li>
            <li className={s.sidebarListItem} onClick={() => setActualPage(4)}>
              <Button className={actualPage === 4 ? s.active : s.listIcon}>
                <LocalFireDepartmentOutlinedIcon />
              </Button>
              <p>Népszerű</p>
            </li>
          </ul>
        </div>

        <div className={s.main}>{renderMain()}</div>
        {actualPage === 1 && (
          <div className={s.manage}>
            <div className={s.manageContent}>
              <div className="flex justify-between">
                <h3>Jóváírások</h3>
              </div>
              {/* <Timer /> */}
              <ul className={s.manageList}>
                {transactions
                  ? transactions.map((t, i) => (
                      <li key={i} className={s.manageItem}>
                        <div className={s.manageTransaction}>
                          <MonetizationOnOutlinedIcon />
                        </div>
                        <div>
                          <h5>{t.reason}</h5>
                        </div>
                      </li>
                    ))
                  : Array.from(new Array(10)).map((item, index) => (
                      <Box key={index}>
                        <Skeleton animation="wave" />
                      </Box>
                    ))}
              </ul>
            </div>

            <div className={s.manageContent}>
              <div className="flex justify-between">
                <h3>Felhasználók</h3>
              </div>
              {/*  <Timer /> */}
              <ul className={s.manageList}>
                {users
                  ? users.map((t, i) => (
                      <li key={i} className={s.manageItem}>
                        <div className={s.manageUser}>
                          <PersonOutlineOutlinedIcon />
                        </div>
                        <div>
                          <h5>{t.fullName}</h5>
                        </div>
                      </li>
                    ))
                  : Array.from(new Array(10)).map((item, index) => (
                      <Box key={index}>
                        <Skeleton animation="wave" />
                      </Box>
                    ))}
              </ul>
            </div>
          </div>
        )}
      </div>
    </>
  );
};

export default Admin;
