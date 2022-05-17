import axios from "../../axios";
import React, { FC, useEffect, useState } from "react";
import s from "./Admin.module.scss";
import { IUser } from "src/models/user.model";
import PermIdentityOutlinedIcon from "@mui/icons-material/PermIdentityOutlined";
import PaidOutlinedIcon from "@mui/icons-material/PaidOutlined";
import GridViewOutlinedIcon from "@mui/icons-material/GridViewOutlined";
import LocalFireDepartmentOutlinedIcon from "@mui/icons-material/LocalFireDepartmentOutlined";
import MonetizationOnOutlinedIcon from "@mui/icons-material/MonetizationOnOutlined";
import ChatOutlinedIcon from "@mui/icons-material/ChatOutlined";
import LightbulbOutlinedIcon from "@mui/icons-material/LightbulbOutlined";
import MenuBookOutlinedIcon from "@mui/icons-material/MenuBookOutlined";

import UpdateOutlinedIcon from "@mui/icons-material/UpdateOutlined";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import KeyboardArrowDownOutlinedIcon from "@mui/icons-material/KeyboardArrowDownOutlined";
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
  IconButton,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  Skeleton,
  Switch,
  TextField,
  Tooltip,
  Typography,
} from "@mui/material";
import moment, { min } from "moment";
import { Timer } from "./admin-components";
import { ITransaction } from "src/models/transaction.model";
import { Header } from "..";
import { IAddress } from "src/models/address.model";
import Web3 from "web3";

type concatArray = {
  content: string;
  creationDate: Date | string | number;
  identity: "TOPIC" | "COMMENT" | "SUBJECT";
};

const Admin: FC = () => {
  const [users, setUsers] = useState<IUser[] | null>(null);
  const [transactions, setTransactions] = useState<ITransaction[] | null>(null);

  const [comments, setComments] = useState<IComment[] | null>(null);
  const [reactions, setReactions] = useState<ICommentReacters[] | null>(null);
  const [topics, setTopics] = useState<ITopic[] | null>(null);
  const [subjects, setSubjects] = useState<ISubject[] | null>(null);
  const [actualPage, setActualPage] = useState<number>(1);
  const [addresses, setAddresses] = useState<IAddress[] | null>(null);
  const [selectedAddress, setSelectedAddresses] = useState<IAddress>({
    address: "0x0000000000000000000000000000000000000000",
  });
  const [amountOfNikCoin,setAmountOfNikCoin] = useState<number>(0);

  useEffect(() => {
    const getData = async () => {
      await getUsers();
      // await getTransactions();
      await getComments();
      // getReacters();
      await getTopics();
      await getSubjects();
      await getAddresses();
    };
    getData();
  }, []);

  const getUsers = async () => {
    const token = sessionStorage.getItem("foerumtoken");
    const { data } = await axios.get<IUser[]>("/MyUser", {
      headers: { Authorization: token },
    });
    setUsers(data);
  };

  const getTransactions = async () => {
    const token = sessionStorage.getItem("foerumtoken");
    const { data } = await axios.get<ITransaction[]>("/Transaction", {
      headers: { Authorization: token },
    });
    setTransactions(data);
  };

  const getComments = async () => {
    const token = sessionStorage.getItem("foerumtoken");
    const { data } = await axios.get<IComment[]>("/Comment", {
      headers: { Authorization: token },
    });
    setComments(data);
  };

  /*   const getReacters = async () => {
    const { data } = await axios.get<ICommentReacters[]>("/CommentReacters");
    console.log(data);
    setReactions(data);
  }; */

  const getTopics = async () => {
    const token = sessionStorage.getItem("foerumtoken");
    axios
      .get("/Topic", { headers: { Authorization: token } })
      .then((res) => {
        setTopics(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const getSubjects = async () => {
    const token = sessionStorage.getItem("foerumtoken");
    axios
      .get("/Subject", { headers: { Authorization: token } })
      .then((res) => {
        setSubjects(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const getAddresses = async () => {
    const token = sessionStorage.getItem("foerumtoken");
    axios
      .get("/MyUser/GetAllWallets", { headers: { Authorization: token } })
      .then((res) => {
        setAddresses(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const findSubject = (tid: any) => {
    const subject = subjects?.find((s) => s.subjectID === tid);
    return subject?.subjectName;
  };

  const editUser = (user: any) => {
    const token = sessionStorage.getItem("foerumtoken");
    axios
      .put(`/MyUser/${user.id}`, user, { headers: { Authorization: token } })
      .then((res) => {})
      .catch((err) => {
        console.log(err);
      });
  };

  const updateLatest = async () => {
    await getUsers();
    //await getTransactions();
    await getComments();
    // getReacters();
    await getTopics();
    await getSubjects();

    createActivityList();
  };

  const handleAddressChange = (e: any): void => {
    const newValue: IAddress | undefined = addresses?.find(
      (x) => x.address === e.target.value
    );
    if (newValue) setSelectedAddresses(newValue);
  };

  const addNikCoin = (e: any) => {
    e.preventDefault()

    // console.log(selectedAddress,amountOfNikCoin);
    const web3 = new Web3('https://data-seed-prebsc-1-s1.binance.org:8545');
    const abi = require('human-standard-token-abi');
    const contractAddress = '0xA0e11Ca7c99655C6ca16336F1AF69b6A7683FDfC';
    const contract = new web3.eth.Contract(abi, contractAddress);
    console.log(contract);
    contract.methods.transferFrom("0x555bC0c8dD4B1822636e44D85417afDeA6628C90", selectedAddress, amountOfNikCoin).call().then((res : any) => {
     console.log(res);
    })
  }

  const createActivityList = () => {
    if (comments && topics && subjects) {
      if (comments.length > 0 && topics.length > 0 && subjects.length > 0) {
        const arr = new Array<concatArray>();
        comments.map((c) => {
          arr.push({
            content: c.content ? c.content : "",
            creationDate: c.creationDate ? c.creationDate : "",
            identity: "COMMENT",
          });
        });

        topics.map((t) => {
          arr.push({
            content: t.topicName ? t.topicName : "",
            creationDate: t.creationDate ? t.creationDate : "",
            identity: "TOPIC",
          });
        });

        /*  subjects.map((s) => {
        arr.push({
          content: s.subjectName ? s.subjectName : "",
          creationDate: "",
          identity: "SUBJECT",
        });
      }); */

        const sortedArr = arr
          .sort((cd1, cd2) => +cd1.creationDate - +cd2.creationDate)
          .reverse();

        return sortedArr.map((q, i) => (
          <li key={i} className={s.activityListItem}>
            <div className={s.listItemContent}>
              {q.identity === "COMMENT" && (
                <div className={s.contentChat}>
                  <ChatOutlinedIcon />
                </div>
              )}
              {q.identity === "TOPIC" && (
                <div className={s.contentLamp}>
                  <LightbulbOutlinedIcon />
                </div>
              )}
              {q.identity === "SUBJECT" && (
                <div className={s.contentBook}>
                  <MenuBookOutlinedIcon />
                </div>
              )}
              <div>
                <h5>{q.content}</h5>
                {q.identity !== "SUBJECT" && (
                  <p>{moment(q.creationDate).format("dd-mm-yyyy, hh:mm:ss")}</p>
                )}
              </div>
            </div>
          </li>
        ));
      }
    }
    return (
      <li className={s.noActivity}>
        <span>
          <LightbulbOutlinedIcon />
        </span>
        <p>Nincsenek aktivitások</p>
      </li>
    );
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
                          {u.fullName}
                        </Typography>
                      </AccordionSummary>

                      <AccordionDetails className={s.itemDetails}>
                        <Typography className={s.detailItem}>
                          Nem aktiv
                          <Switch value={u.isActive} />
                          aktiv
                        </Typography>
                        <Typography
                          className={s.detailItem}
                          sx={{ marginBottom: "0.5rem" }}
                        >
                          <TextField
                            type="text"
                            variant="outlined"
                            value={u.fullName}
                            sx={{
                              color: "red",
                              border: "none",
                            }}
                          />
                        </Typography>
                        <Typography
                          className={s.detailItem}
                          sx={{ marginBottom: "0.5rem" }}
                        >
                          <TextField
                            type="number"
                            variant="outlined"
                            value={u.nikCoin}
                          />
                        </Typography>
                        <Typography
                          className={s.detailItem}
                          sx={{ marginBottom: "0.5rem" }}
                        >
                          <TextField
                            type="number"
                            variant="outlined"
                            value={u.startYear}
                          />
                        </Typography>
                        <Typography className={s.detailItem}>
                          <Button
                            onClick={() => editUser(u)}
                            variant="contained"
                            style={{
                              backgroundColor: "#182A4E",
                              color: "white",
                              outline: "none",
                              border: "none",
                            }}
                            disabled={true}
                          >
                            Szerkesztés
                          </Button>
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
                        <Button
                          variant="contained"
                          style={{
                            backgroundColor: "#182A4E",
                            color: "white",
                            outline: "none",
                            border: "none",
                          }}
                          disabled={true}
                        >
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
                {topics ? (
                  topics.length > 0 ? (
                    topics.map((t, i) => (
                      <div key={i} className={s.topicItem}>
                        <h4>{t.topicName}</h4>

                        {subjects && <p>{findSubject(t.subjectID)}</p>}
                      </div>
                    ))
                  ) : (
                    <div className="flex flex-col w-full justify-center items-center mt-16 p-4 text-gray-400">
                      <span className="flex justify-center items-center h-16 w-16 mb-4 border-2 border-gray-400 border-dashed rounded-full">
                        <ChatOutlinedIcon />
                      </span>
                      <p>Nem találtunk egyetlen témát sem.</p>
                    </div>
                  )
                ) : (
                  Array.from(new Array(3)).map((item, index) => (
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
                  ))
                )}
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
              {comments || reactions || topics ? (
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
      <Header />
      <div className={s.root}>
        <div className={s.sidebar}>
          <ul className={s.sidebarList}>
            <li className={s.sidebarListItem} onClick={() => setActualPage(1)}>
              <IconButton className={actualPage === 1 ? s.active : s.listIcon}>
                <GridViewOutlinedIcon />
              </IconButton>
              <p>Áttekintés</p>
            </li>
            <li className={s.sidebarListItem}>
              <IconButton
                className={actualPage === 2 ? s.active : s.listIcon}
                onClick={() => setActualPage(2)}
                disabled={users && users.length > 0 ? false : true}
              >
                <PermIdentityOutlinedIcon />
              </IconButton>
              <p>Felhasználók</p>
            </li>
            <li className={s.sidebarListItem}>
              <IconButton
                className={actualPage === 3 ? s.active : s.listIcon}
                onClick={() => setActualPage(3)}
                disabled={
                  transactions && transactions.length > 0 ? false : true
                }
              >
                <PaidOutlinedIcon />
              </IconButton>
              <p>Jóváírások</p>
            </li>
            <li className={s.sidebarListItem} onClick={() => setActualPage(4)}>
              <IconButton className={actualPage === 4 ? s.active : s.listIcon}>
                <LocalFireDepartmentOutlinedIcon />
              </IconButton>
              <p>Népszerű</p>
            </li>
          </ul>
        </div>

        <div className={s.main}>{renderMain()}</div>
        {actualPage === 1 && (
          <div className={s.manage}>
            <div className={s.manageContent}>
              <div className="flex flex-col justify-between">
                <h3>Jóváírások</h3>
                <div>
                  <form className="flex flex-col space-y-4" onSubmit={addNikCoin}>
                    <Select
                      labelId="address-label"
                      value={selectedAddress.address}
                      label="address"
                      onChange={handleAddressChange}
                    >
                      {addresses &&
                        addresses.map((address, i) => (
                          <MenuItem key={i} value={address.address}>
                            {address.userName}
                          </MenuItem>
                        ))}
                    </Select>
                    <TextField
                      label="nikcoin"
                      onChange={(e) => setAmountOfNikCoin(+e.target.value)}
                      value={amountOfNikCoin}
                      type = "number"
                      inputProps={{min: 0}}
                    />
                    <Button disabled={amountOfNikCoin === 0} variant="contained" type="submit">Coin hozzáadása</Button>
                  </form>
                </div>
              </div>
              <ul className={s.manageList}>
                {transactions ? (
                  transactions.length > 0 ? (
                    transactions.map((t, i) => (
                      <li key={i} className={s.manageItem}>
                        <div className={s.manageTransaction}>
                          <MonetizationOnOutlinedIcon />
                        </div>
                        <div>
                          <h5>{t.reason}</h5>
                        </div>
                      </li>
                    ))
                  ) : (
                    <div className="flex flex-col w-full justify-center items-center mt-16 p-4 text-gray-400">
                      <span className="flex justify-center items-center h-16 w-16 mb-4 border-2 border-gray-400 border-dashed rounded-full">
                        <MonetizationOnOutlinedIcon />
                      </span>
                      <p>Nem találtunk egyetlen tranzakciot sem.</p>
                    </div>
                  )
                ) : (
                  Array.from(new Array(10)).map((item, index) => (
                    <Box key={index}>
                      <Skeleton animation="wave" />
                    </Box>
                  ))
                )}
              </ul>
            </div>

            <div className={s.manageContent}>
              <div className="flex justify-between">
                <h3>Felhasználók</h3>
              </div>
              <ul className={s.manageList}>
                {users ? (
                  users.length > 0 ? (
                    users.map((t, i) => (
                      <li key={i} className={s.manageItem}>
                        <div className={s.manageUser}>
                          <PersonOutlineOutlinedIcon />
                        </div>
                        <div>
                          <h5>{t.fullName}</h5>
                        </div>
                      </li>
                    ))
                  ) : (
                    <div className="flex flex-col w-full justify-center items-center mt-16 p-4 text-gray-400">
                      <span className="flex justify-center items-center h-16 w-16 mb-4 border-2 border-gray-400 border-dashed rounded-full">
                        <PersonOutlineOutlinedIcon />
                      </span>
                      <p>Nem találtunk egyetlen felhasználót sem.</p>
                    </div>
                  )
                ) : (
                  Array.from(new Array(10)).map((item, index) => (
                    <Box key={index}>
                      <Skeleton animation="wave" />
                    </Box>
                  ))
                )}
              </ul>
            </div>
          </div>
        )}
      </div>
    </>
  );
};

export default Admin;
