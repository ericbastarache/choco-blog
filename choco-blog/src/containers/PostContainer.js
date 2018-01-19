import React from 'react';
import { connect } from 'react-redux';
import { fetchPost } from '../actions';
import PostItem from '../components/Posts/Post';

class PostContainer extends React.Component {

    componentDidMount() {
        const { match: { params } } = this.props;
        this.props.dispatch(fetchPost(`${params.id}${window.location.hash.replace(/#/g, '%23')}`));
    }
    
    render() {
        return (
            <div>
                <h1>Post Container</h1>
                {<PostItem {...this.props}/>}
            </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        post: state.posts.post
    }
}

export default connect(mapStateToProps)(PostContainer);