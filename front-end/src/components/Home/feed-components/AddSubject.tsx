import React, { useState } from 'react'
import { ISubject } from 'src/models/subject.model';

const AddSubject = (topic: ISubject) => {

    const [subjectName, setSubjectName] = useState('');

    return (
        <div >
            <div className='form-control'>
                <input placeholder='Mi lesz a téma neve?' type='text' onChange={e => setSubjectName(e.target.value)}/>
                <br/>
            </div>
            
            <button onClick={createTopic} style={{backgroundColor:"#182A4E"}} className='btn'>Hozzáadás</button>
        </div>
    )
}

export default AddSubject