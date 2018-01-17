export const FETCH_POSTS = 'FETCH_POSTS';
export const FETCH_POST = 'FETCH_POST';

//local api url CHANGE LATER
export const API_URL = 'http://localhost:5000/api';

export const fetchPosts = (state) => {
    return {
        type: FETCH_POSTS,
        payload: state
    }
}

export const fetchPost = (id) => {

    const response = fetch(`${API_URL}/posts/`, {
        method: 'GET',
        data: id
    }).then(data => data);

    return {
        type: FETCH_POST,
        payload: data
    }
}