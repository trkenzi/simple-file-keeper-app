import React from 'react'
import {useSelector} from 'react-redux';
import Note from '../ConcreteNote/Note';
import {CircularProgress, Container, Grid} from '@material-ui/core';
import useStyle from './style';

const NotesContainer = ({setCurrentId}) => {

    const classes = useStyle();
    const notes = useSelector((state) => state.noteReducer);

    return (
        !notes.length ? <div  style={{display: 'flex', justifyContent: 'center'}}><CircularProgress  className={classes.circularProgress}/> </div> : (
        <Container className={classes.cardGrid} maxWidth="md">
            <Grid className={classes.mainContainer} container alignItems="stretch" spacing={3}>
            {
                notes.map((note) => (
               
                    <Grid key={note.id} item>
                        <Note concreteNote = {note} setCurrentId = {setCurrentId}/>
                    </Grid>
                    ))
            }
            </Grid>
        </Container>
        )
    )
}

export default NotesContainer;
