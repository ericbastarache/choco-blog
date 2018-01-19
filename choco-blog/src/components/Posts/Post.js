import React from 'react';
import {Card, CardHeader, CardText} from 'material-ui/Card';

const PostItem = props => {
  const { post } = props;
  console.log('post', post);
  if (!post) {
    return <p>loading...</p>
  }

  return (
      <div key={post.post.postid}>
         <Card>
            <CardHeader title={post.post.name} subtitle={`Post created by ${post.post.userName} on ${post.post.updatedDate}`}/>
            <CardText>
              {post.post.content}
            </CardText>
         </Card>
         <br />
     </div>
  );
}

export default PostItem;