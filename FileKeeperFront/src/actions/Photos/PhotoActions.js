import * as api from '../../api/Photos/PhotosApi';


export const getPhotos = () => async (dispatch) => {
    try{
        const {data} = await api.getPhotos();
        
        dispatch({
            type: 'GET_PHOTOS',
            payload: data
        });
    }
    catch(error){
        console.log(error.message);
    }
}

export const addPhoto = (photoData) => async (dispatch) =>{
    try{
        const {data} = await api.addPhoto(photoData);

        dispatch({
            type: 'ADD_PHOTO',
            payload: data
        });
    }
    catch(error){
        console.log(error.message);
    }
}

export const updatePhoto = (id, updateData) => async (dispatch) =>{
    try{
      
        const {data} = await api.updatePhoto(id, updateData);

        dispatch({
            type: 'UPDATE_PHOTO',
            payload: data
        });

    }
    catch(error){
        console.log(error.message);
    }
}

export const deletePhoto = (id) => async (dispatch) => {
    try{
       
        await api.deletePhoto(id);

        dispatch({
            type: 'DELETE_PHOTO',
            payload: id
        });
    }
    catch(error){
        console.log(error.message);
    }
}