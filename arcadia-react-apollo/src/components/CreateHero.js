import React, { Component } from 'react';
import { graphql, gql } from 'react-apollo';
import { ALL_HEROES_QUERY } from './HeroesList';

class CreateHero extends Component {

    state = {
        name: ''
    }

    render() {
        return (
           <div>
                <input
                    value={this.state.name}
                    onChange={(e) => this.setState({ name: e.target.value })}
                    type='text'
                    placeholder='The name of the new hero'
                />
                <button onClick={() => this._createHero()}>
                    Submit
                </button>
           </div>
        )
    }

    _createHero = async () => {
        const { name } = this.state;
        await this.props.createHeroMutation(
            {
                variables: {
                    hero: {
                        name: name
                    }
                },
                update: (store, { data: { createHero } }) => {
                    const data = store.readQuery({ query: ALL_HEROES_QUERY});
                    data.allHeroes.splice(0, 0, createHero);
                    store.writeQuery(
                        {
                            query: ALL_HEROES_QUERY,
                            data
                        }
                    );
                }
            }
        );
        this.props.history.push('/');
    }
}

const CREATE_HERO_MUTATION = gql`
    mutation CreateHeroMutation($hero: HeroInput!){
        createHero(
            hero: $hero
        ) {
            id
            name 
        }
    }
`

export default graphql(CREATE_HERO_MUTATION, { name: 'createHeroMutation' })(CreateHero)