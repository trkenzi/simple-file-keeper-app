import { makeStyles } from '@material-ui/core/styles';

export default makeStyles((theme) => ({
    cardGrid: {
        paddingTop: theme.spacing(8),
        paddingBottom: theme.spacing(8),
      },

      mainContainer: {
        display: 'flex',
        alignItems: 'center',
      },

      circularProgress:{
        paddingTop: theme.spacing(3),
        marginTop: theme.spacing(7)
      }
  })); 