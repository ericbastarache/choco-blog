import React from 'react';
import { connect } from 'react-redux';
import Registration from '../components/Registration/Registration';

class RegisterContainer extends React.Component {
    render() {
        return (
            <Registration {...this.props} />
        );
    }

    handleSubmit = e => {
        
    }
};

const mapStateToProps = state => {
    return {
        username: state.username,
        password: state.password,
        email: state.email
    }
}

export default connect(mapStateToProps)(RegisterContainer);