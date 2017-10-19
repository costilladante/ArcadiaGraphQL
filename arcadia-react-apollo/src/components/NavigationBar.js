import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { withRouter } from 'react-router';

class NavigationBar extends Component {
    render() {
        return (
            <div>
                <Link to='/' style= {{display: 'inline'}}>All Companies</Link>
                <div style= {{display: 'inline'}}> | </div>
                <Link to='/create' style= {{display: 'inline'}}>Create Company</Link>
            </div>
        )
    }
}

export default withRouter(NavigationBar);