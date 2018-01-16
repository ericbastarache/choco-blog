import React from 'react';
import PropTypes from 'prop-types';
import { Field, reduxForm } from 'redux-form';

let Login = props => {
    return (
        <form onSubmit={props.handleSubmit}>
            <div>
                <label htmlFor="username">Username: </label>
                <Field name="username" component="input" type="text" />
            </div>
            <div>
                <label htmlFor="password">Password: </label>
                <Field name="password" component="input" type="password" />
            </div>
            <button type="submit">Submit</button>
        </form>
    );
};

Login.propTypes = {
    handleSubmit: PropTypes.func
}

Login = reduxForm({
    form: 'login'
})(Login);

export default Login;