export const FETCH_POSTS = 'FETCH_POSTS';
export const FETCH_POST = 'FETCH_POST';

//local api url CHANGE LATER
export const API_URL = process.env.NODE_ENV === 'Production' ? `${window.location.protocol}//${window.location.hostname}/api` : 'http://localhost:5000/api';

export const fetchPosts = (state) => {
    return {
        type: FETCH_POSTS,
        payload: state
    }
}

export const fetchPost = (id) => {

    // const request = fetch(`${API_URL}/posts/${id}`, {
    //     method: 'GET'
    // }).then(data => data);

    // return {
    //     type: FETCH_POST,
    //     payload: data
    // }
}