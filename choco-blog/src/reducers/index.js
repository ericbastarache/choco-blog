import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';
import posts from './reducer_posts';

const rootReducer = combineReducers({
    posts,
    router: routerReducer
});

export default rootReducer;