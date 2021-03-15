import React from 'react'
import {useSelector} from 'react-redux';
import Photo from '../ConcretePhoto/Photo';
import {CircularProgress, Container, Grid} from '@material-ui/core';
import useStyle from './style';

const PhotosContainer = ({setCurrentId}) => {

    const classes = useStyle();
    const photos = useSelector((state) => state.photoReducer);

    return (
        !photos.length ? <div  style={{display: 'flex', justifyContent: 'center'}}><CircularProgress  className={classes.circularProgress}/> </div> : (
        <Container className={classes.cardGrid} maxWidth="md">
            <Grid className={classes.mainContainer} container alignItems="stretch" spacing={3}>
            {
                photos.map((photo) => (
               
                    <Grid key={photo.id} item>
                        <Photo concretePhoto = {photo} setCurrentId = {setCurrentId}/>
                    </Grid>
                    ))
            }
            </Grid>
        </Container>
        )
    )
}

export default PhotosContainer;
