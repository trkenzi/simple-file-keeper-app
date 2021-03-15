import React from 'react'
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import useStyle from './styles';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import {useDispatch} from 'react-redux';
import {deleteNote} from '../../../actions/Notes/NoteActions';

const Note = ({concreteNote, setCurrentId}) => {

    const dispatch = useDispatch();
    const classes = useStyle();

    return (
          <Card className={classes.card}>

              <CardContent className={classes.cardContent}>

                  <Typography gutterBottom variant="h5" component="h2">
                      {concreteNote.title}
                  </Typography>
                  
                  <Typography>
                      {concreteNote.description}
                  </Typography>

                  <br/>

                  <Typography variant="caption" display="block" gutterBottom>
                      Important date: {`${new Date(concreteNote.importantDate).getDate()}.${new Date(concreteNote.importantDate).getMonth()+1}.${new Date(concreteNote.importantDate).getFullYear()}`}
                  </Typography> 
                  
              </CardContent>

              <CardActions>

                  <Button size="small" color="primary" onClick={() => dispatch(deleteNote(concreteNote.id))}>
                    <DeleteIcon/>
                    Delete
                  </Button>

                  <Button size="small" color="primary" onClick = {() => setCurrentId(concreteNote.id)}>
                    <EditIcon/>
                    Edit
                  </Button>
              </CardActions>
          </Card>
    )
}

export default Note;
