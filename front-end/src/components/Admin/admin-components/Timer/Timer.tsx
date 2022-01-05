import { FC, useEffect, useState } from "react";

const Timer: FC = () => {
  const [timer, setTimer] = useState<number | null>(null);
  const [loadedTime, setLoadedTime] = useState<number | null>(null);

  useEffect(() => {
    setLoadedTime(new Date(Date.now()).getTime());
  }, []);

  const timeCounter = () => {
    const second = 1000,
      minute = second * 60,
      hour = minute * 60,
      day = hour * 24;

    const timeout = setTimeout(() => {
      const actualDate = new Date().getTime();
      if (loadedTime) {
        const newTime = actualDate - loadedTime;
        setTimer(Math.floor((newTime % hour) / minute));
        console.log(timer)
      }
      clearInterval(timeout);
    }, 1000);
  };

  useEffect(() => {
    timeCounter();
  });

  return (
    <p className="text-gray-400 text-xs">
      Utoljára frissitve:&nbsp;
      {timer && timer > 0 ? timer : "kevesebb mint 1"}&nbsp;percel ezelőtt
    </p>
  );
};

export default Timer;
