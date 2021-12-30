import axios from "../../axios";
import React, { useEffect, useState } from "react";
import s from "./Admin.module.scss";
import { IUser } from "src/models/user.model";
import Header from "../Home/Header";

import PermIdentityOutlinedIcon from "@mui/icons-material/PermIdentityOutlined";
import PaidOutlinedIcon from "@mui/icons-material/PaidOutlined";
import GridViewOutlinedIcon from "@mui/icons-material/GridViewOutlined";
import LocalFireDepartmentOutlinedIcon from "@mui/icons-material/LocalFireDepartmentOutlined";

const Admin = () => {
  const [users, setUsers] = useState<IUser[] | null>(null);
  const [actualPage, setActualPage] = useState<number>(1);

  useEffect(() => {
    getUsers();
  }, []);

  const getUsers = async () => {
    const { data } = await axios.get<IUser[]>("/MyUser");
    console.log(data);
    setUsers(data);
  };

  const getComments = async () => {
    const { data } = await axios.get<IUser[]>("/MyUser");
    console.log(data);
    setUsers(data);
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
              <div className={s.topic}>
                <h2>topic</h2>
              </div>
              <div className={s.topic}>
                <h2>topic</h2>
              </div>
              <div className={s.topic}>
                <h2>topic</h2>
              </div>
            </div>

            <div className={s.latestActivity}>
              <h3>Latest Activity</h3>
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

        <div></div>
      </div>
    </>
  );
};

export default Admin;
