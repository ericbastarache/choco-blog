import React from 'react';
import { Switch, Route } from 'react-router-dom';

//components to render
import Home from '../components/Home/Home';
import Login from './LoginContainer';
import Blog from './BlogContainer';
import Register from './RegisterContainer';
import Post from './PostContainer';

class Main extends React.Component {
    render() {
        return (
            <div>
                <Switch>
                    <Route exact path="/" component={Home} />
                    <Route exact path="/blog" component={Blog} />
                    <Route exact path="/blog/:id" component={Post} />
                    <Route path="/login" component={Login} />
                    <Route path="/register" component={Register} />
                </Switch>
            </div>
        )
    }
}

export default Main;