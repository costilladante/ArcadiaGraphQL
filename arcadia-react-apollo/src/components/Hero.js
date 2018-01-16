import React, { Component } from 'react';
import Game from './Game';
class Hero extends Component {
    render() {
        return (
            <div>
                <div> Id: {this.props.hero.id}</div>
                <div> Name: {this.props.hero.name}</div> 
                <div> Games: {this.props.hero.games.map((game) =><Game id={game.id} name={game.name}/>)} </div> 
                <div> ------------------------------------ </div>    
            </div>

        )
    }
}

export default Hero;