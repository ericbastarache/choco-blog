import React from 'react';
import PropTypes from 'prop-types';
import { AppBar, Tabs, Tab } from 'material-ui';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import { Link } from 'react-router-dom';

const Header = props => {
    return (        
        <div>
            <MuiThemeProvider>
                <AppBar
                    title={props.headTitle}
                    iconClassNameRight="muidocs-icon-navigation-expand-more">
                    <Tabs tabItemContainerStyle={{width: '400px'}}>
                       <Tab label={props.homeLink} containerElement={<Link to="/" />} />
                       <Tab label={props.blogLink} containerElement={<Link to="/blog" />} />
                       <Tab label={props.registerLink} containerElement={<Link to="/register" />} />
                       <Tab label={props.loginLink} containerElement={<Link to="/login" />} />
                    </Tabs>
                </AppBar>
            </MuiThemeProvider>
        </div>
    );
};

Header.propTypes = {
    headTitle: PropTypes.string,
    homeLink: PropTypes.string,
    registerLink: PropTypes.string,
    loginLink: PropTypes.string
};

export default Header;