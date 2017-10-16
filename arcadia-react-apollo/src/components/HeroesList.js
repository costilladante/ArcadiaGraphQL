import React, { Component } from 'react';
import Hero from './Hero';

class HeroesList extends Component {
    render() {
        const renderTest = [
            {
                id: 1,
                name: 'Mario',
                company: 'Nintendo'
            },
            {
                id: 2,
                name: 'Link',
                company: 'Nintendo'
            }
        ]

        return (
            <div>
                {renderTest.map(hero => (
                    <Hero key={hero.id} hero={hero} />
                ))}
            </div>
        )
    }
}

export default HeroesList;