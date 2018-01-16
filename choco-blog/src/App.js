import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Main from './containers/Main';
import Header from './components/Header/Header';

class App extends Component {
  render() {
    return (
      <div>
        <Header headTitle="Choco Blog"/>
        <Main />
      </div>
    );
  }
}

export default App;
