import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import './App.css';
import Main from './containers/Main';
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';

class App extends Component {
  render() {
    return (
      <MuiThemeProvider>
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
      </MuiThemeProvider>
    );
  }
}

export default App;
