import React from "react";

const Header = () => {
  return (
    <div className="h-16 bg-basebg">
      <div className="flex justify-between h-full content-center text-center text-white">
        <div className="flex content-center p-5">
          <img src="" alt="Logo" loading="lazy" />
        </div>

        <div className="flex content-center p-5">
          <h1>Jobb</h1>
        </div>
      </div>
    </div>
  );
};

export default Header;
