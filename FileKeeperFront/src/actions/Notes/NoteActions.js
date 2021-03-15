import * as api from '../../api/Notes/NoteApi';

export const getNotes = () => async(dispatch) => {
    try{
        const {data} = await api.getNotes();

        dispatch({
            type: 'GET_NOTES',
            payload: data
        });
    }
    catch(error){
        console.log(error.message);
    }
}

export const addNote = (noteData) => async(dispatch) =>{
    
    try{
        const {data} = await api.addNote(noteData);

        dispatch({
            type: 'ADD_NOTE',
            payload: data
        })

    }
    catch(error){
        console.log(error.message);
    }
}

export const deleteNote = (noteId) => async(dispatch) => {

    try{
        await api.deleteNote(noteId);

        dispatch({
            type: 'DELETE_NOTE',
            payload: noteId
        });
    }
    catch(error){
        console.log(error.message);
    }
}

export const updateNote = (noteId, noteData) => async(dispatch) =>{

    try{
        const {data} = await api.updateNote(noteId, noteData);

        dispatch({
            type: 'UPDATE_NOTE',
            payload: data
        });
    }
    catch(error){
        console.log(error.message);
    }
}