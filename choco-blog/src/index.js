import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { compose, createStore, applyMiddleware } from 'redux';
import createHistory from 'history/createBrowserHistory';
import { ConnectedRouter, routerMiddleware, push } from 'react-router-redux';
import { Provider } from 'react-redux';
import reducers from './reducers';

const history = createHistory();

const middleware = routerMiddleware(history);
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const store = createStore(
    composeEnhancers(applyMiddleware(middleware))
);

ReactDOM.render(
<Provider store={store}>
    <ConnectedRouter history={history}>
        <App />
    </ConnectedRouter>
</Provider>, document.getElementById('root'));
registerServiceWorker();
