import { FETCH_POSTS, FETCH_POST } from '../actions';

const INITIAL_STATE = {
    posts: [],
    post: null
};

const posts = (state = INITIAL_STATE, action) => {
    console.log('action', action);
    switch(action.type) {
        case FETCH_POSTS:
            return { 
                ...state, 
                posts: action.payload.data
            };
        case FETCH_POST:
            return { 
                ...state, 
                post: action.payload.data 
            };
        default:
            return state
    }
}

export default posts;