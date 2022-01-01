import React, { FC } from "react"
import { IComment } from "src/models/comment.model"
import "../Home/home.scss"
import { FaTimes } from 'react-icons/fa'
import { IUser } from "src/models/user.model"

interface ICommentProps{
    comment: IComment
    allUsers: IUser[]
}



const Comment:FC<ICommentProps> = ({comment, allUsers}) => {
    
    //const user = allUsers.find((u) => u.id === comment.userID);
    const getCommenter = () => {
        const user = allUsers.find((u) => u.id === comment.userID);
        console.log(user)
        return user ? user.fullName:"";
      };

    return(
        <div className="comment">
            <h1>{getCommenter()}:</h1>
            <br/>
            <h1>{comment.content}</h1>
            <h1>{comment.attachmentUrl}</h1>
            <br/>
            <h3>Válaszadás dátuma: {comment.creationDate}</h3>
            <FaTimes
            style={{ color: 'red', cursor: 'pointer' }}
            />
        </div>
    )
}

export default Comment;