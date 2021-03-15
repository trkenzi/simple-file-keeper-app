import React, {useEffect, useState} from 'react'
import AddPhotoForm from '../Forms/Photos/AddPhotoForm';
import PhotosContainer from './Container/PhotosContainer';
import {useDispatch} from 'react-redux';
import {getPhotos} from '../../actions/Photos/PhotoActions';

const PhotosMainComponent = () => {
    const dispatch = useDispatch();
    const [currentId, setCurrentId] = useState(null);

    useEffect( () => {
        dispatch(getPhotos())
    }, [dispatch]);

    return (
        <div>
            <AddPhotoForm currentId = {currentId} setCurrentId={setCurrentId}/>
            <PhotosContainer setCurrentId = {setCurrentId}/>
        </div>
    )
}

export default PhotosMainComponent;
