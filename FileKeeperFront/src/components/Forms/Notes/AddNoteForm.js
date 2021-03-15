import React, {useState, useEffect} from 'react' 
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Container from '@material-ui/core/Container';
import NoteIcon from '@material-ui/icons/Note';
import useStyles from './styles';
import Typography from '@material-ui/core/Typography';
import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider,KeyboardDatePicker } from '@material-ui/pickers';
import { useDispatch, useSelector } from 'react-redux';
import { addNote, updateNote } from '../../../actions/Notes/NoteActions';


const AddNoteForm = ({currentId, setCurrentId}) => {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const dispatch = useDispatch();
    const classes = useStyles();
    
    const handleDateChange = (creationDate) => {
      setSelectedDate(creationDate);
    };

    const concreteNote = useSelector((state) => currentId ? state.noteReducer.find((note) => note.id === currentId) : null);

    const [noteData, setNoteData] = useState({
        title: '',
        description: '',
        importantDate: ''
    });
    
    
    useEffect(() => {
      if(concreteNote){
        setNoteData(concreteNote);
        setSelectedDate(concreteNote.importantDate);
      }
    }, [concreteNote]);

   const handleSubmit = (event) => {
        event.preventDefault();
        noteData.importantDate = selectedDate;
       
        if(currentId){
          dispatch(updateNote(currentId, noteData))
          setCurrentId(null)
        }
        else
          dispatch(addNote(noteData));
        
          clear();
   };

   const clear = () =>{
      setNoteData({
        title: '',
        description: '',
        importantDate: new Date()
      })
   }

    return (
        <Container component="main" maxWidth="xs">
      
        <div className={classes.paper}>
          <Avatar className={classes.avatar}>
             <NoteIcon  /> 
          </Avatar>
          <Typography component="h1" variant="h5">
            {!currentId ?  "Add" : "Edit"} a note
          </Typography>
          <form className={classes.form} autoComplete="off" noValidate onSubmit={handleSubmit}>
            <TextField
              variant="outlined"
              margin="normal"
              fullWidth
              label="Title *"
              name="title"
              value={noteData.title}
              onChange={(event) => setNoteData({...noteData, title: event.target.value})}
            />
            <TextField
              variant="outlined"
              margin="normal"
              fullWidth
              name="description"
              value={noteData.description}
              label="Description *"
              onChange={(event) => setNoteData({...noteData, description: event.target.value})}
              
            />
        <MuiPickersUtilsProvider utils={DateFnsUtils} >
            <KeyboardDatePicker
           disableToolbar
           fullWidth
           name="importantDate"
           variant="inline"
           format="dd/MM/yyyy"
           margin="normal"
           id="date-picker-inline"
           label="Important date *"
           value={selectedDate}
           onChange={handleDateChange}
           disablePast={true}
           KeyboardButtonProps={{
             'aria-label': 'change date',
           }}
            
            />
        </MuiPickersUtilsProvider>
        
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              disabled={!noteData.title || !noteData.description || !selectedDate}
              className={classes.submit}
            >
              {!currentId ? "ADD" : "EDIT"}
            </Button>

           
           
          </form>
        </div>
        
      </Container>
    )
}

export default AddNoteForm;
