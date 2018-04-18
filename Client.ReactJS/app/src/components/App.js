import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import GamesPage from './GamesPage';
import './App.css';
import { Switch, Route } from 'react-router';

class App extends Component {
  render() {
    return (
      <div className="App">

        <header className="App-header">         
          <h1 className="App-title">Welcome to React</h1>
        </header>

        <p className="App-intro">
          <Link to="games">Games</Link>
        </p>

        <Switch>
          <Route path='/games' component={GamesPage} />
        </Switch>

      </div>
    );
  }
}

export default App;
