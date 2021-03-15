import React from 'react'
import NavigationBar from './components/NavBar/NavigationBar';
import {BrowserRouter, Switch, Route} from 'react-router-dom';
import PhotosMainComponent from './components/Photos/PhotosMainComponent'
import NotesMainComponent from './components/Notes/NotesMainComponent'


const App = () => {
    return (
        <BrowserRouter>
            <NavigationBar/>
            <Switch>
                <Route path="/" exact component={PhotosMainComponent}/>
                <Route path="/notes" exact component={NotesMainComponent}/>
            </Switch>
        </BrowserRouter>
    )
}

export default App

