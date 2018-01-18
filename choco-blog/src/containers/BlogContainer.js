import React from 'react';
import { connect } from 'react-redux';
import { fetchPosts } from '../actions';
import BlogItem from '../components/BlogItem/BlogItem';

class BlogContainer extends React.Component {

    componentDidMount() {
       this.props.dispatch(fetchPosts());
    }
    
    render() {
        console.log('props', this.props);
        return (
            <div>
                <h1>Blog Container</h1>
                <BlogItem {...this.props}/>
            </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        posts: state.posts.posts
    }
}

export default connect(mapStateToProps)(BlogContainer);