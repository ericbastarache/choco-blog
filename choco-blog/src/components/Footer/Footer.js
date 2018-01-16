import React from 'react';
import PropTypes from 'prop-types';

const Footer = props => {
    return (
        <div>{props.foot}</div>
    );
};

Footer.propTypes = {
    foot: PropTypes.string
};

export default Footer;