import React, { Component } from 'react';
import { graphql, gql } from 'react-apollo';
import { ALL_HEROES_QUERY } from './HeroesList';

class DeleteHero extends Component {

    state = {
        id: ''
    }

    render() {
        return (
            <div>
                <input
                    value={this.state.id}
                    onChange={(e) => this.setState({ id: e.target.value })}
                    placeholder='The ID of the Hero'
                />
                <button
                    onClick={() => this._deleteHero()}
                >
                    Delete
        </button>
            </div>
        )
    }

    _deleteHero = async () => {
        const { id } = this.state;
        await this.props.deleteHeroMutation(
            {
                variables: {
                    id: id
                },
                update: (store, { data: { deleteHero } }) => {
                    const data = store.readQuery({ query: ALL_HEROES_QUERY });
                    const removeIndex = data.allHeroes.findIndex(c => c.id === deleteHero.id);
                    data.allHeroes.splice(removeIndex, 1);
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

const DELETE_HERO_MUTATION = gql`
    mutation DeleteHeroMutation($id: Int!){
        deleteHero(
            id: $id
        ) {
            id
            name
        }
    }
`

export default graphql(DELETE_HERO_MUTATION, { name: 'deleteHeroMutation' })(DeleteHero)