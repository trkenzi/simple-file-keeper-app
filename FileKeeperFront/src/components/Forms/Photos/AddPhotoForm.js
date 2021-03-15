import React, {useState, useEffect} from 'react' 
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Container from '@material-ui/core/Container';
import CameraIcon from '@material-ui/icons/PhotoCamera';
import useStyles from './styles';
import Typography from '@material-ui/core/Typography';
import DateFnsUtils from '@date-io/date-fns';
import FileBase from 'react-file-base64';
import { MuiPickersUtilsProvider,KeyboardDatePicker } from '@material-ui/pickers';
import { useDispatch, useSelector } from 'react-redux';
import { addPhoto, updatePhoto } from '../../../actions/Photos/PhotoActions';

const AddPhotoForm = ({currentId, setCurrentId}) => {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const dispatch = useDispatch();
    
    const handleDateChange = (creationDate) => {
      setSelectedDate(creationDate);
    };
    
    const concretePhoto = useSelector((state) => currentId ? state.photoReducer.find((photo) => photo.id === currentId) : null);

    const [photoData, setPhotoData] = useState({
        title: '',
        description: '',
        photoUrl: '',
        creationDate: ''
    });
    
    
    useEffect(() => {
      if(concretePhoto){
        setPhotoData(concretePhoto);
        setSelectedDate(concretePhoto.creationDate);
      }
    }, [concretePhoto]);

   const handleSubmit = (event) => {
        event.preventDefault();
        photoData.creationDate = selectedDate;
       
        if(currentId){
          dispatch(updatePhoto(currentId, photoData))
          setCurrentId(null)
        }
        else
          dispatch(addPhoto(photoData));
        
          clear();
   };

   const clear = () =>{
      setPhotoData({
        title: '',
        description: '',
        photoUrl: '',
        creationDate: new Date()
      })
   }

    const classes = useStyles();
    return (
        <Container component="main" maxWidth="xs">
      
        <div className={classes.paper}>
          <Avatar className={classes.avatar}>
             <CameraIcon  /> 
          </Avatar>
          <Typography component="h1" variant="h5">
            {!currentId ?  "Add" : "Edit"} a photo
          </Typography>
          <form className={classes.form} autoComplete="off" noValidate onSubmit={handleSubmit}>
            <TextField
              variant="outlined"
              margin="normal"
              fullWidth
              label="Photo title *"
              name="title"
              value={photoData.title}
              onChange={(event) => setPhotoData({...photoData, title: event.target.value})}
            />
            <TextField
              variant="outlined"
              margin="normal"
              fullWidth
              name="description"
              value={photoData.description}
              label="Photo description *"
              onChange={(event) => setPhotoData({...photoData, description: event.target.value})}
              
            />
        <MuiPickersUtilsProvider utils={DateFnsUtils} >
            <KeyboardDatePicker
           disableToolbar
           fullWidth
           name="creationDate"
           variant="inline"
           format="dd/MM/yyyy"
           margin="normal"
           id="date-picker-inline"
           label="Creation date *"
           value={selectedDate}
           onChange={handleDateChange}
           
           KeyboardButtonProps={{
             'aria-label': 'change date',
           }}
            
            />
        </MuiPickersUtilsProvider>
        <FileBase type="file"  multiple={false} onDone = {({base64}) => setPhotoData({...photoData, photoUrl: base64})} />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              disabled={!photoData.title || !photoData.description || !photoData.photoUrl || !selectedDate}
              className={classes.submit}
            >
              {!currentId ? "ADD" : "EDIT"}
            </Button>

           
           
          </form>
        </div>
        
      </Container>
    )
}

export default AddPhotoForm;
