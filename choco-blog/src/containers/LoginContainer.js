import React from 'react';
// import { connect } from 'react-redux';
import Login from '../components/Login/Login';
class LoginContainer extends React.Component {
    render() {
        return (
            <Login handleSubmit={this.handleSubmit}/>
        )
    }

    handleSubmit = e => dispatch => {
        //dispatch login user action here 
        //we will need an auth reducer here for handling
        //any auth related actions (register, login)
    }
};


export default LoginContainer;
//use this later to actually connect to store
// export default connect(mapStateToProps)(LoginContainer);
