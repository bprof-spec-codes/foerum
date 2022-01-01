import React, { useState } from 'react'
import { IYear } from 'src/models/year.model';

const AddYear = (topic: IYear) => {
    const [year, setYear] = useState('');

    return (
        <div >
            <div className='form-control'>
                <input placeholder='Melyik évfolyam?' type='text' onChange={e => setYear(e.target.value)}/>
                <br/>
            </div>
            
            <button style={{backgroundColor:"#182A4E"}} className='btn'>Hozzáadás</button>
        </div>
    )
}

export default AddYear