import React, { useState } from 'react'
import { ITopic } from 'src/models/topic.model'

const AddComment = (topic: ITopic) => {
    const [commentBody, setCommentBody] = useState('');

    return (
        <div >
            <div className='form-control'>
                <input placeholder='Ide írhatod hozzászólásod szövegét' type='text' onChange={e => setCommentBody(e.target.value)}/>
                <br/>
            </div>
            
            <button style={{backgroundColor:"#182A4E"}} className='btn'>Küldés</button>
        </div>
    )
}

export default AddComment