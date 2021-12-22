import React from "react"
import { IComment } from "src/models/comment.model"
import "../Home/home.scss"

const Comment = (comment: IComment) => {
    
    
    return(
        <div /*className="container"*/>
            <h1 /*className="container__inner"*/>{comment.userId}</h1>
            <br/>
            <h1>{comment.content}</h1>
            <h3>Válaszadás dátuma: {comment.creationDate}</h3>
        </div>
    )
}

export default Comment;