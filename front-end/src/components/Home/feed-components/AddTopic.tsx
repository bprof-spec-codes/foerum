import React, { useState } from 'react'
import { ITopic } from 'src/models/topic.model';

const AddTopic = (topic: ITopic) => {
    const [topicName, setTopicName] = useState('');
    const [nikCoin, setNikCoin] = useState('')
    const [attachment, setAttachment] = useState('');



    return (
        <div >
            <div className='form-control'>
                <input placeholder='Mi a kérdés tárgya?' type='text' onChange={e => setTopicName(e.target.value)}/>
                <br/>
                <input placeholder='Hány NIK coint ajánlasz fel a válaszért?' type='text' onChange={e => setNikCoin(e.target.value)}/>
                <br/>
                <input placeholder='Kívánsz hozzáadni csatolmányt?' type='text' onChange={e => setAttachment(e.target.value)}/>
                <br/>
            </div>
            
            <button style={{backgroundColor:"#182A4E"}} className='btn'>Hozzáadás</button>
        </div>
    )
}

export default AddTopic