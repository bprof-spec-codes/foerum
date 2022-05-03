import React, { FC, useEffect, useState } from "react";
import { IRootState } from "src/store/reducers";
import { connect } from "react-redux";
import { Avatar } from "@mui/material";

export interface IProfileCardProps extends StateProps {}

const ProfileCard: FC<IProfileCardProps> = (props) => {
  const [userName, setUserName] = useState<string | null>(null);
  const [userEmail, setUserEmail] = useState<string | null>(null);
  useEffect(() => {
    const userName = sessionStorage.getItem("username");
    const userEmail = sessionStorage.getItem("useremail");

    setUserName(userName);
    setUserEmail(userEmail);
  }, []);

  const normalizeUserName = (name: string) => {
    return name.toLowerCase().replace(/\s/g, "");
  };

  return (
    <div className="relative h-1/3 shadow-md rounded-lg">
      <div className="h-16 bg-basebg text-white rounded-t-2xl"></div>

      {userName && userEmail && (
        <div>
          <div className="w-full absolute top-4 items-center text-center">
            <div
              className="flex justify-center items-center mt-1 ml-auto mr-auto bg-white rounded-full"
              style={{ height: "80px", width: "80px" }}
            >
              <Avatar
                sx={{
                  height: "70px",
                  width: "70px",
                }}
              />
            </div>
            <span className="text-sm text-gray-400">
              @{normalizeUserName(userName)}
            </span>
            <p className="text-xl">{userName}</p>
          </div>
          <div className="flex flex-col justify-between mt-20 p-4 align-center text-center">
            <p>{userEmail}</p>
          </div>
          <div className="flex flex-col pb-4 align-center text-center">
            NikCoin egyenleg:
          </div>
        </div>
      )}
    </div>
  );
};

const mapStateToProps = ({ authentication }: IRootState) => ({
  account: authentication.account,
});

type StateProps = ReturnType<typeof mapStateToProps>;

export default connect(mapStateToProps)(ProfileCard);
