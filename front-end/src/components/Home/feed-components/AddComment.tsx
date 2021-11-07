import React from 'react'
import { ITopic } from 'src/models/topic.model'

const AddComment = (topic: ITopic) => {
    return (
        <div >
            <div className="container__inner__comment-container">
                <p>Írd ide a hozzászólásod szövegét</p>
            </div>
            <button style={{backgroundColor:"#182A4E"}} className='btn'>Küldés</button>
        </div>
    )
}

export default AddComment