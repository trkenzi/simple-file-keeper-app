import { makeStyles } from '@material-ui/core/styles';

export default makeStyles((theme) => ({
    
    appBar: {
      borderBottom: `1px solid ${theme.palette.divider}`,
    },
    toolbar: {
      flexWrap: 'wrap',
    },
    link: {
      margin: theme.spacing(1, 1.5),
    },
    toolbarTitle: {
        flexGrow: 1,
      },
  
  }));