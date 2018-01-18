import React from 'react';
import {Card, CardHeader, CardText} from 'material-ui/Card';

class BlogContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            posts: []
        }
    }

    componentDidMount() {
        const API_URL = process.env.NODE_ENV === 'Production' ? `${window.location.protocol}//${window.location.hostname}/api` : 'http://localhost:5000/api';

        fetch(`${API_URL}/posts/all`, {
            method: 'GET'})
                .then((data) => {
                    return data.json()
                }).then((json) => {
                    this.setState({ posts: json })
                })
    }
    
    render() {
        if (!this.state.posts) {
            return null;
        }
        return (
            <div>
                <h1>Blog Container</h1>
                {this.state.posts.map((post) => {
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

export default BlogContainer;