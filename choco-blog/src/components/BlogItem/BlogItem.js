import React from 'react';
import {Card, CardHeader, CardText} from 'material-ui/Card';

const BlogItem = props => {
  const { posts } = props;
  console.log('posts', posts);
  return (
    posts.map(post => {
      return <div key={post.id}>
         <Card>
             <CardHeader title={post.name} subtitle={`Post created by ${post.userName} on ${post.updatedDate}`}/>
             <CardText>
              {post.content}
             </CardText>
         </Card>
         <br />
     </div>
    })
  );
}

export default BlogItem;