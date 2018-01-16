import React from 'react';
import PropTypes from 'prop-types';
import AppBar from 'material-ui/AppBar';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import { Link } from 'react-router-dom';

const Header = props => {
    return (
        <div>
            <MuiThemeProvider>
        <AppBar
            title={props.headTitle}
            iconClassNameRight="muidocs-icon-navigation-expand-more"

        />
        </MuiThemeProvider>
        </div>
    );
};

Header.propTypes = {
    headTitle: PropTypes.string
};

export default Header;