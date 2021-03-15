import React from 'react'
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import useStyle from './style';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import {useDispatch} from 'react-redux';
import {deletePhoto} from '../../../actions/Photos/PhotoActions';


const Photo = ({concretePhoto, setCurrentId}) => {

    const dispatch = useDispatch();
    const classes = useStyle();

    return (
          <Card className={classes.card}>
              <CardMedia className={classes.cardMedia} image={concretePhoto.photoUrl} />
              
              <CardContent className={classes.cardContent}>

                  <Typography gutterBottom variant="h5" component="h2">
                      {concretePhoto.title}
                  </Typography>

                  <Typography>
                      {concretePhoto.description}
                  </Typography>

                  <br/>

                  <Typography variant="caption" display="block" gutterBottom>
                      Creation date: {`${new Date(concretePhoto.creationDate).getDate()}.${new Date(concretePhoto.creationDate).getMonth()+1}.${new Date(concretePhoto.creationDate).getFullYear()}`}
                  </Typography> 
                  
              </CardContent>

              <CardActions>

                  <Button size="small" color="primary" onClick={() => dispatch(deletePhoto(concretePhoto.id))}>
                    <DeleteIcon/>
                    Delete
                  </Button>

                  <Button size="small" color="primary" onClick = {() => setCurrentId(concretePhoto.id)}>
                    <EditIcon/>
                    Edit
                  </Button>
              </CardActions>
          </Card>
    )
}

export default Photo;
