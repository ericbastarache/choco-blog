import { FETCH_POSTS, FETCH_POST } from '../actions';

const INITIAL_STATE = {
    posts: [],
    post: null
};

const posts = (state = INITIAL_STATE, action) => {
    switch(action.type) {
        case FETCH_POSTS:
            return { ...state, posts: action.payload };
        case FETCH_POST:
            return { ...state, post: action.payload };
        default:
            return state
    }
}

export default posts;