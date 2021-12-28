import React from "react"
import { IComment } from "src/models/comment.model"
import "../Home/home.scss"
import { FaTimes } from 'react-icons/fa'

const Comment = (comment: IComment) => {
    
    
    return(
        <div className="comment">
            <h1>Hozzászóló: {comment.userId} *hozzászóló neve*</h1>
            <br/>
            <h1>{comment.content}</h1>
            <h3>Válaszadás dátuma: {comment.creationDate}</h3>
            <FaTimes
            style={{ color: 'red', cursor: 'pointer' }}
            />
        </div>
    )
}

export default Comment;