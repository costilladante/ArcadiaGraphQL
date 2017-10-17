import React, { Component } from 'react';

class Company extends Component {
    render() {
        return (
            <div>
                <div> Id: {this.props.company.id}</div>
                <div> Name: {this.props.company.name}</div>
                <div> - - - - - - - - - - - - - - - - - </div>
            </div>

        )
    }
}

export default Company;