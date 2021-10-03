import React from "react";

const Header = () => {
  return (
    <div className="h-16 bg-basebg">
      <div className="flex justify-between h-full content-center text-center text-white">
        <div className="flex content-center p-5">
          <img src="" alt="Logo" loading="lazy" />
        </div>

        <div className="flex w-10/12 p-4">
            <div className="flex w-full h-8 bg-white rounded-2xl">
            <input type="text" className="flex w-full my-2 mx-4 text-black outline-none" placeholder={`Search`} />
            </div>
        </div>

        <div className="flex content-center p-5">
          <h1>Jobb</h1>
        </div>
      </div>
    </div>
  );
};

export default Header;
