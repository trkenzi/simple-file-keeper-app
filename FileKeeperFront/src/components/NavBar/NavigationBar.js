import React from 'react'
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import useStyles from './styles'
import Button from '@material-ui/core/Button';
import {Link} from 'react-router-dom';


const NavigationBar = () => {

  const classes = useStyles();
  
    return (
      <AppBar position="static" color="default"  elevation={0} className={classes.appBar}>
        <Toolbar className={classes.toolbar}>
          
          <Typography variant="h6" color="inherit" noWrap className={classes.toolbarTitle}>
            File keeper
          </Typography>
       
           
            <Button component={Link} to="/" variant="text" color="inherit"  className={classes.link}>
              Photos
            </Button>

            <Button component={Link} to="/notes" variant="text" color="inherit"  className={classes.link}>
              Notes
            </Button>
          
        </Toolbar>
      </AppBar>
    )
}

export default NavigationBar;
