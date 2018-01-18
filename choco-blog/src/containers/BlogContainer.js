import React from 'react';
import { connect } from 'react-redux';
import {Card, CardHeader, CardText} from 'material-ui/Card';
import { fetchPosts } from '../actions';

class BlogContainer extends React.Component {
    state = {
        posts: []
    };

    componentDidMount() {
        console.log('componentMount', this.props);
        this.props.dispatch(fetchPosts());
    }
    
    render() {
        console.log('props', this.props);
        if (!this.state.posts) {
            return null;
        }
        return (
            <div>
                <h1>Blog Container</h1>
                {this.props.posts.posts.map((post) => {
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
    return {
        posts: state.posts
    }
}

export default connect(mapStateToProps)(BlogContainer);