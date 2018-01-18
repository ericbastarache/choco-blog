import React from 'react';
import { Field, reduxForm } from 'redux-form';

let Registration = props => {
  return (
    <div>
      <h1>Registration View</h1>
      <form onSubmit={props.handleSubmit}>
        <div>
            <label htmlFor="first_name">First Name: </label>
            <Field name="first_name" component="input" type="text" />
        </div>
        <div>
            <label htmlFor="last_name">Last Name: </label>
            <Field name="last_name" component="input" type="text" />
        </div>
        <div>
            <label htmlFor="username">Username: </label>
            <Field name="username" component="input" type="text" />
        </div>
        <div>
            <label htmlFor="email">Email: </label>
            <Field name="email" component="input" type="email" />
        </div>
        <div>
            <label htmlFor="password">Password: </label>
            <Field name="password" component="input" type="password" />
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

Registration = reduxForm({
  form: 'registration'
})(Registration);

export default Registration;