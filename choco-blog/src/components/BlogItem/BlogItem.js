import React from 'react';
import {Card, CardHeader, CardText, CardActions} from 'material-ui/Card';
import RaisedButton from 'material-ui/RaisedButton';
import { Link } from 'react-router-dom';

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
            <CardActions>
              <Link to={`blog/${post.slug}`}><RaisedButton label="View Post" /></Link>
            </CardActions>
         </Card>
         <br />
     </div>
    })
  );
}

export default BlogItem;