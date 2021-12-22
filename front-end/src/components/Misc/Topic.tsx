import axios from "axios";
import React, { useEffect, useState } from "react"
import { IComment } from "src/models/comment.model";
import Comment from "../Misc/Comment";
import { ITopic } from "src/models/topic.model"
import AddComment from "../Home/feed-components/AddComment";
import Button from "../Home/feed-components/Button";
import "../Home/home.scss"

const Topic = (topic: ITopic, onAdd: any) =>{
    const [showAdd, setShowAdd] = useState(false)

    const [comments, setComments] = useState<IComment[]>([]);
    const [showAddComment, setShowAddComment] = useState(false)
  
    useEffect(() => {
      axios
        .get<ITopic[]>("http://localhost:8585/Comment")
        .then((res) => {
          setComments(res.data);
          console.log(res.data);
        })
        .catch((err) => {
          console.log(err);
        });
    }, []);

    return(
        <div className="container">
            <h1 className="container__inner">{topic.topicName}</h1>
            <br/>
            <h1>User: {topic.userID}</h1>
            <h2>Csatolmányok: {topic.attachmentUrl}</h2>
            <h3>Létrehozás dátuma: {topic.creationDate}</h3>
            <h2>A válaszért {topic.offeredCoins} db NIKCoint ajánlok fel.</h2>
            <h2>Hozzászólások:</h2>
            <br/>

            {comments &&
            comments.map((comment,i) => (
              <div key={i}>
                <Comment 
                  {...comment}
                />

              </div>
            ))}
            
            <header>
                <Button 
                onClicked={()=>setShowAdd(!showAdd)} 
                color={showAdd? '#FAB001' : '#182A4E'} 
                text={showAdd ? 'Mégse' : 'Új hozzászólás írása'}
                />
            </header>

            {showAdd && <AddComment {...topic}/>}
        </div>
    )
}

export default Topic;