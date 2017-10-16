import React, { Component } from 'react';
import logo from '../dante.png';
import '../styles/App.css';
import HeroesList from './HeroesList';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Arcadia Front-End</h1>
        </header>
        <header className="App-subHeader">
          <p className="App-subTitle">Sample project implementing GraphQL client using Apollo and React! ¯\_(ツ)_/¯</p>
        </header>
        <HeroesList />
      </div >
    );
  }
}

export default App;
