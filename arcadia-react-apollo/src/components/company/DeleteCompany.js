import React, { Component } from 'react';
import { graphql, gql } from 'react-apollo';
import { ALL_COMPANIES_QUERY } from './CompaniesList';

class DeleteCompany extends Component {

    state = {
        id: ''
    }

    render() {
        return (
            <div>
                <input
                    value={this.state.id}
                    onChange={(e) => this.setState({ id: e.target.value })}
                    placeholder='The ID of the company'
                />
                <button
                    onClick={() => this._deleteCompany()}
                >
                    Delete
        </button>
            </div>
        )
    }

    _deleteCompany = async () => {
        const { id } = this.state;
        await this.props.deleteCompanyMutation(
            {
                variables: {
                    id: id
                },
                update: (store, { data: { deleteCompany } }) => {
                    const data = store.readQuery({ query: ALL_COMPANIES_QUERY });
                    const removeIndex = data.allCompanies.findIndex(c => c.id === deleteCompany.id);
                    data.allCompanies.splice(removeIndex, 1);
                    store.writeQuery(
                        {
                            query: ALL_COMPANIES_QUERY,
                            data
                        }
                    );
                }
            }
        );
        this.props.history.push('/');
    }
}

const DELETE_COMPANY_MUTATION = gql`
    mutation DeleteCompanyMutation($id: Int!){
        deleteCompany(
            id: $id
        ) {
            id
            name
        }
    }
`

export default graphql(DELETE_COMPANY_MUTATION, { name: 'deleteCompanyMutation' })(DeleteCompany)