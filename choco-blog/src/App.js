import React, { Component } from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import './App.css';
import Main from './containers/Main';
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';

class App extends Component {
  render() {
    return (
      <Router>
        <div>
          <Header headTitle="Choco Blog"
                  homeLink="Home"
                  blogLink="Blog"
                  loginLink="Login"
                  registerLink="Register"
                  />
            <Main />
          <Footer foot="Copyright &copy; 2018" />
        </div>
      </Router>
    );
  }
}

export default App;
