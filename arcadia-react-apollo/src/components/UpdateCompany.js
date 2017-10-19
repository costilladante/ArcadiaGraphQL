import React, { Component } from 'react';
import { graphql, gql } from 'react-apollo';
import { ALL_COMPANIES_QUERY } from './CompaniesList';

class UpdateCompany extends Component {

    state = {
        id: '',
        name: ''
    }

    render() {
        return (
            <div>
                <input
                    value={this.state.id}
                    onChange={(e) => this.setState({ id: e.target.value })}
                    placeholder='The ID of the company'
                />
                <input
                    value={this.state.name}
                    onChange={(e) => this.setState({ name: e.target.value })}
                    type='text'
                    placeholder='The name of the company'
                />
                <button
                    onClick={() => this._updateCompany()}
                >
                    Submit
        </button>
            </div>
        )
    }

    _updateCompany = async () => {
        const { id, name } = this.state;
        await this.props.updateCompanyMutation(
            {
                variables: {
                    id: id,
                    company: {
                        name: name
                    }
                },
                update: (store, { data: { updateCompany } }) => {
                    const data = store.readQuery({ query: ALL_COMPANIES_QUERY });
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

const UPDATE_COMPANY_MUTATION = gql`
    mutation UpdateCompanyMutation($id: Int!, $company: CompanyInput!){
        updateCompany(
            id: $id
            company: $company
        ) {
            id
            name
        }
    }
`

export default graphql(UPDATE_COMPANY_MUTATION, { name: 'updateCompanyMutation' })(UpdateCompany)