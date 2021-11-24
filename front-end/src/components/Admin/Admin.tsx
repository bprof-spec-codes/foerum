import axios from "../../axios";
import React, { useEffect, useState } from "react";
import { IUser } from "src/models/user.model";
import Header from "../Home/Header";

const Admin = () => {
  const [users, setUsers] = useState<IUser[] | null>(null);
  useEffect(() => {
    axios
      .get<IUser[]>("/MyUser")
      .then((respone) => {
        console.log(respone.data);
        setUsers(respone.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <div>
      <Header />
      <div className="flex-col my-12 w-full">
        <div className="flex justify-between bg-green-200 rounded mx-24 p-5">
          <div>adatok</div>
          <div>kép</div>
        </div>
        <div className="flex-col mx-24">
          {users &&
            users.map((user, i) => (
              <div
                key={i}
                className="flex bg-blue-200 justify-between p-5 my-2 rounded cursor-pointer"
              >
                <div className="w-1/2">
                  <h3>Név: {user.fullName}</h3>
                  <p>Role: {user.role}</p>
                  <p className="text-xs">{user.email}</p>
                </div>
                <div className="w-1/2">
                  <p>Kezdés éve: {user.startYear}</p>
                  <p>NIK Coin: {user.nikCoin}</p>
                  <p>Aktív: {user.isActive ? "Aktív" : "Inaktív"}</p>
                </div>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Admin;
