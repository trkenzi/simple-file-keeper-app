
const noteReducer = (notes=[], action) =>{
    switch(action.type){
        case 'GET_NOTES':
            return action.payload;
        case 'ADD_NOTE':
            return [...notes, action.payload];
        case 'DELETE_NOTE':
            return notes.filter(note => note.id !== action.payload)
        case 'UPDATE_NOTE':
            return notes.map(note => note.id === action.payload.id ? action.payload : note);
        default:
            return notes;
    }
}

export default noteReducer;