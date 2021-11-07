import React from "react"
import { ITopic } from "src/models/topic.model"
import AddComment from "../Home/feed-components/AddComment";
import Button from "../Home/feed-components/Button";
import "../Home/home.scss"

const Topic = (topic: ITopic, onAdd: any, showAdd: boolean) =>{
    //showAdd=true;

    return(
        <div className="container">
            <h1 className="container__inner">{topic.topicName}</h1>
            <br/>
            <h1>User: {topic.userId}</h1>
            <h2>Csatolmányok: {topic.attachmentUrl}</h2>
            <h3>Létrehozás dátuma: {topic.creationDate}</h3>
            <h2>A válaszért {topic.offeredCoins} db NIKCoint ajánlok fel.</h2>
            <br/>
            <p className="container__inner__comment-container">Kommentek:</p>
            <br/>
            
            <header>
                <Button 
                onClicked={onAdd} 
                color={showAdd? '#FAB001' : '#182A4E'} 
                text={showAdd ? 'Mégse' : 'Új hozzászólás írása'}
                />
            </header>

            {showAdd && <AddComment {...topic}/>}
        </div>
    )
}

export default Topic;