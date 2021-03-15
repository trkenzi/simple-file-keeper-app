import {combineReducers} from 'redux';
import photoReducer from './Photos/PhotoReducer';
import noteReducer from './Notes/NoteReducer';

const reducers = combineReducers({
    photoReducer,
    noteReducer
});

export default reducers; 