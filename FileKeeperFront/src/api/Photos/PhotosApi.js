import axios from 'axios';

const url = 'https://localhost:44339/api/Photos';

export const getPhotos = () => axios.get(url);
export const addPhoto = (newPhoto) => axios.post(url, newPhoto);
export const deletePhoto = (id) => axios.delete(`${url}/${id}`);
export const updatePhoto = (photoId, photoData) => axios.put(`${url}/${photoId}`, photoData);