import { combineReducers } from 'redux';
import postReducer from './reducer_posts';

const rootReducer = combineReducers({
    posts: postReducer
});

export default rootReducer;