import React, { Component } from 'react';

class Hero extends Component {
    render() {
        return (
            <div>
                <div> Id: {this.props.hero.id}</div>
                <div> Name: {this.props.hero.name}</div>
                <div> Company: {this.props.hero.company}</div>
                <div> - - - - - - - - - - - - - - - - - </div>
            </div>

        )
    }
}

export default Hero;