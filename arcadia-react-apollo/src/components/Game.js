import React, { Component } from 'react';

class Game extends Component {
    render() {
        return (
            <div>
                <div> Id: {this.props.id}</div>
                <div> Name: {this.props.name}</div> 
               
            </div>

        )
    }
}

export default Game;