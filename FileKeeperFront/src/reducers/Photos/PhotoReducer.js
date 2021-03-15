
const photoReducer =  (photos = [], action) => {
    switch(action.type){
        case 'GET_PHOTOS':
            return action.payload;
            
        case 'ADD_PHOTO':
            return [...photos, action.payload];
            
        case 'DELETE_PHOTO':
            return photos.filter(photo => photo.id !== action.payload);
          
        case 'UPDATE_PHOTO':
            return photos.map(photo => photo.id === action.payload.id ? action.payload : photo);
            
        default:
            return photos;
    }
}

export default photoReducer;