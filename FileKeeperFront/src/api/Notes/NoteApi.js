import axios from 'axios';

const url = 'https://localhost:44339/api/Notes';

export const getNotes = () => axios.get(url);
export const addNote = (noteData) => axios.post(url, noteData);
export const deleteNote = (noteId) => axios.delete(`${url}/${noteId}`);
export const updateNote = (noteId, noteData) => axios.put(`${url}/${noteId}`, noteData);