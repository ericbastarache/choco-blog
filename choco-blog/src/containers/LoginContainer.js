import React from 'react';
import { connect } from 'react-redux';

class LoginContainer extends React.Component {
    state = {
        user: {}
    };
    
    render() {
        return (
            <div>Login</div>
        )
    }
};

const mapStateToProps = state => {
    return {
        user: state.login.user
    }
}

export default connect(mapStateToProps)(LoginContainer);
