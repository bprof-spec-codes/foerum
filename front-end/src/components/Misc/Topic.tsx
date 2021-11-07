import React from "react"
import { ITopic } from "src/models/topic.model"
import "../Home/home.scss"

const Topic = (topic: ITopic) =>{
    return(
        <div className="container">
            <h1>User ID-je: {topic.userId}</h1><br/>
            <h1 className="container__inner">{topic.topicName}</h1>
            <h2>Csatolmányok: {topic.attachmentUrl}</h2>
            <h3>Létrehozás dátuma: {topic.creationDate}</h3>
            <h2>A válaszért {topic.offeredCoins} db NIKCoint ajánlok fel.</h2>
            <br/>
            <p className="container__inner">Kommentek:</p>
            
        </div>
    )
}

export default Topic;