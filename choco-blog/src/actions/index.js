export const FETCH_POSTS = 'FETCH_POSTS';
export const FETCH_POST = 'FETCH_POST';

export const fetchPosts = (state) => {
    return {
        type: FETCH_POSTS,
        payload: state
    }
}

export const fetchPost = (id) => {
    return {
        type: FETCH_POST,
        payload: id
    }
}