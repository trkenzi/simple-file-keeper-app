import React, {useEffect, useState}  from 'react'
import AddNoteForm from '../Forms/Notes/AddNoteForm';
import NotesContainer from '../Notes/Container/NotesContainer';
import {useDispatch} from 'react-redux';
import {getNotes} from '../../actions/Notes/NoteActions';

const NotesMainComponent = () => {
    const dispatch = useDispatch();
    const [currentId, setCurrentId] = useState(null);

    useEffect( () => {
        dispatch(getNotes())
    }, [dispatch]);
    
    return (
        <div>
            <AddNoteForm currentId = {currentId} setCurrentId={setCurrentId}/>
            <NotesContainer setCurrentId = {setCurrentId}/>
        </div>
    )
}

export default NotesMainComponent;
