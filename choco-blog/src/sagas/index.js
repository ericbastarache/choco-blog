import { put, takeEvery, all } from 'redux-saga/effects';

export function * fetchPostsAsync() {
  const res = yield fetch(`${API_URL}/posts/all`, {
    method: 'GET'})
        .then((data) => {
            return data.json()
        }).then(json => json);

  return {
      type: FETCH_POSTS,
      payload: res
  }
}

export default function * rootSaga() {
  yield all([
    fetchPostsAsync()
  ]);
}
