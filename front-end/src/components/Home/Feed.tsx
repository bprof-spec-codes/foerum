import React, { useState } from "react";
import { TopicCard } from "./feed-components";

const Feed = () => {
  const [questions, setQuestions] = useState();
  return (
    <div>
      <div>
        <div>
          <TopicCard />
        </div>

        <div></div>
      </div>
    </div>
  );
};

export default Feed;
