import React from 'react';
import { connect } from 'react-redux';
import { fetchPosts } from '../actions';
import {Card, CardHeader, CardText} from 'material-ui/Card';

class BlogContainer extends React.Component {

    componentDidMount() {
       this.props.dispatch(fetchPosts());
    }
    
    render() {
        console.log('props', this.props);
        return (
            <div>
                <h1>Blog Container</h1>
                {this.props.posts.map((post) => {
                    return (
                        <div key={post.id}>
                            <Card>
                                <CardHeader title={post.name} subtitle={`Post created by ${post.userName} on ${post.updatedDate}`}/>
                                <CardText>{post.content}
                                </CardText>
                            </Card>
                            <br />
                        </div>
                )}
            )}
            </div>
        )
    }
}

const mapStateToProps = state => {
    console.log('state', state);
    return {
        posts: state.posts.posts
    }
}

export default connect(mapStateToProps)(BlogContainer);