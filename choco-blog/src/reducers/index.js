import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';
import postReducer from './reducer_posts';

const rootReducer = combineReducers({
    posts: postReducer,
    router: routerReducer
});

export default rootReducer;