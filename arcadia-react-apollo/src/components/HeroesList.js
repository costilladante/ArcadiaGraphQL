import React, { Component } from 'react';
import Hero from './Hero';
import { graphql, gql } from 'react-apollo';

class HeroesList extends Component {
    render() {


        if (this.props.allHeroesQuery && this.props.allHeroesQuery.loading) {
            return <div>Loading Heroes... </div>
        }

        if (this.props.allHeroesQuery && this.props.allHeroesQuery.error) {
            return <div>Oh noes! Something went wrong!</div>
        }

        const heroesToRender = this.props.allHeroesQuery.allHeroes;
         console.log(heroesToRender);
        return (
            <div>
                {heroesToRender.map(hero => (
                    <Hero key={hero.id} hero={hero} />
                ))}
            </div>
        )
    }
    
}
export const ALL_HEROES_QUERY = gql`
query AllHeroes {    
    allHeroes {
        id
        name
        games{        
                id  
                name       
        }  
    }
}
`
export default graphql(ALL_HEROES_QUERY, { name: 'allHeroesQuery' })(HeroesList);
