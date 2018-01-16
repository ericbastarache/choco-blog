import React from 'react';
import { Switch, BrowserRouter as Router, Route } from 'react-router-dom';
import Home from '../components/Home/Home';
import Login from './LoginContainer';
import Register from './RegisterContainer';

//components to render

class Main extends React.Component {
    render() {
        return (
            <Router>
                <div>
                    <Route exact path="/" component={Home} />
                    <Route path="/login" component={Login} />
                    <Route path="/register" component={Register} />
                </div>
            </Router>
        )
    }
}

export default Main;