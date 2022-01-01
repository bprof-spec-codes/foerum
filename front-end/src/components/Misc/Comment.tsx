import React, { FC } from "react"
import { IComment } from "src/models/comment.model"
import "../Home/home.scss"
import { FaTimes} from 'react-icons/fa'
import { BiChevronsUp, BiChevronsDown} from 'react-icons/bi'
import { RiCoinFill} from 'react-icons/ri'
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
            <div className="row">
                <div className="column left">
                    <h1>{getCommenter()}:</h1>
                    <br/>
                    <h1>{comment.content}</h1>
                    <h1>{comment.attachmentUrl}</h1>
                    <br/>
                    <h3>Válaszadás dátuma: {comment.creationDate}</h3>
                </div>
                <div className="column right">            
                    <FaTimes style={{ color: 'red', cursor: 'pointer' }}/>
                    <br />
                    <BiChevronsUp style={{ color: 'green', cursor: 'pointer' }}/>
                    <BiChevronsDown style={{ color: 'orange', cursor: 'pointer' }}/>
                    <br />
                    <RiCoinFill style={{ color: 'blue', cursor: 'pointer' }}/>

                </div>
            </div>



        </div>
    )
}

export default Comment;