import React, { useState } from "react"
import { ITopic } from "src/models/topic.model"
import AddComment from "../Home/feed-components/AddComment";
import Button from "../Home/feed-components/Button";
import "../Home/home.scss"

const Topic = (topic: ITopic, onAdd: any) =>{
    const [showAdd, setShowAdd] = useState(false)

    return(
        <div className="container">
            <h1 className="container__inner">{topic.topicName}</h1>
            <br/>
            <h1>User: {topic.userID}</h1>
            <h2>Csatolmányok: {topic.attachmentUrl}</h2>
            <h3>Létrehozás dátuma: {topic.creationDate}</h3>
            <h2>A válaszért {topic.offeredCoins} db NIKCoint ajánlok fel.</h2>
            <br/>
            <p className="container__inner__comment-container">Hozzászólások:</p>
            <br/>
            
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