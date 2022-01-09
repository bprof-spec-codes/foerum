import React, { FC, useEffect } from "react";
import { IRootState } from "src/store/reducers";
import { connect } from "react-redux";

export interface IProfileCardProps extends StateProps {}

const ProfileCard: FC<IProfileCardProps> = (props) => {
  const { fullName, email, startYear, nikCoin } = props.account;
  useEffect(()=>{
    console.log(props)
  },[props]) 

  return (
    <div>
      <div className="relative">
        <div className="h-16 bg-basebg text-white rounded-t-2xl"></div>
        <div className="w-full absolute top-4 items-center text-center">
          <img
            src=""
            alt="profilkep"
            loading="lazy"
            className="h-24 w-24 rounded-full bg-blue-50"
          />
          <p className="text-xl">Név: {fullName}</p>
        </div>

        <div className="mt-16">
          <p className="pt-16">Email: {email}</p>
          <p>Évfolyam: {startYear}</p>
          <p>NIK Coin: {nikCoin}</p>
        </div>
      </div>
    </div>
  );
};

const mapStateToProps = ({ authentication }: IRootState) => ({
  account: authentication.account,
});

type StateProps = ReturnType<typeof mapStateToProps>;

export default connect(mapStateToProps)(ProfileCard);
